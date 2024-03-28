using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChefPlus.core;
using ChefPlus.data;
using Npgsql;

namespace Chef_Plus
{
    public partial class frm_cadastro_observacao : XtraForm
    {
        public string id_reg;

        private string nome;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_observacao()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;

            ExeSql sql_table = new ExeSql("SELECT * FROM categorias WHERE tipo='produtos' ORDER BY id ASC");

            checkedListBoxControl1.DisplayMember = "nome";
            checkedListBoxControl1.ValueMember = "id";
            checkedListBoxControl1.DataSource = sql_table.DataSet().Tables[0];
        }

        private void frm_cadastro_observacao_Load(object sender, EventArgs e)
        {
            ExeSql sql_exist_categoria = new ExeSql("SELECT COUNT(*) FROM categorias WHERE tipo='produtos'");
            if (sql_exist_categoria.ExecuteScalarInt() <= 0)
            {
                InfoUser.MessageBoxShow("É necessário cadastrar ao menos uma categoria para acessar essa tela.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT nome FROM observacoes WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();


                    for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                    {

                        string str_sql_acesso = "SELECT COUNT(*) FROM observacoes_categorias WHERE id_observacao=@id_observacao AND id_categoria=@id_categoria";

                        ExeSql sql_acesso = new ExeSql(str_sql_acesso);

                        sql_acesso.AddParams("@id_observacao", id_reg, DbType.Int32);
                        sql_acesso.AddParams("@id_categoria", checkedListBoxControl1.GetItemValue(i).ToString(), DbType.Int32);

                        if (sql_acesso.ExecuteScalarInt() > 0)
                        {
                            checkedListBoxControl1.SetItemChecked(i, true);
                        }

                    }
                }
                sql_load.CloseConnection();
            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {

            }
            else
            {
                InfoUser.MessageBoxShow("{{error_open_form_reg}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            valid.Reset();
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == false)
            {
                for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                {

                    checkedListBoxControl1.SetItemChecked(i, false);
                }
                return;
            }
            else if (checkEdit1.Checked == true)
            {
                for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                {
                    checkedListBoxControl1.SetItemChecked(i, true);
                }
                return;
            }
        }

        private void frm_cadastro_observacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_cadastro_observacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (valid.IsEditing())
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult dialogResult = InfoUser.MessageBoxShow("As alterações não foram salvas!\r\n\r\nDeseja realmente sair da tela?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (valid.GetOperation() == ModifiedOperation.New && id_reg != "")
                        {
                            ExeSql sql_del = new ExeSql("DELETE FROM observacoes WHERE id = @id");
                            sql_del.AddParams("@id", id_reg, DbType.Int32);
                            if (!sql_del.ExecuteSql())
                            {
                                InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        e.Cancel = false;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                InfoUser.MessageBoxShow("Nome não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit1.Text != nome && textEdit1.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT COUNT(*) FROM observacoes WHERE nome=@nome AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int count_items = 0;
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
            {
                if (checkedListBoxControl1.GetItemChecked(i))
                {
                    count_items += 1;
                }
            }
            if (count_items <= 0)
            {
                InfoUser.MessageBoxShow("Nenhuma categoria foi selecionada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query_insert = "INSERT INTO observacoes (date_insert) VALUES";
                query_insert += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query_insert);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
            }

            String query_obs_update = "UPDATE observacoes SET nome=@nome, date_update=@date_update";
            query_obs_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_obs_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome", textEdit1.Text);
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                cmd_update.AddParams("@date_update", DateHelper.GetDateNow(DateType.Type1));
            }
            else
            {
                cmd_update.AddParams("@date_update", "");
            }
            if (!cmd_update.ExecuteSql())
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String query_delete = "DELETE FROM observacoes_categorias WHERE id_observacao=@id_observacao";
            ExeSql cmd_delete = new ExeSql(query_delete);

            cmd_delete.AddParams("@id_observacao", id_reg, DbType.Int32);
            if (!cmd_delete.ExecuteSql())
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool error_acesso = false;
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
            {
                if (checkedListBoxControl1.GetItemChecked(i))
                {
                    String query_obs_insert = "INSERT INTO observacoes_categorias (id_observacao, id_categoria) VALUES";
                    query_obs_insert += "(@id_observacao, @id_categoria)";

                    ExeSql cmd_obs_insert = new ExeSql(query_obs_insert);
                    cmd_obs_insert.AddParams("@id_observacao", id_reg, DbType.Int32);
                    cmd_obs_insert.AddParams("@id_categoria", checkedListBoxControl1.GetItemValue(i).ToString(), DbType.Int32);
                    if (!cmd_obs_insert.ExecuteSql())
                    {
                        error_acesso = true;
                    }
                }
            }
            if (error_acesso == true)
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao definir as categorias. {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            valid.confirmClose();

            this.Close();

        }

        private void btn_menu_trash_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja realmente excluir o registro atual?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (valid.GetOperation() == ModifiedOperation.New && id_reg == "")
                {
                    valid.confirmClose();
                }
                else if (valid.GetOperation() == ModifiedOperation.New && id_reg != "")
                {
                    valid.confirmClose();
                    ExeSql sql_del = new ExeSql("UPDATE observacoes SET date_delete=@date_delete WHERE id=@id");
                    sql_del.AddParams("@id", id_reg, DbType.Int32);
                    sql_del.AddParams("@date_delete", DateHelper.GetDateNow(DateType.Type1));
                    if (!sql_del.ExecuteSql())
                    {
                        InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (valid.GetOperation() == ModifiedOperation.Edit)
                {
                    valid.confirmClose();
                    ExeSql sql_del = new ExeSql("UPDATE observacoes SET date_delete=@date_delete WHERE id=@id");
                    sql_del.AddParams("@id", id_reg, DbType.Int32);
                    sql_del.AddParams("@date_delete", DateHelper.GetDateNow(DateType.Type1));
                    if (!sql_del.ExecuteSql())
                    {
                        InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Close();
            }
            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}

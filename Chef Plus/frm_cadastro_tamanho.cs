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
    public partial class frm_cadastro_tamanho : XtraForm
    {
        public string id_reg;

        private string nome;
        private string sigla;
        private string id_tipo;

        public string carregar_id_tipo;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_tamanho()
        {
            InitializeComponent();

            ExeSql adapter_categorias = new ExeSql("SELECT id, nome FROM p_tipos WHERE (nome<>'') ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];

            id_reg = string.Empty;

            nome = string.Empty;
            sigla = string.Empty;
            id_tipo = string.Empty;

            carregar_id_tipo = string.Empty;
        }

        private void frm_cadastro_tamanhos_Load(object sender, EventArgs e)
        {
            ExeSql sql_exist_tipo = new ExeSql("SELECT COUNT(*) FROM p_tipos WHERE (nome<>'')");
            if (sql_exist_tipo.ExecuteScalarInt() <= 0)
            {
                InfoUser.MessageBoxShow("É necessário cadastrar ao menos um Tipo para acessar essa tela.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT * FROM p_tamanhos WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();
                    textEdit2.Text = myReader["sigla"].ToString();
                    sigla = myReader["sigla"].ToString();
                    lookUpEdit1.EditValue = (int)myReader["id_tipo"];
                    id_tipo = myReader["id_tipo"].ToString();
                    if (Convert.ToInt16(myReader["qt_max_part"].ToString()) > 1)
                    {
                        checkEdit1.Checked = true;
                        spinEdit1.Value = Convert.ToInt16(myReader["qt_max_part"].ToString());
                    }
                }
                sql_load.CloseConnection();
            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {
                if (carregar_id_tipo != string.Empty && carregar_id_tipo != "")
                {
                    lookUpEdit1.EditValue = Convert.ToInt32(carregar_id_tipo);
                }
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

        private void frm_cadastro_tamanhos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_cadastro_tamanhos_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM p_tamanhos WHERE id = @id");
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
            if (textEdit2.Text == "")
            {
                InfoUser.MessageBoxShow("Sigla não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lookUpEdit1.EditValue == null || lookUpEdit1.EditValue.ToString() == "")
            {
                InfoUser.MessageBoxShow("Tipo não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit1.Text != nome && textEdit1.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT COUNT(*) FROM p_tamanhos WHERE nome=@nome and id_tipo=@id_tipo");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                sql_exist1.AddParams("@id_tipo", lookUpEdit1.EditValue, DbType.Int32);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if ((textEdit2.Text != sigla && textEdit2.Text != "") || (lookUpEdit1.EditValue.ToString() != id_tipo && (lookUpEdit1.EditValue != null || lookUpEdit1.EditValue.ToString() != "")))
            {
                ExeSql sql_exist2 = new ExeSql("SELECT COUNT(*) FROM p_tamanhos WHERE sigla=@sigla and id_tipo=@id_tipo");
                sql_exist2.AddParams("@sigla", textEdit2.Text);
                sql_exist2.AddParams("@id_tipo", lookUpEdit1.EditValue, DbType.Int32);
                if (sql_exist2.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com a Sigla informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query = "INSERT INTO p_tamanhos (date_insert) VALUES";
                query += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
            }

            String query_tamanho_update = "UPDATE p_tamanhos SET nome=@nome, sigla=@sigla, id_tipo=@id_tipo, qt_max_part=@qt_max_part, date_update=@date_update";
            query_tamanho_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_tamanho_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome", textEdit1.Text);
            cmd_update.AddParams("@sigla", textEdit2.Text);
            cmd_update.AddParams("@id_tipo", lookUpEdit1.EditValue, DbType.Int32);
            if (checkEdit1.Checked)
            {
                cmd_update.AddParams("@qt_max_part", spinEdit1.Value.ToString(), DbType.Int16);
            }
            else
            {
                cmd_update.AddParams("@qt_max_part", "1", DbType.Int16);
            }

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
            

            valid.confirmClose();

            this.Close();

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                labelControl4.Visible = true;
                spinEdit1.Visible = true;
            }
            else
            {
                labelControl4.Visible = false;
                spinEdit1.Visible = false;
            }
        }
    }
}

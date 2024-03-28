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
using DevExpress.XtraSplashScreen;
using Npgsql;

namespace Chef_Plus
{
    public partial class frm_cadastro_categorias_contas : XtraForm
    {

        public string id_reg;

        private string nome;

        private string id_pai;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_categorias_contas()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;

            id_pai = string.Empty;

            ExeSql adapter_categorias = new ExeSql("SELECT * FROM categorias_contas WHERE internal = '0' AND (id_pai IS NULL or id_pai = '0') ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "descricao";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];
        }

        private void cadastro_categoria_Load(object sender, EventArgs e)
        {
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT id, descricao, id_pai FROM categorias_contas WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["descricao"].ToString();
                    nome = myReader["descricao"].ToString();

                    id_pai = myReader["id_pai"].ToString();

                    if (id_pai == null || id_pai == "" || id_pai == "0")
                    {
                        checkEdit1.Checked = true;
                    }
                    else
                    {
                        lookUpEdit1.EditValue = (int)myReader["id_pai"];
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

        private void frm_cadastro_categorias_contas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                InfoUser.MessageBoxShow("Descrição não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit1.Text != nome && textEdit1.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM categorias_contas WHERE descricao=@descricao");
                sql_exist1.AddParams("@descricao", textEdit1.Text);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com a Descrição informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (checkEdit1.Checked == false && (lookUpEdit1.EditValue == null || lookUpEdit1.EditValue.ToString() == ""))
            {
                InfoUser.MessageBoxShow("Categoria Principal não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query_insert = "INSERT INTO categorias_contas (internal) VALUES";
                query_insert += "(0) RETURNING id";

                ExeSql cmd_insert = new ExeSql(query_insert);
                id_reg = cmd_insert.ExecuteScalarString();
            }

            String query_categorias_update = "UPDATE categorias_contas SET descricao=@descricao, id_pai=@id_pai";
            query_categorias_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_categorias_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@descricao", textEdit1.Text);
            if (checkEdit1.Checked == true)
            {
                cmd_update.AddParams("@id_pai", "0", DbType.Int32);
            }
            else if (checkEdit1.Checked == false)
            {
                cmd_update.AddParams("@id_pai", lookUpEdit1.EditValue.ToString(), DbType.Int32);
            }

            if (!cmd_update.ExecuteSql())
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            valid.confirmClose();

            this.Close();
        }

        private void frm_cadastro_categorias_contas_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM categorias_contas WHERE id = @id");
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

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                lookUpEdit1.Enabled = false;
            }
            else
            {
                lookUpEdit1.Enabled = true;
            }
        }
    }
}

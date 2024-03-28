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
    public partial class frm_cadastro_tipo : XtraForm
    {
        public string id_reg;

        private string nome;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_tipo()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;
        }

        private void frm_cadastro_tipo_Load(object sender, EventArgs e)
        {

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT nome FROM p_tipos WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();

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

        private void frm_cadastro_tipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_cadastro_tipo_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM p_tipos WHERE id = @id");
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
                ExeSql sql_exist1 = new ExeSql("SELECT COUNT(*) FROM p_tipos WHERE nome=@nome");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query = "INSERT INTO p_tipos (date_insert) VALUES";
                query += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
            }

            String query_tipo_update = "UPDATE p_tipos SET nome=@nome, date_update=@date_update";
            query_tipo_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_tipo_update);

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
            

            valid.confirmClose();

            this.Close();

        }
    }
}

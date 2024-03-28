using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChefPlus.core;
using ChefPlus.data;
using Npgsql;

namespace Chef_Plus
{
    public partial class frm_cadastro_usuario : XtraForm
    {
        public string id_reg;

        private string usuario;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_usuario()
        {
            InitializeComponent();
            id_reg = string.Empty;

            usuario = string.Empty;

            ExeSql sql_table = new ExeSql("SELECT * FROM permissoes ORDER BY permissao ASC");

            checkedListBoxControl1.DisplayMember = "permissao";
            checkedListBoxControl1.ValueMember = "id";
            checkedListBoxControl1.DataSource = sql_table.DataSet().Tables[0];

        }

        private void frm_cadastro_usuario_Load(object sender, EventArgs e)
        {
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT * FROM usuarios WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    textEdit2.Text = myReader["telefone"].ToString();
                    textEdit3.Text = myReader["email"].ToString();
                    spinEdit1.Value = Convert.ToInt32(myReader["comissao"].ToString());
                    if (myReader["tipo"].ToString() == "1")
                    {
                        checkEdit1.Checked = true;
                    }
                    else if (myReader["tipo"].ToString() == "2")
                    {
                        checkEdit2.Checked = true;
                        for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                        {

                            string str_sql_acesso = "SELECT count(*) FROM acesso WHERE id_usuario=@id_usuario AND id_permissao=@id_permissao";

                            ExeSql sql_acesso = new ExeSql(str_sql_acesso);

                            sql_acesso.AddParams("@id_usuario", id_reg, DbType.Int32);
                            sql_acesso.AddParams("@id_permissao", checkedListBoxControl1.GetItemValue(i).ToString(), DbType.Int32);

                            if (sql_acesso.ExecuteScalarInt() > 0)
                            {
                                checkedListBoxControl1.SetItemChecked(i, true);
                            }

                        }
                    }
                    textEdit4.Text = myReader["usuario"].ToString();
                    usuario = myReader["usuario"].ToString();
                    textEdit5.Text = InfoUser.Base64Decode(myReader["senha"].ToString());
                    if (myReader["status"].ToString() == "0")
                    {
                        checkEdit3.Checked = false;
                    }
                    else if (myReader["status"].ToString() == "1")
                    {
                        checkEdit3.Checked = true;
                    }

                    textEdit6.Text = DateHelper.FormatDate(myReader["date_insert"].ToString(), DateType.Type1, DateType.Type3);

                    textEdit5.ReadOnly = true;
                }
                sql_load.CloseConnection();
                if (id_reg == "1")
                {
                    textEdit4.Enabled = false;
                    panelControl1.Enabled = false;
                    checkEdit3.Enabled = false;
                }
            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {

                string comando = "SELECT COUNT(*) FROM usuarios WHERE id='1'";
                ExeSql sql_exist = new ExeSql(comando);

                if (sql_exist.ExecuteScalarInt() <= 0)
                {
                    id_reg = "1";
                    textEdit4.Text = "admin";
                    textEdit4.Enabled = false;
                    panelControl1.Enabled = false;
                    checkEdit1.Checked = true;
                    checkEdit3.Checked = true;
                    checkEdit3.Enabled = false;

                }
                else
                {
                    
                    checkEdit1.Checked = true;
                    checkEdit3.Checked = true;

                }

            }
            else
            {
                InfoUser.MessageBoxShow("{{error_open_form_reg}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            this.Location = new Point((Screen.PrimaryScreen.Bounds.Size.Width / 2) - (this.Size.Width / 2), (Screen.PrimaryScreen.Bounds.Size.Height / 2) - (this.Size.Height / 2));
            valid.Reset();

        }

        private void frm_cadastro_usuario_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (valid.IsEditing())
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult dialogResult = InfoUser.MessageBoxShow("As alterações não foram salvas!\r\n\r\nDeseja realmente sair da tela?",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (valid.GetOperation() == ModifiedOperation.New && id_reg != "")
                        {
                            ExeSql sql_del = new ExeSql("DELETE FROM usuarios WHERE id = @id");
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
            if (checkEdit1.Checked)
            {
                this.Size = new Size(515, 387);
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked)
            {
                this.Size = new Size(868, 387);
            }
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                InfoUser.MessageBoxShow("Nome não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var match_telefone = Regex.Match(textEdit2.Text, @"^\([1-9]{2}\) [9]{0,1}[6-9]{1}[0-9]{3}\-[0-9]{4}$", RegexOptions.IgnoreCase);
            if (!match_telefone.Success)
            {
                InfoUser.MessageBoxShow("Telefone não informado ou inválido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit3.Text == "")
            {
                InfoUser.MessageBoxShow("E-mail não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var match_email = Regex.Match(textEdit3.Text, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
            if (!match_email.Success)
            {
                InfoUser.MessageBoxShow("E-mail inválido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textEdit4.Text == "")
            {
                InfoUser.MessageBoxShow("Usuário não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit4.Text != usuario && textEdit4.Text != "")
            {
                ExeSql sql_exist = new ExeSql("SELECT COUNT(*) FROM usuarios WHERE usuario=@usuario");
                sql_exist.AddParams("@usuario", textEdit4.Text);
                if (sql_exist.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Usuário informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (textEdit5.Text == "")
            {
                InfoUser.MessageBoxShow("Senha não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit5.Text.Length < 4)
            {
                InfoUser.MessageBoxShow("Senha deve ter no mínimo 4 caracteres.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String user_exist = "SELECT COUNT(*) FROM usuarios WHERE id='1'";
            ExeSql sql_user_exist = new ExeSql(user_exist);
            int count_user_exist = sql_user_exist.ExecuteScalarInt();
            if (count_user_exist <= 0)
            {
                String insert_user = "INSERT INTO USUARIOS (id, date_insert) VALUES";
                insert_user += " (1, @date_insert)";

                textEdit6.Text = DateHelper.GetDateNow(DateType.Type3);
                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(insert_user);
                cmd_cad.AddParams("@date_insert", date_insert);
                if (!cmd_cad.ExecuteSql())
                {
                    InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (valid.GetOperation() == ModifiedOperation.New)
                {
                    String query = "INSERT INTO USUARIOS (date_insert) VALUES";
                    query += "(@date_insert) RETURNING id";

                    textEdit6.Text = DateHelper.GetDateNow(DateType.Type3);
                    var date_insert = DateHelper.GetDateNow(DateType.Type1);

                    ExeSql cmd_cad = new ExeSql(query);
                    cmd_cad.AddParams("@date_insert", date_insert);
                    id_reg = cmd_cad.ExecuteScalarString();
                }
            }


            string senha_base64 = InfoUser.Base64Encode(textEdit5.Text);


            String query_user_update = "UPDATE usuarios SET nome=@nome, telefone=@telefone, status=@status, usuario=@usuario, senha=@senha, email=@email, comissao=@comissao, tipo=@tipo, date_update=@date_update";
            query_user_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_user_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome", textEdit1.Text);
            cmd_update.AddParams("@telefone", textEdit2.Text);
            cmd_update.AddParams("@email", textEdit3.Text);
            cmd_update.AddParams("@comissao", spinEdit1.Value.ToString(), DbType.Int32);
            if (checkEdit3.Checked == true) { cmd_update.AddParams("@status", "1"); } else { cmd_update.AddParams("@status", "0"); }
            if (checkEdit1.Checked == true)
            {
                cmd_update.AddParams("@tipo", "1");
            }
            else if (checkEdit2.Checked == true)
            {
                cmd_update.AddParams("@tipo", "2");
            }
            cmd_update.AddParams("@usuario", textEdit4.Text);
            cmd_update.AddParams("@senha", senha_base64);

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

            String query_delete = "DELETE FROM acesso WHERE id_usuario=@id_usuario";
            ExeSql cmd_delete = new ExeSql(query_delete);

            cmd_delete.AddParams("@id_usuario", id_reg, DbType.Int32);
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
                    String query_acesso_insert = "INSERT INTO acesso (id_permissao, id_usuario) VALUES";
                    query_acesso_insert += "(@id_permissao, @id_usuario)";

                    ExeSql cmd_acesso_insert = new ExeSql(query_acesso_insert);
                    cmd_acesso_insert.AddParams("@id_permissao", checkedListBoxControl1.GetItemValue(i).ToString(), DbType.Int32);
                    cmd_acesso_insert.AddParams("@id_usuario", id_reg, DbType.Int32);
                    if (!cmd_acesso_insert.ExecuteSql())
                    {
                        error_acesso = true;
                    }
                }
            }
            if (error_acesso == true)
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao definir as permissões. {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            valid.confirmClose();

            this.Close();
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit4.Checked == false)
            {
                for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                {

                    checkedListBoxControl1.SetItemChecked(i, false);
                }
                return;
            }
            else if (checkEdit4.Checked == true)
            {
                for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                {
                    checkedListBoxControl1.SetItemChecked(i, true);
                }
                return;
            }
        }

        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_Leave(object sender, EventArgs e)
        {
            string formated = FormatHelper.Telefone(textEdit2.Text);
            textEdit2.Text = formated;
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {

        }

        private void frm_cadastro_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

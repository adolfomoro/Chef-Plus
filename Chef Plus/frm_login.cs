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
using System.Configuration;
using System.Net.Mail;
using ChefPlus.core;
using Microsoft.Win32;
using ChefPlus.data;
using Npgsql;

namespace Chef_Plus
{
    public partial class frm_login : XtraForm
    {

        public frm_login()
        {
            InitializeComponent();
            string versao = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var array_versao = versao.Split('.');
            labelControl1.Text += " "+ array_versao[0]+"."+ array_versao[1];

        }

        private void frm_login_Load(object sender, EventArgs e)
        {

            ExeSql mySqlDataAdapter = new ExeSql("SELECT * FROM usuarios WHERE status = '1'");

            lookUpEdit1.Properties.DisplayMember = "usuario";
            lookUpEdit1.Properties.ValueMember = "usuario";
            lookUpEdit1.Properties.DataSource = mySqlDataAdapter.DataSet().Tables[0];

            if (RegKey.get_value("last_user") != null)
            {
                lookUpEdit1.EditValue = RegKey.get_value("last_user");
            }
            else
            {
                ExeSql sql_user = new ExeSql("SELECT usuario FROM usuarios WHERE id='1'");
                NpgsqlDataReader myReader = sql_user.DataReader();
                if (myReader.Read())
                {
                    lookUpEdit1.EditValue = Convert.ToString(myReader["usuario"].ToString());
                }
                sql_user.CloseConnection();
            }
            textEdit1.Focus();
            textEdit1.Select();

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            (bool status, string message) login = UserLogin.Login((string)lookUpEdit1.EditValue, textEdit1.Text);
            if (login.status == true)
            {
                RegKey.set_value("last_user", lookUpEdit1.EditValue.ToString());
                this.Close();
            }
            else
            {
                if (login.message != "" && login.message != null)
                {
                    InfoUser.MessageBoxShow(login.message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }          
        }

        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1.PerformClick();
            }
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            string texto = labelControl4.Text;
            if ((string)lookUpEdit1.EditValue == "" || lookUpEdit1.EditValue == null)
            {
                InfoUser.MessageBoxShow("Informe o usuário para que a senha possa ser enviada por e-mail.",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string email = "";
            string senha = "";

            ExeSql sql_user = new ExeSql("SELECT * FROM usuarios WHERE usuario='" + lookUpEdit1.EditValue + "'");

            NpgsqlDataReader myReader = sql_user.DataReader();


            if (myReader.Read())
            {
                email = myReader["email"].ToString();

                senha = InfoUser.Base64Decode(myReader["senha"].ToString());
            }
            sql_user.CloseConnection();
            labelControl4.Text = "Aguarde...";
            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja enviar a senha para '"+email+"' ?",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    //(!)Editar corpo do email
                    string[] emails = { email };
                    if (InfoUser.EnviaEmail(emails, "Senha", senha))
                    {
                        InfoUser.MessageBoxShow("Um e-mail com a senha do usuário '" + lookUpEdit1.EditValue + "' foi enviado para ''" + email + "' com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        InfoUser.MessageBoxShow("Ocorreu um erro ao enviar o e-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    InfoUser.MessageBoxShow("Não foi possível enviar o e-mail com a senha no momento. Tente novamente mais tarde.",  MessageBoxButtons.OK, MessageBoxIcon.Information, ex.ToString());
                }
                labelControl4.Text = texto;
            }
            if (dialogResult == DialogResult.No)
            {
                labelControl4.Text = texto;
                return;
            }

        }
    }
}

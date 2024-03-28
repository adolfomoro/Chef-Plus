using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chef_Plus
{
    public partial class frm_cadastro_fornecedor : XtraForm
    {

        public string id_reg;

        private string nome;
        private string documento;
        private string rg_ie;
        private string fone_p;

        public ModifiedItemsForm valid { get; set; }


        public frm_cadastro_fornecedor()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;
            documento = string.Empty;
            rg_ie = string.Empty;
            fone_p = string.Empty;
        }

        private void frm_cadastro_fornecedor_Load(object sender, EventArgs e)
        {
            valid.MaskFunction(textEdit2, @"^.{2,}$", "Nome Inválido", true);
            valid.MaskFunction(textEdit3, @"^$|^([0-9]{2}[\.]{1}[0-9]{3}[\.]{1}[0-9]{3}[\/]{1}[0-9]{4}[-]{1}[0-9]{2})|([0-9]{3}[\.]{1}[0-9]{3}[\.]{1}[0-9]{3}[-]{1}[0-9]{2})$", "Documento Inválido", false);
            valid.MaskFunction(textEdit4, @"^$|^.{3,}$", "Informação Inválida", false);
            valid.MaskFunction(textEdit5, @"^\([1-9]{2}\) [9]{0,1}[6-9]{1}[0-9]{3}\-[0-9]{4}$", "Telefone Inválido", true);
            valid.MaskFunction(textEdit7, @"^$|^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", "E-Mail Inválido", false);
            valid.MaskFunction(textEdit8, @"^$|^[0-9]{5}-[\d]{3}$", "CEP Inválido", false);

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT * FROM fornecedores WHERE id = @id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["id"].ToString();
                    id_reg = myReader["id"].ToString();
                    textEdit2.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();
                    textEdit3.Text = myReader["documento"].ToString();
                    documento = myReader["documento"].ToString();
                    textEdit4.Text = myReader["rg_ie"].ToString();
                    rg_ie = myReader["rg_ie"].ToString();
                    textEdit5.Text = myReader["celular"].ToString();
                    fone_p = myReader["celular"].ToString();
                    textEdit7.Text = myReader["email"].ToString();

                    textEdit8.Text = myReader["cep"].ToString();
                    textEdit9.Text = myReader["endereco"].ToString();
                    textEdit10.Text = myReader["numero"].ToString();
                    textEdit11.Text = myReader["bairro"].ToString();
                    textEdit12.Text = myReader["complemento"].ToString();
                    textEdit13.Text = myReader["cidade"].ToString();
                    comboBoxEdit2.EditValue = myReader["uf"].ToString();
                    textEdit14.Text = myReader["referencia"].ToString();


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
            textEdit2.Focus();
            textEdit2.Select();
        }

        private void frm_cadastro_fornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_cadastro_fornecedor_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM fornecedores WHERE id = @id");
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
                    ExeSql sql_del = new ExeSql("UPDATE fornecedores SET date_delete=@date_delete WHERE id=@id");
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
                    ExeSql sql_del = new ExeSql("UPDATE fornecedores SET date_delete=@date_delete WHERE id=@id");
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

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (!valid.CheckContinue())
            {
                return;
            }
            List<string> array = new List<string>();
            if (textEdit2.Text != nome && textEdit2.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM fornecedores WHERE nome=@nome AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@nome", textEdit2.Text);
                int rowsAffected = sql_exist1.ExecuteScalarInt();
                if (rowsAffected > 0)
                {
                    array.Add("Nome");
                }
            }
            if (textEdit3.Text != documento && textEdit3.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM fornecedores WHERE documento=@documento AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@documento", textEdit3.Text);
                int rowsAffected = sql_exist1.ExecuteScalarInt();
                if (rowsAffected > 0)
                {
                    array.Add("Documento");
                }
            }
            if (textEdit4.Text != rg_ie && textEdit4.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM fornecedores WHERE rg_ie=@rg_ie AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@rg_ie", textEdit4.Text);
                int rowsAffected = sql_exist1.ExecuteScalarInt();
                if (rowsAffected > 0)
                {
                    array.Add("Documento");
                }
            }
            if (textEdit5.Text != fone_p && textEdit5.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM fornecedores WHERE (celular=@telefone) AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@telefone", textEdit5.Text);
                int rowsAffected = sql_exist1.ExecuteScalarInt();
                if (rowsAffected > 0)
                {
                    array.Add("Fone Principal");
                }
            }
            if (array.Any())
            {
                DialogResult dialogResult = InfoUser.MessageBoxShow("Já existe um registro com o "+ string.Join(" e ", array)+" informado.\r\n\r\nDeseja continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query = "INSERT INTO fornecedores (date_insert) VALUES";
                query += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
                textEdit1.Text = id_reg;
            }
            if (salvar_dados().ExecuteSql())
            {

            }
            else
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            valid.confirmClose();

            this.Close();
        }

        private ExeSql salvar_dados()
        {
            String query_categorias_update = "UPDATE fornecedores SET nome=@nome, documento=@documento, rg_ie=@rg_ie, celular=@celular, email=@email, cep=@cep, endereco=@endereco, numero=@numero, bairro=@bairro, complemento=@complemento, cidade=@cidade, uf=@uf, referencia=@referencia, date_update=@date_update";
            query_categorias_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_categorias_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome",  textEdit2.Text);
            cmd_update.AddParams("@documento", textEdit3.Text);
            cmd_update.AddParams("@rg_ie", textEdit4.Text);
            cmd_update.AddParams("@celular", textEdit5.Text);
            cmd_update.AddParams("@email", textEdit7.Text);
            cmd_update.AddParams("@cep", textEdit8.Text);
            cmd_update.AddParams("@endereco", textEdit9.Text);
            cmd_update.AddParams("@numero", textEdit10.Text);
            cmd_update.AddParams("@bairro", textEdit11.Text);
            cmd_update.AddParams("@complemento", textEdit12.Text);
            cmd_update.AddParams("@cidade", textEdit13.Text);
            cmd_update.AddParams("@uf", comboBoxEdit2.Text);
            cmd_update.AddParams("@referencia", textEdit14.Text);

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                cmd_update.AddParams("@date_update", DateHelper.GetDateNow(DateType.Type1));
            }
            else
            {
                cmd_update.AddParams("@date_update", "");
            }


            return cmd_update;
        }

        private void textEdit5_Leave(object sender, EventArgs e)
        {
            string formated = FormatHelper.Telefone(textEdit5.Text);
            textEdit5.Text = formated;
            
        }

        private void textEdit8_Leave(object sender, EventArgs e)
        {
            string formated = FormatHelper.CEP(textEdit8.Text);
            textEdit8.Text = formated;
        }

        private void textEdit3_Leave(object sender, EventArgs e)
        {
            string formated = FormatHelper.CPF_CNPJ(textEdit3.Text);
            textEdit3.Text = formated;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = textEdit8.Text.ToString().Replace("-", "");
                if (cep.Length < 8)
                {
                    InfoUser.MessageBoxShow("CEP incorreto.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                WebClient client = new WebClient();
                client.Proxy = null;
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string html = client.DownloadString("http://api.postmon.com.br/v1/cep/" + cep + "?format=json");
                JObject results = JObject.Parse(html);
                comboBoxEdit2.SelectedItem = (string)results["estado"];
                textEdit9.Text = (string)results["logradouro"];
                textEdit11.Text = (string)results["bairro"];
                textEdit13.Text = (string)results["cidade"];
                textEdit12.Text = (string)results["complemento"];
            }
            catch
            {
                InfoUser.MessageBoxShow("CEP não encontrado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textEdit10.Focus();
            textEdit10.SelectAll();
        }
    }
}

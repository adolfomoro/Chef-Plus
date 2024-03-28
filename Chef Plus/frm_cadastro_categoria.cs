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
    public partial class frm_cadastro_categoria : XtraForm
    {

        private frm_categorias.CategoriaTipo categoria;

        public string id_reg;

        private string nome;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_categoria(frm_categorias.CategoriaTipo _categoria)
        {
            InitializeComponent();

            categoria = _categoria;

            id_reg = string.Empty;

            nome = string.Empty;
        }

        private void cadastro_categoria_Load(object sender, EventArgs e)
        {
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT nome, tipo FROM categorias WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();

                    if (myReader["tipo"].ToString() == "produtos")
                    {
                        checkEdit1.Checked = true;
                    }
                    else if (myReader["tipo"].ToString() == "insumos")
                    {
                        checkEdit2.Checked = true;
                    }

                }
                sql_load.CloseConnection();
            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {
                if (categoria.Value == frm_categorias.CategoriaTipo.Produtos.Value)
                {
                    checkEdit1.Checked = true;
                }
                else if (categoria.Value == frm_categorias.CategoriaTipo.Insumos.Value)
                {
                    checkEdit2.Checked = true;
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

        private void frm_cadastro_categoria_KeyDown(object sender, KeyEventArgs e)
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
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM categorias WHERE nome=@nome and tipo=@tipo");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                sql_exist1.AddParams("@tipo", categoria.Value);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com a Descrição informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query_insert = "INSERT INTO categorias (date_insert) VALUES";
                query_insert += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_insert = new ExeSql(query_insert);
                cmd_insert.AddParams("@date_insert", date_insert);
                id_reg = cmd_insert.ExecuteScalarString();
            }

            if (!salvar_dados().ExecuteSql())
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            valid.confirmClose();

            this.Close();
        }

        private ExeSql salvar_dados()
        {
            String query_categorias_update = "UPDATE categorias SET nome=@nome, tipo=@tipo, date_update=@date_update";
            query_categorias_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_categorias_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome", textEdit1.Text);
            if (checkEdit1.Checked == true)
            {
                cmd_update.AddParams("@tipo", "produtos");
            }
            else if (checkEdit2.Checked == true)
            {
                cmd_update.AddParams("@tipo", "insumos");
            }

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

        private void frm_cadastro_categoria_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM categorias WHERE id = @id");
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
    }
}

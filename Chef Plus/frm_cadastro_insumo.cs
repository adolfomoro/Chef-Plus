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
using ChefPlus.data;
using ChefPlus.core;
using System.Globalization;
using System.Text.RegularExpressions;
using Npgsql;
using System.IO;

namespace Chef_Plus
{
    public partial class frm_cadastro_insumo : XtraForm
    {
        public string id_reg;

        private string nome;
        private string id_perso;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_insumo()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;
            id_perso = string.Empty;

            ExeSql adapter_categorias = new ExeSql("SELECT * FROM categorias WHERE tipo = 'insumos' ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];


            HelperDev.MaskMoney(textEdit4, 2);

            HelperDev.MaskMoney(textEdit5, 3);
            HelperDev.MaskMoney(textEdit6, 3);

        }

        private void refresh_estoque()
        {
            ExeSql sql_estoque = new ExeSql("SELECT (CASE tipo WHEN'E' THEN'Entrada' ELSE CASE tipo WHEN'C' THEN 'Correção' ELSE CASE tipo WHEN 'S' THEN 'Saída' END END END) AS tipo, (SELECT nome FROM usuarios WHERE id = est_mov.id_usuario) AS USER, moneyf(qt,3) as qt, moneyf(valor,2) as valor, obs, date_insert FROM estoque_movimentacao AS est_mov WHERE id_produto=@id_produto ORDER BY id ASC");
            sql_estoque.AddParams("@id_produto", id_reg, DbType.Int32);
            gridControl1.DataSource = sql_estoque.DataTable();

            textEdit6.Text = HelperProdutos.LoadEstoque(id_reg);

            gridView1.MoveLast();
        }

        private void frm_cadastro_insumo_Load(object sender, EventArgs e)
        {
            ExeSql sql_exist_categoria = new ExeSql("SELECT COUNT(*) FROM categorias WHERE tipo='insumos'");
            if (sql_exist_categoria.ExecuteScalarInt() <= 0)
            {
                InfoUser.MessageBoxShow("É necessário cadastrar ao menos uma categoria para acessar essa tela.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT id, id_perso, nome, id_categoria, tipo, moneyf(preco_custo, 2) as preco_custo, controla_estoque, moneyf(estoque_minimo, 3) as estoque_minimo, date_insert, date_update FROM insumos WHERE id = @id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();
                    textEdit2.Text = myReader["id"].ToString();
                    textEdit3.Text = myReader["id_perso"].ToString();
                    id_perso = myReader["id_perso"].ToString();

                    lookUpEdit1.EditValue = (int)myReader["id_categoria"];

                    if (myReader["tipo"].ToString() == "UN")
                    {
                        checkEdit1.Checked = true;
                    } else if (myReader["tipo"].ToString() == "KG")
                    {
                        checkEdit2.Checked = true;
                    }
                    else if (myReader["tipo"].ToString() == "LT")
                    {
                        checkEdit3.Checked = true;
                    }

                    textEdit4.Text = myReader["preco_custo"].ToString();

                    checkEdit4.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["controla_estoque"]));

                    textEdit5.Text = myReader["estoque_minimo"].ToString();

                }
                sql_load.CloseConnection();
                refresh_estoque();
                simpleButton1.Visible = true;

            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {

                simpleButton1.Visible = false;
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


        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit4.Checked == true)
            {
                labelControl15.Enabled = true;
                labelControl16.Enabled = true;
                textEdit5.Enabled = true;
                simpleButton1.Enabled = true;
                if (valid.GetOperation() == ModifiedOperation.New)
                {
                    labelControl16.Enabled = true;
                    textEdit6.Enabled = true;
                }
            }
            else
            {
                labelControl15.Enabled = false;
                labelControl16.Enabled = false;
                textEdit5.Enabled = false;
                simpleButton1.Enabled = false;
                if (valid.GetOperation() == ModifiedOperation.New)
                {
                    labelControl16.Enabled = false;
                    textEdit6.Enabled = false;
                }
            }
        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void labelControl21_Click(object sender, EventArgs e)
        {
            //(!) Exibir mensagem explicando o que é um código personalizado e como ativa-lo

        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (textEdit4.Text == "")
            {
                textEdit4.Text = "0,00";
            }
            if (textEdit5.Text == "")
            {
                textEdit5.Text = "0,00";
            }
            if (textEdit1.Text == "")
            {
                InfoUser.MessageBoxShow("Nome não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit1.Text != nome && textEdit1.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM insumos WHERE nome=@nome AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (textEdit3.Text != id_perso && textEdit3.Text != "")
            {
                ExeSql sql_exist2 = new ExeSql("SELECT count(*) FROM insumos WHERE id_perso=@id_perso AND (date_delete IS NULL or date_delete = '')");
                sql_exist2.AddParams("@id_perso", textEdit3.Text);
                if (sql_exist2.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Código Personalizado informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (lookUpEdit1.EditValue == null || lookUpEdit1.EditValue.ToString() == "")
            {
                InfoUser.MessageBoxShow("Categoria não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query_insert = "INSERT INTO insumos (date_insert) VALUES";
                query_insert += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_insert = new ExeSql(query_insert);
                cmd_insert.AddParams("@date_insert", date_insert);
                id_reg = cmd_insert.ExecuteScalarString();
                textEdit2.Text = id_reg;
            }

            if (salvar_dados().ExecuteSql())
            {
                if (valid.GetOperation() == ModifiedOperation.New)
                {
                    if (!HelperProdutos.EstoqueMovimentacao(Convert.ToInt32(id_reg), textEdit6.Text, "0,00", "Entrada de Estoque Inicial", HelperProdutos.TipoEstoqueMovimentacao.Entrada, UserLogin.IdUserGet()))
                    {
                        InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o estoque.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
            String query_insumo_update = "update insumos set nome=@nome, id_perso=@id_perso, id_categoria=@id_categoria, tipo=@tipo, preco_custo=moneyinsert(@preco_custo),  controla_estoque=@controla_estoque, estoque_minimo=moneyinsert(@estoque_minimo), date_update=@date_update";
            query_insumo_update += " where id = @id";
            ExeSql cmd_update = new ExeSql(query_insumo_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome", textEdit1.Text);
            cmd_update.AddParams("@id_perso", textEdit3.Text);
            cmd_update.AddParams("@id_categoria", Convert.ToString(lookUpEdit1.EditValue), DbType.Int32);

            if (checkEdit1.Checked == true)
            {
                cmd_update.AddParams("@tipo", "UN");
            }
            else if (checkEdit2.Checked == true)
            {
                cmd_update.AddParams("@tipo", "KG");
            }
            else if (checkEdit3.Checked == true)
            {
                cmd_update.AddParams("@tipo", "LT");
            }

            cmd_update.AddParams("@preco_custo", textEdit4.Text);

            cmd_update.AddParams("@controla_estoque", Convert.ToInt32(checkEdit4.Checked).ToString());

            cmd_update.AddParams("@estoque_minimo", textEdit5.Text);

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

        private void frm_cadastro_insumo_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM insumos WHERE id = @id");
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

        private void frm_cadastro_insumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void pictureEdit1_ImageChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (valid.IsEditing())
            {
                DialogResult dialogResult = InfoUser.MessageBoxShow("Para fazer alterações no estoque é necessário salvar o registro atual.\r\n\r\nDeseja salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    btn_menu_save.PerformClick();

                    valid.confirmClose();
                }
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            frm_estoque f = new frm_estoque(id_reg);
            f.ShowDialog();
            f.Dispose();
            refresh_estoque();
            valid.confirmClose();
        }

        private void textEdit3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

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
                    ExeSql sql_del = new ExeSql("UPDATE insumos SET date_delete=@date_delete WHERE id=@id");
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
                    ExeSql sql_del = new ExeSql("UPDATE insumos SET date_delete=@date_delete WHERE id=@id");
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

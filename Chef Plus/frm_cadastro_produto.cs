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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace Chef_Plus
{
    public partial class frm_cadastro_produto : XtraForm
    {
        public string id_reg;

        private string nome;
        private string id_perso;

        private bool show_message = false;
        private bool display_message = false;

        public ModifiedItemsForm valid { get; set; }

        public class Insumos
        {
            public string IdTamanho { get; set; }
            public bool IdInsumo { get; set; }
            public string Qt { get; set; }
            public string Custo { get; set; }

        }

        List<Insumos> l_insumos = new List<Insumos>();



        public frm_cadastro_produto()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;
            id_perso = string.Empty;

            show_message = false;
            display_message = false;

            ids_delete.Clear();

            l_insumos.Clear();


            ExeSql adapter_categorias = new ExeSql("SELECT * FROM categorias WHERE tipo = 'produtos' ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];

            ExeSql adapter_cozinhas = new ExeSql("SELECT id, nome, (SELECT nome FROM impressoras WHERE id_link = cozinhas.id AND link='cozinha') AS nome_impressora FROM cozinhas AS cozinhas ORDER BY id ASC");
            lookUpEdit2.Properties.DisplayMember = "nome";
            lookUpEdit2.Properties.ValueMember = "nome";
            lookUpEdit2.Properties.DataSource = adapter_cozinhas.DataSet().Tables[0];

           

            HelperDev.MaskMoney(textEdit4, 2);
            HelperDev.MaskMoney(textEdit5, 2);

            HelperDev.MaskMoney(textEdit6, 3);
            HelperDev.MaskMoney(textEdit7, 3);

        }

        private void refresh_estoque()
        {
            ExeSql sql_estoque = new ExeSql("SELECT (CASE tipo WHEN'E' THEN'Entrada' ELSE CASE tipo WHEN'C' THEN'Correção' ELSE CASE tipo WHEN 'S' THEN 'Saída' END END END) AS tipo, (SELECT nome FROM usuarios WHERE id = est_mov.id_usuario) AS USER, moneyf(qt,3) as qt, moneyf(valor,2) as valor, obs, date_insert FROM estoque_movimentacao AS est_mov WHERE id_produto=@id_produto ORDER BY id ASC");
            sql_estoque.AddParams("@id_produto", id_reg, DbType.Int32);
            gridControl1.DataSource = sql_estoque.DataTable();

            textEdit7.Text = HelperProdutos.LoadEstoque(id_reg);
            gridView1.MoveLast();
        }

        private void frm_cadastro_produto_Load(object sender, EventArgs e)
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
                ExeSql sql_load = new ExeSql("SELECT id, id_perso, nome, id_categoria, tipo, moneyf(preco_venda, 2) as preco_venda, moneyf(preco_custo, 2) as preco_custo, descricao, sem_taxa_servico, imprimir_cozinha, id_cozinha, imprimir_retirada, access_comanda_mobile, access_cardapio_digital, imagem, controla_estoque, moneyf(estoque_minimo, 3) as estoque_minimo, date_insert, date_update FROM produtos WHERE id = @id");
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
                    textEdit5.Text = myReader["preco_venda"].ToString();
                    memoEdit1.Text = myReader["descricao"].ToString();
                    
                    checkEdit4.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["sem_taxa_servico"]));
                    checkEdit5.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["imprimir_cozinha"]));

                    lookUpEdit2.EditValue = (int)myReader["id_cozinha"];
                    checkEdit9.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["imprimir_retirada"]));
                    checkEdit6.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["access_comanda_mobile"]));
                    checkEdit7.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["access_cardapio_digital"]));

                    pictureEdit1.Image = ImageHelper.Base64ToImage(myReader["imagem"].ToString());

                    checkEdit8.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["controla_estoque"]));

                    textEdit6.Text = myReader["estoque_minimo"].ToString();


                    textEdit8.Text = DateHelper.FormatDate(myReader["date_insert"].ToString(), DateType.Type1, DateType.Type3);

                    if (myReader["date_update"].ToString() != null && myReader["date_update"].ToString() != "")
                    {
                        textEdit9.Text = DateHelper.FormatDate(myReader["date_insert"].ToString(), DateType.Type1, DateType.Type3);
                        textEdit9.Visible = true;
                        labelControl18.Visible = true;
                    }

                }
                sql_load.CloseConnection();
                refresh_estoque();
                
                simpleButton3.Visible = true;


            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {
                simpleButton3.Visible = false;
            }
            else
            {
                InfoUser.MessageBoxShow("{{error_open_form_reg}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            select_insumos();
            valid.Reset();
            show_message = true;
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pictureEdit1.Image = Chef_Plus.Properties.Resources.food_default;
            simpleButton2.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog(); 
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap pic= new Bitmap(open.FileName);
                if (pic.Height > 800 || pic.Width > 1200)
                {
                    InfoUser.MessageBoxShow("Não é possível carregar está imagem. Ela ultrapassa o tamanho máximo de 1200x800 pixels.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    pictureEdit1.Image = pic;
                }
            }
            if (pictureEdit1.Image != Chef_Plus.Properties.Resources.food_default)
            {
                simpleButton2.Enabled = true;
            }
            else
            {
                simpleButton2.Enabled = false;
            }
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit5.Checked == true)
            {
                labelControl12.Enabled = true;
                lookUpEdit2.Enabled = true;
            }
            else
            {
                labelControl12.Enabled = false;
                lookUpEdit2.Enabled = false;
            }
        }

        private void checkEdit8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit8.Checked == true)
            {
                labelControl15.Enabled = true;
                labelControl16.Enabled = true;
                textEdit6.Enabled = true;
                simpleButton3.Enabled = true;

                if (valid.GetOperation() == ModifiedOperation.New)
                {
                    labelControl16.Enabled = true;
                    textEdit7.Enabled = true;
                }
            }
            else
            {
                labelControl15.Enabled = false;
                labelControl16.Enabled = false;
                textEdit6.Enabled = false;
                simpleButton3.Enabled = false;
                if (valid.GetOperation() == ModifiedOperation.New)
                {
                    labelControl16.Enabled = false;
                    textEdit7.Enabled = false;
                }
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true && show_message == true && display_message == false)
            {
                display_message = true;
                InfoUser.MessageBoxShow("Não é possível lançar produtos vendidos por KG pela \"Comanda Mobile\" e no \"Cardápio Digital\".", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkEdit9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int total = 500;
            labelControl20.Text = "Restam " + (total - memoEdit1.Text.Length).ToString() + "\r\n" + "Caracteres";
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
                ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM produtos WHERE nome=@nome AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                int rowsAffected = sql_exist1.ExecuteScalarInt();
                if (rowsAffected > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (lookUpEdit1.EditValue == null || lookUpEdit1.EditValue.ToString() == "")
            {
                InfoUser.MessageBoxShow("Categoria não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit3.Text != id_perso && textEdit3.Text != "")
            {
                ExeSql sql_exist2 = new ExeSql("SELECT count(*) FROM produtos WHERE id_perso=@id_perso AND (date_delete IS NULL or date_delete = '')");
                sql_exist2.AddParams("@id_perso", textEdit3.Text);
                if (sql_exist2.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com Código Personalizado informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (checkEdit5.Checked == true && (lookUpEdit2.EditValue == null || lookUpEdit2.EditValue.ToString() == ""))
            {
                InfoUser.MessageBoxShow("Impressora para a cozinha não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query = "INSERT INTO PRODUTOS (date_insert, tipo_produto) VALUES";
                query += "(@date_insert, 1) RETURNING id";

                textEdit8.Text = DateHelper.GetDateNow(DateType.Type3);
                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
                textEdit2.Text = id_reg;
            }
            
            if (salvar_dados().ExecuteSql())
            {
                var query_del = "DELETE FROM produtos_insumos WHERE id_insumo IN (" + String.Join(",", ids_delete) + ") and id_produto=@id_produto";
                ExeSql cmd_dels = new ExeSql(query_del);
                cmd_dels.AddParams("@id_produto", id_reg, DbType.Int32);
                cmd_dels.ExecuteSql();

                for (int i = 0; i < gridView2.RowCount; ++i)
                {
                    DataRow row = gridView2.GetDataRow(i);

                    ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM produtos_insumos WHERE id_produto=@id_produto and id_insumo=@id_insumo");
                    sql_exist1.AddParams("@id_produto", id_reg, DbType.Int32);
                    sql_exist1.AddParams("@id_insumo", row["id_insumo"].ToString(), DbType.Int32);

                    if (sql_exist1.ExecuteScalarInt() > 0)
                    {
                        String query = "UPDATE produtos_insumos SET qt=moneyinsert(@qt) WHERE id_produto=@id_produto and id_insumo=@id_insumo";
                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id_produto", id_reg, DbType.Int32);
                        cmd.AddParams("@id_insumo", row["id_insumo"].ToString(), DbType.Int32);
                        cmd.AddParams("@qt", row["qt"].ToString());
                        cmd.AddParams("@date_insert", DateHelper.GetDateNow(DateType.Type1));
                        cmd.ExecuteSql();
                    }
                    else
                    {
                        String query = "INSERT INTO produtos_insumos (id_produto, id_insumo, qt, date_insert) VALUES";
                        query += "(@id_produto, @id_insumo, moneyinsert(@qt), @date_insert)";

                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id_produto", id_reg, DbType.Int32);
                        cmd.AddParams("@id_insumo", row["id_insumo"].ToString(), DbType.Int32);
                        cmd.AddParams("@qt", row["qt"].ToString());
                        cmd.AddParams("@date_insert", DateHelper.GetDateNow(DateType.Type1));
                        cmd.ExecuteSql();
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
            String query_prod_update = "update produtos set nome=@nome, id_perso=@id_perso, id_categoria=@id_categoria, tipo=@tipo, preco_custo=moneyinsert(@preco_custo), preco_venda=moneyinsert(@preco_venda), descricao=@descricao, sem_taxa_servico=@sem_taxa_servico, imprimir_cozinha=@imprimir_cozinha, id_cozinha=@id_cozinha, imprimir_retirada=@imprimir_retirada, access_comanda_mobile=@access_comanda_mobile, access_cardapio_digital=@access_cardapio_digital, imagem=@imagem, controla_estoque=@controla_estoque, estoque_minimo=moneyinsert(@estoque_minimo), date_update=@date_update";
            query_prod_update += " where id = @id";
            ExeSql cmd_update = new ExeSql(query_prod_update);

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
            cmd_update.AddParams("@preco_venda", textEdit5.Text);

            cmd_update.AddParams("@descricao", memoEdit1.Text);
            cmd_update.AddParams("@sem_taxa_servico", Convert.ToInt32(checkEdit4.Checked).ToString());
            cmd_update.AddParams("@imprimir_cozinha", Convert.ToInt32(checkEdit5.Checked).ToString());
            cmd_update.AddParams("@id_cozinha", Convert.ToString(lookUpEdit2.EditValue), DbType.Int32);
            cmd_update.AddParams("@imprimir_retirada", Convert.ToInt32(checkEdit9.Checked).ToString());
            cmd_update.AddParams("@access_comanda_mobile", Convert.ToInt32(checkEdit6.Checked).ToString());
            cmd_update.AddParams("@access_cardapio_digital", Convert.ToInt32(checkEdit7.Checked).ToString());

            cmd_update.AddParams("@imagem", ImageHelper.ImageToBase64(pictureEdit1.Image));

            cmd_update.AddParams("@controla_estoque", Convert.ToInt32(checkEdit8.Checked).ToString());

            cmd_update.AddParams("@estoque_minimo", textEdit6.Text);

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                cmd_update.AddParams("@date_update", DateHelper.GetDateNow(DateType.Type1));
            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {
                if (!HelperProdutos.EstoqueMovimentacao(Convert.ToInt32(id_reg), textEdit7.Text, "0,00", "Entrada de Estoque Inicial", HelperProdutos.TipoEstoqueMovimentacao.Entrada, UserLogin.IdUserGet()))
                {
                    InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o estoque.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cmd_update.AddParams("@date_update", "");
            }
            return cmd_update;
        }

        private void frm_cadastro_produto_FormClosing(object sender, FormClosingEventArgs e)
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
                            ExeSql sql_del = new ExeSql("DELETE FROM produtos WHERE id = @id");
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

        private void frm_cadastro_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (p_c_insumos.Visible == true)
                {
                    p_c_insumos.Visible = false;
                    return;
                }
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (p_c_insumos.Visible == true)
                {
                    simpleButton4.PerformClick();
                }
            }
        }

        private void pictureEdit1_ImageChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (valid.IsEditing())
            {
                DialogResult dialogResult = InfoUser.MessageBoxShow("Para fazer alterações no estoque é necessário salvar o registro atual.\r\n\r\nDeseja salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //(!) Verificar se der erro deve parar, mas esta continuando
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
                    ExeSql sql_del = new ExeSql("UPDATE produtos SET date_delete=@date_delete WHERE id=@id");
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
                    ExeSql sql_del = new ExeSql("UPDATE produtos SET date_delete=@date_delete WHERE id=@id");
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

        private void textEdit10_Enter(object sender, EventArgs e)
        {
            if (p_c_insumos.Visible == false)
            {
                p_c_insumos.Visible = true;
                select_c_insumos();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            p_c_insumos.Visible = false;
        }

        private void textEdit10_EditValueChanged(object sender, EventArgs e)
        {
            if (p_c_insumos.Visible == false)
            {
                p_c_insumos.Visible = true;
            }
            select_c_insumos();
        }

        private void labelControl23_Click(object sender, EventArgs e)
        {
            frm_cadastro_insumo frm = new frm_cadastro_insumo();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_c_insumos();
        }

        private void select_c_insumos()
        {
            ExeSql sql_insumos = new ExeSql("select id, nome, moneyf(preco_custo, 2) as preco_custo, tipo from insumos as insumos where ((nome<>'') and (nome ilike '%" + textEdit10.Text + "%')) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            gridControl3.DataSource = sql_insumos.DataTable();
        }

        private void select_insumos()
        {
            ExeSql sql_insumos = new ExeSql("select id, id_insumo, (select nome from insumos where id=prod_insumos.id_insumo) as nome, '0,00' as precent, '0'::numeric as percent, (select tipo from insumos where id=prod_insumos.id_insumo) as tipo, moneyf(qt, 3) as qt, moneyf((qt * (select preco_custo from insumos where id=prod_insumos.id_insumo)), 3) as custo from (select sum(qt * (select preco_custo from insumos where id=produtos_insumos.id_insumo)) as aaaa from produtos_insumos where id_produto=@id_produto) as tbl_total, produtos_insumos as prod_insumos where id_produto=@id_produto ORDER BY id ASC");
            sql_insumos.AddParams("@id_produto", id_reg, DbType.Int32);

            gridControl2.DataSource = sql_insumos.DataTable();
        }

        private void p_c_button_add_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string id = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
            frm_add_insumo frm = new frm_add_insumo();
            frm.id_produto = id_reg;
            frm.id_insumo = id;
            frm.grid = gridView2;
            frm.valid = valid;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void p_c_button_add_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        List<string> ids_delete = new List<string>();
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id_insumo").ToString();

            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja realmente excluir o insumo selecionado?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
                valid.Modified();
                ids_delete.Add(id);
            }
            gridView2.CloseEditor();
            gridView2.UpdateTotalSummary();

        }

        private void gridView2_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            

        }

        private void gridView2_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "percent")
            {
                string valor1 = "0,00";
                if (gridView2.GetRowCellValue(e.RowHandle, "custo") != null && gridView2.GetRowCellValue(e.RowHandle, "custo").ToString() != "")
                {
                    valor1 = gridView2.GetRowCellValue(e.RowHandle, "custo").ToString();
                    if (valor1 != null && valor1 != "" && valor1 != "0")
                    {
                        string valor2 = "0,00";
                        if (gridView2.Columns["custo"].SummaryItem.SummaryValue != null && gridView2.Columns["custo"].SummaryItem.SummaryValue.ToString() != "")
                        {
                            valor2 = gridView2.Columns["custo"].SummaryItem.SummaryValue.ToString();
                        }
                        else
                        {
                            return;
                        }
                        gridView2.SetRowCellValue(e.RowHandle, "percent", DecimalHelper.Dividir(DecimalHelper.Multiplicar("100", valor1, true, 0), valor2, true, 0));
                    }
                }
            }
        }

        private void gridView2_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string id = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
            frm_add_insumo frm = new frm_add_insumo();
            frm.id_produto = id_reg;
            frm.id_insumo = id;
            frm.grid = gridView2;
            frm.valid = valid;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void gridView2_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            Font font = e.Appearance.Font;
            font = new Font("Tahoma", 20, FontStyle.Regular);

            e.Graphics.DrawString("Sem Ficha Técnica", font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y-30, e.Bounds.Width, e.Bounds.Height), drawFormat);
        }
    }

}

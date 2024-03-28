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
    public partial class frm_cadastro_combo : XtraForm
    {
        public string id_reg;

        private string nome;
        private string id_perso;

        private bool show_message = false;
        private bool display_message = false;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_combo()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;
            id_perso = string.Empty;

            show_message = false;
            display_message = false;

            ids_delete.Clear();

            ExeSql adapter_categorias = new ExeSql("SELECT * FROM categorias WHERE tipo = 'produtos' ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];
           

            HelperDev.MaskMoney(textEdit4, 2);
            HelperDev.MaskMoney(textEdit5, 2);

        }



        private void frm_cadastro_combo_Load(object sender, EventArgs e)
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

                    checkEdit6.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["access_comanda_mobile"]));
                    checkEdit7.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["access_cardapio_digital"]));

                    pictureEdit1.Image = ImageHelper.Base64ToImage(myReader["imagem"].ToString());


                    textEdit8.Text = DateHelper.FormatDate(myReader["date_insert"].ToString(), DateType.Type1, DateType.Type3);

                    if (myReader["date_update"].ToString() != null && myReader["date_update"].ToString() != "")
                    {
                        textEdit9.Text = DateHelper.FormatDate(myReader["date_insert"].ToString(), DateType.Type1, DateType.Type3);
                        textEdit9.Visible = true;
                        labelControl18.Visible = true;
                    }

                }
                sql_load.CloseConnection();



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
            select_itens_combo();
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
            if (gridView1.RowCount <= 0)
            {
                InfoUser.MessageBoxShow("Nenhum Item adicionado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query = "INSERT INTO PRODUTOS (date_insert, tipo_produto) VALUES";
                query += "(@date_insert, 3) RETURNING id";

                textEdit8.Text = DateHelper.GetDateNow(DateType.Type3);
                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
                textEdit2.Text = id_reg;
            }
            
            if (salvar_dados().ExecuteSql())
            {
                foreach (string obj in ids_delete)
                {
                    var query_del = "DELETE FROM produtos_combos_lista WHERE id=@id";
                    ExeSql cmd_dels = new ExeSql(query_del);
                    cmd_dels.AddParams("@id", obj, DbType.Int32);
                    cmd_dels.ExecuteSql();

                    var query_del2 = "DELETE FROM produtos_combos_itens WHERE id_combo=@id_combo";
                    ExeSql cmd_dels2 = new ExeSql(query_del2);
                    cmd_dels2.AddParams("@id_combo", obj, DbType.Int32);
                    cmd_dels2.ExecuteSql();
                }

                for (int i = 0; i < gridView1.RowCount; ++i)
                {
                    DataRow row = gridView1.GetDataRow(i);

                    if (row["id"].ToString() == "0")
                    {
                        String query = "INSERT INTO produtos_combos_lista (id_produto, nome, preco, quantidade, date_insert) VALUES";
                        query += "(@id_produto, @nome, moneyinsert(@preco), @quantidade, @date_insert) RETURNING id";

                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id_produto", id_reg, DbType.Int32);
                        cmd.AddParams("@nome", row["nome"].ToString());
                        cmd.AddParams("@preco", row["preco"].ToString());
                        cmd.AddParams("@quantidade", row["quantidade"].ToString(), DbType.Int32);
                        cmd.AddParams("@date_insert", DateHelper.GetDateNow(DateType.Type1));

                        gridView1.SetRowCellValue(i, "id", cmd.ExecuteScalarString());
                    }
                    else
                    {
                        String query = "UPDATE produtos_combos_lista SET nome=@nome, preco=moneyinsert(@preco), quantidade=@quantidade WHERE id=@id";
                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id", id_reg, DbType.Int32);
                        cmd.AddParams("@nome", row["nome"].ToString());
                        cmd.AddParams("@preco", row["preco"].ToString());
                        cmd.AddParams("@quantidade", row["quantidade"].ToString(), DbType.Int32);
                        cmd.ExecuteSql();
                    }

                    string[] Itens = row["item_id"].ToString().Split('-');

                    var query_del = "DELETE FROM produtos_combos_itens WHERE id_combo=@id_combo";
                    ExeSql cmd_dels = new ExeSql(query_del);
                    cmd_dels.AddParams("@id_combo", row["id"].ToString(), DbType.Int32);
                    cmd_dels.ExecuteSql();

                    foreach (string var in Itens)
                    {
                        String query = "INSERT INTO produtos_combos_itens (id_combo, id_produto) VALUES";
                        query += "(@id_combo, @id_produto)";

                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id_combo", row["id"].ToString(), DbType.Int32);
                        cmd.AddParams("@id_produto", var, DbType.Int32);

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
            String query_prod_update = "update produtos set nome=@nome, id_perso=@id_perso, id_categoria=@id_categoria, tipo=@tipo, preco_custo=moneyinsert(@preco_custo), preco_venda=moneyinsert(@preco_venda), descricao=@descricao, sem_taxa_servico=@sem_taxa_servico, access_comanda_mobile=@access_comanda_mobile, access_cardapio_digital=@access_cardapio_digital, imagem=@imagem, date_update=@date_update";
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
            cmd_update.AddParams("@access_comanda_mobile", Convert.ToInt32(checkEdit6.Checked).ToString());
            cmd_update.AddParams("@access_cardapio_digital", Convert.ToInt32(checkEdit7.Checked).ToString());

            cmd_update.AddParams("@imagem", ImageHelper.ImageToBase64(pictureEdit1.Image));

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                cmd_update.AddParams("@date_update", DateHelper.GetDateNow(DateType.Type1));
            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {
                cmd_update.AddParams("@date_update", "");
            }
            return cmd_update;
        }

        private void frm_cadastro_combo_FormClosing(object sender, FormClosingEventArgs e)
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

        private void frm_cadastro_combo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {

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


        List<string> ids_delete = new List<string>();
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();

            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja realmente excluir o item selecionado?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                valid.Modified();
                ids_delete.Add(id);
            }
            gridView1.CloseEditor();
            gridView1.UpdateTotalSummary();

        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            //(!) Salvar registro antes de abrir esta tela
            frm_cadastro_combo_item frm = new frm_cadastro_combo_item();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.valid_form_last = valid;
            frm.id_produto = id_reg;
            frm.grid = gridView1;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void select_itens_combo()
        {
            ExeSql sql_combos = new ExeSql("select id, id_produto, nome, moneyf(preco, 2) as preco, quantidade,(select string_agg((select nome from produtos where id=item.id_produto),',') from produtos_combos_itens as item where id_combo=produtos_combos_lista.id ) as opcoes,(select string_agg(produtos_combos_itens.id_produto::varchar,'-') from produtos_combos_itens where id_combo=produtos_combos_lista.id ) item_id from produtos_combos_lista as produtos_combos_lista where (id_produto=@id_produto) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            sql_combos.AddParams("@id_produto", id_reg, DbType.Int32);
            gridControl1.DataSource = sql_combos.DataTable();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                return;
            }

            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            ColumnView view = gridControl1.MainView as ColumnView;
            GridColumn colCountry = view.Columns["id"];
            int rowHandle = gridView1.LocateByDisplayText(0, colCountry, id);

            frm_cadastro_combo_item frm = new frm_cadastro_combo_item();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.valid_form_last = valid;
            frm.grid = gridView1;
            frm.id_produto = id_reg;
            frm.id_row = gridView1.FocusedRowHandle;
            frm.ShowDialog();
            frm.Dispose();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "preco")
            {
                if (gridView1.Columns["preco"].SummaryItem.SummaryValue != null && gridView1.Columns["preco"].SummaryItem.SummaryValue.ToString() != "")
                {
                    textEdit5.Text = gridView1.Columns["preco"].SummaryItem.SummaryValue.ToString();
                }


            }
        }
    }

}

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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Chef_Plus
{
    public partial class frm_produtos : XtraForm
    {

        public frm_produtos()
        {
            InitializeComponent();

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_produtos();
            select_produtos_tamanho();
            select_combos();
            SplashScreenManager.CloseForm(false);
        }

        private void select_produtos()
        {
            ExeSql sql_produtos = new ExeSql("select controla_estoque, id, (select nome from categorias where id = prod.id_categoria) as categoria_nome, nome, moneyf(preco_venda, 2) as preco_venda, moneyf(preco_custo, 2) as preco_custo, moneyf((select coalesce(SUM(qt),0) from estoque_movimentacao where id_produto=prod.id), 3) as estoque_atual from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='1' and (date_delete is NULL or date_delete = '') ORDER BY id ASC");
            gridControl1.DataSource = sql_produtos.DataTable();

            ExeSql cmd = new ExeSql("select count(*) from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='1' and (date_delete is NULL or date_delete = '')");
            xtraTabPage1.Text = " PRODUTOS (" + cmd.ExecuteScalarInt() + ")";

            gridView1_FocusedRowChanged(this, null);
        }

        private void select_produtos_tamanho()
        {
            if (checkEdit1.Checked == true)
            {
                ExeSql sql_produtos = new ExeSql("select prod.id_produto as id, (select nome from categorias where id = (select id_categoria from produtos where id = prod.id_produto)) as categoria_nome, (select nome from p_tipos where id = (select id_tipo from produtos where id = prod.id_produto)) as tipo, (select nome from p_tamanhos where id = prod.id_tamanho) || ' (' || (select sigla from p_tamanhos where id = prod.id_tamanho) || ')' as tamanho, (select nome from produtos where id = prod.id_produto) as nome, moneyf(preco_venda, 2) as preco_venda from produtos_personalizados_tamanhos as prod where (((select nome from produtos where id = prod.id_produto)<>'') and ((select nome from produtos where id = prod.id_produto) ilike '%" + textEdit1.Text + "%')) and (select tipo_produto from produtos where id = prod.id_produto) = '2' and ((select date_delete from produtos where id = prod.id_produto) is NULL or (select date_delete from produtos where id = prod.id_produto) = '') ORDER BY id ASC");
                gridControl3.DataSource = sql_produtos.DataTable();

                ExeSql cmd = new ExeSql("select count(*) from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='2' and (date_delete is NULL or date_delete = '')");
                xtraTabPage2.Text = " PRODUTOS POR TAMANHO (" + cmd.ExecuteScalarInt() + ")";
                gridControl3.Visible = true;
                gridControl2.Visible = false;
            }
            else
            {
                ExeSql sql_produtos = new ExeSql("select id, (select nome from categorias where id = prod.id_categoria) as categoria_nome, (select nome from p_tipos where id = prod.id_tipo) as tipo, nome, (coalesce((SELECT moneyf(min(preco_venda), 2) as preco1 FROM produtos_personalizados_tamanhos where id_produto = prod.id), '0,00') || ' - ' || coalesce((SELECT moneyf(max(preco_venda), 2) as preco2 FROM produtos_personalizados_tamanhos where id_produto = prod.id), '0,00'))  as precos from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='2' and (date_delete is NULL or date_delete = '') ORDER BY id ASC");
                gridControl2.DataSource = sql_produtos.DataTable();

                ExeSql cmd = new ExeSql("select count(*) from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='2' and (date_delete is NULL or date_delete = '')");
                xtraTabPage2.Text = " PRODUTOS POR TAMANHO (" + cmd.ExecuteScalarInt() + ")";
                gridControl3.Visible = false;
                gridControl2.Visible = true;

            }
        }

        private void select_combos()
        {
            ExeSql sql_produtos = new ExeSql("select controla_estoque, id, (select nome from categorias where id = prod.id_categoria) as categoria_nome, nome, moneyf(preco_venda, 2) as preco_venda, moneyf(preco_custo, 2) as preco_custo from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='3' and (date_delete is NULL or date_delete = '') ORDER BY id ASC");
            gridControl4.DataSource = sql_produtos.DataTable();

            ExeSql cmd = new ExeSql("select count(*) from produtos as prod where ((nome<>'') and (nome ilike '%" + textEdit1.Text + "%')) and tipo_produto='3' and (date_delete is NULL or date_delete = '')");
            xtraTabPage3.Text = " COMBOS (" + cmd.ExecuteScalarInt() + ")";
        }

        private void frm_produtos_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                select_produtos();
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                select_produtos_tamanho();
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                select_combos();
            }
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_trash_Click(object sender, EventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }

            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                gridControl1.ShowRibbonPrintPreview();
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                gridControl2.ShowRibbonPrintPreview();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                frm_cadastro_produto frm = new frm_cadastro_produto();
                frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();
                select_produtos();
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                frm_cadastro_produto_personalizado frm = new frm_cadastro_produto_personalizado();
                frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();
                select_produtos_tamanho();
            }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                frm_cadastro_combo frm = new frm_cadastro_combo();
                frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();
                select_combos();
            }

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

            frm_cadastro_produto frm = new frm_cadastro_produto();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_produtos();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void frm_produtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                return;
            }

            string controla = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "controla_estoque").ToString();

            if (controla == "1")
            {
                simpleButton1.Enabled = true;
            }
            else
            {
                simpleButton1.Enabled = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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

            frm_estoque f = new frm_estoque(id);
            f.ShowDialog();
            f.Dispose();
            select_produtos();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void gridView1_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {

        }

        private void gridView2_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {

        }

        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView2.IsGroupRow(gridView2.FocusedRowHandle))
            {
                return;
            }

            string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString();
            ColumnView view = gridControl2.MainView as ColumnView;
            GridColumn colCountry = view.Columns["id"];
            int rowHandle = gridView2.LocateByDisplayText(0, colCountry, id);

            frm_cadastro_produto_personalizado frm = new frm_cadastro_produto_personalizado();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_produtos_tamanho();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView2.FocusedRowHandle = rowHandle;
        }

        private void xtraTabPage2_Enter(object sender, EventArgs e)
        {
            
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == xtraTabPage1)
            {
                simpleButton1.Visible = true;
            }
            if (e.Page == xtraTabPage2)
            {
                simpleButton1.Visible = false;
                checkEdit1.Checked = false;
            }
            if (e.Page == xtraTabPage3)
            {
                simpleButton1.Visible = false;
            }

            textEdit1.Text = "";
            select_produtos();
            select_produtos_tamanho();
            select_combos();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            select_produtos_tamanho();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            if (gridView3.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView3.IsGroupRow(gridView3.FocusedRowHandle))
            {
                return;
            }

            string id = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
            ColumnView view = gridControl3.MainView as ColumnView;
            GridColumn colCountry = view.Columns["id"];
            int rowHandle = gridView3.LocateByDisplayText(0, colCountry, id);

            frm_cadastro_produto_personalizado frm = new frm_cadastro_produto_personalizado();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_produtos_tamanho();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView3.FocusedRowHandle = rowHandle;
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            if (gridView4.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView4.IsGroupRow(gridView4.FocusedRowHandle))
            {
                return;
            }

            string id = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, "id").ToString();
            ColumnView view = gridControl4.MainView as ColumnView;
            GridColumn colCountry = view.Columns["id"];
            int rowHandle = gridView4.LocateByDisplayText(0, colCountry, id);

            frm_cadastro_combo frm = new frm_cadastro_combo();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_combos();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView4.FocusedRowHandle = rowHandle;
        }
    }
}

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
    public partial class frm_insumos : XtraForm
    {

        public frm_insumos()
        {
            InitializeComponent();

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_insumos();
            SplashScreenManager.CloseForm(false);
        }

        private void select_insumos()
        {
            ExeSql sql_insumos = new ExeSql("select controla_estoque, id, (select nome from categorias where id = insumos.id_categoria) as categoria_nome, nome, moneyf(preco_custo, 2) as preco_custo, moneyf((select coalesce(SUM(qt),0) from estoque_movimentacao where id_produto=prod.id), 3) as estoque_atual from insumos as insumos where ((nome<>'') and (nome ILIKE '%" + textEdit1.Text + "%')) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            gridControl1.DataSource = sql_insumos.DataTable();

            ExeSql cmd = new ExeSql("select count(*) from insumos as insumos where ((nome<>'') and (nome ILIKE '%" + textEdit1.Text + "%')) AND (date_delete IS NULL or date_delete = '')");
            xtraTabPage1.Text = " INSUMOS (" + cmd.ExecuteScalarInt() + ")";

            gridView1_FocusedRowChanged(this, null);
        }

        private void frm_insumos_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                select_insumos();
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
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                frm_cadastro_insumo frm = new frm_cadastro_insumo();
                frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();
                select_insumos();
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

            frm_cadastro_insumo frm = new frm_cadastro_insumo();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_insumos();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void frm_insumos_KeyDown(object sender, KeyEventArgs e)
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
            select_insumos();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }
    }
}

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
    public partial class frm_complementos : XtraForm
    {


        public frm_complementos()
        {
            InitializeComponent();

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_complementos();
            SplashScreenManager.CloseForm(false);
        }

        private void select_complementos()
        {

            ExeSql sql_complementos = new ExeSql("SELECT id, (SELECT string_agg(nome, ', ') FROM categorias WHERE id IN (SELECT id_categoria FROM complementos_categorias WHERE id_complemento = comple.id)) AS categorias, nome, moneyf(preco_venda, 2) as preco_venda, moneyf(preco_custo, 2) as preco_custo FROM complementos AS comple WHERE ((nome<>'') AND (nome ILIKE '%" + textEdit1.Text + "%')) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            gridControl1.DataSource = sql_complementos.DataTable();

            ExeSql cmd = new ExeSql("SELECT count(*) FROM complementos WHERE ((nome<>'') AND (nome iLIKE '%" + textEdit1.Text + "%')) AND (date_delete IS NULL or date_delete = '')");
            xtraTabPage1.Text = " COMPLEMENTOS (" + cmd.ExecuteScalarInt() + ")";
        }

        private void frm_complementos_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                select_complementos();
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
                frm_cadastro_complemento frm = new frm_cadastro_complemento();
                frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();
                select_complementos();
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

            frm_cadastro_complemento frm = new frm_cadastro_complemento();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_complementos();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void frm_complementos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}

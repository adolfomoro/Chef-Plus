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
    public partial class frm_fornecedores : XtraForm
    {


        public frm_fornecedores()
        {
            InitializeComponent();

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_fornecedores();
            SplashScreenManager.CloseForm(false);
        }

        private void select_fornecedores()
        {
            ExeSql sql_fornecedores = new ExeSql("SELECT id, nome, celular, email FROM fornecedores AS fornecedores WHERE ((nome<>'') AND (nome ILIKE '%" + textEdit1.Text + "%')) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            gridControl1.DataSource = sql_fornecedores.DataTable();
        }

        private void frm_fornecedores_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            select_fornecedores();
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

            gridControl1.ShowRibbonPrintPreview();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {

            frm_cadastro_fornecedor frm = new frm_cadastro_fornecedor();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_fornecedores();


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

            frm_cadastro_fornecedor frm = new frm_cadastro_fornecedor();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_fornecedores();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void frm_fornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}

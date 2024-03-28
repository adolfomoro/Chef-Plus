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
    public partial class frm_clientes : XtraForm
    {

        public string returnID { get; set; }

        public frm_clientes()
        {
            InitializeComponent();

            returnID = string.Empty;

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_clientes();
            SplashScreenManager.CloseForm(false);
        }

        private void select_clientes()
        {
            ExeSql sql_clientes = new ExeSql("SELECT id, nome, celular, telefone, concat_ws(', ', NULLIF(bairro, ''), NULLIF(endereco, '')) as endereco, numero, saldo FROM clientes AS clientes WHERE ((nome<>'') AND (nome ILIKE '%" + textEdit1.Text + "%' or celular = '" + FormatHelper.Telefone(textEdit1.Text) + "' or telefone = '" + FormatHelper.Telefone(textEdit1.Text) + "')) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            gridControl1.DataSource = sql_clientes.DataTable();
        }

        private void frm_clientes_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            select_clientes();
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

            frm_cadastro_cliente frm = new frm_cadastro_cliente();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_clientes();


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

            if (Application.OpenForms.OfType<frm_mesas_pedido>().Count() > 0)
            {
                returnID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                this.Close();
                return;
            }
            else
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                ColumnView view = gridControl1.MainView as ColumnView;
                GridColumn colCountry = view.Columns["id"];
                int rowHandle = gridView1.LocateByDisplayText(0, colCountry, id);

                frm_cadastro_cliente frm = new frm_cadastro_cliente();
                frm.id_reg = id;
                frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();
                select_clientes();

                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    gridView1.FocusedRowHandle = rowHandle;
            }
        }

        private void frm_clientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}

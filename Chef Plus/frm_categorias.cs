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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace Chef_Plus
{
    public partial class frm_categorias : XtraForm
    {

        public class CategoriaTipo
        {
            private CategoriaTipo(string value) { Value = value; }

            public string Value { get; set; }

            public static CategoriaTipo Produtos { get { return new CategoriaTipo("produtos"); } }
            public static CategoriaTipo Insumos { get { return new CategoriaTipo("insumos"); } }
        }

        private CategoriaTipo categoria;

        public frm_categorias(CategoriaTipo _categoria)
        {
            InitializeComponent();

            categoria = _categoria;

            if (categoria.Value == CategoriaTipo.Produtos.Value)
            {
                this.Text = this.Text + " de Produtos";
            }
            else if (categoria.Value == CategoriaTipo.Insumos.Value)
            {
                this.Text = this.Text + " de Insumos";
            }


            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_categorias();
            SplashScreenManager.CloseForm(false);
        }

        private void select_categorias()
        {

            ExeSql sql_categorias = new ExeSql("SELECT id, nome FROM categorias WHERE (nome<>'') and tipo=@tipo ORDER BY id ASC");
            sql_categorias.AddParams("@tipo", categoria.Value);
            gridControl1.DataSource = sql_categorias.DataTable();

        }

        private void categorias_Load(object sender, EventArgs e)
        {

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
            frm_cadastro_categoria frm = new frm_cadastro_categoria(categoria);
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_categorias();
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

            frm_cadastro_categoria frm = new frm_cadastro_categoria(categoria);
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_categorias();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void frm_categorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

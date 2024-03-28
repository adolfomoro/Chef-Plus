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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using DevExpress.Export;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;
using DevExpress.XtraSplashScreen;

namespace Chef_Plus
{
    
    public partial class frm_usuarios : XtraForm
    {

        public frm_usuarios()
        {
            InitializeComponent();
        }

        private void frm_usuarios_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_users();
            SplashScreenManager.CloseForm(false);

        }

        private void select_users()
        {
            ExeSql sql_users = new ExeSql("SELECT id, nome, telefone, status FROM usuarios WHERE ((nome<>'') AND (nome ILIKE '%" + textEdit1.Text + "%' OR email ILIKE '%" + textEdit1.Text + "%')) ORDER BY id ASC");
            gridControl1.DataSource = sql_users.DataTable();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            select_users();

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

            frm_cadastro_usuario frm = new frm_cadastro_usuario();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_users();

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            frm_cadastro_usuario frm = new frm_cadastro_usuario();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_users();
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



        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            Font font = e.Appearance.Font;
            font = new Font("Tahoma", 25);
            e.Graphics.DrawString("Sem Resultados", font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
        }

        private void frm_usuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.Name == "status" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                string status = Convert.ToString(e.Value);
                switch (status)
                {
                    case "0": e.DisplayText = "Desativado"; break;
                    case "1": e.DisplayText = "Ativado"; break;
                    default: e.DisplayText = "Error"; break;
                }
            }
        }

    }
}

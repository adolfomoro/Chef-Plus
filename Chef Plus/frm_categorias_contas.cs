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
    
    public partial class frm_categorias_contas : XtraForm
    {

        public frm_categorias_contas()
        {
            InitializeComponent();
        }

        private void frm_categorias_contas_Load(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_categorias();
            SplashScreenManager.CloseForm(false);

        }

        private void select_categorias()
        {
            ExeSql sql_users = new ExeSql("SELECT * FROM categorias_contas WHERE (descricao<>'') AND internal = '0' ORDER BY id ASC");
            treeList1.DataSource = sql_users.DataTable();
            treeList1.ExpandAll();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            select_categorias();

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            frm_cadastro_categorias_contas frm = new frm_cadastro_categorias_contas();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_categorias();
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

        private void frm_categorias_contas_KeyDown(object sender, KeyEventArgs e)
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

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            string id = treeList1.FocusedNode.GetValue("id").ToString();

            frm_cadastro_categorias_contas frm = new frm_cadastro_categorias_contas();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_categorias();
        }
    }
}

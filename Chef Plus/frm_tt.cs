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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace Chef_Plus
{
    public partial class frm_tt : XtraForm
    {
        public frm_tt()
        {
            InitializeComponent();

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_tipos();
            SplashScreenManager.CloseForm(false);
        }

        private void select_tipos()
        {
            ExeSql sql_tipos = new ExeSql("SELECT id, nome FROM p_tipos WHERE (nome<>'') ORDER BY id ASC");
            gridControl1.DataSource = sql_tipos.DataTable();
        }

        private void frm_tt_Load(object sender, EventArgs e)
        {

        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_tt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                return;
            }

            string id_tipo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            ExeSql sql_tamanhos = new ExeSql("SELECT id, nome, sigla FROM p_tamanhos WHERE (nome<>'') and id_tipo=@id_tipo ORDER BY id ASC");
            sql_tamanhos.AddParams("@id_tipo", id_tipo, DbType.Int32);
            gridControl2.DataSource = sql_tamanhos.DataTable();
        }

        private void btn_new_tipo_Click(object sender, EventArgs e)
        {
            frm_cadastro_tipo frm = new frm_cadastro_tipo();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_tipos();
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

            frm_cadastro_tipo frm = new frm_cadastro_tipo();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_tipos();
            
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;

            gridView1_FocusedRowChanged(this, null);
        }

        private void btn_new_tamanho_Click(object sender, EventArgs e)
        {
            int rowHandle1 = 0;
            string id_tipo = string.Empty;
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                id_tipo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                ColumnView view = gridControl1.MainView as ColumnView;
                GridColumn colCountry = view.Columns["id"];
                rowHandle1 = gridView1.LocateByDisplayText(0, colCountry, id_tipo);
            }

            frm_cadastro_tamanho frm = new frm_cadastro_tamanho();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.carregar_id_tipo = id_tipo;
            frm.ShowDialog();
            frm.Dispose();
            select_tipos();
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                if (rowHandle1 != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    gridView1.FocusedRowHandle = rowHandle1;
                    gridView1_FocusedRowChanged(this, null);
                }
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            int rowHandle1 = 0;
            string id_tipo = string.Empty;
            if (gridView1.SelectedRowsCount > 0 && !gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                id_tipo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                ColumnView view1 = gridControl1.MainView as ColumnView;
                GridColumn colCountry1 = view1.Columns["id"];
                rowHandle1 = gridView1.LocateByDisplayText(0, colCountry1, id_tipo);
            }

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

            frm_cadastro_tamanho frm = new frm_cadastro_tamanho();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_tipos();

            if (rowHandle1 != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                gridView1.FocusedRowHandle = rowHandle1;
                gridView1_FocusedRowChanged(this, null);
            }

            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView2.FocusedRowHandle = rowHandle;

        }

        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gridView2.SelectedRowsCount <= 0)
            {
                return;
            }
            if (gridView2.IsGroupRow(gridView2.FocusedRowHandle))
            {
                return;
            }

            string id_tamanho = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString();
            ExeSql sql_produtos = new ExeSql("SELECT id_produto as id, (select nome from produtos_personalizados where id=prods.id_produto) as nome, moneyf(preco_venda,2) as preco_venda FROM produtos_personalizados_tamanhos as prods WHERE id_tamanho=@id_tamanho ORDER BY id ASC");
            sql_produtos.AddParams("@id_tamanho", id_tamanho, DbType.Int32);
            gridControl3.DataSource = sql_produtos.DataTable();
        }
    }
}

using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chef_Plus
{
    public partial class frm_formas_pagamento : XtraForm
    {
        public frm_formas_pagamento()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_formas_pagamento();
            select_bandeiras();
            SplashScreenManager.CloseForm(false);

            repositoryItemTextEdit2.Mask.Culture = new System.Globalization.CultureInfo("pt-BR");
            repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryItemTextEdit2.Mask.EditMask = "N2";
            repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = true;
        }

        private void select_formas_pagamento()
        {
            ExeSql sql_formas = new ExeSql("select id, nome from formas_pagamento where (date_delete is NULL or date_delete = '') ORDER BY id ASC");
            gridControl1.DataSource = sql_formas.DataTable();

            gridView1_FocusedRowChanged(this, null);
        }

        private void select_bandeiras()
        {
            ExeSql sql_formas = new ExeSql("select id, descricao from bandeiras where (date_delete is NULL or date_delete = '') ORDER BY id ASC");
            gridControl2.DataSource = sql_formas.DataTable();
        }

        private void frm_formas_pagamento_Load(object sender, EventArgs e)
        {

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

            string id_pagamento = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            if (id_pagamento == "1")
            {
                gridControl3.Enabled = false;
                gridControl3.DataSource = null;
            }
            else
            {
                gridControl3.Enabled = true;
                ExeSql sql_pagamentos = new ExeSql("SELECT m.id, m.descricao, (case when s.id is null then FALSE else TRUE end) status, coalesce(moneyf(s.taxa, 2), '0,00') as taxa, coalesce(s.dias, '0') as dias FROM bandeiras as m LEFT JOIN formas_pagamento_bandeiras s ON s.id_bandeira = m.id and s.id_pagamento=@id_pagamento");
                sql_pagamentos.AddParams("@id_pagamento", id_pagamento, DbType.Int32);
                gridControl3.DataSource = sql_pagamentos.DataTable();
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            gridView3.PostEditor();
            gridView3.UpdateCurrentRow();
        }

        private void repositoryItemTextEdit1_Leave(object sender, EventArgs e)
        {

        }

        private void repositoryItemTextEdit2_Leave(object sender, EventArgs e)
        {

        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (e.Column.FieldName == "taxa")
            {
                if (Convert.ToBoolean(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "status")) == false && e.Value.ToString() != "0,00")
                {
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, "status", true);
                }
                string id_pagamento = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                string id_bandeira = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
                String query_categorias_update = "UPDATE formas_pagamento_bandeiras SET taxa=moneyinsert(moneyf(@taxa::numeric,2)) WHERE id_pagamento=@id_pagamento and id_bandeira=@id_bandeira";
                ExeSql cmd_update = new ExeSql(query_categorias_update);
                cmd_update.AddParams("@id_pagamento", id_pagamento, DbType.Int32);
                cmd_update.AddParams("@id_bandeira", id_bandeira, DbType.Int32);
                cmd_update.AddParams("@taxa", e.Value);
                cmd_update.ExecuteSql();
            }
            if (e.Column.FieldName == "dias")
            {
                if (Convert.ToBoolean(gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "status")) == false && e.Value.ToString() != "0")
                {
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, "status", true);
                }
                string id_pagamento = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                string id_bandeira = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
                String query_categorias_update = "UPDATE formas_pagamento_bandeiras SET dias=@dias WHERE id_pagamento=@id_pagamento and id_bandeira=@id_bandeira";
                ExeSql cmd_update = new ExeSql(query_categorias_update);
                cmd_update.AddParams("@id_pagamento", id_pagamento, DbType.Int32);
                cmd_update.AddParams("@id_bandeira", id_bandeira, DbType.Int32);
                cmd_update.AddParams("@dias", e.Value.ToString());
                cmd_update.ExecuteSql();
            }
            if (e.Column.FieldName == "status")
            {
                string id_pagamento = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                string id_bandeira = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
                bool status = Convert.ToBoolean(e.Value.ToString());
                if (status == true)
                {
                    var query_del = "INSERT INTO formas_pagamento_bandeiras (id_pagamento, id_bandeira, dias, taxa) VALUES (@id_pagamento, @id_bandeira, '0', moneyinsert('0,00'))";
                    ExeSql cmd_dels = new ExeSql(query_del);
                    cmd_dels.AddParams("@id_pagamento", id_pagamento, DbType.Int32);
                    cmd_dels.AddParams("@id_bandeira", id_bandeira, DbType.Int32);
                    cmd_dels.ExecuteSql();
                }
                else
                {

                    var query_del = "DELETE FROM formas_pagamento_bandeiras WHERE id_pagamento=@id_pagamento and id_bandeira=@id_bandeira";
                    ExeSql cmd_dels = new ExeSql(query_del);
                    cmd_dels.AddParams("@id_pagamento", id_pagamento, DbType.Int32);
                    cmd_dels.AddParams("@id_bandeira", id_bandeira, DbType.Int32);
                    cmd_dels.ExecuteSql();
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, "dias", "0");
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, "taxa", "0,00");
                }

            }

        }

        private void repositoryItemTextEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void repositoryItemTextEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void frm_formas_pagamento_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_formas_pagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {

            frm_cadastro_bandeira frm = new frm_cadastro_bandeira();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_bandeiras();
            gridView1_FocusedRowChanged(this, null);
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
            if (Convert.ToInt32(id) <= 50)
            {
                InfoUser.MessageBoxShow("Este registro não pode ser editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ColumnView view = gridControl2.MainView as ColumnView;
            GridColumn colCountry = view.Columns["id"];
            int rowHandle = gridView2.LocateByDisplayText(0, colCountry, id);

            frm_cadastro_bandeira frm = new frm_cadastro_bandeira();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_bandeiras();
            gridView1_FocusedRowChanged(this, null);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView2.FocusedRowHandle = rowHandle;
        }

        private void repositoryItemTextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            gridView3.PostEditor();
            gridView3.UpdateCurrentRow();
        }

        private void repositoryItemTextEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(((TextEdit)(sender)).Text) > Convert.ToDouble(100))
            {
                ((TextEdit)(sender)).Text = "100,00";
            }
            gridView3.PostEditor();
            gridView3.UpdateCurrentRow();
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
            if (Convert.ToInt32(id) <= 50)
            {
                InfoUser.MessageBoxShow("Este registro não pode ser editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ColumnView view = gridControl1.MainView as ColumnView;
            GridColumn colCountry = view.Columns["id"];
            int rowHandle = gridView1.LocateByDisplayText(0, colCountry, id);

            frm_cadastro_forma_pagamento frm = new frm_cadastro_forma_pagamento();
            frm.id_reg = id;
            frm.valid = new ModifiedItemsForm(ModifiedOperation.Edit, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_bandeiras();
            gridView1_FocusedRowChanged(this, null);
            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                gridView1.FocusedRowHandle = rowHandle;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_cadastro_forma_pagamento frm = new frm_cadastro_forma_pagamento();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_formas_pagamento();
            select_bandeiras();
            gridView1_FocusedRowChanged(this, null);
        }
    }
}

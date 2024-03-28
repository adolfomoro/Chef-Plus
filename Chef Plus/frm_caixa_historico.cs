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
    public partial class frm_caixa_historico : XtraForm
    {


        public frm_caixa_historico()
        {
            InitializeComponent();

            ExeSql adapter_origem = new ExeSql("SELECT id, nome FROM usuarios");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";

            DataTable data_adapter_usuarios = adapter_origem.DataSet().Tables[0];

            DataRow row = data_adapter_usuarios.NewRow();
            row["id"] = 0;
            row["nome"] = "Todos";
            data_adapter_usuarios.Rows.Add(row);

            lookUpEdit1.Properties.DataSource = data_adapter_usuarios;

            lookUpEdit1.EditValue = (int)UserLogin.IdUserGet();

            SplashScreenManager.ShowForm(this, typeof(WaitForm), true, true, false);
            select_historico();
            SplashScreenManager.CloseForm(false);
        }

        private void select_historico()
        {
            if (checkEdit1.Checked)
            {
                ExeSql sql_caixas;
                if (lookUpEdit1.EditValue.ToString() == "0")
                {
                    sql_caixas = new ExeSql("SELECT id, date_abertura, date_fechamento, substring(trim((select nome from usuarios where id=caixa.id_usuario)) FROM '^([^ ]+)') as usuario, moneyf(saldo_inicial,2) as saldo_inicial, moneyf(saldo_final,2) as saldo_final, obs FROM caixa AS caixa ORDER BY id DESC limit " + numericUpDown1.Value.ToString());
                }
                else
                {
                    sql_caixas = new ExeSql("SELECT id, date_abertura, date_fechamento, substring(trim((select nome from usuarios where id=caixa.id_usuario)) FROM '^([^ ]+)') as usuario, moneyf(saldo_inicial,2) as saldo_inicial, moneyf(saldo_final,2) as saldo_final, obs FROM caixa AS caixa where id_usuario=@id_usuario ORDER BY id DESC limit " + numericUpDown1.Value.ToString());
                    sql_caixas.AddParams("@id_usuario", lookUpEdit1.EditValue.ToString(), DbType.Int32);
                }

                gridControl1.DataSource = sql_caixas.DataTable();


            }
            if (checkEdit2.Checked)
            {
                ExeSql sql_caixas;
                if (lookUpEdit1.EditValue.ToString() == "0")
                {
                    sql_caixas = new ExeSql("SELECT id, date_abertura, date_fechamento, substring(trim((select nome from usuarios where id=caixa.id_usuario)) FROM '^([^ ]+)') as usuario, moneyf(saldo_inicial,2) as saldo_inicial, moneyf(saldo_final,2) as saldo_final, obs FROM caixa AS caixa where TO_DATE(date_abertura, 'dd/MM/yyyy') BETWEEN TO_DATE(@date_1, 'dd/MM/yyyy') AND TO_DATE(@date_2, 'dd/MM/yyyy') ORDER BY id ASC");
                }
                else
                {
                    sql_caixas = new ExeSql("SELECT id, date_abertura, date_fechamento, substring(trim((select nome from usuarios where id=caixa.id_usuario)) FROM '^([^ ]+)') as usuario, moneyf(saldo_inicial,2) as saldo_inicial, moneyf(saldo_final,2) as saldo_final, obs FROM caixa AS caixa where TO_DATE(date_abertura, 'dd/MM/yyyy') BETWEEN TO_DATE(@date_1, 'dd/MM/yyyy') AND TO_DATE(@date_2, 'dd/MM/yyyy') AND (id_usuario=@id_usuario) ORDER BY id ASC");
                    sql_caixas.AddParams("@id_usuario", lookUpEdit1.EditValue.ToString(), DbType.Int32);
                }
                sql_caixas.AddParams("@date_1", dateEdit1.Text, DbType.String);
                sql_caixas.AddParams("@date_2", dateEdit2.Text, DbType.String);
                gridControl1.DataSource = sql_caixas.DataTable();
            }
        }

        private void frm_caixa_historico_Load(object sender, EventArgs e)
        {

        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_caixa_historico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            select_historico();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            frm_caixa frm = new frm_caixa(id);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            labelControl2.Visible = true;
            numericUpDown1.Value = 20;

            dateEdit1.Visible = false;
            dateEdit2.Visible = false;

            labelControl3.Visible = false;
            labelControl5.Visible = false;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            labelControl2.Visible = false;

            dateEdit1.Visible = true;
            dateEdit2.Visible = true;

            labelControl3.Visible = true;
            labelControl5.Visible = true;

            dateEdit1.EditValue = DateTime.Now;
            dateEdit2.EditValue = DateTime.Now;
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.Name == "status" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "date_fechamento") == null || view.GetListSourceRowCellValue(e.ListSourceRowIndex, "date_fechamento").ToString() == "")
                {
                    e.DisplayText = "Aberto";

                }
                else
                {
                    e.DisplayText = "Fechado";
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "status")
            {
                if (gridView1.GetRowCellValue(e.RowHandle, "date_fechamento") == null || gridView1.GetRowCellValue(e.RowHandle, "date_fechamento").ToString() == "")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Green;
                }
            }
        }
    }
}

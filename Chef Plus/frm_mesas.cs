using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chef_Plus
{
    public partial class frm_mesas : XtraForm
    {
        string texto_display = "Digite [NÚMERO] + [ENTER]";
        string numeros = "";
        Timer timer1 = new Timer();

        ExeSql sql_pedidos = new ExeSql("SELECT id, conta_solicitada, '' as permanencia, ( case when codigo =-1 then ('BALCÃO - '::text||id::text) else (case when length(codigo::text) > 2 then codigo::text else lpad(codigo::text,2,'0') end)end) as comanda, codigo as id_comanda, (select nome from usuarios where id=pedidos.id_usuario) as atendente, '' as status, '0,00' as subtotal, date_abertura FROM pedidos where (codigo > 0 or codigo = -1) AND (date_delete IS NULL or date_delete = '') ORDER BY comanda ASC");

        public frm_mesas()
        {
            InitializeComponent();

            numeros = string.Empty;
        }

        private void frm_mesas_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = sql_pedidos.DataTable();
            labelControl1.Text = texto_display;
            timer1.Tick += (timer1_Tick);
            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Interval = 500;

            if (layoutView1.FocusedRowHandle > -1)
            {
                int rowHandle = layoutView1.FocusedRowHandle;

                gridControl1.DataSource = sql_pedidos.DataTable();

                if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    layoutView1.FocusedRowHandle = rowHandle;
            }
            else
            {
                gridControl1.DataSource = sql_pedidos.DataTable();
            }

            for (int i = 0; i < layoutView1.RowCount; i++)
            {
                TimeSpan teste = Convert.ToDateTime(DateTime.Now.ToString()) - Convert.ToDateTime(DateTime.ParseExact(layoutView1.GetRowCellValue(i, "date_abertura").ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture));
                int horas = teste.Hours;
                int minutos = teste.Minutes;
                string data = horas + "h " + minutos + "min";
                layoutView1.SetRowCellValue(i, "permanencia", data);
                layoutView1.UpdateCurrentRow();
            }

            timer1.Start();
        }

        private void layoutView1_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomDrawCardCaptionEventArgs e)
        {
            e.CardCaption = layoutView1.GetRowCellValue(e.RowHandle, "comanda").ToString();

            //(!)mostrar nome do cliente no balcao
        }

        private void frm_mesas_Resize(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => {
                layoutView1.FocusedRowHandle = 0;
            }));
        }

        private void frm_mesas_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            if (int.TryParse(e.KeyChar.ToString(), out i))
            {
                if (numeros.Length >= 4){
                    return;
                }
                    numeros += e.KeyChar.ToString();
                    labelControl1.Text = numeros+" + [ENTER]";
                    labelControl1.ForeColor = Color.Blue;

            }
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Escape)
            {
                if (numeros == "")
                {
                    this.Close();
                    return;
                }
                else
                {
                    numeros = "";
                    labelControl1.Text = texto_display;
                    labelControl1.ForeColor = Color.Gray;
                    return;
                }
            }

            if (e.KeyChar == (char)Keys.Enter && numeros != "")
            {
                if (Convert.ToInt64(numeros) <= 0)
                {
                    InfoUser.MessageBoxShow("Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frm_mesas_pedido frm = new frm_mesas_pedido(null, frm_mesas_pedido.TipoPedido.Comanda, numeros);

                numeros = "";
                labelControl1.Text = texto_display;
                labelControl1.ForeColor = Color.Gray;

                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void frm_mesas_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void layoutView1_CardClick(object sender, DevExpress.XtraGrid.Views.Layout.Events.CardClickEventArgs e)
        {
            frm_mesas_pedido.TipoPedido tipo;
            if (layoutView1.GetRowCellValue(e.RowHandle, "id_comanda").ToString() == "-1")
            {
                tipo = frm_mesas_pedido.TipoPedido.Balcao;
            }
            else
            {
                tipo = frm_mesas_pedido.TipoPedido.Comanda;
            }
            frm_mesas_pedido frm = new frm_mesas_pedido(layoutView1.GetRowCellValue(e.RowHandle, "id").ToString(), tipo, layoutView1.GetRowCellValue(e.RowHandle, "id_comanda").ToString());

            numeros = "";
            labelControl1.Text = texto_display;
            labelControl1.ForeColor = Color.Gray;

            frm.ShowDialog();
            frm.Dispose();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                layoutView1.Columns.ColumnByFieldName("subtotal").Visible = true;

            }
            else
            {
                layoutView1.Columns.ColumnByFieldName("subtotal").Visible = false;
            }
            layoutView1.TemplateCard.Height = 0;
            layoutView1.TemplateCard.Width = 0;
        }

        private void layoutView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.Name == "status" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (view.GetListSourceRowCellValue(e.ListSourceRowIndex, "conta_solicitada").ToString() == "0")
                {
                    e.DisplayText = "Oculpada";

                }
                else
                {
                    e.DisplayText = "Conta Solicitada";
                }
            }
        }

        private void layoutView1_CustomFieldValueStyle(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewFieldValueStyleEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.Column.Name == "status")
            {
                if (view.GetListSourceRowCellValue(e.RowHandle, "conta_solicitada").ToString() == "0")
                {
                    e.Appearance.ForeColor = Color.Red;

                }
                else
                {
                    e.Appearance.ForeColor = Color.Orange;
                }

            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            frm_mesas_pedido frm = new frm_mesas_pedido(null, frm_mesas_pedido.TipoPedido.Balcao, "-1");

            numeros = "";
            labelControl1.Text = texto_display;
            labelControl1.ForeColor = Color.Gray;

            frm.ShowDialog();
            frm.Dispose();
        }
    }
}

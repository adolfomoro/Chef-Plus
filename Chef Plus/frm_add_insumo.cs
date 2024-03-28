using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
namespace Chef_Plus
{
    public partial class frm_add_insumo : XtraForm
    {
        public enum TipoLancamento
        {
            UN,
            KG,
            LT
        }

        private TipoLancamento tipo;

        public string id_produto;
        public string id_insumo;

        public string id_tamanho;

        public GridView grid;
        public ModifiedItemsForm valid;

        private string tipo_string;

        public frm_add_insumo()
        {
            InitializeComponent();

            id_produto = string.Empty;
            id_insumo = string.Empty;

            id_tamanho = string.Empty;

            tipo_string = string.Empty;

        }

        private void frm_add_insumo_Load(object sender, EventArgs e)
        {
            ExeSql sql_load = new ExeSql("SELECT id, tipo FROM insumos WHERE id=@id");
            sql_load.AddParams("@id", id_insumo, DbType.Int32);

            NpgsqlDataReader myReader = sql_load.DataReader();
            if (myReader.Read())
            {
                switch (myReader["tipo"].ToString())
                {
                    case "UN":
                        tipo_string = "UN";
                        tipo = TipoLancamento.UN;
                        panel_unidade.Visible = true;
                        HelperDev.MaskMoney(textEdit_un, 0);
                        textEdit_un.Focus();
                        textEdit_un.Select();
                        break;
                    case "KG":
                        tipo_string = "KG";
                        tipo = TipoLancamento.KG;
                        panel_kg.Visible = true;
                        HelperDev.MaskMoney(textEdit1, 3);
                        HelperDev.MaskMoney(textEdit2, 0);
                        textEdit1.Focus();
                        textEdit1.Select();
                        break;
                    case "LT":
                        tipo_string = "LT";
                        tipo = TipoLancamento.LT;
                        panel_lt.Visible = true;
                        HelperDev.MaskMoney(textEdit3, 3);
                        HelperDev.MaskMoney(textEdit4, 0);
                        textEdit3.Focus();
                        textEdit3.Select();
                        break;
                    default:
                        InfoUser.MessageBoxShow("{{error_open_form_reg}}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                }
            }
            sql_load.CloseConnection();
        }

        private bool AddInsumo(string quantidade)
        {
            string nome_insumo = string.Empty;
            string tipo_insumo = string.Empty;
            string custo_insumo = string.Empty;

            ExeSql sql_load = new ExeSql("select nome, tipo, moneyf(preco_custo,2) as preco_custo from insumos where id=@id");
            sql_load.AddParams("@id", id_insumo, DbType.Int32);
            NpgsqlDataReader myReader = sql_load.DataReader();
            if (myReader.Read())
            {
                nome_insumo = myReader["nome"].ToString();
                tipo_insumo = myReader["tipo"].ToString();
                custo_insumo = myReader["preco_custo"].ToString();
            }
            sql_load.CloseConnection();

            bool exist = false;
            Int32 linha = 0;
            for (int i = 0; i < grid.RowCount; ++i)
            {
                DataRow row = grid.GetDataRow(i);
                if (id_tamanho != string.Empty)
                {
                    if (row["id_insumo"].ToString() == id_insumo && row["id_tamanho"].ToString() == id_tamanho)
                    {
                        exist = true;
                        linha = i;
                    }
                }
                else
                {
                    if (row["id_insumo"].ToString() == id_insumo)
                    {
                        exist = true;
                        linha = i;
                    }
                }
            }

            if (exist == true)
            {
                grid.SetRowCellValue(linha, "qt", DecimalHelper.FormatarMoeda(quantidade, 3));
                grid.SetRowCellValue(linha, "custo", DecimalHelper.Multiplicar(quantidade, custo_insumo, true, 2));
                valid.Modified();
            }
            else
            {
                grid.AddNewRow();
                if (id_tamanho != string.Empty)
                {
                    grid.SetRowCellValue(GridControl.NewItemRowHandle, grid.Columns.ColumnByName("insumos_id_tamanho"), id_tamanho);
                }
                grid.SetRowCellValue(GridControl.NewItemRowHandle, grid.Columns.ColumnByName("insumos_id_insumo"), id_insumo);
                grid.SetRowCellValue(GridControl.NewItemRowHandle, grid.Columns.ColumnByName("insumos_nome"), nome_insumo);
                grid.SetRowCellValue(GridControl.NewItemRowHandle, grid.Columns.ColumnByName("insumos_qt"), DecimalHelper.FormatarMoeda(quantidade, 3));
                grid.SetRowCellValue(GridControl.NewItemRowHandle, grid.Columns.ColumnByName("insumos_medida"), tipo_string);
                grid.SetRowCellValue(GridControl.NewItemRowHandle, grid.Columns.ColumnByName("insumos_custo"), DecimalHelper.Multiplicar(quantidade, custo_insumo, true, 2));
                valid.Modified();

            }
            grid.UpdateCurrentRow();
            grid.UpdateSummary();
            return true;
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (tipo == TipoLancamento.UN)
            {
                if (Convert.ToDouble(textEdit_un.Text) <= 0)
                {
                    InfoUser.MessageBoxShow("Quantidade para lançamento não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AddInsumo(textEdit_un.Text);
                this.Close();
            }
            if (tipo == TipoLancamento.KG)
            {
                if (Convert.ToDouble(textEdit1.Text) <= 0)
                {
                    InfoUser.MessageBoxShow("Quantidade para lançamento não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AddInsumo(textEdit1.Text);
                this.Close();
            }
            if (tipo == TipoLancamento.LT)
            {
                if (Convert.ToDouble(textEdit3.Text) <= 0)
                {
                    InfoUser.MessageBoxShow("Quantidade para lançamento não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AddInsumo(textEdit3.Text);
                this.Close();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!AddInsumo("1"))
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o insumo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!AddInsumo("2"))
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o insumo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!AddInsumo("3"))
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o insumo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (!AddInsumo("4"))
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o insumo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textEdit_un_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        bool txt_1 = false;
        bool txt_2 = false;
        bool txt_3 = false;
        bool txt_4 = false;

        private void calcular()
        {
            if (tipo == TipoLancamento.KG)
            {
                if (txt_1 == true)
                {
                    textEdit2.Text = DecimalHelper.Multiplicar(textEdit1.Text, "1000");
                }
                if (txt_2 == true)
                {
                    textEdit1.Text = DecimalHelper.Dividir(textEdit2.Text, "1000", true, 3);
                }
            }
            if (tipo == TipoLancamento.LT)
            {
                if (txt_3 == true)
                {
                    textEdit4.Text = DecimalHelper.Multiplicar(textEdit3.Text, "1000");
                }
                if (txt_4 == true)
                {
                    textEdit3.Text = DecimalHelper.Dividir(textEdit4.Text, "1000", true, 3);
                }
            }

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void textEdit1_Enter(object sender, EventArgs e)
        {
            txt_1 = true;
        }

        private void textEdit1_Leave(object sender, EventArgs e)
        {
            txt_1 = false;
        }

        private void textEdit2_Enter(object sender, EventArgs e)
        {
            txt_2 = true;
        }

        private void textEdit2_Leave(object sender, EventArgs e)
        {
            txt_2 = false;
        }

        private void textEdit3_Enter(object sender, EventArgs e)
        {
            txt_3 = true;
        }

        private void textEdit3_Leave(object sender, EventArgs e)
        {
            txt_3 = false;
        }

        private void textEdit4_Enter(object sender, EventArgs e)
        {
            txt_4 = true;
        }

        private void textEdit4_Leave(object sender, EventArgs e)
        {
            txt_4 = false;
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void frm_add_insumo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

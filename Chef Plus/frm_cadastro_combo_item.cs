using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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

namespace Chef_Plus
{
    public partial class frm_cadastro_combo_item : XtraForm
    {

        public string id_reg;
        public string id_produto;
        public int id_row;
        private string nome_item;

        public ModifiedItemsForm valid_form_last { get; set; }

        public ModifiedItemsForm valid { get; set; }

        public GridView grid;

        public frm_cadastro_combo_item()
        {
            InitializeComponent();

            id_produto = string.Empty;
            nome_item = string.Empty;

            HelperDev.MaskMoney(textEdit2, 2);

        }

        private void form_cadastro_combo_item_Load(object sender, EventArgs e)
        {
            ExeSql sql_produtos = new ExeSql("select id, false as selecionado, (select nome from categorias where id=id_categoria) as categoria_nome, nome, moneyf(preco_venda,2) as preco_venda, date_delete from produtos as prod where (nome<>'') and (date_delete is NULL or date_delete = '') ORDER BY nome ASC");
            sql_produtos.AddParams("@id_combo", id_reg, DbType.Int64);
            gridControl1.DataSource = sql_produtos.DataTable();

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                textEdit1.Text = grid.GetRowCellValue(id_row, "nome").ToString();
                nome_item = grid.GetRowCellValue(id_row, "nome").ToString();
                textEdit2.Text = grid.GetRowCellValue(id_row, "preco").ToString();
                spinEdit1.EditValue = grid.GetRowCellValue(id_row, "quantidade").ToString();

                string[] Itens = grid.GetRowCellValue(id_row, "item_id").ToString().Split('-');


                for (int i = 0; i < gridView1.RowCount; ++i)
                {
                    DataRow row = gridView1.GetDataRow(i);

                    if (row == null)
                    {
                        continue;
                    }
                    if (gridView1.IsGroupRow(i))
                    {
                        continue;
                    }

                    if (Itens.Any(x => x == row["id"].ToString()))
                    {
                        gridView1.SetRowCellValue(i, "selecionado", true);
                    }

                }
            }



            valid.Reset();
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void form_cadastro_combo_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridView1_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {

        }

        private void gridView1_GroupRowCollapsed(object sender, DevExpress.XtraGrid.Views.Base.RowEventArgs e)
        {

        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            
            gridView1.PostEditor();
            gridView1.UpdateCurrentRow();

            if (valid.IsEditing() == false)
            {
                valid.Modified();
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                gridView1.Columns.ColumnByFieldName("selecionado").FilterInfo = new ColumnFilterInfo("[selecionado] LIKE 'true'");
            }
            else
            {
                gridView1.Columns.ColumnByFieldName("selecionado").FilterInfo = new ColumnFilterInfo("");
            }
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (textEdit2.Text == "")
            {
                textEdit2.Text = "0,00";
            }
            if (textEdit1.Text == string.Empty)
            {
                InfoUser.MessageBoxShow("Nome do Item não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit1.Text != nome_item && textEdit1.Text != "")
            {
                for (int i = 0; i < grid.RowCount; ++i)
                {
                    DataRow row = grid.GetDataRow(i);
                    if (row["nome"].ToString() == textEdit1.Text)
                    {
                        InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            if (Convert.ToInt64(spinEdit1.EditValue) <= 0)
            {
                InfoUser.MessageBoxShow("Quantidade não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }


            List<string> listaItensID = new List<string>();
            List<string> listaItensNOME = new List<string>();
            for (int i = 0; i < gridView1.RowCount; ++i)
            {
                DataRow row = gridView1.GetDataRow(i);

                if (row == null)
                {
                    continue;
                }
                if (gridView1.IsGroupRow(i))
                {
                    continue;
                }

                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, "selecionado")) == true)
                {
                    listaItensID.Add(row["id"].ToString());
                    listaItensNOME.Add(row["nome"].ToString());
                }

            }

            if (listaItensID.Count <= 0)
            {
                InfoUser.MessageBoxShow("Selecione Um ou Mais itens para o combo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                grid.SetRowCellValue(id_row, "nome", textEdit1.Text);
                grid.SetRowCellValue(id_row, "preco", textEdit2.Text);
                grid.SetRowCellValue(id_row, "quantidade", spinEdit1.EditValue.ToString());
                grid.SetRowCellValue(id_row, "item_id", String.Join("-", listaItensID).ToString());
                grid.SetRowCellValue(id_row, "opcoes", String.Join(",", listaItensNOME));
                valid.Modified();
            }
            else
            {
                grid.AddNewRow();
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "id", "0");
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "id_produto", id_produto);
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "nome", textEdit1.Text);
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "preco", textEdit2.Text);
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "quantidade", spinEdit1.EditValue.ToString());
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "item_id", String.Join("-", listaItensID).ToString());
                grid.SetRowCellValue(GridControl.NewItemRowHandle, "opcoes", String.Join(",", listaItensNOME));
                valid.Modified();

            }
            grid.UpdateCurrentRow();
            grid.UpdateSummary();

            valid_form_last.Modified();

            this.Close();
        }

    }
}

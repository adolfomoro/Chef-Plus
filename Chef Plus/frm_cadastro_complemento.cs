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
using Npgsql;
using DevExpress.XtraEditors.Controls;

namespace Chef_Plus
{
    public partial class frm_cadastro_complemento : XtraForm
    {

        public string id_reg;

        private string nome;

        public ModifiedItemsForm valid { get; set; }

        public frm_cadastro_complemento()
        {
            InitializeComponent();

            id_reg = string.Empty;

            nome = string.Empty;

            ids_delete.Clear();

            ExeSql mySqlDataAdapter = new ExeSql("SELECT * FROM categorias WHERE tipo='produtos' ORDER BY id ASC");

            checkedComboBoxEdit1.Properties.DisplayMember = "nome";
            checkedComboBoxEdit1.Properties.ValueMember = "id";
            checkedComboBoxEdit1.Properties.DataSource = mySqlDataAdapter.DataSet().Tables[0];

            HelperDev.MaskMoney(textEdit3, 2);
            HelperDev.MaskMoney(textEdit4, 2);
        }

        private void frm_cadastro_complemento_Load(object sender, EventArgs e)
        {
            ExeSql sql_exist_categoria = new ExeSql("SELECT COUNT(*) FROM categorias WHERE tipo='produtos'");
            if (sql_exist_categoria.ExecuteScalarInt() <= 0)
            {
                InfoUser.MessageBoxShow("É necessário cadastrar ao menos uma categoria para acessar essa tela.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                ExeSql sql_load = new ExeSql("SELECT id, nome, moneyf(preco_venda, 2) as preco_venda, moneyf(preco_custo, 2) as preco_custo, tipo, controla_estoque FROM complementos WHERE id=@id");
                sql_load.AddParams("@id", id_reg, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    textEdit1.Text = myReader["nome"].ToString();
                    nome = myReader["nome"].ToString();
                    textEdit2.Text = myReader["id"].ToString();
                    textEdit3.Text = myReader["preco_custo"].ToString();
                    textEdit4.Text = myReader["preco_venda"].ToString();

                    var tipo = myReader["tipo"].ToString();
                    if (tipo == "UN")
                    {
                        checkEdit1.Checked = true;
                    }
                    else if (tipo == "KG")
                    {
                        checkEdit2.Checked = true;
                    }
                    else if (tipo == "LT")
                    {
                        checkEdit3.Checked = true;
                    }

                    checkEdit4.Checked = Convert.ToBoolean(Convert.ToInt16(myReader["controla_estoque"]));

                }
                sql_load.CloseConnection();
                foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.GetItems())
                {
                    ExeSql sql_exist1 = new ExeSql("SELECT COUNT(*) FROM complementos_categorias WHERE id_complemento=@id_complemento AND id_categoria=@id_categoria");
                    sql_exist1.AddParams("@id_complemento", id_reg, DbType.Int32);
                    sql_exist1.AddParams("@id_categoria", item.Value.ToString(), DbType.Int32);
                    if (sql_exist1.ExecuteScalarInt() > 0)
                    {
                        item.CheckState = CheckState.Checked;
                    }

                }

            }
            else if (valid.GetOperation() == ModifiedOperation.New)
            {

            }
            else
            {
                InfoUser.MessageBoxShow("{{error_open_form_reg}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (checkEdit4.Checked)
            {
                this.Size = new Size(959, 516);
                xtraTabControl1.Visible = true;
            }
            else
            {
                this.Size = new Size(959, 199);
                xtraTabControl1.Visible = false;
            }
            select_insumos();
            valid.Reset();
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_cadastro_complemento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (p_c_insumos.Visible == true)
                {
                    p_c_insumos.Visible = false;
                    return;
                }
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (p_c_insumos.Visible == true)
                {
                    simpleButton4.PerformClick();
                }
            }
        }

        private void btn_menu_trash_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja realmente excluir o registro atual?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (valid.GetOperation() == ModifiedOperation.New && id_reg == "")
                {
                    valid.confirmClose();
                }
                else if (valid.GetOperation() == ModifiedOperation.New && id_reg != "")
                {
                    valid.confirmClose();
                    ExeSql sql_del = new ExeSql("UPDATE complementos SET date_delete=@date_delete WHERE id=@id");
                    sql_del.AddParams("@id", id_reg, DbType.Int32);
                    sql_del.AddParams("@date_delete", DateHelper.GetDateNow(DateType.Type1));
                    if (!sql_del.ExecuteSql())
                    {
                        InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (valid.GetOperation() == ModifiedOperation.Edit)
                {
                    valid.confirmClose();
                    ExeSql sql_del = new ExeSql("UPDATE complementos SET date_delete=@date_delete WHERE id=@id");
                    sql_del.AddParams("@id", id_reg, DbType.Int32);
                    sql_del.AddParams("@date_delete", DateHelper.GetDateNow(DateType.Type1));
                    if (!sql_del.ExecuteSql())
                    {
                        InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.Close();
            }
            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void frm_cadastro_complemento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (valid.IsEditing())
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult dialogResult = InfoUser.MessageBoxShow("As alterações não foram salvas!\r\n\r\nDeseja realmente sair da tela?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (valid.GetOperation() == ModifiedOperation.New && id_reg != "")
                        {
                            ExeSql sql_del = new ExeSql("DELETE FROM complementos WHERE id = @id");
                            sql_del.AddParams("@id", id_reg, DbType.Int32);
                            if (!sql_del.ExecuteSql())
                            {
                                InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        e.Cancel = false;
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (textEdit3.Text == "")
            {
                textEdit3.Text = "0,00";
            }
            if (textEdit4.Text == "")
            {
                textEdit4.Text = "0,00";
            }
            if (textEdit1.Text == "")
            {
                InfoUser.MessageBoxShow("Nome não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textEdit1.Text != nome && textEdit1.Text != "")
            {
                ExeSql sql_exist1 = new ExeSql("SELECT COUNT(*) FROM complementos WHERE nome=@nome AND (date_delete IS NULL or date_delete = '')");
                sql_exist1.AddParams("@nome", textEdit1.Text);
                if (sql_exist1.ExecuteScalarInt() > 0)
                {
                    InfoUser.MessageBoxShow("Já existe um registro com o Nome informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            int count_items = 0;
            foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.GetItems())
            {
                if (item.CheckState == CheckState.Checked)
                {
                    count_items += 1;
                }
            }
            if (count_items <= 0)
            {
                InfoUser.MessageBoxShow("Nenhuma categoria foi selecionada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (valid.GetOperation() == ModifiedOperation.New)
            {
                String query_insert = "INSERT INTO complementos (date_insert) VALUES";
                query_insert += "(@date_insert) RETURNING id";

                var date_insert = DateHelper.GetDateNow(DateType.Type1);

                ExeSql cmd_cad = new ExeSql(query_insert);
                cmd_cad.AddParams("@date_insert", date_insert);
                id_reg = cmd_cad.ExecuteScalarString();
                textEdit2.Text = id_reg;
            }
            String query_complemento_update = "UPDATE complementos SET nome=@nome, tipo=@tipo, preco_custo=moneyinsert(@preco_custo), preco_venda=moneyinsert(@preco_venda), controla_estoque=@controla_estoque, date_update=@date_update";
            query_complemento_update += " WHERE id = @id";
            ExeSql cmd_update = new ExeSql(query_complemento_update);

            cmd_update.AddParams("@id", id_reg, DbType.Int32);
            cmd_update.AddParams("@nome", textEdit1.Text);
            if (checkEdit1.Checked == true)
            {
                cmd_update.AddParams("@tipo", "UN");
            }
            else if (checkEdit2.Checked == true)
            {
                cmd_update.AddParams("@tipo", "KG");
            }
            else if (checkEdit3.Checked == true)
            {
                cmd_update.AddParams("@tipo", "LT");
            }
            cmd_update.AddParams("@preco_custo", textEdit3.Text);
            cmd_update.AddParams("@preco_venda", textEdit4.Text);
            cmd_update.AddParams("@controla_estoque", Convert.ToInt32(checkEdit4.Checked).ToString());

            if (valid.GetOperation() == ModifiedOperation.Edit)
            {
                cmd_update.AddParams("@date_update", DateHelper.GetDateNow(DateType.Type1));
            }
            else
            {
                cmd_update.AddParams("@date_update", "");
            }

            if (cmd_update.ExecuteSql())
            {
                var query_del = "DELETE FROM produtos_insumos WHERE id_insumo IN (" + String.Join(",", ids_delete) + ") and id_produto=@id_produto";
                ExeSql cmd_dels = new ExeSql(query_del);
                cmd_dels.AddParams("@id_produto", id_reg, DbType.Int32);
                cmd_dels.ExecuteSql();

                for (int i = 0; i < gridView2.RowCount; ++i)
                {
                    DataRow row = gridView2.GetDataRow(i);

                    ExeSql sql_exist1 = new ExeSql("SELECT count(*) FROM produtos_insumos WHERE id_produto=@id_produto and id_insumo=@id_insumo");
                    sql_exist1.AddParams("@id_produto", id_reg, DbType.Int32);
                    sql_exist1.AddParams("@id_insumo", row["id_insumo"].ToString(), DbType.Int32);

                    if (sql_exist1.ExecuteScalarInt() > 0)
                    {
                        String query = "UPDATE produtos_insumos SET qt=moneyinsert(@qt) WHERE id_produto=@id_produto and id_insumo=@id_insumo";
                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id_produto", id_reg, DbType.Int32);
                        cmd.AddParams("@id_insumo", row["id_insumo"].ToString(), DbType.Int32);
                        cmd.AddParams("@qt", row["qt"].ToString());
                        cmd.AddParams("@date_insert", DateHelper.GetDateNow(DateType.Type1));
                        cmd.ExecuteSql();
                    }
                    else
                    {
                        String query = "INSERT INTO produtos_insumos (id_produto, id_insumo, qt, date_insert) VALUES";
                        query += "(@id_produto, @id_insumo, moneyinsert(@qt), @date_insert)";

                        ExeSql cmd = new ExeSql(query);
                        cmd.AddParams("@id_produto", id_reg, DbType.Int32);
                        cmd.AddParams("@id_insumo", row["id_insumo"].ToString(), DbType.Int32);
                        cmd.AddParams("@qt", row["qt"].ToString());
                        cmd.AddParams("@date_insert", DateHelper.GetDateNow(DateType.Type1));
                        cmd.ExecuteSql();
                    }
                }
            }
            else
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String query_delete = "DELETE FROM complementos_categorias WHERE id_complemento=@id_complemento";
            ExeSql cmd_delete = new ExeSql(query_delete);

            cmd_delete.AddParams("@id_complemento", id_reg, DbType.Int32);
            if (!cmd_delete.ExecuteSql())
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool error_acesso = false;
            foreach (CheckedListBoxItem item in checkedComboBoxEdit1.Properties.GetItems())
            {
                if (item.CheckState == CheckState.Checked)
                {
                    String query_categorias_insert = "INSERT INTO complementos_categorias (id_complemento, id_categoria) VALUES";
                    query_categorias_insert += "(@id_complemento, @id_categoria)";

                    ExeSql cmd_categorias_insert = new ExeSql(query_categorias_insert);
                    cmd_categorias_insert.AddParams("@id_complemento", id_reg, DbType.Int32);
                    cmd_categorias_insert.AddParams("@id_categoria", item.Value.ToString(), DbType.Int32);
                    if (!cmd_categorias_insert.ExecuteSql())
                    {
                        error_acesso = true;
                    }
                }

            }
            if (error_acesso == true)
            {
                InfoUser.MessageBoxShow("Ocorreu um erro ao definir as categorias. {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            valid.confirmClose();

            this.Close();
        }

        private void textEdit10_Enter(object sender, EventArgs e)
        {
            if (p_c_insumos.Visible == false)
            {
                p_c_insumos.Visible = true;
                select_c_insumos();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            p_c_insumos.Visible = false;
        }

        private void textEdit10_EditValueChanged(object sender, EventArgs e)
        {
            if (p_c_insumos.Visible == false)
            {
                p_c_insumos.Visible = true;
            }
        }

        private void labelControl23_Click(object sender, EventArgs e)
        {
            frm_cadastro_insumo frm = new frm_cadastro_insumo();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            select_c_insumos();
        }

        private void select_c_insumos()
        {
            ExeSql sql_insumos = new ExeSql("select id, nome, moneyf(preco_custo, 2) as preco_custo, tipo from insumos as insumos where ((nome<>'') and (nome ilike '%" + textEdit10.Text + "%')) AND (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            gridControl3.DataSource = sql_insumos.DataTable();
        }

        private void select_insumos()
        {
            ExeSql sql_insumos = new ExeSql("select id, id_insumo, (select nome from insumos where id=prod_insumos.id_insumo) as nome, '0'::numeric as percent, (select tipo from insumos where id=prod_insumos.id_insumo) as tipo, moneyf(qt, 3) as qt, moneyf((qt * (select preco_custo from insumos where id=prod_insumos.id_insumo)), 3) as custo from (select sum(qt * (select preco_custo from insumos where id=produtos_insumos.id_insumo)) as aaaa from produtos_insumos where id_produto=@id_produto) as tbl_total, produtos_insumos as prod_insumos where id_produto=@id_produto ORDER BY id ASC");
            sql_insumos.AddParams("@id_produto", id_reg, DbType.Int32);

            gridControl2.DataSource = sql_insumos.DataTable();
        }

        private void p_c_button_add_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            string id = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
            frm_add_insumo frm = new frm_add_insumo();
            frm.id_produto = id_reg;
            frm.id_insumo = id;
            frm.grid = gridView2;
            frm.valid = valid;
            frm.ShowDialog();
            frm.Dispose();
        }

        List<string> ids_delete = new List<string>();
        private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            string id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id_insumo").ToString();

            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja realmente excluir o insumo selecionado?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
                valid.Modified();
                ids_delete.Add(id);
            }
            gridView2.CloseEditor();
            gridView2.UpdateTotalSummary();
        }

        private void gridView2_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "percent")
            {
                string valor1 = "0,00";
                if (gridView2.GetRowCellValue(e.RowHandle, "custo") != null && gridView2.GetRowCellValue(e.RowHandle, "custo").ToString() != "")
                {
                    valor1 = gridView2.GetRowCellValue(e.RowHandle, "custo").ToString();
                    if (valor1 != null && valor1 != "" && valor1 != "0")
                    {
                        string valor2 = "0,00";
                        if (gridView2.Columns["custo"].SummaryItem.SummaryValue != null && gridView2.Columns["custo"].SummaryItem.SummaryValue.ToString() != "")
                        {
                            valor2 = gridView2.Columns["custo"].SummaryItem.SummaryValue.ToString();
                        }
                        else
                        {
                            return;
                        }
                        gridView2.SetRowCellValue(e.RowHandle, "percent", DecimalHelper.Dividir(DecimalHelper.Multiplicar("100", valor1, true, 0), valor2, true, 0));
                    }
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string id = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, "id").ToString();
            frm_add_insumo frm = new frm_add_insumo();
            frm.id_produto = id_reg;
            frm.id_insumo = id;
            frm.grid = gridView2;
            frm.valid = valid;
            frm.ShowDialog();
            frm.Dispose();
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit4.Checked)
            {
                this.Size = new Size(959, 516);
                xtraTabControl1.Visible = true;
            }
            else
            {
                this.Size = new Size(959, 199);
                xtraTabControl1.Visible = false;
            }
        }

        private void gridView2_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;
            Font font = e.Appearance.Font;
            font = new Font("Tahoma", 20, FontStyle.Regular);

            e.Graphics.DrawString("Sem Ficha Técnica", font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y - 30, e.Bounds.Width, e.Bounds.Height), drawFormat);
        }
    }
}

using ChefPlus.data;
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
using Npgsql;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using System.Threading;
using DevExpress.XtraGrid;

namespace Chef_Plus
{
    public partial class frm_lanca_produtos : XtraForm
    {

        private HelperProdutos.Produto produto;

        static class IdGenerator
        {
            private static long _lastId = 0;

            public static string GetNextId()
            {
                _lastId += 1;
                return _lastId.ToString();
            }

            public static void Reset()
            {
                _lastId = 0;
            }

        }

        class Itens
        {
            public string internalID = IdGenerator.GetNextId();
            public string id;
            public string nome;
        }

        List<Itens> list_sabores;

        List<ObsProdutos> list_observacoes;

        List<CompleProdutos> list_complementos;

        public frm_lanca_produtos()
        {
            InitializeComponent();

            produto = null;


            IdGenerator.Reset();
            list_sabores = new List<Itens>();
            list_observacoes = new List<ObsProdutos>();
            list_complementos = new List<CompleProdutos>();

            ExeSql adapter_categorias = new ExeSql("SELECT id, nome FROM categorias");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";

            DataTable data_adapter_categorias = adapter_categorias.DataSet().Tables[0];

            DataRow row = data_adapter_categorias.NewRow();
            row["id"] = 0;
            row["nome"] = "Todas as Categorias";
            data_adapter_categorias.Rows.Add(row);

            lookUpEdit1.Properties.DataSource = data_adapter_categorias;

            lookUpEdit1.EditValue = 0;


            ExeSql adapter_atendentes = new ExeSql("SELECT id, nome FROM usuarios where status='1'");
            lookUpEdit2.Properties.DisplayMember = "nome";
            lookUpEdit2.Properties.ValueMember = "id";
            lookUpEdit2.Properties.DataSource = adapter_atendentes.DataSet().Tables[0];

            lookUpEdit2.EditValue = UserLogin.IdUserGet();

            ConsultarProdutos();

        }

        void ConsultarProdutos()
        {

            ExeSql sql_produtos;
            if (lookUpEdit1.EditValue.ToString() == "0")
            {
                sql_produtos = new ExeSql(ChefPlus.data.HelperSqlUtil.ConsultaProdutosVenda);
            }
            else
            {
                sql_produtos = new ExeSql(ChefPlus.data.HelperSqlUtil.ConsultaProdutosVendaCategoria);
                sql_produtos.AddParams("@id_categoria", lookUpEdit1.EditValue.ToString(), DbType.Int32);
            }
            sql_produtos.AddParams("@consulta", textEdit1.Text);
            gridControl1.DataSource = sql_produtos.DataTable();

        }

        DataTable dt = null;
        void Configurar()
        {
            string precoVenda = string.Empty;
            switch (produto.Produtotipo)
            {
                case HelperProdutos.ProdutoTipo.Produtos:
                    precoVenda = produto.Precos[produto.Precos.FindIndex(x => x.id == "1")].PrecoVenda;
                    break;
                case HelperProdutos.ProdutoTipo.ProdutosTamanho:

                    

                    if (radioGroup1.SelectedIndex <= -1)
                    {
                        precoVenda = "0,00";
                        labelControl7.Visible = false;
                    }
                    else
                    {
                        labelControl7.Visible = true;

                        if (list_sabores.Count > 1)
                        {
                            int rowHandle = 0;
                            string id = string.Empty;
                            if (gridView2.SelectedRowsCount > 0)
                            {
                                id = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString();
                            }

                            dt.Clear();
                            dt.Columns.Clear();

                            dt.Columns.Add("id");
                            dt.Columns.Add("internal_id");
                            dt.Columns.Add("produto");
                            dt.Columns.Add("adicionados");
                            dt.Columns.Add("detalhes");
                            dt.Columns.Add("principal");

                            DataRow insert1 = dt.NewRow();
                            insert1["id"] = "P_" + produto.id;
                            insert1["internal_id"] = "0";
                            insert1["produto"] = "<b>" + produto.tipo_perso + " personalizado(a) " + produto.nome + "</b>";
                            foreach (ObsProdutos obj2 in list_observacoes)
                            {
                                if (obj2.idInternal == insert1["internal_id"].ToString())
                                    insert1["adicionados"] += obj2.nome + ";";
                            }

                            foreach (CompleProdutos obj3 in list_complementos)
                            {
                                if (obj3.idInternal == insert1["internal_id"].ToString())
                                    insert1["adicionados"] += obj3.nome + "(" + obj3.quantidade + "x);";
                            }
                            insert1["detalhes"] = "<b>" + produto.tipo_perso + " " + produto.nome + "</b>";
                            insert1["principal"] = "1";

                            dt.Rows.Add(insert1);

                            foreach (Itens obj in list_sabores)
                            {
                                DataRow insert2 = dt.NewRow();
                                insert2["id"] = obj.id;
                                insert2["internal_id"] = obj.internalID;
                                insert2["produto"] = obj.nome;
                                foreach (ObsProdutos obj2 in list_observacoes)
                                {
                                    if (obj2.idInternal == insert2["internal_id"].ToString())
                                        insert2["adicionados"] += obj2.nome + ";";
                                }

                                foreach (CompleProdutos obj3 in list_complementos)
                                {
                                    if (obj3.idInternal == insert2["internal_id"].ToString())
                                        insert2["adicionados"] += obj3.nome + "(" + obj3.quantidade + "x);";
                                }
                                insert2["detalhes"] = "";
                                insert2["principal"] = "0";
                                dt.Rows.Add(insert2);
                            }

                            gridControl2.DataSource = dt;
                            ColumnView view = gridControl2.MainView as ColumnView;
                            GridColumn colCountry = view.Columns.ColumnByFieldName("internal_id");
                            rowHandle = gridView2.LocateByDisplayText(0, colCountry, id);

                            if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                                gridView2.FocusedRowHandle = rowHandle;

                        }
                        else
                        {
                            gridControl2.DataSource = null;
                        }

                        precoVenda = produto.Precos[produto.Precos.FindIndex(x => x.id == radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value.ToString())].PrecoVenda;

                        
                    }
                    break;
            }

            labelControl4.Text = DecimalHelper.Multiplicar(precoVenda, spinEdit1.Text, true, 2);
            foreach (CompleProdutos obj in list_complementos)
            {
                if (obj.idInternal == "0")
                {
                    labelControl4.Text = DecimalHelper.Somar(labelControl4.Text, DecimalHelper.Multiplicar(list_sabores.Count.ToString(), DecimalHelper.Multiplicar(obj.quantidade, obj.precoVenda, true, 2), true, 2), true, 2);
                }
                else
                {
                    labelControl4.Text = DecimalHelper.Somar(labelControl4.Text, DecimalHelper.Multiplicar(obj.quantidade, obj.precoVenda, true, 2), true, 2);
                }
            }
            gridView2_FocusedRowChanged(gridView2, null);
        }


        List<UserControl_Complementos> lista;
        void loadComplementos()
        {

            if (produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
            {
                ExeSql sql_load_complementos = new ExeSql("SELECT p.id, p.nome, moneyf(p.preco_venda,2) as preco_venda FROM complementos p JOIN complementos_categorias c ON c.id_complemento = p.id WHERE c.id_categoria = @id_categoria ORDER BY nome ASC");
                sql_load_complementos.AddParams("@id_categoria", produto.idCategoria, DbType.Int32);

                layoutControl2.Controls.Clear();
                if (radioGroup1.SelectedIndex <= -1)
                {
                    return;
                }
                lista = new List<UserControl_Complementos>();
                NpgsqlDataReader myReader_complementos = sql_load_complementos.DataReader();
                while (myReader_complementos.Read())
                {
                    bool Checked = false;
                    string quantidade = "1";
                    if (list_complementos.Exists(aa => aa.idInternal == ((list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString()) && aa.idProduto == myReader_complementos["id"].ToString()))
                    {
                        Checked = true;
                        quantidade = list_complementos[list_complementos.FindIndex(aa => aa.idInternal == ((list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString()) && aa.idProduto == myReader_complementos["id"].ToString())].quantidade;
                    }
                    UserControl_Complementos cmd = new UserControl_Complementos(Configurar, list_complementos, myReader_complementos["id"].ToString(), myReader_complementos["nome"].ToString(), (list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString(), Checked, myReader_complementos["preco_venda"].ToString(), quantidade);
                    lista.Add(cmd);
                    layoutControl2.Controls.Add(cmd);


                }
                sql_load_complementos.CloseConnection();
            }
            else if (produto.Produtotipo == HelperProdutos.ProdutoTipo.Produtos)
            {
                ExeSql sql_load_complementos = new ExeSql("SELECT p.id, p.nome, moneyf(p.preco_venda,2) as preco_venda FROM complementos p JOIN complementos_categorias c ON c.id_complemento = p.id WHERE c.id_categoria = @id_categoria ORDER BY nome ASC");
                sql_load_complementos.AddParams("@id_categoria", produto.idCategoria, DbType.Int32);

                layoutControl2.Controls.Clear();
                if (radioGroup1.SelectedIndex <= -1)
                {
                    return;
                }
                lista = new List<UserControl_Complementos>();
                NpgsqlDataReader myReader_complementos = sql_load_complementos.DataReader();
                while (myReader_complementos.Read())
                {
                    bool Checked = false;
                    string quantidade = "1";
                    if (list_complementos.Exists(aa => aa.idInternal == ((list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString()) && aa.idProduto == myReader_complementos["id"].ToString()))
                    {
                        Checked = true;
                        quantidade = list_complementos[list_complementos.FindIndex(aa => aa.idInternal == ((list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString()) && aa.idProduto == myReader_complementos["id"].ToString())].quantidade;
                    }
                    UserControl_Complementos cmd = new UserControl_Complementos(Configurar, list_complementos, myReader_complementos["id"].ToString(), myReader_complementos["nome"].ToString(), (list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString(), Checked, myReader_complementos["preco_venda"].ToString(), quantidade);
                    lista.Add(cmd);
                    layoutControl2.Controls.Add(cmd);


                }
                sql_load_complementos.CloseConnection();
            }

        }

        private void frm_lanca_produtos_Load(object sender, EventArgs e)
        {

        }

        private void frm_lanca_produtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (tabPane1.SelectedPage == tabNavigationPage2)
                {
                    tabPane1.SelectedPage = tabNavigationPage1;
                    return;
                }
                this.Close();
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ConsultarProdutos();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ConsultarProdutos();
        }

        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {

            if (e.Page == tabNavigationPage2)
            {

                if (produto != null)
                {

                    if (produto.Produtotipo == HelperProdutos.ProdutoTipo.Produtos)
                    {

                    }
                    else if (produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
                    {

                    }
                }
                Configurar();
            }

        }




        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage2;
        }

        private void tabPane1_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                produto = null;
            }
            if (gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                produto = null;
            }

            if (gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                produto = HelperProdutos.ConsultarProduto(id);
            }

            if (produto == null)
            {
                tabPane1.SelectedPage = tabNavigationPage1;
                InfoUser.MessageBoxShow("Nenhum produto selecionado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
            {
                spinEdit1.EditValue = 1;
            }
            Configurar();
        }

        private void spinEdit1_EditValueChanging(object sender, ChangingEventArgs e)
        {

        }

        private void spinEdit1_TextChanged(object sender, EventArgs e)
        {
            if (produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
            {
                spinEdit1.EditValue = 1;
            }
            Configurar();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {


        }

        private void labelControl3_Click_1(object sender, EventArgs e)
        {

        }

        private void labelControl23_Click(object sender, EventArgs e)
        {
            frm_cadastro_observacao frm = new frm_cadastro_observacao();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            ExeSql adapter_observacoes = new ExeSql("SELECT p.id, p.nome FROM observacoes p JOIN observacoes_categorias c ON c.id_observacao = p.id WHERE c.id_categoria = @id_categoria ORDER BY nome ASC");
            adapter_observacoes.AddParams("@id_categoria", produto.idCategoria, DbType.Int64);
            checkedListBoxControl1.DisplayMember = "nome";
            checkedListBoxControl1.ValueMember = "id";
            checkedListBoxControl1.DataSource = adapter_observacoes.DataSet().Tables[0];
            Configurar();
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {
            frm_cadastro_complemento frm = new frm_cadastro_complemento();
            frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
            frm.ShowDialog();
            frm.Dispose();
            //(!)atualizar complementos
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int total_parts = list_sabores.Count;
            ColumnView view = sender as ColumnView;
            if (e.Column.Name == "itens_produto" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                string principal = gridView2.GetRowCellValue(e.ListSourceRowIndex, "principal").ToString();
                switch (principal)
                {
                    case "0": e.DisplayText = "   " + e.Value.ToString(); break;
                    case "1": e.DisplayText = "<b>" + e.Value.ToString() + "</b>"; break;
                }
            }

            if (e.Column.Name == "itens_detalhes" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                string principal = gridView2.GetRowCellValue(e.ListSourceRowIndex, "principal").ToString();
                switch (principal)
                {
                    case "0": e.DisplayText = ((Convert.ToInt64(e.ListSourceRowIndex)) + "/" + total_parts).ToString(); break;
                }
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gridView2_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        class ObsProdutos : HelperProdutos.ObservacoesProduto
        {
            public string idInternal;
        }

        public class CompleProdutos : HelperProdutos.ComplementosProduto
        {
            public string idInternal;
            public bool Checked;
        }

        bool carregando = false;
        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (carregando == false)
            {
                if (radioGroup1.SelectedIndex <= -1 && produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
                {
                    checkedListBoxControl1.SetItemCheckState(e.Index, CheckState.Unchecked);
                    return;
                }
                if (produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
                {
                    for (int i = 0; i < list_observacoes.Count; i++)
                    {
                        if (list_observacoes[i].id == checkedListBoxControl1.GetItemValue(e.Index).ToString() && list_observacoes[i].idInternal == ((list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString()))
                        {
                            list_observacoes.RemoveAt(i);
                        }
                    }
                    if (checkedListBoxControl1.GetItemCheckState(e.Index) == CheckState.Checked)
                    {
                        list_observacoes.Add(
                           new ObsProdutos()
                           {
                               idInternal = (list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString(),
                               idProduto = (list_sabores.Count <= 1) ? list_sabores[0].id : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "id").ToString(),
                               id = checkedListBoxControl1.GetItemValue(e.Index).ToString(),
                               nome = checkedListBoxControl1.GetItemText(e.Index).ToString(),
                           }
                       );
                    }
                }
                else if (produto.Produtotipo == HelperProdutos.ProdutoTipo.Produtos)
                {
                    for (int i = 0; i < list_observacoes.Count; i++)
                    {
                        if (list_observacoes[i].id == checkedListBoxControl1.GetItemValue(e.Index).ToString() && list_observacoes[i].idInternal == produto.id)
                        {
                            list_observacoes.RemoveAt(i);
                        }
                    }
                    if (checkedListBoxControl1.GetItemCheckState(e.Index) == CheckState.Checked)
                    {
                        list_observacoes.Add(
                           new ObsProdutos()
                           {
                               idInternal = produto.id,
                               idProduto = produto.id,
                               id = checkedListBoxControl1.GetItemValue(e.Index).ToString(),
                               nome = checkedListBoxControl1.GetItemText(e.Index).ToString(),
                           }
                       );
                    }
                }

                Configurar();
            }

        }

        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            carregando = true;

            if (gridView2.FocusedRowHandle < 0)
            {
                carregando = false;
                return;
            }
            for (int a = 0; a < checkedListBoxControl1.ItemCount; a++)
            {
                if (list_observacoes.Exists(aa => aa.idInternal == gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString() && aa.id == checkedListBoxControl1.GetItemValue(a).ToString()))
                {
                    checkedListBoxControl1.SetItemCheckState(a, CheckState.Checked);
                }
                else
                {
                    checkedListBoxControl1.SetItemCheckState(a, CheckState.Unchecked);
                }

            }
            Console.WriteLine("foi");
            foreach (UserControl_Complementos obj in lista)
            {
                obj.internal_id = getRow();
                obj.teste();
            }
            carregando = false;

        }

        public string getRow()
        {
            return (list_sabores.Count <= 1) ? list_sabores[0].internalID : gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "internal_id").ToString();
        }

        private void gridControl2_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBoxControl1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl7.ForeColor = labelControl7.ForeColor == Color.DodgerBlue ? Color.Red : Color.DodgerBlue;

        }

        private void gridView2_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

            if (radioGroup1.SelectedIndex <= -1)
            {
                e.Graphics.DrawString("Selecione um Tamanho", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
            }
            else if (list_sabores.Count <= 1)
            {
                e.Graphics.DrawString("Adicione mais sabores para personalizar", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
            }

        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "nome" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                e.DisplayText = "<backcolor=232, 234, 235><color=0,0,0> " + gridView1.GetRowCellValue(e.ListSourceRowIndex, "categoria_nome").ToString() + " </color></backcolor> " + e.Value.ToString();
            }
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {
            list_sabores.Add(
                    new Itens()
                    {
                        id = "5",
                        nome = "6teefe"
                    }
                );
            Configurar();
        }
    }
}

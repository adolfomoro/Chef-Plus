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
using Npgsql;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;

namespace Chef_Plus
{
    public partial class frm_caixa : XtraForm
    {

        private string id_caixa;
        private bool aberto = false;

        private string obs;

        private string total_dinheiro;
        private string total_tudo;

        public frm_caixa(string _id_caixa)
        {
            InitializeComponent();

            id_caixa = string.Empty;
            aberto = false;

            obs = string.Empty;

            total_dinheiro = string.Empty;
            total_tudo = string.Empty;

            id_caixa = _id_caixa;

            if (_id_caixa == null)
            {
                ExeSql sql_caixa = new ExeSql("SELECT COUNT(*) FROM caixa WHERE id_usuario = @id_usuario and (date_fechamento IS NULL or date_fechamento = '')");
                sql_caixa.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);
                int rows_caixa = sql_caixa.ExecuteScalarInt();
                if (rows_caixa > 0)
                {

                    ExeSql sql_load = new ExeSql("SELECT *, moneyf(saldo_inicial,2) as saldo_inicial_  FROM caixa WHERE id_usuario = @id_usuario and (date_fechamento IS NULL or date_fechamento = '')");
                    sql_load.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);

                    NpgsqlDataReader myReader = sql_load.DataReader();
                    if (myReader.Read())
                    {
                        id_caixa = myReader["id"].ToString();
                        textEdit1.Text = myReader["saldo_inicial_"].ToString();
                        memoEdit1.Text = myReader["obs"].ToString();
                        obs = myReader["obs"].ToString();
                        labelControl5.Text = DateHelper.FormatDate(myReader["date_abertura"].ToString(), DateType.Type1, DateType.Type2);
                    }

                    panelControl2.BackColor = Color.Green;
                    labelControl1.Text = "Caixa Aberto";
                    btn_abrir.Visible = false;
                    textEdit1.Enabled = false;
                    labelControl4.Visible = true;
                    labelControl5.Visible = true;
                    btn_add.Enabled = true;

                    btn_fechar.Visible = true;
                    aberto = true;

                    load_movimentos(true);
                }
                else
                {
                    panelControl2.BackColor = Color.Red;
                    labelControl1.Text = "Caixa Fechado";
                    btn_abrir.Visible = true;
                    aberto = false;
                    load_movimentos(false);
                }
            }
            else
            {
                ExeSql sql_load = new ExeSql("SELECT *, moneyf(saldo_inicial,2) as saldo_inicial_  FROM caixa WHERE id = @id");
                sql_load.AddParams("@id", id_caixa, DbType.Int32);

                NpgsqlDataReader myReader = sql_load.DataReader();
                if (myReader.Read())
                {
                    id_caixa = myReader["id"].ToString();
                    textEdit1.Text = myReader["saldo_inicial_"].ToString();
                    memoEdit1.Text = myReader["obs"].ToString();
                    obs = myReader["obs"].ToString();
                    labelControl5.Text = DateHelper.FormatDate(myReader["date_abertura"].ToString(), DateType.Type1, DateType.Type2);
                    if (myReader["date_fechamento"].ToString() == null || myReader["date_fechamento"].ToString() == "")
                    {
                        panelControl2.BackColor = Color.Green;
                        labelControl1.Text = "Caixa Aberto";
                        aberto = true;
                    }
                    else
                    {
                        labelControl7.Text = DateHelper.FormatDate(myReader["date_fechamento"].ToString(), DateType.Type1, DateType.Type2);
                        panelControl2.BackColor = Color.Red;
                        labelControl1.Text = "Caixa Fechado";
                        labelControl6.Visible = true;
                        labelControl7.Visible = true;
                        aberto = false;
                    }

                }

                btn_abrir.Visible = false;
                textEdit1.Enabled = false;
                memoEdit1.Enabled = false;
                labelControl4.Visible = true;
                labelControl5.Visible = true;
                btn_trash.Visible = false;
                btn_add.Visible = false;
                load_movimentos(true);
            }

            HelperDev.MaskMoney(textEdit1, 2);
            

        }

        private void cadastro_categoria_Load(object sender, EventArgs e)
        {
            
        }

        public class Resumo
        {
            public string descricao { get; set; }
            public string valor { get; set; }
            public string valor_tipo { get; set; }

            public Resumo(string _descricao, string _valor, string _valor_tipo)
            {
                descricao = _descricao;
                valor = _valor;
                valor_tipo = _valor_tipo;
            }
        }

        void load_movimentos(bool relatorio)
        {

            ExeSql sql_load = new ExeSql("SELECT id, tipo_reg, tipo_mov, descricao, observacao ,data_hora, moneyf(vlr_entrada,2) as vlr_entrada , moneyf(vlr_saida,2) as vlr_saida, (SELECT INITCAP(nome) as nome from formas_pagamento where id=resultados.id_pagamento ) as forma_pagamento, id_pagamento FROM " +
            "((select 0 as id, 'SALDO' as tipo_reg, 'C' as tipo_mov, 'SALDO INICIAL' as descricao, '' as observacao, saldo_inicial as vlr_entrada, null as vlr_saida, 1 as id_pagamento, date_abertura as data_hora from caixa where id=@id_caixa ) union all " +
            "select id, 'CAIXA' as tipo_reg, tipo_valor as tipo_mov, (CASE WHEN tipo = 'A' THEN 'Entrada - Acréscimo' ELSE CASE WHEN tipo = 'S' THEN 'Saída - Sangria' ELSE CASE WHEN tipo = 'D' THEN 'Saída - Despesa' END END END) as descricao, obs as observacao, (CASE WHEN tipo_valor = 'C' THEN valor END) as vlr_entrada, (CASE WHEN tipo_valor = 'D' THEN valor END) as vlr_saida, id_pagamento, date_insert as data_hora from caixa_movimento where id_caixa=@id_caixa AND (date_delete IS NULL or date_delete = '') union all " +
            "select id, 'PEDIDO' as tipo_reg, 'C' as tipo_mov, ('Pedido Nº '||id_pedido||'//(!)Colocar tipo pedido aqui') as descricao, obs as observacao, valor as vlr_entrada, null as vlr_saida, id_pagamento, date_insert as data_hora from pagamentos where id_caixa=@id_caixa AND id_pedido IS NOT NULL AND (date_delete IS NULL or date_delete = '')) as resultados ORDER BY id ASC");
            sql_load.AddParams("@id_caixa", id_caixa, DbType.Int32);
            gridControl1.DataSource = sql_load.DataTable();

            gridView1.Columns["observacao"].Visible = false;
            gridView1.PreviewFieldName = "observacao";
            gridView1.OptionsView.ShowPreview = true;
            gridView1.OptionsView.AutoCalcPreviewLineCount = true;

            // Handle this event to paint Preview row manually
            gridView1.CustomDrawRowPreview += (s, e) => {
                e.Appearance.ForeColor = Color.Gray;
            };

            gridView2.FocusRectStyle = DrawFocusRectStyle.None;

            if (relatorio == true)
            {
                ArrayList datasource = new ArrayList();

                ExeSql sql_caixa = new ExeSql("SELECT moneyf(saldo_inicial, 2) as saldo_inicial FROM caixa WHERE id = @id_caixa");
                sql_caixa.AddParams("@id_caixa", id_caixa, DbType.Int32);
                string saldo_inicial = sql_caixa.ExecuteScalarString();

                datasource.Add(new Resumo("<b>(+)  SALDO INICIAL</b>", saldo_inicial, "C"));
                datasource.Add(new Resumo("<b>(+)  ENTRADAS DO CAIXA</b>", "", ""));
                ExeSql sql_entrada_caixa_acrescimo = new ExeSql("SELECT moneyf(Coalesce(valor, 0::numeric),2) as valor FROM (select SUM(valor) as valor from caixa_movimento where id_caixa=@id_caixa AND tipo_valor = 'C' AND (date_delete IS NULL or date_delete = '')) as resultados");
                sql_entrada_caixa_acrescimo.AddParams("@id_caixa", id_caixa, DbType.Int32);
                string valor_entrada_caixa_acrescimo = sql_entrada_caixa_acrescimo.ExecuteScalarString();

                ExeSql sql_valores_pedidos = new ExeSql("select moneyf(sum(valor),2) as valor, INITCAP((SELECT nome from formas_pagamento where id=pagamentos.id_pagamento) ||' | '||(SELECT descricao from bandeiras where id=pagamentos.id_bandeira)) as forma_pagamento from pagamentos where id_caixa=@id_caixa AND id_pagamento<>'1' AND id_pagamento<>'2' AND (date_delete IS NULL or date_delete = '') group by (id_pagamento, id_bandeira)");
                sql_valores_pedidos.AddParams("@id_caixa", id_caixa, DbType.Int32);
                NpgsqlDataReader reader_valores_pedidos = sql_valores_pedidos.DataReader();
                string valor_entradas = "0,00";
                if (Convert.ToDouble(DecimalHelper.FormatarMoeda(valor_entrada_caixa_acrescimo, 2)) <= 0 && !reader_valores_pedidos.HasRows)
                {
                    datasource.Add(new Resumo("   <color=DimGray>Não há registros de entrada</color>", "", ""));
                }
                else
                {
                    if (Convert.ToDouble(DecimalHelper.FormatarMoeda(valor_entrada_caixa_acrescimo, 2)) > 0)
                    {
                        datasource.Add(new Resumo("   <color=DimGray>ACRÉSCIMOS</color>", "", ""));
                        datasource.Add(new Resumo("       Dinheiro/Cheque", valor_entrada_caixa_acrescimo, "C"));
                        valor_entradas = DecimalHelper.Somar(valor_entradas, valor_entrada_caixa_acrescimo, true, 2);
                    }

                    if (reader_valores_pedidos.HasRows)
                    {
                        datasource.Add(new Resumo("   <color=DimGray>PEDIDOS</color>", "", ""));
                    }
                    while (reader_valores_pedidos.Read())
                    {
                        datasource.Add(new Resumo("       " + reader_valores_pedidos["forma_pagamento"].ToString(), reader_valores_pedidos["valor"].ToString(), "C"));
                        valor_entradas = DecimalHelper.Somar(valor_entradas, reader_valores_pedidos["valor"].ToString(), true, 2);
                    }
                    datasource.Add(new Resumo("   <color=DimGray>TOTAL - ENTRADAS</color>", "", ""));
                    datasource.Add(new Resumo("       Total", valor_entradas, "C"));
                }
                datasource.Add(new Resumo("", "", ""));
                datasource.Add(new Resumo("<b>(-)  SAÍDAS DO CAIXA</b>", "", ""));
                string valor_saidas = "0,00";

                ExeSql sql_saida_caixa_acrescimo = new ExeSql("SELECT moneyf(Coalesce(valor, 0::numeric),2) as valor FROM (select SUM(valor) as valor from caixa_movimento where id_caixa=@id_caixa AND tipo_valor = 'D' AND tipo='S' AND (date_delete IS NULL or date_delete = '')) as resultados");
                sql_saida_caixa_acrescimo.AddParams("@id_caixa", id_caixa, DbType.Int32);
                string valor_saida_caixa_sangria = sql_saida_caixa_acrescimo.ExecuteScalarString();

                ExeSql sql_saida_caixa_despesas = new ExeSql("SELECT moneyf(Coalesce(valor, 0::numeric),2) as valor FROM (select SUM(valor) as valor from caixa_movimento where id_caixa=@id_caixa AND tipo_valor = 'D' AND tipo='D' AND (date_delete IS NULL or date_delete = '')) as resultados");
                sql_saida_caixa_despesas.AddParams("@id_caixa", id_caixa, DbType.Int32);
                string valor_saida_caixa_despesas = sql_saida_caixa_despesas.ExecuteScalarString();
                if (Convert.ToDouble(DecimalHelper.FormatarMoeda(valor_saida_caixa_sangria, 2)) <= 0 && Convert.ToDouble(DecimalHelper.FormatarMoeda(valor_saida_caixa_despesas, 2)) <= 0)
                {
                    datasource.Add(new Resumo("   <color=DimGray>Não há registros de saída</color>", "", ""));
                }
                else
                {
                    if (Convert.ToDouble(DecimalHelper.FormatarMoeda(valor_saida_caixa_sangria, 2)) > 0)
                    {
                        datasource.Add(new Resumo("   <color=DimGray>SANGRIAS</color>", "", ""));
                        datasource.Add(new Resumo("       Dinheiro/Cheque", valor_saida_caixa_sangria, "D"));
                        valor_saidas = DecimalHelper.Somar(valor_saidas, valor_saida_caixa_sangria, true, 2);
                    }
                    if (Convert.ToDouble(DecimalHelper.FormatarMoeda(valor_saida_caixa_despesas, 2)) > 0)
                    {
                        datasource.Add(new Resumo("   <color=DimGray>DESPESAS</color>", "", ""));
                        datasource.Add(new Resumo("       Dinheiro/Cheque", valor_saida_caixa_despesas, "D"));
                        valor_saidas = DecimalHelper.Somar(valor_saidas, valor_saida_caixa_despesas, true, 2);
                    }
                    datasource.Add(new Resumo("   <color=DimGray>TOTAL - SAÍDAS</color>", "", ""));
                    datasource.Add(new Resumo("       Total", valor_saidas, "D"));
                }

                string valor_somente_dinheiro = "0,00";
                string valor_total = "0,00";

                datasource.Add(new Resumo("", "", ""));
                datasource.Add(new Resumo("<b>(=)  SALDO FINAL</b>", "", ""));

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "tipo_mov").ToString() == "C" && gridView1.GetRowCellValue(i, "id_pagamento").ToString() == "1")
                    {
                        valor_somente_dinheiro = DecimalHelper.Somar(valor_somente_dinheiro, gridView1.GetRowCellValue(i, "vlr_entrada").ToString(), true, 2);
                    }
                    if (gridView1.GetRowCellValue(i, "tipo_mov").ToString() == "D" && gridView1.GetRowCellValue(i, "id_pagamento").ToString() == "1")
                    {
                        valor_somente_dinheiro = DecimalHelper.Subtrair(valor_somente_dinheiro, gridView1.GetRowCellValue(i, "vlr_saida").ToString(), true, 2);
                    }
                    if (gridView1.GetRowCellValue(i, "tipo_mov").ToString() == "C")
                    {
                        valor_total = DecimalHelper.Somar(valor_total, gridView1.GetRowCellValue(i, "vlr_entrada").ToString(), true, 2);
                    }
                    if (gridView1.GetRowCellValue(i, "tipo_mov").ToString() == "D")
                    {
                        valor_total = DecimalHelper.Subtrair(valor_total, gridView1.GetRowCellValue(i, "vlr_saida").ToString(), true, 2);
                    }
                }
                datasource.Add(new Resumo("       Somente Dinheiro", valor_somente_dinheiro, ""));
                datasource.Add(new Resumo("       <b>TUDO</b>", "<b>" + valor_total + "</b>", ""));

                total_dinheiro = valor_somente_dinheiro;
                total_tudo = valor_total;


                gridControl2.DataSource = datasource;
            }



            gridView1_FocusedRowChanged(this, null);

        }

        private void frm_caixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_caixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (obs != memoEdit1.Text)
            {
                String query_caixa_obs_update = "UPDATE caixa SET obs=@obs";
                query_caixa_obs_update += " WHERE id = @id";
                ExeSql cmd_update = new ExeSql(query_caixa_obs_update);

                cmd_update.AddParams("@id", id_caixa, DbType.Int32);
                cmd_update.AddParams("@obs", memoEdit1.Text);
                cmd_update.ExecuteSql();
            }
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO caixa (id_usuario, date_abertura, saldo_inicial, obs) VALUES";
            query += "(@id_usuario, @date_abertura, moneyinsert(@saldo_inicial), @obs) RETURNING id";

            var date_abertura = DateHelper.GetDateNow(DateType.Type1);

            ExeSql cmd_cad = new ExeSql(query);
            cmd_cad.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);
            cmd_cad.AddParams("@date_abertura", date_abertura);
            cmd_cad.AddParams("@saldo_inicial", textEdit1.Text);
            cmd_cad.AddParams("@obs", memoEdit1.Text);
            obs = memoEdit1.Text;
            id_caixa = cmd_cad.ExecuteScalarString();
            panelControl2.BackColor = Color.Green;
            labelControl1.Text = "Caixa Aberto";
            btn_abrir.Visible = false;
            textEdit1.Enabled = false;
            labelControl5.Text = DateHelper.FormatDate(date_abertura, DateType.Type1, DateType.Type2);
            labelControl4.Visible = true;
            labelControl5.Visible = true;
            btn_add.Enabled = true;
            btn_fechar.Visible = true;
            aberto = true;
            load_movimentos(true);
        }

        private void gridView2_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            if (e.Column.FieldName.ToString() == "valor")
            {
                if (gridView2.GetRowCellValue(e.RowHandle, "valor_tipo").ToString() == "C")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                if (gridView2.GetRowCellValue(e.RowHandle, "valor_tipo").ToString() == "D")
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void gridView2_RowStyle(object sender, RowStyleEventArgs e)
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

            string tipo_reg = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tipo_reg").ToString();

            if (tipo_reg == "CAIXA" && aberto == true)
            {
                btn_trash.Enabled = true;
            }
            else
            {
                btn_trash.Enabled = false;
            }
        }

        private void btn_trash_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja realmente excluir o lançamento atual?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ExeSql sql_select = new ExeSql("SELECT id_conta_a_pagar from caixa_movimento where id=@id");
                sql_select.AddParams("@id", gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString(), DbType.Int32);
                string id_conta = sql_select.ExecuteScalarString();

                ExeSql sql_del = new ExeSql("UPDATE caixa_movimento SET date_delete=@date_delete WHERE id=@id");
                sql_del.AddParams("@id", gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString(), DbType.Int32);
                sql_del.AddParams("@date_delete", DateHelper.GetDateNow(DateType.Type1));
                if (!sql_del.ExecuteSql())
                {
                    InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (id_conta != null && id_conta != "" && id_conta != "0")
                {
                    ExeSql sql_del_2 = new ExeSql("DELETE FROM contas_pagar WHERE id=@id");
                    sql_del_2.AddParams("@id", id_conta, DbType.Int32);
                    if (!sql_del_2.ExecuteSql())
                    {
                        InfoUser.MessageBoxShow("{{error_mysql}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                load_movimentos(true);
            }
        }

        private void btn_fechar_Click(object sender, EventArgs e)
        {
            load_movimentos(true);
            frm_caixa_fechar frm = new frm_caixa_fechar(id_caixa, total_dinheiro, total_tudo);
            frm.ShowDialog();
            frm.Dispose();

            ExeSql sql_select = new ExeSql("SELECT date_fechamento from caixa where id=@id");
            sql_select.AddParams("@id", id_caixa, DbType.Int32);
            string date_fechamento = sql_select.ExecuteScalarString();

            if (date_fechamento == null || date_fechamento == "")
            {
                load_movimentos(true);
            }
            else
            {
                id_caixa = null;
                total_dinheiro = "";
                total_tudo = "";
                panelControl2.BackColor = Color.Red;
                labelControl1.Text = "Caixa Fechado";
                btn_abrir.Visible = true;
                textEdit1.Text = "0,00";
                textEdit1.Enabled = true;
                labelControl5.Text = "";
                labelControl4.Visible = false;
                labelControl5.Visible = false;
                labelControl6.Visible = false;
                labelControl7.Visible = false;
                btn_add.Enabled = false;
                btn_fechar.Visible = false;
                memoEdit1.Text = "";
                obs = "";
                aberto = false;
                load_movimentos(true);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_caixa_lancamento frm = new frm_caixa_lancamento(this, id_caixa);
            frm.ShowDialog();
            frm.Dispose();
            load_movimentos(true);
        }
    }
}

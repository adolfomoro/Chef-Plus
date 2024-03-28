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
using Npgsql;

namespace Chef_Plus
{
    public partial class frm_caixa_lancamento : XtraForm
    {

        string id_caixa;
        XtraForm frm_caixa;

        public frm_caixa_lancamento(XtraForm _frm, string _id_caixa)
        {
            InitializeComponent();

            frm_caixa = _frm;
            id_caixa = _id_caixa;

            ExeSql adapter_categorias = new ExeSql("SELECT * FROM categorias_contas where internal='0' ORDER BY id ASC");
            treeListLookUpEdit1.Properties.DisplayMember = "descricao";
            treeListLookUpEdit1.Properties.ValueMember = "id";
            treeListLookUpEdit1.Properties.DataSource = adapter_categorias.DataSet().Tables[0];

            ExeSql adapter_fornecedores = new ExeSql("SELECT * FROM fornecedores where (date_delete IS NULL or date_delete = '') ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_fornecedores.DataSet().Tables[0];

            HelperDev.MaskMoney(textEdit1, 2);
        }

        private void frm_caixa_lancamento_Load(object sender, EventArgs e)
        {


        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_caixa_lancamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_caixa_lancamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(DecimalHelper.FormatarMoeda(textEdit1.Text, 2)) <= 0)
            {
                InfoUser.MessageBoxShow("Valor não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkEdit1.Checked == true)
            {
                if (treeListLookUpEdit1.EditValue == null || treeListLookUpEdit1.EditValue.ToString() == "")
                {
                    InfoUser.MessageBoxShow("Categoria não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            String query = "INSERT INTO caixa_movimento (date_insert, id_caixa, id_pagamento, valor, tipo_valor, tipo, obs, id_conta_a_pagar) VALUES";
            query += "(@date_insert, @id_caixa, @id_pagamento, moneyinsert(@valor), @tipo_valor, @tipo, @obs, @id_conta_a_pagar)";

            var date_insert = DateHelper.GetDateNow(DateType.Type1);

            ExeSql cmd_cad = new ExeSql(query);
            cmd_cad.AddParams("@date_insert", date_insert);
            cmd_cad.AddParams("@id_caixa", id_caixa, DbType.Int32);
            cmd_cad.AddParams("@id_pagamento", radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value, DbType.Int32);
            cmd_cad.AddParams("@valor", textEdit1.Text);
            if (checkEdit1.Checked == true)
            {
                cmd_cad.AddParams("@tipo_valor", "D");
                cmd_cad.AddParams("@tipo", "D");

                String query_a_pagar = "INSERT INTO contas_pagar (date_insert, id_categoria, id_fornecedor, descricao, parcela, total_parcelas, valor, date_pagamento, date_vencimento, descontos, juros_multas, valor_pago, obs) VALUES";
                query_a_pagar += "(@date_insert, @id_categoria, @id_fornecedor, @descricao, 1, 1, moneyinsert(@valor), @date_pagamento, @date_vencimento, moneyinsert('0,00'), moneyinsert('0,00'), moneyinsert(@valor_pago), @obs)  RETURNING id";

                ExeSql cmd_cad_a_pagar = new ExeSql(query_a_pagar);
                cmd_cad_a_pagar.AddParams("@date_insert", date_insert);
                cmd_cad_a_pagar.AddParams("@id_categoria", treeListLookUpEdit1.EditValue.ToString(), DbType.Int32);
                if (lookUpEdit1.EditValue == null)
                {
                    cmd_cad_a_pagar.AddParams("@id_fornecedor", 0, DbType.Int32);
                }
                else
                {
                    cmd_cad_a_pagar.AddParams("@id_fornecedor", lookUpEdit1.EditValue.ToString(), DbType.Int32);
                }
                cmd_cad_a_pagar.AddParams("@descricao", "Saída do caixa " + id_caixa);
                cmd_cad_a_pagar.AddParams("@valor", textEdit1.Text);

                cmd_cad_a_pagar.AddParams("@date_pagamento", date_insert);
                cmd_cad_a_pagar.AddParams("@date_vencimento", date_insert);
                cmd_cad_a_pagar.AddParams("@valor_pago", textEdit1.Text);
                cmd_cad_a_pagar.AddParams("@obs", textEdit2.Text);
                string id_a_pagar = cmd_cad_a_pagar.ExecuteScalarString();

                cmd_cad.AddParams("@id_conta_a_pagar", id_a_pagar, DbType.Int32);
            }
            else if (checkEdit2.Checked == true)
            {
                cmd_cad.AddParams("@tipo_valor", "D");
                cmd_cad.AddParams("@tipo", "S");
                cmd_cad.AddParams("@id_conta_a_pagar", 0, DbType.Int32);
            }
            else if (checkEdit3.Checked == true)
            {
                cmd_cad.AddParams("@tipo_valor", "C");
                cmd_cad.AddParams("@tipo", "A");

                cmd_cad.AddParams("@id_conta_a_pagar", 0, DbType.Int32);
            }
            cmd_cad.AddParams("@obs", textEdit2.Text);
            cmd_cad.ExecuteSql();

            this.Close();

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            labelControl5.Enabled = true;
            labelControl7.Enabled = true;
            treeListLookUpEdit1.Enabled = true;
            lookUpEdit1.Enabled = true;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            labelControl5.Enabled = false;
            labelControl7.Enabled = false;
            treeListLookUpEdit1.Enabled = false;
            lookUpEdit1.Enabled = false;
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            labelControl5.Enabled = false;
            labelControl7.Enabled = false;
            treeListLookUpEdit1.Enabled = false;
            lookUpEdit1.Enabled = false;
        }

        private void treeListLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {


        }
    }
}

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
    public partial class frm_lancar_credito_cliente : XtraForm
    {
        public string id_cliente;

        public frm_lancar_credito_cliente()
        {
            InitializeComponent();

            id_cliente = string.Empty;

            ExeSql adapter_formas = new ExeSql("SELECT * FROM formas_pagamento ORDER BY id ASC");
            lookUpEdit1.Properties.DisplayMember = "nome";
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DataSource = adapter_formas.DataSet().Tables[0];

            HelperDev.MaskMoney(textEdit1, 2);
        }

        private void frm_lancar_credito_cliente_Load(object sender, EventArgs e)
        {

        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_lancar_credito_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_lancar_credito_cliente_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(DecimalHelper.FormatarMoeda(textEdit1.Text, 2)) <= 0)
            {
                InfoUser.MessageBoxShow("Valor não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lookUpEdit1.EditValue == null || lookUpEdit1.EditValue.ToString() == "")
            {
                InfoUser.MessageBoxShow("Forma de Pagamento não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((lookUpEdit2.EditValue == null || lookUpEdit2.EditValue.ToString() == "") && lookUpEdit2.Visible == true)
            {
                InfoUser.MessageBoxShow("Bandeira não informada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String query = "INSERT INTO clientes_conta (date_insert, id_cliente, obs, id_pagamento, id_bandeira, valor, operacao) VALUES";
            query += "(@date_insert, @id_cliente, @obs, @id_pagamento, @id_bandeira, moneyinsert(@valor), 'C')";

            var date_insert = DateHelper.GetDateNow(DateType.Type1);

            ExeSql cmd_cad = new ExeSql(query);
            cmd_cad.AddParams("@date_insert", date_insert);
            cmd_cad.AddParams("@id_cliente", id_cliente, DbType.Int32);
            cmd_cad.AddParams("@obs", memoEdit1.Text);
            cmd_cad.AddParams("@id_pagamento", lookUpEdit1.EditValue.ToString(), DbType.Int32);
            if (lookUpEdit2.EditValue != null)
            {
                cmd_cad.AddParams("@id_bandeira", lookUpEdit2.EditValue.ToString(), DbType.Int32);
            }
            else
            {
                cmd_cad.AddParams("@id_bandeira", "0", DbType.Int32);
            }
            cmd_cad.AddParams("@valor", textEdit1.Text);
            cmd_cad.ExecuteSql();

            //(!) Inserir registro tambem na tabela de contas a receber, com categoria 2

            this.Close();

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ExeSql adapter_bandeiras = new ExeSql("SELECT *, (select descricao from bandeiras where id=formas_pagamento_bandeiras.id_bandeira) as descricao FROM formas_pagamento_bandeiras WHERE id_pagamento=@id_pagamento ORDER BY id ASC");
            adapter_bandeiras.AddParams("@id_pagamento", lookUpEdit1.EditValue.ToString(), DbType.Int32);
            if (adapter_bandeiras.DataSet().Tables[0].Rows.Count > 0)
            {
                labelControl3.Visible = true;
                lookUpEdit2.Visible = true;
                lookUpEdit2.Properties.DisplayMember = "descricao";
                lookUpEdit2.Properties.ValueMember = "id";
                lookUpEdit2.Properties.DataSource = adapter_bandeiras.DataSet().Tables[0];
            }
            else
            {
                labelControl3.Visible = false;
                lookUpEdit2.Visible = false;
            }
        }
    }
}

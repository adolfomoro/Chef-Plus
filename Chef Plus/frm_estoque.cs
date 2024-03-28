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

namespace Chef_Plus
{
    public partial class frm_estoque : XtraForm
    {
        private string id_produto;

        private string tipo;
        public frm_estoque(string id)
        {
            InitializeComponent();

            tipo = string.Empty;

            id_produto = id;

        }

        private void frm_estoque_Load(object sender, EventArgs e)
        {
            ExeSql sql_load = new ExeSql("SELECT id, nome, moneyf(preco_custo, 2) as preco_custo, tipo FROM (select id, nome, preco_custo, tipo from produtos union all select id, nome, preco_custo, tipo from insumos ) as resultados WHERE id=@id");
            sql_load.AddParams("@id", id_produto, DbType.Int32);

            NpgsqlDataReader myReader = sql_load.DataReader();
            if (myReader.Read())
            {
                labelControl9.Text = myReader["nome"].ToString();
                labelControl10.Text = myReader["preco_custo"].ToString();
                labelControl11.Text = HelperProdutos.LoadEstoque(id_produto);;
                tipo = myReader["tipo"].ToString();
                if (tipo == "UN")
                {
                    textEdit1.Properties.MaxLength = 10;
                    textEdit2.Properties.MaxLength = 13;
                    HelperDev.MaskMoney(textEdit2, 2);
                }
                else if (tipo == "KG" || tipo == "LT")
                {
                    textEdit1.Properties.MaxLength = 13;
                    textEdit2.Properties.MaxLength = 14;

                    HelperDev.MaskMoney(textEdit1, 3);
                    HelperDev.MaskMoney(textEdit2, 2);
                }
                else
                {
                    InfoUser.MessageBoxShow("{{error_open_form_reg}}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                calcular_estoque();
            }
            sql_load.CloseConnection();
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                checkEdit3.Checked = true;
                checkEdit3.Visible = true;
                checkEdit4.Visible = true;
            }
            else
            {
                checkEdit3.Visible = false;
                checkEdit4.Visible = false;
            }

            if (checkEdit1.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = true;
                calcular_estoque();
                memoEdit1.Text = "Compra de Novos Itens";
            }
            else if (checkEdit2.Checked == true && checkEdit3.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Adicionar (+)";
            }
            else if (checkEdit2.Checked == true && checkEdit4.Checked == true)
            {
                labelControl6.Text = "(-) Remover:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Remover (-)";
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked == true)
            {
                checkEdit3.Checked = true;
                checkEdit3.Visible = true;
                checkEdit4.Visible = true;
            }
            else
            {
                checkEdit3.Visible = false;
                checkEdit4.Visible = false;
            }

            if (checkEdit1.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = true;
                calcular_estoque();
                memoEdit1.Text = "Compra de Novos Itens";
            }
            else if (checkEdit2.Checked == true && checkEdit3.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Adicionar (+)";
            }
            else if (checkEdit2.Checked == true && checkEdit4.Checked == true)
            {
                labelControl6.Text = "(-) Remover:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Remover (-)";
            }
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = true;
                calcular_estoque();
                memoEdit1.Text = "Compra de Novos Itens";
            }
            else if (checkEdit2.Checked == true && checkEdit3.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Adicionar (+)";
            }
            else if (checkEdit2.Checked == true && checkEdit4.Checked == true)
            {
                labelControl6.Text = "(-) Remover:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Remover (-)";
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = true;
                calcular_estoque();
                memoEdit1.Text = "Compra de Novos Itens";
            }
            else if (checkEdit2.Checked == true && checkEdit3.Checked == true)
            {
                labelControl6.Text = "(+) Adicionar:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Adicionar (+)";
            }
            else if (checkEdit2.Checked == true && checkEdit4.Checked == true)
            {
                labelControl6.Text = "(-) Remover:";
                textEdit2.Enabled = false;
                calcular_estoque();
                memoEdit1.Text = "Correção de Estoque - Remover (-)";
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            calcular_estoque();
        }

        private void calcular_estoque()
        {
            if (checkEdit1.Checked == true)
            {
                labelControl13.Text = DecimalHelper.Somar(labelControl11.Text, textEdit1.Text);
                labelControl15.Text = DecimalHelper.Dividir(textEdit2.Text, textEdit1.Text, true, 2);
            }
            else if (checkEdit2.Checked == true && checkEdit3.Checked == true)
            {
                labelControl13.Text = DecimalHelper.Somar(labelControl11.Text, textEdit1.Text);
                labelControl15.Text = DecimalHelper.Dividir(textEdit2.Text, textEdit1.Text, true, 2);
            }
            else if (checkEdit2.Checked == true && checkEdit4.Checked == true)
            {
                labelControl13.Text = DecimalHelper.Subtrair(labelControl11.Text, textEdit1.Text);
                labelControl15.Text = "0,00";
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && (tipo == "UN"))
            {
                e.Handled = true;
            }
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            calcular_estoque();
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textEdit1.Text) <= 0)
            {
                InfoUser.MessageBoxShow("Estoque para Movimentação não informado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string valor_entrada = "";
            HelperProdutos.TipoEstoqueMovimentacao tipo;
            if (checkEdit1.Checked == true)
            {
                tipo = HelperProdutos.TipoEstoqueMovimentacao.Entrada;
                valor_entrada = textEdit2.Text;
            }
            else if (checkEdit2.Checked == true && checkEdit3.Checked == true)
            {
                tipo = HelperProdutos.TipoEstoqueMovimentacao.C_Add;
                valor_entrada = "";
            }
            else
            {
                tipo = HelperProdutos.TipoEstoqueMovimentacao.C_remov;
                valor_entrada = "";
            }



            if (!HelperProdutos.EstoqueMovimentacao(Convert.ToInt32(id_produto), textEdit1.Text, valor_entrada, memoEdit1.Text, tipo, UserLogin.IdUserGet())){
                InfoUser.MessageBoxShow("Ocorreu um erro ao lançar o estoque.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void frm_estoque_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void frm_estoque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}

using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
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
    public partial class frm_consulta_produto : XtraForm
    {

        string id_pedido;

        string codigo;

        protected override void WndProc(ref Message message)
        {
            const int WM_NCHITTEST = 0x0084;

            if (message.Msg == WM_NCHITTEST)
                return;

            base.WndProc(ref message);
        }

        public frm_consulta_produto(string _id_pedido, string _codigo)
        {
            InitializeComponent();
            id_pedido = _id_pedido;
            codigo = _codigo;
            if (HelperProdutos.UseCodPerso())
            {
                labelControl1.Text = "PESQUISA POR CÓDIGO PERSONALIZADO";
            }
            else
            {
                labelControl1.Text = "PESQUISA POR CÓDIGO INTERNO";
            }
        }

        private void frm_consulta_produto_Load(object sender, EventArgs e)
        {
            textEdit1.EditValue = codigo;
            textEdit1.Select(codigo.Length, 0);
        }

        private void frm_consulta_produto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_consulta_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                if (produto.exist == true)
                {
                    textEdit2.Focus();
                    textEdit2.Select();
                }
                return;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (produto.exist == false)
                {
                    return;
                }
                if (Convert.ToDouble(DecimalHelper.FormatarMoeda(textEdit2.Text, 2)) <= 0)
                {
                    InfoUser.MessageBoxShow("Informe a quantidade a ser lançada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bool returned, string message) produto_lancado = HelperProdutos.LancarProduto(produto.id, id_pedido, textEdit2.Text, "1");
                if (produto_lancado.returned == true)
                {
                    this.Close();
                }
                else
                {
                    if (produto_lancado.message != "" && produto_lancado.message != null)
                    {
                        InfoUser.MessageBoxShow(produto_lancado.message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textEdit1.Focus();
                        textEdit1.Select();
                        textEdit1.Select(codigo.Length, 0);
                        return;
                    }
                }

            }
        }

        HelperProdutos.Produto produto;
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            labelControl3.Appearance.ForeColor = Color.Gray;
            labelControl3.Text = "Aguarde...";
            labelControl4.Visible = false;
            textEdit2.Visible = false;
            textEdit2.Text = "1,00";
            labelControl5.Visible = false;
            labelControl6.Visible = false;
            textEdit3.Visible = false;
            textEdit4.Visible = false;
            produto = HelperProdutos.ConsultarProduto(textEdit1.Text);
            if (produto.exist == false)
            {
                labelControl3.Appearance.ForeColor = Color.IndianRed;
                labelControl3.Text = "Produto não encontrado";
            }
            else
            {
                if (produto.Produtotipo == HelperProdutos.ProdutoTipo.Produtos)
                {

                    labelControl3.Appearance.ForeColor = Color.SkyBlue;
                    labelControl3.Text = produto.nome;
                    switch (produto.medida)
                    {
                        case HelperProdutos.ProdutoMedida.UN:
                            textEdit2.Text = "1";
                            HelperDev.MaskMoney(textEdit2, 0);
                            break;
                        case HelperProdutos.ProdutoMedida.KG:
                            textEdit2.Text = "1,000";
                            HelperDev.MaskMoney(textEdit2, 3);
                            break;
                        case HelperProdutos.ProdutoMedida.LT:
                            textEdit2.Text = "1,000";
                            HelperDev.MaskMoney(textEdit2, 3);
                            break;
                    }

                    textEdit3.Text = produto.Precos[produto.Precos.FindIndex(x => x.id == "1")].PrecoVenda;

                    labelControl4.Visible = true;
                    textEdit2.Visible = true;
                    labelControl5.Visible = true;
                    labelControl6.Visible = true;
                    textEdit3.Visible = true;
                    textEdit4.Visible = true;
                    textEdit4.EditValue = DecimalHelper.Multiplicar(textEdit3.Text, textEdit2.Text, true, 2);

                }
                if (produto.Produtotipo == HelperProdutos.ProdutoTipo.ProdutosTamanho)
                {
                    labelControl3.Appearance.ForeColor = Color.SkyBlue;
                    labelControl3.Text = produto.nome;
                }
            }
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            textEdit4.EditValue = DecimalHelper.Multiplicar(textEdit3.Text, textEdit2.Text, true, 2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ChefPlus.core;

namespace Chef_Plus
{
    public partial class ListTamanhos : DevExpress.XtraEditors.XtraUserControl
    {
        private ModifiedItemsForm valid { get; set; }

        List<frm_cadastro_produto_personalizado.Tamanhos> l_tamanhos;

        private string id;

        public ListTamanhos(ModifiedItemsForm _valid, List<frm_cadastro_produto_personalizado.Tamanhos> _l_tamanhos, string _id, string produto, string sigla, Boolean check = false, string custo = "0,00", string venda = "0,00")
        {
            InitializeComponent();
            checkEdit1.Text = produto + " ("+sigla.ToUpper()+")";

            this.Enter += delegate
            {
                this.BackColor = Color.FromArgb(235, 236, 255);
            };

            this.Leave += delegate
            {
                this.BackColor = Color.FromArgb(235, 236, 239);
            };

            valid = _valid;
            l_tamanhos = _l_tamanhos;
            id = _id;

            frm_cadastro_produto_personalizado.Tamanhos n = new frm_cadastro_produto_personalizado.Tamanhos
            {
                Id = _id,
                Check = check,
                Custo = custo,
                Venda = venda,
            };
            l_tamanhos.Add(n);

            checkEdit1.Checked = check;
            textEdit1.Text = custo;
            textEdit2.Text = venda;


            HelperDev.MaskMoney(textEdit1, 2);
            HelperDev.MaskMoney(textEdit2, 2);

            this.Name = "p_tamanho_id" + _id;
            checkEdit1.Name = "p_tamanho_check_id" + _id;
            textEdit1.Name = "p_tamanho_custo_id" + _id;
            textEdit2.Name = "p_tamanho_venda_id" + _id;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkEdit1.Checked)
            {
                pictureEdit1.Visible = true;
                textEdit1.Enabled = true;
                textEdit2.Enabled = true;
                l_tamanhos[l_tamanhos.FindIndex(x => x.Id == id)].Check = true;
            }
            else
            {
                pictureEdit1.Visible = false;
                textEdit1.Enabled = false;
                textEdit2.Enabled = false;
                l_tamanhos[l_tamanhos.FindIndex(x => x.Id == id)].Check = false;
            }
            valid.Modified();

        }

        private void ListTamanhos_Load(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            l_tamanhos[l_tamanhos.FindIndex(x => x.Id == id)].Custo = textEdit1.Text;
            valid.Modified();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            l_tamanhos[l_tamanhos.FindIndex(x => x.Id == id)].Venda = textEdit2.Text;
            valid.Modified();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}

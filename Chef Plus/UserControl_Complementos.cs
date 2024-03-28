using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChefPlus.core;
using DevExpress.XtraEditors;

namespace Chef_Plus
{
    public partial class UserControl_Complementos : UserControl
    {


        List<frm_lanca_produtos.CompleProdutos> l_complementos;

        private string id;
        private string complemento;
        private string preco_venda;
        public string internal_id;

        private bool userCheck = true;

        Action method;



        public void teste() {
            Console.WriteLine(internal_id);
            userCheck = true;
            if (l_complementos.Any(x => x.idProduto == id && x.idInternal == internal_id))
            {
                if (l_complementos.Exists(aa => aa.idInternal == internal_id && aa.idProduto == id))
                {
                    checkEdit1.Checked = true;
                }
                else
                {
                    checkEdit1.Checked = true;
                }
                spinEdit1.EditValue = l_complementos[l_complementos.FindIndex(x => x.idProduto == id && x.idInternal == internal_id)].quantidade;
            }
            else
            {
                checkEdit1.CheckState = CheckState.Unchecked;

            }
            userCheck = false;
        }

        public UserControl_Complementos(Action _method, List<frm_lanca_produtos.CompleProdutos> _l_complementos, string _id, string _complemento, string _internal_id, Boolean check = false, string venda = "0,00", string _quantidade = "1")
        {
            InitializeComponent();

            this.Enter += delegate
            {
                this.BackColor = Color.FromArgb(235, 236, 255);
            };

            this.Leave += delegate
            {
                this.BackColor = Color.FromArgb(235, 236, 239);
            };
            id = _id;
            complemento = _complemento;
            checkEdit1.Text = _complemento + " <b><color=66, 135, 245>" + venda + "</color></b>";
            preco_venda = venda;
            internal_id = _internal_id;
            method = _method;
            l_complementos = _l_complementos;



            userCheck = true;
            if (check == true)
            {
                checkEdit1.CheckState = CheckState.Checked;
            }
            else
            {
                checkEdit1.CheckState = CheckState.Unchecked;
            }
            spinEdit1.EditValue = _quantidade;
            userCheck = false;
        }

        private void UserControl_Complementos_Load(object sender, EventArgs e)
        {

        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                spinEdit1.Visible = true;

            }
            else
            {
                spinEdit1.Visible = false;

            }

            if (userCheck == false)
            {
                if (checkEdit1.Checked)
                {

                    l_complementos.Add(
                        new frm_lanca_produtos.CompleProdutos
                        {
                            idInternal = internal_id,
                            idProduto = id,
                            precoVenda = preco_venda,
                            nome = complemento,
                            quantidade = spinEdit1.Value.ToString()
                        }
                     );
                }
                else
                {

                    var item = l_complementos.Find(x => x.idProduto == id && x.idInternal == internal_id);
                    l_complementos.Remove(item);
                }
                method();
            }
        }

        private void checkEdit1_CheckStateChanged(object sender, EventArgs e)
        {


        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("ok." + DateTime.Now);
            l_complementos[l_complementos.FindIndex(x => x.idProduto == id && x.idInternal == internal_id)].quantidade = spinEdit1.EditValue.ToString();
            if (userCheck == false)
            {
                method();
                Console.WriteLine("ok 2." + DateTime.Now);
            }
        }

        private void spinEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Console.WriteLine("Digitando." + DateTime.Now);
        }
    }
}

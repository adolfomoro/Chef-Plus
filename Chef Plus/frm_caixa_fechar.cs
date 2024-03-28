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

namespace Chef_Plus
{
    public partial class frm_caixa_fechar : XtraForm
    {
        private string id_caixa;

        private string total_dinheiro;
        private string total_tudo;

        public frm_caixa_fechar(string _caixa, string _dinheiro, string _total)
        {
            InitializeComponent();

            id_caixa = _caixa;

            total_dinheiro = _dinheiro;
            total_tudo = _total;

            textEdit1.Text = total_dinheiro;
            textEdit2.Text = total_tudo;
        }

        private void cadastro_categoria_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_caixa_fechar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja prosseguir com o fechamento do caixa atual?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var date_fechamento = DateHelper.GetDateNow(DateType.Type1);

                String query_caixa_obs_update = "UPDATE caixa SET date_fechamento=@date_fechamento, saldo_final=moneyinsert(@saldo_final)";
                query_caixa_obs_update += " WHERE id = @id";
                ExeSql cmd_update = new ExeSql(query_caixa_obs_update);

                cmd_update.AddParams("@id", id_caixa, DbType.Int32);
                cmd_update.AddParams("@date_fechamento", date_fechamento);
                cmd_update.AddParams("@saldo_final", total_tudo);
                cmd_update.ExecuteSql();

                this.Close();

                //(!) Gerar cupom de fechamento
            }
        }


        private void frm_caixa_fechar_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}

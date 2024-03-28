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

namespace Chef_Plus
{
    public partial class frm_ddd : XtraForm
    {
        public frm_ddd()
        {
            InitializeComponent();
        }

        private void frm_ddd_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_trash_Click(object sender, EventArgs e)
        {
            String query_user_update = "INSERT INTO config (id, ddd) values (1, @ddd) ON CONFLICT (id) DO UPDATE SET ddd = @ddd";
            ExeSql cmd_update = new ExeSql(query_user_update);

            cmd_update.AddParams("@ddd", comboBoxEdit1.Text);

            if (cmd_update.ExecuteSql())
            {
                InfoUser.set_DDD(comboBoxEdit1.Text);
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frm_ddd_FormClosing);
                this.Close();
            }
            else
            {
                InfoUser.MessageBoxShow("{{error_mysql}} {{support_call}}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frm_ddd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}

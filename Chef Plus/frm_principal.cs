using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ini;
using Microsoft.Win32;

using System.Reflection;
using System.Resources;
using System.Globalization;
using ChefPlus.core;
using ChefPlus.data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using Npgsql;
using System.Threading;
using System.Runtime.InteropServices;

namespace Chef_Plus
{
    public partial class frm_principal : XtraForm
    {

        public static string id_maquina;

        //Arquivo de configuração
        public static IniFile ini_config;
        public static string file_config;

        public frm_principal()
        {
            InitializeComponent();
            cronometro.Reset();
            cronometro.Start();
            

            ExeSql sql_users = new ExeSql("SELECT COUNT(*) FROM usuarios WHERE id = '1'");

            int rows_users = sql_users.ExecuteScalarInt();

            if (rows_users <= 0)
            {
                InfoUser.MessageBoxShow("Antes de iniciar e abrir o programa, é necessário cadastrar um Usuário Administrador.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm_cadastro_usuario frm = new frm_cadastro_usuario();
                frm.valid = new ModifiedItemsForm(ModifiedOperation.New, frm, "btn_menu_save");
                frm.ShowDialog();
                frm.Dispose();

                if (sql_users.ExecuteScalarInt() <= 0)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!UserLogin.CheckLogaded())
            {
                ribbonControl1.Visible = false;
                frm_login frm_login = new frm_login();
                frm_login.ShowDialog();
                if (!UserLogin.CheckLogaded())
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    if (!ribbonControl1.Visible)
                        ribbonControl1.Visible = true;


                    ExeSql sql_caixa = new ExeSql("SELECT COUNT(*) FROM caixa WHERE id_usuario = @id_usuario and (date_fechamento IS NULL or date_fechamento = '')");
                    sql_caixa.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);
                    int rows_caixa = sql_caixa.ExecuteScalarInt();
                    if (rows_caixa > 0)
                    {
                        ExeSql sql_caixa_info = new ExeSql("SELECT to_char(TO_TIMESTAMP(date_abertura, 'dd/MM/yyyy HH24:MI:SS'), 'yyyy-MM-dd HH24:MI:SS') as data_abertura FROM caixa WHERE id_usuario = @id_usuario and (date_fechamento IS NULL or date_fechamento = '')");
                        sql_caixa_info.AddParams("@id_usuario", UserLogin.IdUserGet(), DbType.Int32);
                        string rows_caixa_info = sql_caixa_info.ExecuteScalarString();

                        DateTime data_abretura_add_day = Convert.ToDateTime(rows_caixa_info).AddDays(1);
                        if (data_abretura_add_day <= DateTime.Now)
                        {
                            InfoUser.MessageBoxShow("O caixa deste usuário está aberto a mais de 24 Horas, verifique-o.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            frm_caixa frm = new frm_caixa(null);
                            frm.ShowDialog();
                            frm.Dispose();
                        }
                    }
                }

            }
            if (UserLogin.CheckLogaded())
            {
                if (!ribbonControl1.Visible)
                    ribbonControl1.Visible = true;
            }
        }


        private void frm_principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = InfoUser.MessageBoxShow("Deseja sair do sistema?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_usuarios frm = new frm_usuarios();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_produtos frm = new frm_produtos();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_categorias frm = new frm_categorias(frm_categorias.CategoriaTipo.Produtos);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_complementos frm = new frm_complementos();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_observacoes frm = new frm_observacoes();
            frm.ShowDialog();
            frm.Dispose();
        }

        Stopwatch cronometro = new Stopwatch();
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl2.Text = String.Format("{0:00}:{1:00}:{2:00}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_categorias frm = new frm_categorias(frm_categorias.CategoriaTipo.Insumos);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_insumos frm = new frm_insumos();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_tt frm = new frm_tt();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_clientes frm = new frm_clientes();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_formas_pagamento frm = new frm_formas_pagamento();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_caixa frm = new frm_caixa(null);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_categorias_contas frm = new frm_categorias_contas();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_fornecedores frm = new frm_fornecedores();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_caixa_historico frm = new frm_caixa_historico();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_mesas frm = new frm_mesas();
            frm.ShowDialog();
            frm.Dispose();
        }
    }
}

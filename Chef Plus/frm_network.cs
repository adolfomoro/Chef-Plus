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

using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using ChefPlus.core;
using ChefPlus.data;

namespace Chef_Plus
{
    public partial class frm_network : XtraForm
    {
        public frm_network()
        {
            InitializeComponent();
        }

        public bool CheckRegistryPath()
        {
            string guid = "790A9827-137F-4D93-A981-1A5C38FFB8F8";
            try
            {
                //HKEY_Current_User\\Software\\Microsoft\\Active Setup]

                string registryKey1 = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\{" + guid + "}_is1";
                RegistryKey key1 = Registry.LocalMachine.OpenSubKey(registryKey1);
                if (key1 != null)
                {
                    return true;
                }

                string registryKey2 = @"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{" + guid + "}_is1";
                RegistryKey key2 = Registry.LocalMachine.OpenSubKey(registryKey2);
                if (key2 != null)
                {
                    return true;
                }

                return false;

            }
            catch (Exception )
            {
                return false;
            }
        }

        private void frm_network_Load(object sender, EventArgs e)
        {
            if (CheckRegistryPath() != true)
            {
                pictureEdit2.Enabled = false;
                checkEdit2.Enabled = false;
                simpleButton1.Enabled = true;
            }
            else
            {
                pictureEdit2.Enabled = true;
                checkEdit2.Enabled = true;
                simpleButton1.Enabled = false;
            }

        }

        private void frm_network_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        private void frm_network_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_menu_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            checkEdit1.CheckState = CheckState.Checked;
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            checkEdit2.CheckState = CheckState.Checked;
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            checkEdit3.CheckState = CheckState.Checked;
        }

        private void btn_menu_save_Click(object sender, EventArgs e)
        {
            //(!)Configurar o configurador de DB
            if (checkEdit1.Checked)
            {
                frm_principal.ini_config.IniWriteValue("CONEXAO", "TIPO", "LOCAL");
                if (!DBMain.DBConfigure(frm_principal.ini_config.IniReadValue("CONEXAO", "TIPO"), frm_principal.ini_config.IniReadValue("CONEXAO", "SERVER_IP")))
                {
                    return;
                }
            }
            else if (checkEdit2.Checked)
            {
                frm_principal.ini_config.IniWriteValue("CONEXAO", "TIPO", "SERVER");
            }
            else if (checkEdit3.Checked)
            {
                frm_principal.ini_config.IniWriteValue("CONEXAO", "TIPO", "CLIENT");
            }


            String query = "INSERT INTO maquinas (maquina, tipo) VALUES";
            query += "(@maquina, @tipo)";

            ExeSql cmd_cad = new ExeSql(query);
            cmd_cad.AddParams("@maquina", SystemAdmin.IdentifyThisComputer());
            if (checkEdit1.Checked)
            {
                cmd_cad.AddParams("@tipo", "LOCAL");
            }
            else if (checkEdit2.Checked)
            {
                cmd_cad.AddParams("@tipo", "SERVER");
            }
            else if (checkEdit3.Checked)
            {
                cmd_cad.AddParams("@tipo", "CLIENT");
            }
            cmd_cad.ExecuteSql();
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = InfoUser.MessageBoxShow("Esta operação irá instalar o banco de dados Servidor nesta maquina.\r\n\r\nDeseja continuar? (Esta operação pode demorar alguns minutos)",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string button = simpleButton1.Text;
                try
                {
                    simpleButton1.Text = "Aguarde ...";
                    //(!)Configurar tipo máquina
                    Process cmd = new Process();

                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.Start();
                    using (StreamWriter sw = cmd.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("@echo off");
                            sw.WriteLine(@"cd C:\Users\Adolfo\Desktop\Teste Mysql");
                            sw.WriteLine("start /w \"\" \"install_mysql.exe\" /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /LOG=\"log_install_mysql.txt\"");
                            sw.WriteLine("exit /b %errorlevel%");

                        }
                    }
                    cmd.WaitForExit();

                    if (CheckRegistryPath() != true)
                    {
                        pictureEdit2.Enabled = false;
                        checkEdit2.Enabled = false;
                        simpleButton1.Enabled = true;
                    }
                    else
                    {
                        pictureEdit2.Enabled = true;
                        checkEdit2.Enabled = true;
                        simpleButton1.Enabled = false;

                        checkEdit2.Checked = true;
                        checkEdit2.Focus();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    simpleButton1.Text = button;
                }
            }
            if (dialogResult == DialogResult.No)
            {
                
            }
            
        }
    }
}

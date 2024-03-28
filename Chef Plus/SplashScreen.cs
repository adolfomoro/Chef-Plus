using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChefPlus.core;
using ChefPlus.data;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Ini;

namespace Chef_Plus
{
    public partial class SplashScreen : XtraForm
    {

        public bool NotOpen = false;
        public bool status = false;

        public bool isClosed = false;

        FormWindowState estado = FormWindowState.Normal;
        public SplashScreen()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
        }
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public enum SplashScreenCommand
        {

        }
        BackgroundWorker bgw;
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            bgw = new BackgroundWorker();
            bgw.WorkerSupportsCancellation = true;
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            bgw.RunWorkerAsync();
        }


        delegate void SThisClose();
        delegate void SThisHide();
        delegate void SThisShow();

        void ThisClose()
        {
            if (this.InvokeRequired)
            {
                SThisClose d = new SThisClose(ThisClose);
                this.Invoke(d);
            }
            else
            {
                if (NotOpen)
                {
                    status = false;
                }
                this.Close();

            }
        }


        void ThisHide()
        {
            if (this.InvokeRequired)
            {
                SThisHide d = new SThisHide(ThisHide);
                this.Invoke(d);
            }
            else
            {
                estado = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Minimized;
            }
        }


        void ThisShow()
        {
            if (this.InvokeRequired)
            {
                SThisShow d = new SThisShow(ThisShow);
                this.Invoke(d);
            }
            else
            {
                estado = FormWindowState.Normal;
                this.WindowState = FormWindowState.Normal;
            }
        }

        bool SetNotOpen()
        {
            bgw.CancelAsync();
            NotOpen = true;
            isClosed = true;
            ThisClose();
            return true;
        }

        public void CheckSsMissingDate()
        {

            //definir linguagem
            InfoUser._construtor("pt-br");

            frm_principal.ini_config = new IniFile(frm_principal.file_config);

            while (frm_principal.ini_config.IniReadValue("CONEXAO", "TIPO") == "" || frm_principal.ini_config.IniReadValue("CONEXAO", "TIPO") == null)
            {
                ThisHide();
                using (frm_network f = new frm_network())
                {
                    f.ShowDialog();
                    f.Dispose();
                }
                ThisShow();
            }

            if (!DBMain.DBConfigure(frm_principal.ini_config.IniReadValue("CONEXAO", "TIPO"), frm_principal.ini_config.IniReadValue("CONEXAO", "SERVER_IP")))
            {
                if (SetNotOpen()) return;
            }

            if (!DBMain.Connect())
            {
                ThisHide();
                if (frm_principal.ini_config.IniReadValue("CONEXAO", "TIPO") == "SERVER" || frm_principal.ini_config.IniReadValue("CONEXAO", "TIPO") == "CLIENT")
                {
                    InfoUser.MessageBoxShow("Não foi possível efetuar a conexão com o banco de dados. Verifique se seu servidor está ligado. (" + DBMain.CodeError() + ")\r\n\r\nEntre em contato com o suporte técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InfoUser.MessageBoxShow("Não foi possível efetuar a conexão com o banco de dados. (" + DBMain.CodeError() + ")\r\n\r\nEntre em contato com o suporte técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ThisShow();
                if (SetNotOpen()) return;
            }

            ExeSql sql_maquina = new ExeSql("SELECT count(*) FROM maquinas WHERE maquina=@maquina");
            sql_maquina.AddParams("@maquina", SystemAdmin.IdentifyThisComputer());
            while (sql_maquina.ExecuteScalarInt() <= 0)
            {
                //(!) Verificar bug do HIDE
                ThisHide();
                using (frm_network f = new frm_network())
                {
                    f.ShowDialog();
                    f.Dispose();
                }
                ThisShow();
            }

            ExeSql sql_maquina_id = new ExeSql("SELECT id FROM maquinas WHERE maquina=@maquina");
            sql_maquina_id.AddParams("@maquina", SystemAdmin.IdentifyThisComputer());
            frm_principal.id_maquina = sql_maquina_id.ExecuteScalarString();

            //(!) Puxar informações da empresa do site e inserir na tabela CONFIG

            ExeSql sql_config = new ExeSql("SELECT ddd FROM config WHERE id = '1'");

            string ddd_default = sql_config.ExecuteScalarString();

            if (ddd_default == "" || ddd_default == null)
            {
                ThisHide();
                using (frm_ddd f = new frm_ddd())
                {
                    f.ShowDialog();
                    f.Dispose();
                }
                ThisShow();
            }
            else
            {
                InfoUser.set_DDD(ddd_default);
            }


            Thread.Sleep(100);

            status = true;
            isClosed = true;
            ThisClose();
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckSsMissingDate();
        }
        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosed)
            {
                e.Cancel = true;
            }
        }

        private void SplashScreen_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != estado)
            {
                switch (estado)
                {
                    case FormWindowState.Minimized:
                        ThisHide();
                        break;
                    case FormWindowState.Normal:
                        ThisShow();
                        break;
                }
            }
        }
    }
}
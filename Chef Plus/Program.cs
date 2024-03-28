using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ChefPlus.core;
using ChefPlus.data;
using System.ComponentModel;
using System.IO;
using Ini;
using System.Threading.Tasks;

namespace Chef_Plus
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>

        delegate void SThisHide();
        delegate void SThisShow();
        [STAThread]
        static void Main()
        {

            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;

            SplashScreen frmSplash = new SplashScreen();
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    InfoUser.MessageBoxShow("O programa já está aberto!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                frm_principal.file_config = @System.Environment.CurrentDirectory + @"\CONFIG.ini";

                if (!File.Exists(frm_principal.file_config))
                {
                    InfoUser.MessageBoxShow("Arquivo de configuração não encontrado. Não é possível iniciar o sistema sem ele.\r\n\r\nEntre em contato com o suporte técnico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmSplash.ShowDialog();

                if (frmSplash.status)
                {
                    frmSplash.Close();
                    Application.Run(new frm_principal());
                }
                else
                {
                    if (!frmSplash.NotOpen)
                    {
                        InfoUser.MessageBoxShow("Ocorreu algum erro ao iniciar o programa.\r\n\r\nCaso o problema persista, entre em contao com nossa equipe de suporte imediatamente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                


            }







        }




    }
}

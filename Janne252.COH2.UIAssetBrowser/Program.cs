using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Janne252.COH2.UIAssetBrowser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool bFirstInstance = true;
            using (Mutex pApplicationMutex = new Mutex(true, "Janne252.COH2.UIAssetBrowser", out bFirstInstance))
            {
                // Jos ei ole valmiiksi mutexia samalla nimellä aloittaa normaalisti.
                if (bFirstInstance)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm(args));
                }
                // Muuten lähettää viestin että näytäppäs nyt se ikkuna
                else
                {
                    if (args.Count() == 1)
                        File.WriteAllText(MainForm.GetLoadArgsPath(), args[0]);
                    else
                        File.WriteAllText(MainForm.GetLoadArgsPath(), "");

                    NativeMethods.PostMessage(new IntPtr(NativeMethods.HWND_BROADCAST), MainForm.ShowMainFormMessageIdentifier, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }
    }
}

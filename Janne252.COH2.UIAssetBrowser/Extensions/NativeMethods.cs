using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Janne252.COH2.UIAssetBrowser
{
    public static class NativeMethods
    {
        /// <summary>
        /// Global broadcast window handle.
        /// </summary>
        public static Int32 HWND_BROADCAST = 0xFFFF;

        /// <summary>
        /// Registers a new window message identifier type.
        /// </summary>
        /// <param name="sMessage">The name of the message identifier type.</param>
        /// <returns>The window message identifier numeral if succeeded, zero otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern Int32 RegisterWindowMessage(String sMessage);


        /// <summary>
        /// Posts an message to the specified window.
        /// </summary>
        /// <param name="hWindow">The window to post the message to.</param>
        /// <param name="nMessage">The message type identifier.</param>
        /// <param name="wParam">The wide parameter of the message.</param>
        /// <param name="lParam">The long parameter of the message.</param>
        /// <returns>True if the function call succeeds, false otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern Boolean PostMessage(IntPtr hWindow, Int32 nMessage, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;

        public static void Restore(this Form form)
        {
            if (form.WindowState == FormWindowState.Minimized || true)
            {
                ShowWindow(form.Handle, SW_RESTORE);
            }
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }
}

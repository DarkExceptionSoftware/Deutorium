using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsApplication1
{
    public class ColorDialogEx : ColorDialog
    {
        private const Int32 WM_INITDIALOG = 0x0110;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowText(IntPtr hWnd, string text);

        private string _Title;

        public ColorDialogEx(string Title)
          : base()
        {
            _Title = Title;
        }

        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
        {
            if (msg == WM_INITDIALOG)
                SetWindowText(hWnd, _Title);

            return base.HookProc(hWnd, msg, wparam, lparam);
        }
    }
}
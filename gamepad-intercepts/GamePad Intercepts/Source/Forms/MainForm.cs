using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApiLibrary;

namespace GamePad_Intercepts.Forms
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;

            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 4;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 3 / 4;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public new void Show()
        {
            base.Show();

            User32.SetWindowPos(Handle, User32.HWND_BOTTOM, 0, 0, 0, 0, User32.SWP_NOMOVE | User32.SWP_NOSIZE | User32.SWP_NOACTIVATE);
        }
    }
}

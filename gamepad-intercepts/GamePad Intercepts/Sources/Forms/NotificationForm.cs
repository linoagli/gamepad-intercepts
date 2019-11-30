using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinApiLibrary;

namespace GamePad_Intercepts.Forms
{
    public partial class NotificationForm : Form
    {
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= User32.WS_EX_TOPMOST;
                createParams.ExStyle |= User32.WS_EX_NOACTIVATE;

                return createParams;
            }
        }

        public NotificationForm()
        {
            InitializeComponent();

            this.Opacity = .9;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - this.Height - 100);
        }

        public new void Show()
        {
            // Setting this form's window as topmost
            User32.SetWindowPos(this.Handle, User32.HWND_TOPMOST, 0, 0, 0, 0, User32.SWP_NOACTIVATE | User32.SWP_NOMOVE | User32.SWP_NOSIZE);

            // Showing the form's window
            base.Show();
        }

        public void ShowWithMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    labelMessage.Text = message;
                    Show();
                }));
            }
            else
            {
                labelMessage.Text = message;
                Show();
            }
        }

        public void HideMessage()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    labelMessage.Text = null;
                    Hide();
                }));
            }
            else
            {
                labelMessage.Text = null;
                Hide();
            }
        }
    }
}

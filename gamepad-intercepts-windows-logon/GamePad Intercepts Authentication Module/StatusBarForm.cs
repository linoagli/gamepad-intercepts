using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts_Authentication_Module
{
    partial class StatusBarForm : Form
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
                createParams.ExStyle |= 0x00000008; // WS_EX_TOPMOST
                createParams.ExStyle |= 0x08000000; // WS_EX_NOACTIVATE

                return createParams;
            }
        }

        public StatusBarForm()
        {
            InitializeComponent();

            this.Disposed += StatusBarForm_Disposed;

            this.Opacity = .9;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, Screen.PrimaryScreen.Bounds.Height - this.Height - 20);

            MessageBus.Bus.Instance.Subscribe<string>(this, HandleMessageBusMessages);
        }

        private void HandleMessageBusMessages(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                if (message == MessageBusEvents.CONTROLLER_SEARCHING)
                {
                    this.label_message.Text = "Searching for a Gamepad...";
                }
                else if (message == MessageBusEvents.CONTROLLER_CONNECTED)
                {
                    this.label_message.Text = "Gamepad connected";
                }
            });
        }

        private void StatusBarForm_Disposed(object sender, EventArgs e)
        {
            MessageBus.Bus.Instance.Unsubscribe(this);
        }
    }
}

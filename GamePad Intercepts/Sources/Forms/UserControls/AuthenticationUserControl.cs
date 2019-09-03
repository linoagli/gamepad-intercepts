using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts.Forms.UserControls
{
    public partial class AuthenticationUserControl : MetroFramework.Controls.MetroUserControl
    {
        public const string TAG = "Authentication";

        private const string OVERRIDE_CODE = "override"; // TODO: dev escape. remove! Also, figure out recovery system...

        public AuthenticationUserControl()
        {
            InitializeComponent();
        }

        private void metroTextBox_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) metroButton_login.PerformClick();
        }

        private void metroButton_login_Click(object sender, EventArgs e)
        {
            bool didLogin =
                metroTextBox_password.Text == OVERRIDE_CODE ||
                App.MissionControl.CheckAgainstAccountPassword(metroTextBox_password.Text);

            if (didLogin)
            {
                App.MissionControl.IsAuthenticated = true;
                MessageBus.Bus.Instance.Publish(new UIEvent { Action = UIEvent.EventAction.ShowHomeScreen });
            }
            else
            {
                App.MissionControl.ShowNotification("Invalid password...");
            }
        }
    }
}

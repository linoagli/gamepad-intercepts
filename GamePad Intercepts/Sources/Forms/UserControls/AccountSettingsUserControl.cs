using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace GamePad_Intercepts.Forms.UserControls
{
    public partial class AccountSettingsUserControl : MetroFramework.Controls.MetroUserControl
    {
        public const string TAG = "Account Settings";

        private string tentativePassword;

        public AccountSettingsUserControl()
        {
            InitializeComponent();

            metroTextBox_accountName.Enabled = false; // TODO: re-enable after adding account name customization feature
        }

        public void Initialize()
        {
            metroTextBox_accountName.Text = "";
            metroTextBox_password.Text = null;

            metroLabel_accountNameConfigInstructions.Text = "Update your account display name";
            metroLabel_passwordConfigInstructions.Text = "Enter a new password";

            tentativePassword = null;
        }

        private void metroTextBox_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) metroButton_save.PerformClick();
        }

        private void metroButton_save_Click(object sender, EventArgs e)
        {
            if (tentativePassword == null)
            {
                tentativePassword = metroTextBox_password.Text;
                metroTextBox_password.Text = null;

                metroLabel_passwordConfigInstructions.Text = "Re-enter the password to confirm it.";
            }
            else
            {
                if (metroTextBox_password.Text == tentativePassword)
                {
                    if (tentativePassword.Length < 1)
                    {
                        App.MissionControl.SetAccountPassword(null);
                        App.MissionControl.ShowNotification("Password cleared!!");
                    }
                    else
                    {
                        App.MissionControl.SetAccountPassword(tentativePassword);
                        App.MissionControl.ShowNotification("Password saved!");
                    }
                }
                else
                {
                    App.MissionControl.ShowNotification("The passwords don't match. Try again.");
                }

                Initialize();
            }
        }
    }
}

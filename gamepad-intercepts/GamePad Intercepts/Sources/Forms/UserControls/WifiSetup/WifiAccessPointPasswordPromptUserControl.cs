using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWifi;

namespace GamePad_Intercepts.Forms.UserControls.WifiSetup
{
    public partial class WifiAccessPointPasswordPromptUserControl : MetroFramework.Controls.MetroUserControl
    {
        private WifiSetupUserControl parent;
        private AccessPoint accessPoint;

        public WifiAccessPointPasswordPromptUserControl() : this(null)
        {
            //
        }

        public WifiAccessPointPasswordPromptUserControl(WifiSetupUserControl parent)
        {
            this.parent = parent;

            InitializeComponent();
        }

        public void PromptWith(AccessPoint accessPoint)
        {
            this.accessPoint = accessPoint;
            this.metroLabel_accessPointName.Text = accessPoint.Name;
            this.metroTextBox_password.Text = "";
        }

        private void metroButton_connect_Click(object sender, EventArgs e)
        {
            parent.ConnectToAccessPoint(accessPoint, metroTextBox_password.Text);
        }
    }
}

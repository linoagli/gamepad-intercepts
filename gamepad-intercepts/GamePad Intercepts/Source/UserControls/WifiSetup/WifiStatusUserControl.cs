using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts.UserControls.WifiSetup
{
    public partial class WifiStatusUserControl : MetroFramework.Controls.MetroUserControl
    {
        private WifiSetupUserControl parent;

        public WifiStatusUserControl() : this(null)
        {
            //
        }

        public WifiStatusUserControl(WifiSetupUserControl parent)
        {
            this.parent = parent;

            InitializeComponent();
        }

        public void UpdateStatus()
        {
            bool isConnectedToANetwork = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            var currentConnectedAP = WifiManager.GetCurrentConnectedAccessPoint();

            if (isConnectedToANetwork)
            {
                string status = (currentConnectedAP != null)
                    ? "Connected to " + currentConnectedAP.Name
                    : "Wired connection active.";

                metroLabel_status.Text = status;
            }
            else metroLabel_status.Text = "No internet connection";

            if (currentConnectedAP != null)
            {
                metroButton_disconnect.Text = "Disconnect from " + currentConnectedAP.Name;
                metroButton_disconnect.Enabled = true;
            }
            else
            {
                metroButton_disconnect.Text = "No Wifi Connection";
                metroButton_disconnect.Enabled = false;
            }
        }

        private void metroButton_disconnect_Click(object sender, EventArgs e)
        {
            WifiManager.Disconnect();
            UpdateStatus();
        }

        private void metroButton_connect_Click(object sender, EventArgs e)
        {
            parent.StartWifiSetupWizard();
        }
    }
}

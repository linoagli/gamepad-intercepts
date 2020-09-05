using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using SimpleWifi;
using GamePad_Intercepts.UserControls.WifiSetup;

namespace GamePad_Intercepts.UserControls
{
    public partial class WifiSetupUserControl : UserControl
    {
        public const string TAG = "Wifi Setup";

        private WifiSetupProgressUserControl userControl_wifiSetupProgress;
        private WifiStatusUserControl userControl_wifiStatus;
        private WifiAccessPointListUserControl userControl_wifiAccessPointList;
        private WifiAccessPointPasswordPromptUserControl userControl_wifiAccessPointPasswordPrompt;

        private WindowsFormsSynchronizationContext synchronizationContext;

        public WifiSetupUserControl()
        {
            userControl_wifiSetupProgress = new WifiSetupProgressUserControl();
            userControl_wifiSetupProgress.Tag = new UserControlMetaData(" > Processing...", null);

            userControl_wifiStatus = new WifiStatusUserControl(this);
            userControl_wifiStatus.Tag = new UserControlMetaData(" > Status", null);

            userControl_wifiAccessPointList = new WifiAccessPointListUserControl(this);
            userControl_wifiAccessPointList.Tag = new UserControlMetaData(" > Select a Wifi Network", userControl_wifiStatus);

            userControl_wifiAccessPointPasswordPrompt = new WifiAccessPointPasswordPromptUserControl(this);
            userControl_wifiAccessPointPasswordPrompt.Tag = new UserControlMetaData(" > Wifi Network Authentication", userControl_wifiAccessPointList);

            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;

            InitializeComponent();
        }

        public void ShowWifiStatus()
        {
            userControl_wifiStatus.UpdateStatus();
            ShowUserControl(userControl_wifiStatus);
        }

        public void StartWifiSetupWizard()
        {
            userControl_wifiAccessPointList.LoadAccessPoints();
            ShowUserControl(userControl_wifiAccessPointList);
        }

        public void ConnectToAccessPoint(AccessPoint accessPoint, string password = null)
        {
            userControl_wifiSetupProgress.SetMessage("Connecting to " + accessPoint.Name + "...");
            ShowUserControl(userControl_wifiSetupProgress);

            if (WifiManager.ConnectionRequiresPassword(accessPoint))
            {
                if (password == null)
                {
                    userControl_wifiAccessPointPasswordPrompt.PromptWith(accessPoint);
                    ShowUserControl(userControl_wifiAccessPointPasswordPrompt);
                }
                else WifiManager.Connect(accessPoint, password, wifi_onConnectedComplete);
            }
            else WifiManager.Connect(accessPoint, null, wifi_onConnectedComplete);
        }

        private void ShowUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;

            metroPanel_controlsContainer.Controls.Clear();
            metroPanel_controlsContainer.Controls.Add(userControl);

            //Text = TITLE_BASE + (userControl.Tag as UserControlMetaData).breadcrumb;
        }

        private void wifi_onConnectedComplete(bool success)
        {
            synchronizationContext.Post(delegate
            {
                if (success) userControl_wifiSetupProgress.SetMessage("Connection successful!", ShowWifiStatus);
                else userControl_wifiSetupProgress.SetMessage("Failed to connect. Please try again.", StartWifiSetupWizard);
            }, null);
        }

        private void metroLink_back_Click(object sender, EventArgs e)
        {
            UserControlMetaData metaData = metroPanel_controlsContainer.Controls[0].Tag as UserControlMetaData;

            if (metaData.backUserControl != null) ShowUserControl(metaData.backUserControl);
        }
    }
}

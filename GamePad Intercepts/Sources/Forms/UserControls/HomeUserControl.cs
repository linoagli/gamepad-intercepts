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

namespace GamePad_Intercepts.Forms.UserControls
{
    public partial class HomeUserControl : UserControl
    {
        private WindowsFormsSynchronizationContext synchronizationContext;

        public HomeUserControl()
        {
            InitializeComponent();

            synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
        }

        public void UpdatePowerStatusDisplay(string powerStatusText)
        {
            synchronizationContext.Post(delegate
            {
                metroLabel_powerStatus.Text = powerStatusText;
            }, null);
        }

        public void UpdateNetworkStatusDisplay(string networkStatusText)
        {
            synchronizationContext.Post(delegate
            {
                metroLabel_networkStatus.Text = networkStatusText;
            }, null);
        }
        
        public void UpdateSystemVolumeStatusDisplay(string volumeStatusText)
        {
            synchronizationContext.Post(delegate
            {
                metroLabel_systemVolumeStatus.Text = volumeStatusText;
            }, null);
        }

        private void metroTile_launchGamePlatform_Click(object sender, EventArgs e)
        {
            App.MessageCenter.StartGamesPlatformLauncher();
        }

        private void metroTile_webBrowser_Click(object sender, EventArgs e)
        {
            App.MessageCenter.ShowWebBrowser();
        }

        private void metroTile_wifiSettings_Click(object sender, EventArgs e)
        {
            App.MessageCenter.ShowWifiSettings();
        }
    }
}

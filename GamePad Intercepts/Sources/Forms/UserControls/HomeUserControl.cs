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
using System.Diagnostics;
using WinApi;

namespace GamePad_Intercepts.Forms.UserControls
{
    public partial class HomeUserControl : UserControl
    {
        public const string TAG = "Home";

        private WindowsFormsSynchronizationContext synchronizationContext;

        public HomeUserControl()
        {
            synchronizationContext = (WindowsFormsSynchronizationContext)SynchronizationContext.Current;

            InitializeComponent();

            MessageBus.Bus.Instance.Subscribe<SystemStatusUpdateEvent>(this, OnSystemStatusUpdateEvent);
        }

        private void OnSystemStatusUpdateEvent(SystemStatusUpdateEvent message)
        {
            synchronizationContext.Post(delegate
            {
                if (message.BatteryPercent != -1)
                    metroLabel_powerStatus.Text = "Power Level: " + message.BatteryPercent.ToString() + "%";

                if (message.SystemVolumePercent != -1)
                    metroLabel_systemVolumeStatus.Text = "System Volume: " + message.SystemVolumePercent.ToString() + "%";

                if (message.WifiStatus != null)
                    metroLabel_networkStatus.Text = "Wifi Status: " + message.WifiStatus;
            }, null);
        }

        private void metroTile_soundSettings_Click(object sender, EventArgs e)
        {
            Process process = Process.Start("mmsys.cpl");
            process.WaitForInputIdle(3000);

            MessageBus.Bus.Instance.Publish(new UIEvent() { Action = UIEvent.EventAction.HideHomeScreen });
        }

        private void metroTile_powerOptions_Click(object sender, EventArgs e)
        {
            // TODO: Wrap inside a confirmation dialog
            Process.Start("shutdown", "/s /t 5");
            App.MissionControl.ShowNotification("System shutting down. Goodbye!");
        }
        private void metroTile_wifiSettings_Click(object sender, EventArgs e)
        {
            MessageBus.Bus.Instance.Publish(new UIEvent { Action = UIEvent.EventAction.ShowWifiSettings });
        }

        private void metroTile_webBrowser_Click(object sender, EventArgs e)
        {
            MessageBus.Bus.Instance.Publish(new UIEvent { Action = UIEvent.EventAction.ShowWebBrowser });
        }

        private void metroTile_launchGamePlatform_Click(object sender, EventArgs e)
        {
            App.MissionControl.StartGamesPlatformLauncher();
        }
    }
}

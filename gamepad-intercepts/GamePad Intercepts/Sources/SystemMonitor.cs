using GamePad_Intercepts.Forms.UserControls;
using SimpleWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GamePad_Intercepts
{
    class SystemMonitor
    {
        private int currentBatteryPercent = -1;
        private int currentSystemVolumePercent = -1;
        private string currentWifiStatus = null;

        public SystemMonitor()
        {
            
        }

        public void Run()
        {
            new Thread(delegate ()
            {
                Console.WriteLine("Starting system monitor loop...");

                while (true)
                {
                    // Updating all system info
                    UpdatePowerStatusInfo();
                    UpdateSystemVolumeInfo();
                    UpdateWifiStatusInfo();

                    // Taking a break
                    Thread.Sleep(1000 * 5);
                }
            }).Start();
        }

        public void Stop()
        {
            //
        }

        public void UpdatePowerStatusInfo()
        {
            int batteryPercent = -1;
            try
            {
                batteryPercent = (int) (SystemInformation.PowerStatus.BatteryLifePercent * 100);
            }
            catch (Exception e)
            {
                //
            }

            if (currentBatteryPercent != batteryPercent)
            {
                currentBatteryPercent = batteryPercent;
                //TimeSpan batteryTime = TimeSpan.FromSeconds(SystemInformation.PowerStatus.BatteryLifeRemaining);
                //string powerInfo = batteryPercent.ToString() + "% (" + batteryTime.Hours + " hrs " + batteryTime.Minutes + " mins)";

                MessageBus.Bus.Instance.Publish(new SystemStatusUpdateEvent() { BatteryPercent = batteryPercent });
                App.MissionControl.ShowNotification("Battery Level Changed:\n" + batteryPercent.ToString() + "%");
            }
        }

        public void UpdateSystemVolumeInfo()
        {
            int systemVolumePercent = -1;
            try
            {
                systemVolumePercent = (int) (SystemAudio.GetMasterVolumeLevel() * 100);
            }
            catch (Exception e)
            {
                //
            }

            if (currentSystemVolumePercent != systemVolumePercent)
            {
                currentSystemVolumePercent = systemVolumePercent;

                MessageBus.Bus.Instance.Publish(new SystemStatusUpdateEvent() { SystemVolumePercent = systemVolumePercent });
                App.MissionControl.ShowNotification("Volume Changed:\n" + systemVolumePercent.ToString() + "%");
            }
        }

        public void UpdateWifiStatusInfo()
        {
            string wifiStatus = null;
            try
            {
                bool isConnectedToANetwork = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                var currentConnectedAP = WifiManager.GetCurrentConnectedAccessPoint();

                if (isConnectedToANetwork)
                {
                    wifiStatus += (currentConnectedAP != null)
                        ? "Connected to " + currentConnectedAP.Name
                        : "Wired Connection Active.";
                }
                else wifiStatus += "No Internet Connection";
            }
            catch (Exception e)
            {
                //
            }

            if (currentWifiStatus != wifiStatus)
            {
                currentWifiStatus = wifiStatus;

                MessageBus.Bus.Instance.Publish(new SystemStatusUpdateEvent() { WifiStatus = wifiStatus });
                App.MissionControl.ShowNotification("Network Status Changed:\n" + currentWifiStatus);
            }
        }
    }
}

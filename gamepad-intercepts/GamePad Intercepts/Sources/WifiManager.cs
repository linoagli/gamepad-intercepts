using SimpleWifi;
using SimpleWifi.Win32;
using SimpleWifi.Win32.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts
{
    class WifiManager
    {
        private static Wifi wifi;

        static WifiManager()
        {
            wifi = new Wifi();
        }

        public static AccessPoint GetCurrentConnectedAccessPoint()
        {
            return wifi.GetAccessPoints().FirstOrDefault(ap => ap.IsConnected == true);
        }

        public static IEnumerable<AccessPoint> GetAccessPoints()
        {
            // Work around for a more accurate list of access points.
            // Source: I found there was an odd issue with this approach. it seemed as if AP info
            // would “trickle” in over time; the second time I opened the menu there would be 
            // more access points. I don’t know why that was, but I added a bit of extra code with
            // the intent of providing a larger set of “seed” networks when the menu is opened for
            // the first time. It seems like the act of inspecting Access Points causes more to be
            // actually added.
            // (https://bc-programming.com/blogs/2017/01/retrieving-wifi-access-point-information-in-c/)
            WlanClient wlanClient = new WlanClient();
            foreach (WlanInterface wlanInterface in wlanClient.Interfaces)
            {
                Dictionary<string, WlanProfileInfo> profileData = new Dictionary< string, WlanProfileInfo>();

                foreach (var profile in wlanInterface.GetProfiles())
                {
                    profileData.Add(profile.profileName, profile);
                }

                foreach (WlanAvailableNetwork network in wlanInterface.GetAvailableNetworkList(0))
                {
                    WlanProfileInfo wlanProfileInfo;
                    if (profileData.ContainsKey(network.profileName))
                    {
                        wlanProfileInfo = profileData[network.profileName];
                    }
                }
            }

            // Actually retrieving the list of access points
            return wifi.GetAccessPoints().OrderByDescending(ap => ap.SignalStrength);
        }

        public static bool ConnectionRequiresPassword(AccessPoint accessPoint)
        {
            return !accessPoint.HasProfile && new AuthRequest(accessPoint).IsPasswordRequired;
        }

        public static bool Connect(AccessPoint accessPoint)
        {
            return accessPoint.Connect(new AuthRequest(accessPoint));
        }

        public static bool Connect(AccessPoint accessPoint, String password = null, Action<bool> onCompleteCallback = null)
        {
            var authRequest = new AuthRequest(accessPoint);
            var overwriteProfile = authRequest.IsPasswordRequired && !accessPoint.HasProfile;

            if (overwriteProfile) authRequest.Password = password;

            if (onCompleteCallback != null)
            {
                accessPoint.ConnectAsync(authRequest, overwriteProfile, onCompleteCallback);
                return true;
            }
            else return accessPoint.Connect(authRequest, overwriteProfile);
        }

        public static void Disconnect()
        {
            wifi.Disconnect();
        }

        public static void AddConnectionStatusChangedEventHandler(EventHandler<WifiStatusEventArgs> eventHandler)
        {
            wifi.ConnectionStatusChanged += eventHandler;
        }

        public static void RemoveConnectionStatusChangedEventHandler(EventHandler<WifiStatusEventArgs> eventHandler)
        {
            wifi.ConnectionStatusChanged -= eventHandler;
        }
    }
}

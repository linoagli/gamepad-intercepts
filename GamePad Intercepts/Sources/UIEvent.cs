using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts
{
    class UIEvent
    {
        public enum EventAction
        {
            ToggleHomeScreen, ShowHomeScreen, HideHomeScreen,
            ShowAccountSettings, ShowWifiSettings,
            ShowWebBrowser
        }

        public EventAction Action { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts
{
    class SystemStatusUpdateEvent
    {
        public int BatteryPercent { get; set; } = -1;
        public int SystemVolumePercent { get; set; } = -1;
        public string WifiStatus { get; set; } = null;
    }
}

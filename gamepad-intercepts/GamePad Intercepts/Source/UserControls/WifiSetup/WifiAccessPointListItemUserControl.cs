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

namespace GamePad_Intercepts.UserControls.WifiSetup
{
    public partial class WifiAccessPointListItemUserControl : MetroFramework.Controls.MetroUserControl
    {
        private AccessPoint accessPoint;
        private WifiAccessPointListUserControl userControl_wifiAccessPointList;

        public WifiAccessPointListItemUserControl() : this(null, null)
        {
            //
        }

        public WifiAccessPointListItemUserControl(AccessPoint accessPoint, WifiAccessPointListUserControl userControl)
        {
            this.accessPoint = accessPoint;
            this.userControl_wifiAccessPointList = userControl;

            InitializeComponent();

            StringBuilder stringBuilder = new StringBuilder()
               .Append(accessPoint.Name)
               .Append("\n")
               .Append(accessPoint.IsSecure ? "Secured" : "Open")
               .Append("\n")
               .Append("Signal Strenth: ").Append(accessPoint.SignalStrength).Append(" %");

            metroTile_accessPointButton.Text = stringBuilder.ToString();
        }

        private void metroTile_accessPointButton_Click(object sender, EventArgs e)
        {
            userControl_wifiAccessPointList.ConnectToAccessPoint(accessPoint);
        }
    }
}

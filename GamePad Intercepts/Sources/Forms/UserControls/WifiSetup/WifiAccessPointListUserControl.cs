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
    public partial class WifiAccessPointListUserControl : MetroFramework.Controls.MetroUserControl
    {
        private WifiSetupUserControl parent;

        public WifiAccessPointListUserControl() : this(null)
        {
            //
        }

        public WifiAccessPointListUserControl(WifiSetupUserControl parent)
        {
            this.parent = parent;

            InitializeComponent();
        }

        public void LoadAccessPoints()
        {
            flowLayoutPanel_accessPointList.Controls.Clear();

            foreach (AccessPoint accessPoint in WifiManager.GetAccessPoints())
                flowLayoutPanel_accessPointList.Controls.Add(new WifiAccessPointListItemUserControl(accessPoint, this));
        }

        public void ConnectToAccessPoint(AccessPoint accessPoint)
        {
            parent.ConnectToAccessPoint(accessPoint);
        }

        private void flowLayoutPanel_accessPointList_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel senderObject = (FlowLayoutPanel) sender;

            foreach (Control control in senderObject.Controls)
                control.Width = senderObject.ClientSize.Width - control.Margin.Horizontal;
        }
    }
}

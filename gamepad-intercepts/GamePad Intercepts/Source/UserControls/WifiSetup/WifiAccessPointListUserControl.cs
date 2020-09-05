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

            try
            {
                foreach (AccessPoint accessPoint in WifiManager.GetAccessPoints())
                {
                    WifiAccessPointListItemUserControl control = new WifiAccessPointListItemUserControl(accessPoint, this);
                    ResizeChildControl(control);
                    flowLayoutPanel_accessPointList.Controls.Add(control);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to load access points: " + e.Message);
            }
        }

        private void ResizeChildControl(UserControl control)
        {
            control.Width = flowLayoutPanel_accessPointList.Width - control.Margin.Horizontal - 20;
        }

        public void ConnectToAccessPoint(AccessPoint accessPoint)
        {
            parent.ConnectToAccessPoint(accessPoint);
        }

        private void flowLayoutPanel_accessPointList_Resize(object sender, EventArgs e)
        {
            foreach (UserControl control in ((FlowLayoutPanel)sender).Controls) ResizeChildControl(control);
        }

        private void metroLink_refresh_Click(object sender, EventArgs e)
        {
            LoadAccessPoints();
        }
    }
}

using GamePad_Intercepts.Forms.UserControls;
using GamePad_Intercepts.Forms.UserControls.WifiSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApi;
using WindowsInput;

namespace GamePad_Intercepts.Forms
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private const string BREADCRUMB_BASE = "GamePad Intercepts";

        public HomeUserControl HomeUserControl { get; private set; }
        public WebBrowserUserControl WebBrowserUserControl { get; private set; }
        public WifiSetupUserControl WifiSetupUserControl { get; private set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= User32.WS_EX_TOPMOST;

                return createParams;
            }
        }

        public MainForm()
        {
            HomeUserControl = new HomeUserControl();
            HomeUserControl.Tag = "Home";

            WebBrowserUserControl = new WebBrowserUserControl();
            WebBrowserUserControl.ConfigureBrowser();
            WebBrowserUserControl.Tag = "Browser";

            WifiSetupUserControl = new WifiSetupUserControl();
            WifiSetupUserControl.Tag = "WifiSetup";

            InitializeComponent();

            this.Width = (int) (Screen.PrimaryScreen.Bounds.Width);
            this.Height = (int) (Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point(0, 0);
        }

        public new void Show()
        {
            base.Show();
            App.MessageCenter.EnableControllerMouseKeyboardEmulation();

            Cursor = Cursors.Hand;
        }

        public new void Hide()
        {
            App.MessageCenter.DisableControllerMouseKeyboardEmulation();
            base.Hide();
        }

        public void ShowHomeUserControl()
        {
            ShowUserControl(HomeUserControl);
        }

        public void ShowWebBrowserUserControl()
        {
            WebBrowserUserControl.ShowBrowser();
            ShowUserControl(WebBrowserUserControl);
        }

        public void ShowWifiSetupUserControl()
        {
            WifiSetupUserControl.ShowWifiStatus();
            ShowUserControl(WifiSetupUserControl);
        }

        private void ShowUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;

            metroPanel_controlsContainer.Controls.Clear();
            metroPanel_controlsContainer.Controls.Add(userControl);

            metroLabel_breadcrumb.Text = BREADCRUMB_BASE + " > " + (userControl.Tag as string);

            userControl.Focus();

            if (userControl.Tag.ToString() == HomeUserControl.Tag.ToString()) metroLink_back.Visible = false;
            else if (userControl.Tag.ToString() == WebBrowserUserControl.Tag.ToString()) metroLink_back.Visible = true;
            else if (userControl.Tag.ToString() == WifiSetupUserControl.Tag.ToString()) metroLink_back.Visible = true;
        }

        private void metroLink_back_Click(object sender, EventArgs e)
        {
            string currentControlTag = metroPanel_controlsContainer.Controls[0].Tag.ToString();

            if (currentControlTag == WebBrowserUserControl.Tag.ToString()) ShowHomeUserControl();

            if (currentControlTag == WifiSetupUserControl.Tag.ToString()) ShowHomeUserControl();
        }

        private void metroLink_close_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}

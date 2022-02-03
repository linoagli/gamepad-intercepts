using GamePad_Intercepts.UserControls;
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
using WinApiLibrary;

namespace GamePad_Intercepts.Forms
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private const string BREADCRUMB_BASE = "GamePad Intercepts";

        private WindowsFormsSynchronizationContext synchronizationContext;
        
        private HomeUserControl homeUserControl;
        private WifiSetupUserControl wifiSetupUserControl;

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
            synchronizationContext = (WindowsFormsSynchronizationContext)SynchronizationContext.Current;

            homeUserControl = new HomeUserControl();
            wifiSetupUserControl = new WifiSetupUserControl();

            InitializeComponent();

            MessageBus.Bus.Instance.Subscribe<UIEvent>(this, OnUIEvent);

            //this.Width = (int) (Screen.PrimaryScreen.Bounds.Width);
            //this.Height = (int) (Screen.PrimaryScreen.Bounds.Height);
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        public new void Show()
        {
            base.Show();

            App.MissionControl.EnableControllerMouseKeyboardEmulation();
        }

        public new void Hide()
        {
            App.MissionControl.DisableControllerMouseKeyboardEmulation();

            base.Hide();
        }

        private void ToggleHomeScreen()
        {
            if (Visible) HideHomeScreen();
            else ShowHomeScreen();
        }

        private void ShowHomeScreen()
        {
            ShowUserControl(homeUserControl);
        }

        private void HideHomeScreen()
        {
            // Hiding the home screen really just means hiding the main form
            synchronizationContext.Post(delegate { Hide(); }, null);
        }

        private void ShowUserControl(UserControl userControl)
        {
            synchronizationContext.Post(delegate
            {
                // Making the main form visible if necessary
                if (!Visible)
                {
                    Show();
                    User32.SetForegroundWindow(Handle);
                }

                // Displaying the requested user control
                userControl.Dock = DockStyle.Fill;

                metroPanel_controlsContainer.Controls.Clear();
                metroPanel_controlsContainer.Controls.Add(userControl);
                userControl.Focus();

                // Updating the breadcrumb label text
                //metroLabel_breadcrumb.Text = BREADCRUMB_BASE + " > " + (userControl.Tag as string);

                // Making the back button visible if necessary
                if (userControl is WifiSetupUserControl) metroLink_back.Visible = true;
                else metroLink_back.Visible = false;
            }, null);
        }

        private void OnUIEvent(UIEvent message)
        {
            if (message.Action == UIEvent.EventAction.ToggleHomeScreen) ToggleHomeScreen();
            else if (message.Action == UIEvent.EventAction.ShowHomeScreen) ShowHomeScreen();
            else if (message.Action == UIEvent.EventAction.HideHomeScreen) HideHomeScreen();
            else if (message.Action == UIEvent.EventAction.ShowWifiSettings)
            {
                wifiSetupUserControl.ShowWifiStatus();
                ShowUserControl(wifiSetupUserControl);
            }
        }

        private void metroLink_back_Click(object sender, EventArgs e)
        {
            UserControl currentControl = metroPanel_controlsContainer.Controls[0] as UserControl;

            if (!(currentControl is HomeUserControl)) ShowHomeScreen();
        }

        private void metroLink_close_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}

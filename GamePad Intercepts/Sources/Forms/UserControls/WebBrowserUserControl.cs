using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;

namespace GamePad_Intercepts.Forms.UserControls
{
    public partial class WebBrowserUserControl : MetroFramework.Controls.MetroUserControl
    {
        public const string TAG = "Browser";

        private ChromiumWebBrowser chromeBrowser;

        public WebBrowserUserControl()
        {
            InitializeComponent();
            ConfigureBrowser();
        }

        public async void ConfigureBrowser()
        {
            CefSettings settings = new CefSettings();
            settings.CachePath = App.PATH_DIRECTORY_BROWSER_CACHE;
            settings.CefCommandLineArgs.Add("enable-media-stream", "1"); // Enables WebRTC
            settings.CefCommandLineArgs.Add("debug-plugin-loading", "1"); // Dumps extra logging about plugin loading to the log file.
            settings.CefCommandLineArgs.Add("persist_session_cookies", "1");

            Cef.Initialize(settings);

            foreach (var i in (await Cef.GetPlugins())) Console.WriteLine(i.Description);

            chromeBrowser = new ChromiumWebBrowser("https://www.google.com/");
            chromeBrowser.AddressChanged += chromeBrowser_AddressChanged;
        }

        public void ShowBrowser()
        {
            chromeBrowser.Dock = DockStyle.Fill;
            metroPanel_browserContainer.Controls.Clear();
            metroPanel_browserContainer.Controls.Add(chromeBrowser);
        }

        private void DestroyBrowser()
        {
            Cef.Shutdown();
        }

        private void chromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate () { metroTextBox_url.Text = e.Address; }));
        }

        private void metroTextBox_url_KeyUp(object sender, KeyEventArgs e)
        {
            if (metroTextBox_url.Text == null) return;

            if (e.KeyCode == Keys.Return)
            {
                chromeBrowser.Load(metroTextBox_url.Text);
                metroPanel_browserContainer.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                metroPanel_browserContainer.Focus();
            }
        }

        private void metroLink_back_Click(object sender, EventArgs e)
        {
            chromeBrowser.Back();
        }
    }
}

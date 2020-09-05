using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts.UserControls.WifiSetup
{
    public partial class WifiSetupProgressUserControl : MetroFramework.Controls.MetroUserControl
    {
        private Action onDoneClickedCallback;

        public WifiSetupProgressUserControl()
        {
            InitializeComponent();
        }

        public void SetMessage(string message, Action onDoneClickedCallback = null)
        {
            metroLabel_message.Text = message;
            metroButton_done.Visible = onDoneClickedCallback != null;
            this.onDoneClickedCallback = onDoneClickedCallback;
        }

        private void metroButton_done_Click(object sender, EventArgs e)
        {
            onDoneClickedCallback();
        }
    }
}

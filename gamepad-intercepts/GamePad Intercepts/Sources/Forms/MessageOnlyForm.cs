using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApiLibrary;

namespace GamePad_Intercepts.Forms
{
    public partial class MessageOnlyForm : Form
    {
        private WindowsFormsSynchronizationContext synchronizationContext;

        public MessageOnlyForm()
        {
            var accessHandle = this.Handle; // Necessary to trigger the call to OnHandleCreated

             synchronizationContext = (WindowsFormsSynchronizationContext) SynchronizationContext.Current;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Changing window to message only window
            User32.SetParent(this.Handle, User32.HWND_MESSAGE);
        }

        protected override void WndProc(ref Message message)
        {
            /*
            switch (message.Msg)
            {
                case WM_KEYDOWN:
                    break;

                case WM_INPUT:
                    break;
            }
            */

            base.WndProc(ref message);
        }

        public void AltF4()
        {
            synchronizationContext.Post(delegate
            {
                SendKeys.Send("%{F4}");
            }, null);
        }

        public void AltTab()
        {
            synchronizationContext.Post(delegate
            {
                SendKeys.Send("%{TAB}");
            }, null);
        }
    }
}

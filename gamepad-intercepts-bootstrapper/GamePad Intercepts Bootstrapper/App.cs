using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts_Bootstrapper
{
    class App : ApplicationContext
    {
        public static readonly string PATH_FILE_GAMEPAD_INTERCEPTS = @"C:\GamePad Intercepts\bin\GamePad Intercepts.exe";
        public static readonly string PATH_FILE_XADDITUS = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"xadditus_app\xadditus_app.exe");

        public App()
        {
            // TODO: implement a heartbeat monitor for the processes

            // Launching GamePad Intercepts as an admin
            ProcessStartInfo gamePadInterceptProcessInfo = new ProcessStartInfo()
            {
                FileName = PATH_FILE_GAMEPAD_INTERCEPTS,
                UseShellExecute = true,
                Arguments = "",
                Verb = "runas"
            };
            Process.Start(gamePadInterceptProcessInfo);

            // Launching Xadditus as an admin
            ProcessStartInfo xadditusProcessInfo = new ProcessStartInfo()
            {
                FileName = PATH_FILE_XADDITUS,
                UseShellExecute = true,
                Arguments = "",
                Verb = "runas"
            };
            Process.Start(xadditusProcessInfo);
        }
    }
}

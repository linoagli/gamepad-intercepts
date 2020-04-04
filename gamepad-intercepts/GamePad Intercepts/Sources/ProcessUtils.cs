using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts
{
    class ProcessUtils
    {
        public static bool IsProcessRunning(Process process)
        {
            if (process == null) return false;

            try
            {
                Process.GetProcessById(process.Id);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}

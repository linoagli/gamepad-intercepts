using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts_Keyboard
{
    internal interface IKey
    {
        KeyConfig Config { get; set; }

        bool IsSelected { get; set; }

        bool IsShiftActivated { get; set; }

        bool IsFnActivated { get; set; }
    }
}

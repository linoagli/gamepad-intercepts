using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts_Keyboard
{
    interface IKeyboard
    {
        void NavigateLeft();

        void NavigateUp();

        void NavigateRight();

        void NavigateDown();

        void PressKey();

        void PressSpacebarKey();

        void PressDeleteKey();

        void PressEnterKey();

        void PressShiftKey();

        void PressSpecialKey();
    }
}

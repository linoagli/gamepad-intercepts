using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts
{
    class ControllerInputEvent
    {
        public enum EventAction
        {
            Left, Up, Right, Down,
            Cross, Circle, Square, Triangle,
            R1, R2, R3, L1, L2, L3,
            Start, Select
        }

        public EventAction Action { get; set; }
    }
}

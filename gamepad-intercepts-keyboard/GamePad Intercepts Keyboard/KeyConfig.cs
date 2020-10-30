using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace GamePad_Intercepts_Keyboard
{
    public class KeyConfig
    {
        public int CoordinateX { get; set; } = -1;
        public int CoordinateY { get; set; } = -1;
        public string Label { get; set; } = "";
        public string ShiftLabel { get; set; } = "";
        public string SpecialLabel { get; set; } = "";
        public string SpecialShiftLabel { get; set; } = "";
        public VirtualKeyCode KeyCode { get; set; }
        public VirtualKeyCode SpecialKeyCode { get; set; }

        public override string ToString()
        {
            return String.Format("Key.Config: coord={0},{1}; label={2}, shiftLabel={3}, specialLabel={4}, specialShiftLabel={5}",
                CoordinateX, CoordinateY, Label, ShiftLabel, SpecialLabel, SpecialShiftLabel);
        }
    }
}

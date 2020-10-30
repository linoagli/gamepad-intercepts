using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInput;
using WindowsInput.Native;

namespace GamePad_Intercepts_Keyboard.WPF
{
    /// <summary>
    /// Interaction logic for KeyboardWPF.xaml
    /// </summary>
    public partial class Keyboard : UserControl, IKeyboard
    {
        private IEnumerable<IKey> keys;
        private IKey selectedKey;
        private InputSimulator inputSimulator;

        public Keyboard()
        {
            inputSimulator = new InputSimulator();

            InitializeComponent();
            ConfigureKeys();

            keys = grid_keys.Children.OfType<IKey>();

            // Defaulting selected key to G (closest to the middle of the board)
            NavigateKeys(key_charG.Config.CoordinateX, key_charG.Config.CoordinateY);
        }

        public void NavigateLeft()
        {
            NavigateKeys(-1, 0);
        }

        public void NavigateUp()
        {
            NavigateKeys(0, -1);
        }

        public void NavigateRight()
        {
            NavigateKeys(1, 0);
        }

        public void NavigateDown()
        {
            NavigateKeys(0, 1);
        }

        public void PressKey()
        {
            if (selectedKey == null)
            {
                return;
            }

            if (selectedKey == specialKey_shift)
            {
                ToggleShift();
            }
            else if (selectedKey == specialKey_specialCharacters)
            {
                ToggleSpecialCharacters();
            }
            else
            {
                SimulateInputForKey(selectedKey);
            }
        }

        public void PressSpacebarKey()
        {
            SimulateInputForKey(specialKey_space);
        }

        public void PressDeleteKey()
        {
            SimulateInputForKey(specialKey_delete);
        }

        public void PressEnterKey()
        {
            SimulateInputForKey(specialKey_enter);
        }

        public void PressShiftKey()
        {
            ToggleShift();
        }

        public void PressSpecialKey()
        {
            ToggleSpecialCharacters();
        }

        private void ConfigureKeys()
        {
            //
            // Num keys row
            //
            key_num1.Config = new KeyConfig
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Label = "1",
                ShiftLabel = "!",
                KeyCode = VirtualKeyCode.VK_1
            };

            key_num2.Config = new KeyConfig
            {
                CoordinateX = 1,
                CoordinateY = 0,
                Label = "2",
                ShiftLabel = "@",
                KeyCode = VirtualKeyCode.VK_2
            };

            key_num3.Config = new KeyConfig
            {
                CoordinateX = 2,
                CoordinateY = 0,
                Label = "3",
                ShiftLabel = "#",
                KeyCode = VirtualKeyCode.VK_3
            };

            key_num4.Config = new KeyConfig
            {
                CoordinateX = 3,
                CoordinateY = 0,
                Label = "4",
                ShiftLabel = "$",
                KeyCode = VirtualKeyCode.VK_4
            };

            key_num5.Config = new KeyConfig
            {
                CoordinateX = 4,
                CoordinateY = 0,
                Label = "5",
                ShiftLabel = "%",
                KeyCode = VirtualKeyCode.VK_5
            };

            key_num6.Config = new KeyConfig
            {
                CoordinateX = 5,
                CoordinateY = 0,
                Label = "6",
                ShiftLabel = "^",
                KeyCode = VirtualKeyCode.VK_6
            };

            key_num7.Config = new KeyConfig
            {
                CoordinateX = 6,
                CoordinateY = 0,
                Label = "7",
                ShiftLabel = "&",
                KeyCode = VirtualKeyCode.VK_7
            };

            key_num8.Config = new KeyConfig
            {
                CoordinateX = 7,
                CoordinateY = 0,
                Label = "8",
                ShiftLabel = "*",
                KeyCode = VirtualKeyCode.VK_8
            };

            key_num9.Config = new KeyConfig
            {
                CoordinateX = 8,
                CoordinateY = 0,
                Label = "9",
                ShiftLabel = "(",
                KeyCode = VirtualKeyCode.VK_9
            };

            key_num0.Config = new KeyConfig
            {
                CoordinateX = 9,
                CoordinateY = 0,
                Label = "0",
                ShiftLabel = ")",
                KeyCode = VirtualKeyCode.VK_0
            };

            //
            // Character keys row 1
            //
            key_charQ.Config = new KeyConfig
            {
                CoordinateX = 0,
                CoordinateY = 1,
                Label = "q",
                ShiftLabel = "Q",
                KeyCode = VirtualKeyCode.VK_Q
            };

            key_charW.Config = new KeyConfig
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Label = "w",
                ShiftLabel = "W",
                KeyCode = VirtualKeyCode.VK_W
            };

            key_charE.Config = new KeyConfig
            {
                CoordinateX = 2,
                CoordinateY = 1,
                Label = "e",
                ShiftLabel = "E",
                KeyCode = VirtualKeyCode.VK_E
            };

            key_charR.Config = new KeyConfig
            {
                CoordinateX = 3,
                CoordinateY = 1,
                Label = "r",
                ShiftLabel = "R",
                KeyCode = VirtualKeyCode.VK_R
            };

            key_charT.Config = new KeyConfig
            {
                CoordinateX = 4,
                CoordinateY = 1,
                Label = "t",
                ShiftLabel = "T",
                KeyCode = VirtualKeyCode.VK_T
            };

            key_charY.Config = new KeyConfig
            {
                CoordinateX = 5,
                CoordinateY = 1,
                Label = "y",
                ShiftLabel = "Y",
                KeyCode = VirtualKeyCode.VK_Y
            };

            key_charU.Config = new KeyConfig
            {
                CoordinateX = 6,
                CoordinateY = 1,
                Label = "u",
                ShiftLabel = "U",
                KeyCode = VirtualKeyCode.VK_U
            };

            key_charI.Config = new KeyConfig
            {
                CoordinateX = 7,
                CoordinateY = 1,
                Label = "i",
                ShiftLabel = "I",
                KeyCode = VirtualKeyCode.VK_I,
                SpecialLabel = "[",
                SpecialShiftLabel = "{",
                SpecialKeyCode = VirtualKeyCode.OEM_4
            };

            key_charO.Config = new KeyConfig
            {
                CoordinateX = 8,
                CoordinateY = 1,
                Label = "o",
                ShiftLabel = "O",
                KeyCode = VirtualKeyCode.VK_O,
                SpecialLabel = "]",
                SpecialShiftLabel = "}",
                SpecialKeyCode = VirtualKeyCode.OEM_6
            };

            key_charP.Config = new KeyConfig
            {
                CoordinateX = 9,
                CoordinateY = 1,
                Label = "p",
                ShiftLabel = "P",
                KeyCode = VirtualKeyCode.VK_P,
                SpecialLabel = "\\",
                SpecialShiftLabel = "|",
                SpecialKeyCode = VirtualKeyCode.OEM_5
            };

            //
            // Character keys row 2
            //
            key_charA.Config = new KeyConfig
            {
                CoordinateX = 0,
                CoordinateY = 2,
                Label = "a",
                ShiftLabel = "A",
                KeyCode = VirtualKeyCode.VK_A
            };

            key_charS.Config = new KeyConfig
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Label = "s",
                ShiftLabel = "S",
                KeyCode = VirtualKeyCode.VK_S
            };

            key_charD.Config = new KeyConfig
            {
                CoordinateX = 2,
                CoordinateY = 2,
                Label = "d",
                ShiftLabel = "D",
                KeyCode = VirtualKeyCode.VK_D
            };

            key_charF.Config = new KeyConfig
            {
                CoordinateX = 3,
                CoordinateY = 2,
                Label = "f",
                ShiftLabel = "F",
                KeyCode = VirtualKeyCode.VK_F
            };

            key_charG.Config = new KeyConfig
            {
                CoordinateX = 4,
                CoordinateY = 2,
                Label = "g",
                ShiftLabel = "G",
                KeyCode = VirtualKeyCode.VK_G
            };

            key_charH.Config = new KeyConfig
            {
                CoordinateX = 5,
                CoordinateY = 2,
                Label = "h",
                ShiftLabel = "H",
                KeyCode = VirtualKeyCode.VK_H
            };

            key_charJ.Config = new KeyConfig
            {
                CoordinateX = 6,
                CoordinateY = 2,
                Label = "j",
                ShiftLabel = "J",
                KeyCode = VirtualKeyCode.VK_J
            };

            key_charK.Config = new KeyConfig
            {
                CoordinateX = 7,
                CoordinateY = 2,
                Label = "k",
                ShiftLabel = "K",
                KeyCode = VirtualKeyCode.VK_K,
                SpecialLabel = ";",
                SpecialShiftLabel = ":",
                SpecialKeyCode = VirtualKeyCode.OEM_1
            };

            key_charL.Config = new KeyConfig
            {
                CoordinateX = 8,
                CoordinateY = 2,
                Label = "l",
                ShiftLabel = "L",
                KeyCode = VirtualKeyCode.VK_L,
                SpecialLabel = "'",
                SpecialShiftLabel = "\"",
                SpecialKeyCode = VirtualKeyCode.OEM_7
            };

            specialKey_specialCharacters.Config = new KeyConfig
            {
                CoordinateX = 9,
                CoordinateY = 2,
                Label = "#@:",
            };

            //
            // Character keys row 2
            //
            key_charZ.Config = new KeyConfig
            {
                CoordinateX = 0,
                CoordinateY = 3,
                Label = "z",
                ShiftLabel = "Z",
                KeyCode = VirtualKeyCode.VK_Z
            };

            key_charX.Config = new KeyConfig
            {
                CoordinateX = 1,
                CoordinateY = 3,
                Label = "x",
                ShiftLabel = "X",
                KeyCode = VirtualKeyCode.VK_X
            };

            key_charC.Config = new KeyConfig
            {
                CoordinateX = 2,
                CoordinateY = 3,
                Label = "c",
                ShiftLabel = "C",
                KeyCode = VirtualKeyCode.VK_C
            };

            key_charV.Config = new KeyConfig
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Label = "v",
                ShiftLabel = "V",
                KeyCode = VirtualKeyCode.VK_V
            };

            key_charB.Config = new KeyConfig
            {
                CoordinateX = 4,
                CoordinateY = 3,
                Label = "b",
                ShiftLabel = "B",
                KeyCode = VirtualKeyCode.VK_B
            };

            key_charN.Config = new KeyConfig
            {
                CoordinateX = 5,
                CoordinateY = 3,
                Label = "n",
                ShiftLabel = "N",
                KeyCode = VirtualKeyCode.VK_N
            };

            key_charM.Config = new KeyConfig
            {
                CoordinateX = 6,
                CoordinateY = 3,
                Label = "m",
                ShiftLabel = "M",
                KeyCode = VirtualKeyCode.VK_M,
                SpecialLabel = "-",
                SpecialShiftLabel = "_",
                SpecialKeyCode = VirtualKeyCode.OEM_MINUS
            };

            key_charComma.Config = new KeyConfig
            {
                CoordinateX = 7,
                CoordinateY = 3,
                Label = ",",
                ShiftLabel = "<",
                KeyCode = VirtualKeyCode.OEM_COMMA,
                SpecialLabel = "=",
                SpecialShiftLabel = "+",
                SpecialKeyCode = VirtualKeyCode.OEM_PLUS
            };

            key_charPeriod.Config = new KeyConfig
            {
                CoordinateX = 8,
                CoordinateY = 3,
                Label = ".",
                ShiftLabel = ">",
                KeyCode = VirtualKeyCode.OEM_PERIOD,
                SpecialLabel = "/",
                SpecialShiftLabel = "?",
                SpecialKeyCode = VirtualKeyCode.OEM_2
            };

            specialKey_delete.Config = new KeyConfig
            {
                CoordinateX = 9,
                CoordinateY = 3,
                Label = "del",
                KeyCode = VirtualKeyCode.BACK
            };

            //
            // Special keys row
            //
            specialKey_shift.Config = new KeyConfig
            {
                CoordinateX = 0,
                CoordinateY = 4,
                Label = "shift"
            };

            specialKey_tab.Config = new KeyConfig
            {
                CoordinateX = 1,
                CoordinateY = 4,
                Label = "tab",
                KeyCode = VirtualKeyCode.TAB
            };

            specialKey_space.Config = new KeyConfig
            {
                CoordinateX = 3,
                CoordinateY = 4,
                Label = "space",
                KeyCode = VirtualKeyCode.SPACE
            };

            specialKey_enter.Config = new KeyConfig
            {
                CoordinateX = 8,
                CoordinateY = 4,
                Label = "enter",
                KeyCode = VirtualKeyCode.RETURN
            };
        }

        private void NavigateKeys(int dx, int dy)
        {
            // TODO: i guess mapping the keys to a 2D int-grid and navigating that grid is
            // much better for performance than what i have done here... but meh, this was more fun

            Point newCoordinates = (selectedKey != null)
                ? new Point(selectedKey.Config.CoordinateX + dx, selectedKey.Config.CoordinateY + dy)
                : new Point(dx, dy);

            IKey nextKey;

            if (dx > 0)
            {
                nextKey = keys
                    .Where(key => key.Config.CoordinateY == newCoordinates.Y)
                    .OrderBy(key => key.Config.CoordinateX)
                    .FirstOrDefault(key => key.Config.CoordinateX >= newCoordinates.X);
            }
            else
            {
                nextKey = keys
                    .Where(key => key.Config.CoordinateY == newCoordinates.Y)
                    .OrderByDescending(key => key.Config.CoordinateX)
                    .FirstOrDefault(key => key.Config.CoordinateX <= newCoordinates.X);
            }

            if (nextKey == null)
            {
                return;
            }

            if (selectedKey != null)
            {
                selectedKey.IsSelected = false;
            }

            nextKey.IsSelected = true;
            selectedKey = nextKey;
        }

        private void SimulateInputForKey(IKey key)
        {
            if (key.IsFnActivated)
            {
                if (key.Config.SpecialKeyCode != 0)
                {
                    if (key.IsShiftActivated)
                    {
                        inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, key.Config.SpecialKeyCode);
                    }
                    else
                    {
                        inputSimulator.Keyboard.KeyPress(key.Config.SpecialKeyCode);
                    }
                }
            }
            else
            {
                if (key.IsShiftActivated)
                {
                    inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.SHIFT, key.Config.KeyCode);
                }
                else
                {
                    inputSimulator.Keyboard.KeyPress(key.Config.KeyCode);
                }
            }
        }

        private void ToggleShift()
        {
            bool isActive = specialKey_shift.ToggleSpecialFeature();

            foreach (IKey key in keys)
            {
                key.IsShiftActivated = isActive;
            }
        }

        private void ToggleSpecialCharacters()
        {
            bool isActive = specialKey_specialCharacters.ToggleSpecialFeature();

            foreach (IKey key in keys)
            {
                key.IsFnActivated = isActive;
            }
        }
    }
}

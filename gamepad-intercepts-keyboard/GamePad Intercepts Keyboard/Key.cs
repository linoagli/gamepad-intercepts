using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput.Native;

namespace GamePad_Intercepts_Keyboard
{
    internal partial class Key : UserControl
    {
        private KeyConfig _config;
        public KeyConfig Config
        {
            get => _config;

            set
            {
                _config = value;

                if (_config != null)
                {
                    UpdateDisplay();
                }
            }
        }

        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;

            set
            {
                if (value == _isSelected)
                {
                    return;
                }

                _isSelected = value;

                panel_background.BackColor = (_isSelected) ? Color.Gray : Color.Black;
            }
        }

        private bool _isShiftActivated = false;
        public bool IsShiftActivated
        {
            get => _isShiftActivated;

            set
            {
                if (value == _isShiftActivated)
                {
                    return;
                }

                _isShiftActivated = value;

                UpdateDisplay();
            }
        }

        private bool _isSpecialActivated = false;
        public bool IsSpecialActivated
        {
            get => _isSpecialActivated;

            set
            {
                if (value ==_isSpecialActivated)
                {
                    return;
                }

                _isSpecialActivated = value;

                UpdateDisplay();
            }
        }

        public Key()
        {
            InitializeComponent();
        }

        protected virtual void UpdateDisplay()
        {
            if (_isSpecialActivated)
            {
                if (_isShiftActivated)
                {
                    label_character.Text = _config.SpecialShiftLabel;
                }
                else
                {
                    label_character.Text = _config.SpecialLabel;
                }
            }
            else
            {
                if (_isShiftActivated)
                {
                    label_character.Text = _config.ShiftLabel;
                }
                else
                {
                    label_character.Text = _config.Label;
                }
            }
        }

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
}
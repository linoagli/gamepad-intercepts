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

namespace GamePad_Intercepts_Keyboard.WPF
{
    /// <summary>
    /// Interaction logic for KeyWPF.xaml
    /// </summary>
    public partial class Key : UserControl, IKey
    {
        private readonly Color idleBackgroundColor = (Color)ColorConverter.ConvertFromString("#FF0C060F");
        private readonly Color activeBackgroundColor = (Color)ColorConverter.ConvertFromString("#FF290EA1");

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

                grid_background.Background = new SolidColorBrush((_isSelected) ? activeBackgroundColor : idleBackgroundColor);
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

        private bool _isFnActivated = false;
        public bool IsFnActivated 
        {
            get => _isFnActivated;

            set
            {
                if (value == _isFnActivated)
                {
                    return;
                }

                _isFnActivated = value;

                UpdateDisplay();
            }
        }

        public Key()
        {
            InitializeComponent();
        }

        private void UpdateDisplay()
        {
            if (_isFnActivated)
            {
                if (_isShiftActivated)
                {
                    label_character.Content = _config.SpecialShiftLabel;
                }
                else
                {
                    label_character.Content = _config.SpecialLabel;
                }
            }
            else
            {
                if (_isShiftActivated)
                {
                    label_character.Content = _config.ShiftLabel;
                }
                else
                {
                    label_character.Content = _config.Label;
                }
            }
        }
    }
}

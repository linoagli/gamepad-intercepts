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
    /// Interaction logic for SpecialKeyWPF.xaml
    /// </summary>
    public partial class SpecialKey : UserControl, ISpecialKey
    {
        private readonly Color idleBackgroundColor = (Color)ColorConverter.ConvertFromString("#FF400A5D");
        private readonly Color activeBackgroundColor = (Color)ColorConverter.ConvertFromString("#FF290EA1");

        private readonly Color idleIndicatorColor = (Color)ColorConverter.ConvertFromString("#FF190A21");
        private readonly Color activeIndicatorColor = (Color)ColorConverter.ConvertFromString("#FF1CAD21");

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

        private bool _isSpecialFeatureActive = false;
        public bool IsSpecialFeatureActive
        {
            get => _isSpecialFeatureActive;

            set
            {
                if (value == _isSpecialFeatureActive)
                {
                    return;
                }

                _isSpecialFeatureActive = value;

                rectangle_enabledIndicator.Fill = new SolidColorBrush((_isSpecialFeatureActive) ? activeIndicatorColor : idleIndicatorColor);
            }
        }

        bool IKey.IsShiftActivated 
        { 
            get => false;
            set => _ = false; 
        }
        bool IKey.IsFnActivated 
        { 
            get => false;
            set => _ = false;
        }

        public SpecialKey()
        {
            InitializeComponent();
        }

        private void UpdateDisplay()
        {
            label_character.Content = Config.Label;
        }

        public bool ToggleSpecialFeature()
        {
            return IsSpecialFeatureActive = !IsSpecialFeatureActive;
        }
    }
}

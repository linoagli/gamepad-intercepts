using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePad_Intercepts_Keyboard
{
    internal partial class SpecialKey : Key
    {
        private bool _specialFeatureActive = false;
        public bool SpecialFeatureActive
        {
            get => _specialFeatureActive;

            set
            {
                if (value == _specialFeatureActive)
                {
                    return;
                }

                _specialFeatureActive = value;

                panel_enabledIndicator.BackColor = (_specialFeatureActive) ? Color.Olive : Color.Transparent;
            }
        }

        public SpecialKey()
        {
            InitializeComponent();

            
        }

        protected override void UpdateDisplay()
        {
            label_character.Text = Config.Label;
        }

        public bool ToggleSpecialFeature()
        {
            return SpecialFeatureActive = !SpecialFeatureActive;
        }
    }
}

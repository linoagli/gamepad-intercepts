using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using GamePad_Intercepts_Keyboard.WPF;

namespace GamePad_Intercepts_Keyboard.WinForms
{
    public partial class Keyboard : UserControl, IKeyboard
    {
        WPF.Keyboard wpfKeyboard;

        public Keyboard()
        {
            InitializeComponent();

            wpfKeyboard = new WPF.Keyboard();

            ElementHost elementHost = new ElementHost();
            elementHost.Dock = DockStyle.Fill;
            elementHost.Child = wpfKeyboard;

            Controls.Add(elementHost);
        }

        public void NavigateLeft()
        {
            wpfKeyboard.NavigateLeft();
        }

        public void NavigateUp()
        {
            wpfKeyboard.NavigateUp();
        }

        public void NavigateRight()
        {
            wpfKeyboard.NavigateRight();
        }

        public void NavigateDown()
        {
            wpfKeyboard.NavigateDown();
        }

        public void PressKey()
        {
            wpfKeyboard.PressKey();
        }

        public void PressSpacebarKey()
        {
            wpfKeyboard.PressSpacebarKey();
        }

        public void PressDeleteKey()
        {
            wpfKeyboard.PressDeleteKey();
        }

        public void PressEnterKey()
        {
            wpfKeyboard.PressEnterKey();
        }

        public void PressShiftKey()
        {
            wpfKeyboard.PressShiftKey();
        }

        public void PressSpecialKey()
        {
            wpfKeyboard.PressSpecialKey();
        }
    }
}

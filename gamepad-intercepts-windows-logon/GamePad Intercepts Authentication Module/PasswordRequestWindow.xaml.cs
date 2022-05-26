using GamePad_Intercepts_Authentication_Module;
using GamePad_Intercepts_Keyboard;
using MessageBus;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace GamePad_Intercepts_Authentication_Module
{
    /// <summary>
    /// Interaction logic for PasswordRequestWindow.xaml
    /// </summary>
    public partial class PasswordRequestWindow : Window
    {
        public string Password
        {
            get => passwordBox_password.Password;
        }

        public PasswordRequestWindow(string username)
        {
            InitializeComponent();

            label_instructions.Content = $"Welcome {username}! Please enter your password.";
            passwordBox_password.Focus();

            Bus.Instance.Subscribe<string>(this, HandleMessageBusMessages);
            Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_MODE_ON_SCREEN_KEYBOARD);
        }

        public PasswordRequestWindow() : this(null) { }

        public new void Close()
        {
            Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_MODE_MOUSE_AND_KEYBOARD);
            Bus.Instance.Unsubscribe(this);

            base.Close();
        }

        private void HandleMessageBusMessages(string message)
        {
            Dispatcher.Invoke(() =>
            {
                if (message.Contains(MessageBusEvents.CONTROLLER_INPUT_LEFT))
                {
                    keyboard_keyboard.NavigateLeft();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_UP)
                {
                    keyboard_keyboard.NavigateUp();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_RIGHT)
                {
                    keyboard_keyboard.NavigateRight();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_DOWN)
                {
                    keyboard_keyboard.NavigateDown();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_CROSS)
                {
                    keyboard_keyboard.PressKey();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_L1)
                {
                    keyboard_keyboard.PressDeleteKey();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_R1)
                {
                    keyboard_keyboard.PressSpacebarKey();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_CIRCLE)
                {
                    Close();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_L2)
                {
                    keyboard_keyboard.PressShiftKey();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_R2)
                {
                    keyboard_keyboard.PressSpecialKey();
                }
                else if (message == MessageBusEvents.CONTROLLER_INPUT_START)
                {
                    Close();
                }
            });
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

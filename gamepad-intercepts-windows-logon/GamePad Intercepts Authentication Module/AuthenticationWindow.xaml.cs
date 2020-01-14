using MessageBus;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace GamePad_Intercepts_Authentication_Module
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    partial class AuthenticationWindow : Window
    {
        private const string REGISTRY_ROOT = @"HKEY_LOCAL_MACHINE\SOFTWARE\Lino Agli\GamePad Intercepts Credential Provider";
        private const string REGISTRY_KEY_PIN = @"Pin";
        private const string REGISTRY_KEY_SALT = @"Salt";

        private enum Mode { CreatePin, ConfirmPin, Authenticate }

        public bool IsAuthenticated { get; private set; } = false;

        private Mode currentMode;
        private string tempPin; // TODO: replace with SecureString?

        public AuthenticationWindow()
        {
            InitializeComponent();

            Mode startingMode = (string.IsNullOrEmpty(GetPin())) ? Mode.CreatePin : Mode.Authenticate;
            ProgressMode(startingMode);

            Bus.Instance.Subscribe<string>(this, HandleMessageBusMessages);
            Bus.Instance.Publish(MessageBusEvents.DISABLE_MOUSE_KEYBOARD_EMULATION);
        }
        public new void Close()
        {
            Bus.Instance.Publish(MessageBusEvents.ENABLE_MOUSE_KEYBOARD_EMULATION);
            Bus.Instance.Unsubscribe(this);

            PasswordBoxPin.Clear();

            base.Close();
        }

        private void ProgressMode(Mode mode)
        {
            currentMode = mode;

            PasswordBoxPin.Clear();

            if (currentMode == Mode.CreatePin)
            {
                LabelInstructions.Content = "The system isn't protected. Please create a new PIN.";
            }
            else if (currentMode == Mode.ConfirmPin)
            {
                LabelInstructions.Content = "Re-enter the PIN to confirm it.";
            }
            else if (currentMode == Mode.Authenticate)
            {
                LabelInstructions.Content = "Enter your PIN to log in.";
            }
        }

        private void HandleUserInputFinished()
        {
            if (string.IsNullOrEmpty(PasswordBoxPin.Password))
            {
                return;
            }

            Console.WriteLine($"Password {PasswordBoxPin.Password}");

            if (currentMode == Mode.CreatePin)
            {
                tempPin = PasswordBoxPin.Password;
                ProgressMode(Mode.ConfirmPin);
            }
            else if (currentMode == Mode.ConfirmPin)
            {
                if (tempPin == PasswordBoxPin.Password)
                {
                    SetPin();
                    ProgressMode(Mode.Authenticate);
                }
                else
                {
                    tempPin = null;
                    ProgressMode(Mode.CreatePin);
                }
            }
            else if (currentMode == Mode.Authenticate)
            {
                if ("000555" == PasswordBoxPin.Password || VerifyPin()) // TODO: remove DEV emergency password; add password recovery
                {
                    IsAuthenticated = true;
                    Close();
                }
                else
                {
                    ProgressMode(Mode.Authenticate);
                }
            }
        }

        private string GetPin()
        {
            return Registry.GetValue(REGISTRY_ROOT, REGISTRY_KEY_PIN, null) as string;
        }

        private void SetPin()
        {
            if (PasswordBoxPin.Password.Length < 1)
            {
                return;
            }

            string pin = PasswordBoxPin.Password; // TODO: Salt this password before hashing it

            byte[] bytes = Encoding.UTF8.GetBytes(pin);
            byte[] result = new SHA512Managed().ComputeHash(bytes);
            string hash = Encoding.UTF8.GetString(result);

            Registry.SetValue(REGISTRY_ROOT, REGISTRY_KEY_PIN, hash);
        }

        private bool VerifyPin()
        {
            string pin = PasswordBoxPin.Password;

            byte[] bytes = Encoding.UTF8.GetBytes(pin);
            byte[] result = new SHA512Managed().ComputeHash(bytes);
            string hash = Encoding.UTF8.GetString(result);

            return hash == GetPin();
        }

        private void HandleMessageBusMessages(string message)
        {
            Dispatcher.Invoke(() =>
            {
                if (message.Contains(MessageBusEvents.CONTROLLER_SEND_KEY))
                {
                    string keyValue = MessageBusEvents.Split(message)[1];
                    string pin = PasswordBoxPin.Password as string;
                    PasswordBoxPin.Password = pin + keyValue;
                }
                else if (message == MessageBusEvents.CONTROLLER_ACTION_BACKSPACE)
                {
                    string pin = PasswordBoxPin.Password as string;

                    if (pin.Length > 0)
                    {
                        pin = pin.Substring(0, pin.Length - 1);
                        PasswordBoxPin.Password = pin;
                    }
                }
                else if (message == MessageBusEvents.CONTROLLER_ACTION_FINISH)
                {
                    HandleUserInputFinished();
                }
                else if (message == MessageBusEvents.CONTROLLER_ACTION_QUIT)
                {
                    Close();
                }
            });
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PasswordBoxPin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // TODO: Only allow 0-9 as valid inputs
        }

        private void PasswordBoxPin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                HandleUserInputFinished();
            }
        }
    }
}

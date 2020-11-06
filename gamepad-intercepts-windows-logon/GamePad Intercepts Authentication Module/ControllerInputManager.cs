using DS4Library;
using MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace GamePad_Intercepts_Authentication_Module
{
    class ControllerInputManager
    {
        enum Mode { MouseAndKeyboard, OnScreenKeyboard, PinPad }

        private const float MOUSE_SPEED_MULTIPLIER = 1.5f;

        private DS4DeviceManager ds4DeviceManager;
        private HashSet<DS4Controls.Button> pressedDS4Buttons;
        private InputSimulator inputSimulator;

        private Mode mode;

        public ControllerInputManager()
        {
            ds4DeviceManager = new DS4DeviceManager();
            pressedDS4Buttons = new HashSet<DS4Controls.Button>();
            inputSimulator = new InputSimulator();

            mode = Mode.MouseAndKeyboard;
        }

        public void Init()
        {
            Bus.Instance.Subscribe<string>(this, HandleMessageBusMessages);
            Bus.Instance.Publish(MessageBusEvents.CONTROLLER_SEARCHING);

            ds4DeviceManager.Init();
            ds4DeviceManager.DeviceConnectionStateChanged += OnDS4ControllerConnectionStateChanged;
        }

        public void CleanUp()
        {
            ds4DeviceManager.CleanUp();
            Bus.Instance.Unsubscribe(this);
        }

        private void HandleMessageBusMessages(string message)
        {
            if (message == MessageBusEvents.CONTROLLER_INPUT_MODE_MOUSE_AND_KEYBOARD)
            {
                mode = Mode.MouseAndKeyboard;
            }
            else if (message == MessageBusEvents.CONTROLLER_INPUT_MODE_ON_SCREEN_KEYBOARD)
            {
                mode = Mode.OnScreenKeyboard;
            }
            else if (message == MessageBusEvents.CONTROLLER_INPUT_MODE_PIN_PAD)
            {
                mode = Mode.PinPad;
            }
        }

        private void ParsePressedDS4Buttons()
        {
            if (pressedDS4Buttons.Count == 1)
            {
                if (mode == Mode.MouseAndKeyboard)
                {
                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.TouchPad) inputSimulator.Mouse.LeftButtonClick();

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Cross) inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R1) inputSimulator.Mouse.LeftButtonClick();

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R2) inputSimulator.Mouse.RightButtonClick();
                }
                else if (mode == Mode.OnScreenKeyboard)
                {
                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadLeft) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_LEFT);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadUp) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_UP);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadRight) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_RIGHT);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadDown) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_DOWN);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Cross) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_CROSS);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Square) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_SQUARE);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Triangle) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_TRIANGLE);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Circle) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_CIRCLE);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R1) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_R1);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L1) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_L1);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Options) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_INPUT_START);
                }
                else if (mode == Mode.PinPad)
                {

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadLeft) SendKeyMessage("1");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadUp) SendKeyMessage("2");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadRight) SendKeyMessage("3");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadDown) SendKeyMessage("4");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Cross) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_ACTION_FINISH);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Circle) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_ACTION_QUIT);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Square) Bus.Instance.Publish(MessageBusEvents.CONTROLLER_ACTION_BACKSPACE);

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Triangle) ;

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L1) SendKeyMessage("5");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L2) SendKeyMessage("7");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L3) SendKeyMessage("9");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R1) SendKeyMessage("6");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R2) SendKeyMessage("8");

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R3) SendKeyMessage("0");
                }
            }
        }

        private void SendKeyMessage(String key)
        {
            Bus.Instance.Publish(MessageBusEvents.Join(MessageBusEvents.CONTROLLER_SEND_KEY, key));
        }

        private void OnDS4ControllerConnectionStateChanged(object sender, DS4DeviceManager.DeviceConnectionStateChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                e.Controller.DeviceButtonStateChanged += OnDS4ControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged += OnDS4ControllerAnalogStateChanged;
                e.Controller.DeviceTouchPadMoved += OnDS4ControllerTouchPadMoved;

                Console.WriteLine("DS4 Controller connected");

                Bus.Instance.Publish(MessageBusEvents.CONTROLLER_CONNECTED);
            }
            else
            {
                e.Controller.DeviceButtonStateChanged -= OnDS4ControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged -= OnDS4ControllerAnalogStateChanged;
                e.Controller.DeviceTouchPadMoved -= OnDS4ControllerTouchPadMoved;

                Console.WriteLine("DS4 Controller disconnected");

                Bus.Instance.Publish(MessageBusEvents.CONTROLLER_SEARCHING);
            }
        }

        private void OnDS4ControllerButtonStateChanged(object sender, DS4Controller.DeviceButtonStateChangedEventArgs e)
        {
            if (e.IsPressed)
            {
                pressedDS4Buttons.Add(e.Button);
            }
            else
            {
                pressedDS4Buttons.Remove(e.Button);
            }

            ParsePressedDS4Buttons();
        }

        private void OnDS4ControllerAnalogStateChanged(object sender, DS4Controller.DeviceAnalogStateChangedEventArgs e)
        {
            if (e.Analog == DS4Controls.Analog.LeftThumbStick)
            {
                if (mode == Mode.MouseAndKeyboard)
                {
                    inputSimulator.Mouse.HorizontalScroll((int)(e.Value[0] * MOUSE_SPEED_MULTIPLIER / 64));
                    inputSimulator.Mouse.VerticalScroll(-(int)(e.Value[1] * MOUSE_SPEED_MULTIPLIER / 64));
                }
            }

            if (e.Analog == DS4Controls.Analog.RightThumbStick)
            {
                if (mode == Mode.MouseAndKeyboard)
                {
                    inputSimulator.Mouse.MoveMouseBy((int)(e.Value[0] * MOUSE_SPEED_MULTIPLIER / 32), (int)(e.Value[1] * MOUSE_SPEED_MULTIPLIER / 32));
                }
            }
        }

        private void OnDS4ControllerTouchPadMoved(object sender, DS4Controller.DeviceTouchPadMovedEventArgs e)
        {
            if (mode == Mode.MouseAndKeyboard)
            {
                inputSimulator.Mouse.MoveMouseBy((int)(e.DeltaX * MOUSE_SPEED_MULTIPLIER / 2), (int)(e.DeltaY * MOUSE_SPEED_MULTIPLIER / 2));
            }
        }
    }
}

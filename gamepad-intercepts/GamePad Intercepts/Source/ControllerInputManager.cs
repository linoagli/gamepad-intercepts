using DS4Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace GamePad_Intercepts
{
    class ControllerInputManager
    {
        private const float MOUSE_SPEED_MULTIPLIER_DEFAULT = 1f;
        private const float MOUSE_SPEED_MULTIPLIER_FAST = 2f;
        private const float MOUSE_SPEED_MULTIPLIER_SLOW = .5f;

        private const int BATTERY_THRESHOLD_LOW = 30;
        private const int BATTERY_THRESHOLD_VERY_LOW = 20;
        private const int BATTERY_THRESHOLD_CRITICAL = 10;

        private const string TAG_MOUSE_KEYBOARD_EMULATION = "controllerMouseKeyboardEmulation";
        private const string TAG_BATTERY_STATE = "controllerBatteryState";

        private DS4DeviceManager ds4DeviceManager;
        private HashSet<DS4Controls.Button> pressedDS4Buttons;
        private InputSimulator inputSimulator;

        private bool isMouseAndKeyboardModeEnabled;
        private float mouseSpeedMultiplier;

        public ControllerInputManager()
        {
            ds4DeviceManager = new DS4DeviceManager();
            pressedDS4Buttons = new HashSet<DS4Controls.Button>();
            inputSimulator = new InputSimulator();

            isMouseAndKeyboardModeEnabled = false;
            mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_DEFAULT;
        }

        public void Init()
        {
            ds4DeviceManager.Init(); // TODO: limit number of controllers being parsed to 1
            ds4DeviceManager.DeviceConnectionStateChanged += OnDS4ControllerConnectionStateChanged;
        }

        public void CleanUp()
        {
            ds4DeviceManager.CleanUp();
        }

        public void EnableMouseKeyboardEmulation()
        {
            if (!isMouseAndKeyboardModeEnabled) ToggleMouseKeyboardEmulation();
        }

        public void DisableMouseKeyboardEmulation()
        {
            if (isMouseAndKeyboardModeEnabled) ToggleMouseKeyboardEmulation();
        }

        private void ToggleMouseKeyboardEmulation()
        {
            isMouseAndKeyboardModeEnabled = !isMouseAndKeyboardModeEnabled;

            if (isMouseAndKeyboardModeEnabled) App.MissionControl.ShowStickyNotification("Mouse & Keyboard Emulation Active", TAG_MOUSE_KEYBOARD_EMULATION);
            else App.MissionControl.HideStickyNotification(TAG_MOUSE_KEYBOARD_EMULATION);
        }

        private void ParsePressedDS4Buttons()
        {
            if (pressedDS4Buttons.Count == 1)
            {
                //
                // Button press event publishing
                //

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadLeft)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Left });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadUp)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Up });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadRight)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Right });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.DpadDown)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Down });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Cross)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Cross });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Circle)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Circle });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Square)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Square });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Triangle)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Triangle });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L1)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.L1 });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L2)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.L2 });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.L3)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.L3 });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R1)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.R1 });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R2)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.R2 });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R3)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.R3 });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Options)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Start });
                }

                if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Share)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Select });
                }


                //
                // Mouse and keyboard emulation
                //

                if (isMouseAndKeyboardModeEnabled)
                {
                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.TouchPad)
                    {
                        inputSimulator.Mouse.LeftButtonClick();
                    }

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Cross)
                    {
                        inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                    }

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.Circle)
                    {
                        inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);
                    }

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R1)
                    {
                        inputSimulator.Mouse.LeftButtonClick();
                    }

                    if (pressedDS4Buttons.FirstOrDefault() == DS4Controls.Button.R2)
                    {
                        inputSimulator.Mouse.RightButtonClick();
                    }
                }
            }

            if (pressedDS4Buttons.Count == 2)
            {
                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.Options))
                {
                    MessageBus.Bus.Instance.Publish(new UIEvent { Action = UIEvent.EventAction.ToggleHomeScreen });
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.Share))
                {
                    App.MissionControl.AltTab();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.TouchPad))
                {
                    App.MissionControl.ToggleOnScreenKeyboard();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.DpadUp))
                {
                    App.MissionControl.VolumeUp();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.DpadDown))
                {
                    App.MissionControl.VolumeDown();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.R3))
                {
                    ToggleMouseKeyboardEmulation();
                }
            }
        }

        private void OnDS4ControllerConnectionStateChanged(object sender, DS4DeviceManager.DeviceConnectionStateChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                e.Controller.DeviceButtonStateChanged += OnDS4ControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged += OnDS4ControllerAnalogStateChanged;
                e.Controller.DeviceTouchPadMoved += OnDS4ControllerTouchPadMoved;
                e.Controller.DeviceGeneralStateChanged += OnDeviceGeneralStateChanged;

                App.MissionControl.ShowNotification("DS4 Controller connected");
            }
            else
            {
                e.Controller.DeviceButtonStateChanged -= OnDS4ControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged -= OnDS4ControllerAnalogStateChanged;
                e.Controller.DeviceTouchPadMoved -= OnDS4ControllerTouchPadMoved;
                e.Controller.DeviceGeneralStateChanged -= OnDeviceGeneralStateChanged;

                DisableMouseKeyboardEmulation();

                App.MissionControl.ShowNotification("DS4 Controller disconnected");
            }
        }

        private void OnDS4ControllerButtonStateChanged(object sender, DS4Controller.DeviceButtonStateChangedEventArgs e)
        {
            // Parsing button press combinations
            if (e.IsPressed)
            {
                pressedDS4Buttons.Add(e.Button);
            }
            else
            {
                pressedDS4Buttons.Remove(e.Button);
            }

            ParsePressedDS4Buttons();

            //
            // Parsing more complex input sequences and states
            //

            // Handling mouse speed modifier change states
            if (e.Button == DS4Controls.Button.L1 && e.IsPressed)
            {
                mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_FAST;
            }
            else if (e.Button == DS4Controls.Button.L2 && e.IsPressed)
            {
                mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_SLOW;
            }
            else
            {
                mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_DEFAULT;
            }
        }

        private void OnDS4ControllerAnalogStateChanged(object sender, DS4Controller.DeviceAnalogStateChangedEventArgs e)
        {
            if (e.Analog == DS4Controls.Analog.LeftThumbStick)
            {
                if (isMouseAndKeyboardModeEnabled)
                {
                    inputSimulator.Mouse.HorizontalScroll((int) (e.Value[0] * mouseSpeedMultiplier / 64));
                    inputSimulator.Mouse.VerticalScroll(- (int) (e.Value[1] * mouseSpeedMultiplier / 64));
                }
            }

            if (e.Analog == DS4Controls.Analog.RightThumbStick)
            {
                if (isMouseAndKeyboardModeEnabled)
                {
                    inputSimulator.Mouse.MoveMouseBy(
                        (int)(e.Value[0] * mouseSpeedMultiplier / 32),
                        (int)(e.Value[1] * mouseSpeedMultiplier / 32)
                    );
                }
            }
        }

        private void OnDS4ControllerTouchPadMoved(object sender, DS4Controller.DeviceTouchPadMovedEventArgs e)
        {
            if (isMouseAndKeyboardModeEnabled)
            {
                inputSimulator.Mouse.MoveMouseBy(
                    (int)(e.DeltaX * mouseSpeedMultiplier / 2),
                    (int)(e.DeltaY * mouseSpeedMultiplier / 2)
                );
            }
        }

        private void OnDeviceGeneralStateChanged(object sender, DS4Controller.DeviceGeneralStateChangedEventArgs e)
        {
            switch (e.Battery)
            {
                case BATTERY_THRESHOLD_LOW:
                case BATTERY_THRESHOLD_VERY_LOW:
                    App.MissionControl.ShowNotification("Low controller battery warning: " + e.Battery + "%");
                    break;
            }

            if (e.Battery <= BATTERY_THRESHOLD_CRITICAL)
            {
                App.MissionControl.ShowStickyNotification("Controller battery very low: " + e.Battery + "%", TAG_BATTERY_STATE);
            }
            else
            {
                App.MissionControl.HideStickyNotification(TAG_BATTERY_STATE);
            }
        }
    }
}

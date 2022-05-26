using DS4Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using XInputDotNet;

namespace GamePad_Intercepts
{
    class ControllerInputManager
    {
        private const int MOUSE_SPEED_MULTIPLIER_DEFAULT = 2;
        private const int MOUSE_SPEED_MULTIPLIER_FAST = 4;
        private const int MOUSE_SPEED_MULTIPLIER_SLOW = 1;

        private const int BATTERY_THRESHOLD_LOW = 30;
        private const int BATTERY_THRESHOLD_VERY_LOW = 20;
        private const int BATTERY_THRESHOLD_CRITICAL = 10;

        private const string TAG_MOUSE_KEYBOARD_EMULATION = "controllerMouseKeyboardEmulation";
        private const string TAG_BATTERY_STATE = "controllerBatteryState";

        private DS4DeviceManager ds4DeviceManager;
        private HashSet<DS4Controls.Button> pressedDS4Buttons;

        private XInputControllerManager xInputControllerManager;
        private HashSet<XInputControls.Button> pressedXInputButtons;

        private InputSimulator inputSimulator;

        private bool isMouseAndKeyboardModeEnabled;
        private int mouseSpeedMultiplier;

        public ControllerInputManager()
        {
            ds4DeviceManager = new DS4DeviceManager();
            pressedDS4Buttons = new HashSet<DS4Controls.Button>();

            xInputControllerManager = new XInputControllerManager();
            pressedXInputButtons = new HashSet<XInputControls.Button>();

            inputSimulator = new InputSimulator();

            isMouseAndKeyboardModeEnabled = false;
            mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_DEFAULT;
        }

        public void Init()
        {
            ds4DeviceManager.Init(); // TODO: limit number of controllers being parsed to 1
            ds4DeviceManager.DeviceConnectionStateChanged += OnDS4ControllerConnectionStateChanged;

            xInputControllerManager.Init(); // TODO: limit number of controllers being parsed to 1
            xInputControllerManager.DeviceConnectionStateChanged += OnXInputControllerConnectionStateChanged;
        }

        public void CleanUp()
        {
            xInputControllerManager.CleanUp();
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
                    App.MissionControl.StartGamesPlatformLauncher();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.Share))
                {
                    App.MissionControl.AltTab();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.R3))
                {
                    App.MissionControl.ToggleOnScreenKeyboard();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.L3))
                {
                    ToggleMouseKeyboardEmulation();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.DpadLeft))
                {
                    App.MissionControl.AltEnter();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.DpadUp))
                {
                    App.MissionControl.VolumeUp();
                }

                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS) && pressedDS4Buttons.Contains(DS4Controls.Button.DpadDown))
                {
                    App.MissionControl.VolumeDown();
                }
            }

            if (pressedDS4Buttons.Count == 5)
            {
                if (pressedDS4Buttons.Contains(DS4Controls.Button.PS)
                    && pressedDS4Buttons.Contains(DS4Controls.Button.L1)
                    && pressedDS4Buttons.Contains(DS4Controls.Button.L2)
                    && pressedDS4Buttons.Contains(DS4Controls.Button.R1)
                    && pressedDS4Buttons.Contains(DS4Controls.Button.R2))
                {
                    App.MissionControl.AltF4();
                }
            }
        }

        private void ParsePressedXInputButtons()
        {
            if (pressedXInputButtons.Count == 1)
            {
                //
                // Button press event publishing
                //

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.DpadLeft)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Left });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.DpadUp)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Up });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.DpadRight)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Right });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.DpadDown)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Down });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.A)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Cross });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.B)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Circle });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.X)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Square });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.Y)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Triangle });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.LB)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.L1 });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.LT)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.L2 });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.LS)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.L3 });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.RB)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.R1 });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.RT)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.R2 });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.RS)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.R3 });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.Start)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Start });
                }

                if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.Back)
                {
                    MessageBus.Bus.Instance.Publish(new ControllerInputEvent { Action = ControllerInputEvent.EventAction.Select });
                }


                //
                // Mouse and keyboard emulation
                //

                if (isMouseAndKeyboardModeEnabled)
                {
                    if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.A)
                    {
                        inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                    }

                    if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.B)
                    {
                        inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.ESCAPE);
                    }

                    if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.RB)
                    {
                        inputSimulator.Mouse.LeftButtonClick();
                    }

                    if (pressedXInputButtons.FirstOrDefault() == XInputControls.Button.RT)
                    {
                        inputSimulator.Mouse.RightButtonClick();
                    }
                }
            }

            if (pressedXInputButtons.Count == 2)
            {
                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.Start))
                {
                    App.MissionControl.StartGamesPlatformLauncher();
                }

                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.Back))
                {
                    App.MissionControl.AltTab();
                }

                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.RS))
                {
                    App.MissionControl.ToggleOnScreenKeyboard();
                }

                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.LS))
                {
                    ToggleMouseKeyboardEmulation();
                }

                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.DpadLeft))
                {
                    App.MissionControl.AltEnter();
                }

                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.DpadUp))
                {
                    App.MissionControl.VolumeUp();
                }

                if (pressedXInputButtons.Contains(XInputControls.Button.Guide) && pressedXInputButtons.Contains(XInputControls.Button.DpadDown))
                {
                    App.MissionControl.VolumeDown();
                }
            }

            if (pressedDS4Buttons.Count == 5)
            {
                if (pressedXInputButtons.Contains(XInputControls.Button.Guide)
                    && pressedXInputButtons.Contains(XInputControls.Button.LB)
                    && pressedXInputButtons.Contains(XInputControls.Button.LT)
                    && pressedXInputButtons.Contains(XInputControls.Button.RB)
                    && pressedXInputButtons.Contains(XInputControls.Button.RT))
                {
                    App.MissionControl.AltF4();
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
                e.Controller.DeviceGeneralStateChanged += OnDS4ControllerGeneralStateChanged;

                App.MissionControl.ShowNotification("DS4 Controller connected");
            }
            else
            {
                e.Controller.DeviceButtonStateChanged -= OnDS4ControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged -= OnDS4ControllerAnalogStateChanged;
                e.Controller.DeviceTouchPadMoved -= OnDS4ControllerTouchPadMoved;
                e.Controller.DeviceGeneralStateChanged -= OnDS4ControllerGeneralStateChanged;

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
                    inputSimulator.Mouse.HorizontalScroll(e.Value[0] * mouseSpeedMultiplier / 64);
                    inputSimulator.Mouse.VerticalScroll(-(e.Value[1] * mouseSpeedMultiplier / 64));
                }
            }

            if (e.Analog == DS4Controls.Analog.RightThumbStick)
            {
                if (isMouseAndKeyboardModeEnabled)
                {
                    inputSimulator.Mouse.MoveMouseBy(e.Value[0] * mouseSpeedMultiplier / 20, e.Value[1] * mouseSpeedMultiplier / 20);
                }
            }
        }

        private void OnDS4ControllerTouchPadMoved(object sender, DS4Controller.DeviceTouchPadMovedEventArgs e)
        {
            if (isMouseAndKeyboardModeEnabled)
            {
                inputSimulator.Mouse.MoveMouseBy(e.DeltaX * mouseSpeedMultiplier / 2, e.DeltaY * mouseSpeedMultiplier / 2);
            }
        }

        private void OnDS4ControllerGeneralStateChanged(object sender, DS4Controller.DeviceGeneralStateChangedEventArgs e)
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

        private void OnXInputControllerConnectionStateChanged(object sender, XInputControllerManager.DeviceConnectionStateChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                e.Controller.DeviceButtonStateChanged += OnXInputControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged += OnXInputControllerAnalogStateChanged;
                e.Controller.DeviceGeneralStateChanged += OnXInputControllerGeneralStateChanged;

                App.MissionControl.ShowNotification("XInput Controller connected");
            }
            else
            {
                e.Controller.DeviceButtonStateChanged -= OnXInputControllerButtonStateChanged;
                e.Controller.DeviceAnalogStateChanged -= OnXInputControllerAnalogStateChanged;
                e.Controller.DeviceGeneralStateChanged -= OnXInputControllerGeneralStateChanged;

                DisableMouseKeyboardEmulation();

                App.MissionControl.ShowNotification("XInput Controller disconnected");
            }
        }

        private void OnXInputControllerButtonStateChanged(object sender, XInputController.DeviceButtonStateChangedEventArgs e)
        {
            // Parsing button press combinations
            if (e.IsPressed)
            {
                pressedXInputButtons.Add(e.Button);
            }
            else
            {
                pressedXInputButtons.Remove(e.Button);
            }

            ParsePressedXInputButtons();

            //
            // Parsing more complex input sequences and states
            //

            // Handling mouse speed modifier change states
            if (e.Button == XInputControls.Button.LB && e.IsPressed)
            {
                mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_FAST;
            }
            else if (e.Button == XInputControls.Button.LT && e.IsPressed)
            {
                mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_SLOW;
            }
            else
            {
                mouseSpeedMultiplier = MOUSE_SPEED_MULTIPLIER_DEFAULT;
            }
        }

        private void OnXInputControllerAnalogStateChanged(object sender, XInputController.DeviceAnalogStateChangedEventArgs e)
        {
            if (e.Analog == XInputControls.Analog.LeftThumbStick)
            {
                if (isMouseAndKeyboardModeEnabled)
                {
                    inputSimulator.Mouse.HorizontalScroll(e.Value[0] * mouseSpeedMultiplier / 64);
                    inputSimulator.Mouse.VerticalScroll(-(e.Value[1] * mouseSpeedMultiplier / 64));
                }
            }

            if (e.Analog == XInputControls.Analog.RightThumbStick)
            {
                if (isMouseAndKeyboardModeEnabled)
                {
                    inputSimulator.Mouse.MoveMouseBy(e.Value[0] * mouseSpeedMultiplier / 20, e.Value[1] * mouseSpeedMultiplier / 20);
                }
            }
        }

        private void OnXInputControllerGeneralStateChanged(object sender, XInputController.DeviceGeneralStateChangedEventArgs e)
        {
            //switch (e.Battery)
            //{
            //    case BATTERY_THRESHOLD_LOW:
            //    case BATTERY_THRESHOLD_VERY_LOW:
            //        App.MissionControl.ShowNotification("Low controller battery warning: " + e.Battery + "%");
            //        break;
            //}

            //if (e.Battery <= BATTERY_THRESHOLD_CRITICAL)
            //{
            //    App.MissionControl.ShowStickyNotification("Controller battery very low: " + e.Battery + "%", TAG_BATTERY_STATE);
            //}
            //else
            //{
            //    App.MissionControl.HideStickyNotification(TAG_BATTERY_STATE);
            //}
        }
    }
}

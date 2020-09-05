using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApiLibrary;

namespace GamePad_Intercepts.Forms
{
    public partial class OnScreenKeyboardForm : Form
    {
        private WindowsFormsSynchronizationContext synchronizationContext;
        
        private Point[] possiblePositions;
        private int currentPositionIndex;

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= User32.WS_EX_TOPMOST;
                createParams.ExStyle |= User32.WS_EX_NOACTIVATE;

                return createParams;
            }
        }

        public OnScreenKeyboardForm(WindowsFormsSynchronizationContext synchronizationContext)
        {
            InitializeComponent();

            this.synchronizationContext = synchronizationContext;
            this.possiblePositions = new Point[]
            {
                new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2, Screen.PrimaryScreen.Bounds.Height - (int) (Height * 1.1)),
                new Point((Screen.PrimaryScreen.Bounds.Width - Width) / 2, (int) (Height * .1)),
                new Point(Screen.PrimaryScreen.Bounds.Width - (int) (Width * 1.1), (int) (Height * .1)),
                new Point(Screen.PrimaryScreen.Bounds.Width - (int) (Width * 1.1), Screen.PrimaryScreen.Bounds.Height - (int) (Height * 1.1)),
                new Point((int) (Width * .1), Screen.PrimaryScreen.Bounds.Height - (int) (Height * 1.1)),
                new Point((int) (Width * .1), (int) (Height * .1)),
            };
            this.currentPositionIndex = 0;

            StartPosition = FormStartPosition.Manual;
            Location = possiblePositions[currentPositionIndex];
        }

        public new void Show()
        {
            // Setting this form's window as topmost
            User32.SetWindowPos(Handle, User32.HWND_TOPMOST, 0, 0, 0, 0, User32.SWP_NOACTIVATE | User32.SWP_NOMOVE | User32.SWP_NOSIZE);

            base.Show();

            App.MissionControl.DisableControllerMouseKeyboardEmulation();

            MessageBus.Bus.Instance.Subscribe<ControllerInputEvent>(this, OnControllerInputEvent);
        }

        public new void Hide()
        {
            MessageBus.Bus.Instance.Unsubscribe(this);

            App.MissionControl.EnableControllerMouseKeyboardEmulation();

            base.Hide();
        }

        public void ToggleShow()
        {
            synchronizationContext.Post((state) =>
            {
                if (Visible)
                {
                    Hide();
                }
                else
                {
                    Show();
                }
            }, null);
        }

        private void CycleKeyboardPosition()
        {
            currentPositionIndex++;

            if (currentPositionIndex >= possiblePositions.Length)
            {
                currentPositionIndex = 0;
            }

            Location = possiblePositions[currentPositionIndex];
        }

        private void OnControllerInputEvent(ControllerInputEvent message)
        {
            synchronizationContext.Post((state) =>
            {
                if (message.Action == ControllerInputEvent.EventAction.Left)
                {
                    keyboard.NavigateLeft();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Up)
                {
                    keyboard.NavigateUp();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Right)
                {
                    keyboard.NavigateRight();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Down)
                {
                    keyboard.NavigateDown();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Cross)
                {
                    keyboard.PressKey();
                }
                else if (message.Action ==  ControllerInputEvent.EventAction.Square)
                {
                    keyboard.PressDeleteKey();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Triangle)
                {
                    keyboard.PressSpacebarKey();
                }
                else if (message.Action == ControllerInputEvent.EventAction.L1)
                {
                    keyboard.PressShiftKey();
                }
                else if (message.Action == ControllerInputEvent.EventAction.R1)
                {
                    keyboard.PressSpecialKey();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Start)
                {
                    keyboard.PressEnterKey();
                }
                else if (message.Action == ControllerInputEvent.EventAction.Select)
                {
                    CycleKeyboardPosition();
                }
            }, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApiLibrary;

namespace GamePad_Intercepts
{
    class MouseAndKeyboardRobot
    {
        private static void Move(int dX, int dY, float multiplier = 1f)
        {
            User32.GetCursorPos(out User32.POINT position);
            position.x += (int) (multiplier * dX);
            position.y += (int) (multiplier * dY);
            User32.SetCursorPos(position.x, position.y);
        }

        private static void MoveTo(int x, int y)
        {
            User32.SetCursorPos(x, y);
        }

        private static void LeftDown()
        {
            User32.GetCursorPos(out User32.POINT cursorPosition);
            User32.mouse_event(User32.MOUSEEVENTF_LEFT_DOWN, cursorPosition.x, cursorPosition.y);
        }

        private static void LeftUp()
        {
            User32.GetCursorPos(out User32.POINT cursorPosition);
            User32.mouse_event(User32.MOUSEEVENTF_LEFT_UP, cursorPosition.x, cursorPosition.y);
        }

        private static void LeftClick()
        {
            User32.GetCursorPos(out User32.POINT cursorPosition);
            User32.mouse_event(User32.MOUSEEVENTF_LEFT_DOWN | User32.MOUSEEVENTF_LEFT_UP, cursorPosition.x, cursorPosition.y);
        }

        private static void RightDown()
        {
            User32.GetCursorPos(out User32.POINT cursorPosition);
            User32.mouse_event(User32.MOUSEEVENTF_RIGHT_DOWN, cursorPosition.x, cursorPosition.y);
        }

        private static void RightUp()
        {
            User32.GetCursorPos(out User32.POINT cursorPosition);
            User32.mouse_event(User32.MOUSEEVENTF_RIGHT_UP, cursorPosition.x, cursorPosition.y);
        }

        private static void RightClick()
        {
            User32.GetCursorPos(out User32.POINT cursorPosition);
            User32.mouse_event(User32.MOUSEEVENTF_RIGHT_DOWN | User32.MOUSEEVENTF_RIGHT_UP, cursorPosition.x, cursorPosition.y);
        }

        private static void PressKey(Keys key)
        {
            User32.keybd_event((byte) key, 0);
        }

        private static void ReleaseKey(Keys key)
        {
            User32.keybd_event((byte) key, 0, User32.KEYEVENTF_KEYUP);
        }
    }
}

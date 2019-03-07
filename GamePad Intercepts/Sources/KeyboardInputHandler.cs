using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApi;

namespace GamePad_Intercepts
{
    class KeyboardInputMonitor
    {
        private static User32.LowLevelKeyboardProc lowLevelKeyboardProcess = HookCallback;
        private static IntPtr hookID = IntPtr.Zero;

        private static HashSet<Keys> pressedKeys;
        
        static KeyboardInputMonitor()
        {
            pressedKeys = new HashSet<Keys>();
        }

        public void Init()
        {
            hookID = SetHook(lowLevelKeyboardProcess);
        }

        public void CleanUp()
        {
            User32.UnhookWindowsHookEx(hookID);
        }

        private IntPtr SetHook(User32.LowLevelKeyboardProc proc)
        {
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                return User32.SetWindowsHookEx(User32.WH_KEYBOARD_LL, proc, User32.GetModuleHandle(currentModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var vkCode = Marshal.ReadInt32(lParam);
                var key = (Keys) vkCode;
                RegisterKeyInput(wParam, key);
            }

            return User32.CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private static void RegisterKeyInput(IntPtr action, Keys key)
        {
            if (action == (IntPtr) User32.WM_KEYDOWN)
            {
                pressedKeys.Add(key);
                ParsePressedKeys();
            }

            if (action == (IntPtr) User32.WM_KEYUP)
            {
                pressedKeys.Remove(key);
            }
        }

        private static void ParsePressedKeys()
        {
            if (pressedKeys.Count == 1)
            {
                if (pressedKeys.FirstOrDefault() == Keys.VolumeUp) App.MessageCenter.VolumeUp();
                if (pressedKeys.FirstOrDefault() == Keys.VolumeDown) App.MessageCenter.VolumeDown();
            }
            
            if (pressedKeys.Count == 3)
            {
                if (pressedKeys.Contains(Keys.LControlKey) && pressedKeys.Contains(Keys.LMenu) && pressedKeys.Contains(Keys.H)) App.MessageCenter.ToggleHomeScreen();
            }
        }
    }
}

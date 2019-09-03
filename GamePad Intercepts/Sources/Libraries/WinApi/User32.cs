using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinApi
{
    class User32
    {
        public const int GWLP_ID = -12;
        public const int GWLP_HINSTANCE = -6;
        public const int GWLP_HWNDPARENT = -8;
        public const int GWLP_WNDPROC = -4;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_STYLE = -16;

        public const uint SWP_NOACTIVATE = 0x0010;
        public const uint SWP_FRAMECHANGED = 0x0020;
        public const uint SWP_HIDEWINDOW = 0x0080;
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOOWNERZORDER = 0x0200;
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOZORDER = 0x0004;

        public const int WH_KEYBOARD_LL = 13;
        public const int WH_MOUSE_LL = 14;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;

        public const long WS_BORDER = 0x00800000L;
        public const long WS_CAPTION = 0x00C00000L;
        public const long WS_DISABLED = 0x08000000L;
        public const long WS_MAXIMIZEBOX = 0x00010000L;
        public const long WS_MINIMIZEBOX = 0x00020000L;
        public const long WS_OVERLAPPED = 0x00000000L;
        public const long WS_SIZEBOX = 0x00040000L;
        public const long WS_THICKFRAME = 0x00040000L;
        public const long WS_SYSMENU = 0x00080000L;
        public const long WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;

        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_NOACTIVATE = 0x08000000;

        public const uint MONITOR_DEFAULTTONULL = 0x00000000;
        public const uint MONITOR_DEFAULTTOPRIMARY = 0x00000001;
        public const uint MONITOR_DEFAULTTONEAREST = 0x0000000;

        public const int MOUSEEVENTF_LEFT_DOWN = 0x02;
        public const int MOUSEEVENTF_LEFT_UP = 0x04;
        public const int MOUSEEVENTF_MIDDLE_DOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLE_UP = 0x40;
        public const int MOUSEEVENTF_RIGHT_DOWN = 0x08;
        public const int MOUSEEVENTF_RIGHT_UP = 0x10;

        public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const uint KEYEVENTF_KEYUP = 0x0002;

        public const uint OCR_APPSTARTING = 32650; //Standard arrow and small hourglass
        public const uint OCR_NORMAL = 32512; // Standard arrow
        public const uint OCR_CROSS = 32515; //Crosshair
        public const uint OCR_HAND = 32649; // Windows 2000/XP: Hand
        public const uint OCR_HELP = 32651; // Arrow and question mark
        public const uint OCR_IBEAM = 32513; // I-beam
        public const uint OCR_NO = 32648; // Slashed circle
        public const uint OCR_SIZEALL = 32646; // Four-pointed arrow pointing north, south, east, and west
        public const uint OCR_SIZENESW = 32643; // Double-pointed arrow pointing northeast and southwest
        public const uint OCR_SIZENS = 32645; // Double-pointed arrow pointing north and south
        public const uint OCR_SIZENWSE = 32642; // Double-pointed arrow pointing northwest and southeast
        public const uint OCR_SIZEWE = 32644; // Double-pointed arrow pointing west and east
        public const uint OCR_UP = 32516; // Vertical arrow
        public const uint OCR_WAIT = 32514; // Hourglass

        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);


        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);


        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT point);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, out MONITORINFO lpmi);

        [DllImport("user32.dll")]
        public static extern bool GetWindowInfo(IntPtr hwnd, out WINDOWINFO pwi);

        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursorFromFile(string path);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hcur, uint id);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        public static extern int ShowCursor(bool bShow);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ExitWindowsEx(ExitWindowsFlags uFlags, ShutdownReason dwReason);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons = 0, uint dwExtraInfo = 0);

        [DllImport("User32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags = 0, int dwExtraInfo = 0);


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Width()
            {
                return Right - Left;
            }

            public int Height()
            {
                return Bottom - Top;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MONITORINFO
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;

            public void Init()
            {
                cbSize = (uint) Marshal.SizeOf(typeof(MONITORINFO));
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public uint cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;

            public void Init()
            {
                cbSize = (uint) Marshal.SizeOf(typeof(WINDOWINFO));
            }
        }

        [Flags]
        public enum ExitWindowsFlags : uint
        {
            // One of the following five:
            LogOff = 0x00,
            ShutDown = 0x01,
            Reboot = 0x02,
            PowerOff = 0x08,
            RestartApps = 0x40,

            // plus AT MOST one of the following two:
            Force = 0x04,
            ForceIfHung = 0x10,
        }

        [Flags]
        public enum ShutdownReason : uint
        {
            MajorApplication = 0x00040000,
            MajorHardware = 0x00010000,
            MajorLegacyApi = 0x00070000,
            MajorOperatingSystem = 0x00020000,
            MajorOther = 0x00000000,
            MajorPower = 0x00060000,
            MajorSoftware = 0x00030000,
            MajorSystem = 0x00050000,

            MinorBlueScreen = 0x0000000F,
            MinorCordUnplugged = 0x0000000b,
            MinorDisk = 0x00000007,
            MinorEnvironment = 0x0000000c,
            MinorHardwareDriver = 0x0000000d,
            MinorHotfix = 0x00000011,
            MinorHung = 0x00000005,
            MinorInstallation = 0x00000002,
            MinorMaintenance = 0x00000001,
            MinorMMC = 0x00000019,
            MinorNetworkConnectivity = 0x00000014,
            MinorNetworkCard = 0x00000009,
            MinorOther = 0x00000000,
            MinorOtherDriver = 0x0000000e,
            MinorPowerSupply = 0x0000000a,
            MinorProcessor = 0x00000008,
            MinorReconfig = 0x00000004,
            MinorSecurity = 0x00000013,
            MinorSecurityFix = 0x00000012,
            MinorSecurityFixUninstall = 0x00000018,
            MinorServicePack = 0x00000010,
            MinorServicePackUninstall = 0x00000016,
            MinorTermSrv = 0x00000020,
            MinorUnstable = 0x00000006,
            MinorUpgrade = 0x00000003,
            MinorWMI = 0x00000015,

            FlagUserDefined = 0x40000000,
            FlagPlanned = 0x80000000
        }
    }
}

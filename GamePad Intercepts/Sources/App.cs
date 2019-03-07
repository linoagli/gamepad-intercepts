using GamePad_Intercepts.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WinApi;

namespace GamePad_Intercepts
{
    class App : ApplicationContext
    {
        public static readonly string PATH_DIRECTORY_APP_ROOT = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string PATH_DIRECTORY_BROWSER_CACHE = Path.Combine(PATH_DIRECTORY_APP_ROOT, @"browserCache");
        public static readonly string PATH_FILE_NIRCMD = Path.Combine(PATH_DIRECTORY_APP_ROOT, @"Assets\nircmd.exe");
        public static readonly string PATH_FILE_ON_SCREEN_KEYBOARD = Path.Combine(PATH_DIRECTORY_APP_ROOT, @"Assets\FreeVK.exe"); // TODO: Might need to find another free or open source alternative
        public static readonly string PATH_FILE_XADDITUS = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"xadditus_app\xadditus_app.exe");
        public static readonly string PATH_FILE_STEAM = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Steam\Steam.exe");

        private static MainForm mainForm;
        private static MessageOnlyForm messageOnlyForm;
        private static NotificationForm notificationForm;
        private static StickyNotificationForm stickyNotificationForm;

        private static WindowsFormsSynchronizationContext synchronizationContext;

        private static NotificationManager notificationManager;
        private static SystemMonitor systemMonitor;
        private static KeyboardInputMonitor keyboardInputMonitor;
        private static ControllerInputManager controllerInputManager;

        private static Process onScreenKeyboardProcess;

        public App()
        {
            // WARNING: The order of the initializations below is important. See comments for details

            // Setting environment variables
            Environment.SetEnvironmentVariable("SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS", "0", EnvironmentVariableTarget.User); // Prevents full screen apps (mostly games) using SDL from minizing on focus loss

            // Creating the instances of our forms here. This will guarantee a WindowsFormsSynchronizationContext
            // instance is created and available for future use
            mainForm = new MainForm();
            messageOnlyForm = new MessageOnlyForm();
            notificationForm = new NotificationForm();
            stickyNotificationForm = new StickyNotificationForm();

            // Holding onto a reference of the WindowsFormsSynchronizationContext instance for use running some code
            // on the main windows forms thread when necessary
            synchronizationContext = (WindowsFormsSynchronizationContext)SynchronizationContext.Current;

            // Performing all other necessary initializations and setups below
            notificationManager = new NotificationManager(synchronizationContext);
            notificationManager.NotificationForm = notificationForm;
            notificationManager.StickyNotificationForm = stickyNotificationForm;

            systemMonitor = new SystemMonitor(mainForm.HomeUserControl); // TODO: decouple the monitor from the control and implement some form of message bus system
            systemMonitor.Run();

            keyboardInputMonitor = new KeyboardInputMonitor();
            keyboardInputMonitor.Init();

            controllerInputManager = new ControllerInputManager();
            controllerInputManager.Init();

            // Launching the necessary 3rd party apps
            ProcessStartInfo xadditusProcessInfo = new ProcessStartInfo();
            xadditusProcessInfo.FileName = PATH_FILE_XADDITUS;
            xadditusProcessInfo.UseShellExecute = true;
            xadditusProcessInfo.Arguments = "";
            xadditusProcessInfo.Verb = "runas";
            Process.Start(xadditusProcessInfo);

            // Launching the home screen
            MessageCenter.ToggleHomeScreen();
        }

        public class MessageCenter
        {
            public static void ShowNotification(string message)
            {
                Console.WriteLine("Notifying: " + message);
                notificationManager.Notify(message);
            }

            public static void ShowStickyNotification(string message, string tag)
            {
                Console.WriteLine("Notifying sticky: " + message);
                notificationManager.NotifySticky(message, tag);
            }

            public static void HideStickyNotification(string tag)
            {
                notificationManager.DismissSticky(tag);
            }

            public static void VolumeUp()
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = PATH_FILE_NIRCMD;
                psi.Arguments = "changesysvolume 1300";
                psi.CreateNoWindow = true;
                Process proc = Process.Start(psi);
                proc.WaitForExit(1500);

                systemMonitor.UpdateSystemVolumeInfo();
            }

            public static void VolumeDown()
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = PATH_FILE_NIRCMD;
                psi.Arguments = "changesysvolume -1300";
                psi.CreateNoWindow = true;
                Process.Start(psi);
                Process proc = Process.Start(psi);
                proc.WaitForExit(1500);

                systemMonitor.UpdateSystemVolumeInfo();
            }

            public static void StartGamesPlatformLauncher()
            {
                ProcessStartInfo steamProcessInfo = new ProcessStartInfo();
                steamProcessInfo.FileName = PATH_FILE_STEAM;
                steamProcessInfo.Arguments = "-bigpicture"; // TODO: "-bigpicture -window"
                Process.Start(steamProcessInfo);

                mainForm.Hide();
            }

            public static void ToggleHomeScreen()
            {
                synchronizationContext.Post(delegate
                {                    
                    if (!mainForm.Visible)
                    {
                        mainForm.Show();
                        User32.SetForegroundWindow(mainForm.Handle);

                        mainForm.ShowHomeUserControl();
                    }
                    else
                    {
                        mainForm.Hide();
                    }
                }, null);
            }

            public static void ShowWebBrowser()
            {
                synchronizationContext.Post(delegate
                {
                    if (!mainForm.Visible)
                    {
                        mainForm.Show();
                        User32.SetForegroundWindow(mainForm.Handle);
                    }

                    mainForm.ShowWebBrowserUserControl();
                }, null);
            }

            public static void ShowWifiSettings()
            {
                synchronizationContext.Post(delegate
                {
                    if (!mainForm.Visible)
                    {
                        mainForm.Show();
                        User32.SetForegroundWindow(mainForm.Handle);
                    }

                    mainForm.ShowWifiSetupUserControl();
                }, null);
            }

            public static void ToggleOnScreenKeyboard()
            {
                if (!Utils.IsProcessRunning(onScreenKeyboardProcess))
                {
                    onScreenKeyboardProcess = Process.Start(new ProcessStartInfo() { FileName = PATH_FILE_ON_SCREEN_KEYBOARD });
                }
                else
                {
                    onScreenKeyboardProcess.Kill();
                    onScreenKeyboardProcess = null;
                }
            }

            public static void ShowSoundControlPanel()
            {
                Process.Start("mmsys.cpl");
            }

            public static void EnableControllerMouseKeyboardEmulation()
            {
                controllerInputManager.EnableMouseKeyboardEmulation();
            }

            public static void DisableControllerMouseKeyboardEmulation()
            {
                controllerInputManager.DisableMouseKeyboardEmulation();
            }

            public static void AltTab()
            {
                messageOnlyForm.AltTab();
            }
        }
    }
}

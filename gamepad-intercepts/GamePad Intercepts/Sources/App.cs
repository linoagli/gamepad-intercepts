using GamePad_Intercepts.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GamePad_Intercepts
{
    class App : ApplicationContext
    {
        public static readonly string PATH_DIRECTORY_APP_ROOT = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string PATH_DIRECTORY_BROWSER_CACHE = Path.Combine(PATH_DIRECTORY_APP_ROOT, @"browserCache");
        public static readonly string PATH_FILE_NIRCMD = Path.Combine(PATH_DIRECTORY_APP_ROOT, @"Assets\nircmd.exe");
        public static readonly string PATH_FILE_ON_SCREEN_KEYBOARD = Path.Combine(PATH_DIRECTORY_APP_ROOT, @"Assets\FreeVK.exe"); // TODO: Might need to find another free or open source alternative
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

            notificationManager = new NotificationManager(synchronizationContext);
            notificationManager.NotificationForm = notificationForm;
            notificationManager.StickyNotificationForm = stickyNotificationForm;

            systemMonitor = new SystemMonitor();
            systemMonitor.Run();

            keyboardInputMonitor = new KeyboardInputMonitor();
            keyboardInputMonitor.Init();

            controllerInputManager = new ControllerInputManager();
            controllerInputManager.Init();

            // Locking up the app and launching the main UI
            MessageBus.Bus.Instance.Publish(new UIEvent { Action = UIEvent.EventAction.ShowHomeScreen });
        }

        public class MissionControl
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
                steamProcessInfo.Arguments = "-bigpicture";
                Process.Start(steamProcessInfo);

                mainForm.Hide();
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

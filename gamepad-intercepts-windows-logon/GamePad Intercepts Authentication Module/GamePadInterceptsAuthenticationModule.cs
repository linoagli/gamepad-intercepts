using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace GamePad_Intercepts_Authentication_Module
{
    [ComVisible(true)]
    [Guid("ABCF2CA4-804D-4D9A-ADF8-3C1B483721C6"), ClassInterface(ClassInterfaceType.None)]
    public class GamePadInterceptsAuthenticationModule : IGamePadInterceptsAuthenticationModule
    {
        private StatusBarForm statusBarForm;
        private ControllerInputManager controllerInputManager;
        public void StartControllerManagerService()
        {
            statusBarForm = new StatusBarForm();
            statusBarForm.Show();

            controllerInputManager = new ControllerInputManager();
            controllerInputManager.Init();
        }

        public void StopControllerManagerService()
        {
            controllerInputManager.CleanUp();
            controllerInputManager = null;

            statusBarForm.Close();
            statusBarForm.Dispose();
            statusBarForm = null;
        }

        public void Authenticate(IntPtr wHndlParent, [MarshalAs(UnmanagedType.LPWStr)] ref string username, out bool isAuthenticated)
        {
            AuthenticationWindow authenticationWindow = new AuthenticationWindow();
            new WindowInteropHelper(authenticationWindow).Owner = wHndlParent;
            authenticationWindow.ShowDialog();

            isAuthenticated = authenticationWindow.IsAuthenticated;
        }

        public void RequestPassword(IntPtr wHndlParent, [MarshalAs(UnmanagedType.LPWStr)] ref string username, [MarshalAs(UnmanagedType.LPWStr)] out string password)
        {
            PasswordRequestWindow passwordRequestWindow = new PasswordRequestWindow(username);
            new WindowInteropHelper(passwordRequestWindow).Owner = wHndlParent;
            passwordRequestWindow.ShowDialog();

            password = passwordRequestWindow.Password;
        }
    }
}

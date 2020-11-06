using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamePad_Intercepts_Authentication_Module
{
    [ComVisible(true)]
    [Guid("A8432EB7-BB63-4734-B371-D9FBE10F6066")]
    public interface IGamePadInterceptsAuthenticationModule
    {
        [DispId(1)]
        void StartControllerManagerService();

        [DispId(2)]
        void StopControllerManagerService();

        [DispId(3)]
        void Authenticate(IntPtr wHndlParent, [MarshalAs(UnmanagedType.LPWStr)] ref string username, out bool isAuthenticated);

        [DispId(4)]
        void RequestPassword(IntPtr wHndlParent, [MarshalAs(UnmanagedType.LPWStr)] ref string username, [MarshalAs(UnmanagedType.LPWStr)] out string password);
    }
}

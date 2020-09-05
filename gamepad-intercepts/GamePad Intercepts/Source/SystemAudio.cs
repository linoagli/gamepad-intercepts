using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Enumerations;
using Vannatech.CoreAudio.Externals;
using Vannatech.CoreAudio.Interfaces;

namespace GamePad_Intercepts
{
    class SystemAudio
    {
        public static float GetMasterVolumeLevel()
        {
            float level = -1;

            IAudioEndpointVolume masterVolume = null;
            try
            {
                masterVolume = GetMasterVolumeObject();

                if (masterVolume != null)
                    masterVolume.GetMasterVolumeLevelScalar(out level);
            }
            finally
            {
                if (masterVolume != null)
                    Marshal.ReleaseComObject(masterVolume);
            }

            return level;
        }

        private static IAudioEndpointVolume GetMasterVolumeObject()
        {
            IAudioEndpointVolume masterVolume = null;

            IMMDeviceEnumerator deviceEnumerator = null;
            IMMDevice defautOutDevice = null;
            try
            {
                deviceEnumerator = (IMMDeviceEnumerator) (new MMDeviceEnumerator());
                deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out defautOutDevice);

                Guid IID_IAudioEndpointVolume = typeof(IAudioEndpointVolume).GUID;
                object o;
                defautOutDevice.Activate(IID_IAudioEndpointVolume, 0, IntPtr.Zero, out o);
                masterVolume = (IAudioEndpointVolume) o;
            }
            finally
            {
                if (defautOutDevice != null) Marshal.ReleaseComObject(defautOutDevice);
                if (deviceEnumerator != null) Marshal.ReleaseComObject(deviceEnumerator);
            }

            return masterVolume;
        }

        [ComImport]
        [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
        internal class MMDeviceEnumerator {}
    }
}

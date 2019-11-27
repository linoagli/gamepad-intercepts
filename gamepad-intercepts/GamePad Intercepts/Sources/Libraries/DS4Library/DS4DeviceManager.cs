﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DS4Library
{
    class DS4DeviceManager
    {
        public DS4Controller Controller { get; private set; }

        public event EventHandler<DeviceConnectionStateChangedEventArgs> DeviceConnectionStateChanged;

        public DS4DeviceManager()
        {
            
        }

        public void Init()
        {
            Console.WriteLine("Initializing DS4 input handler...");

            new Thread(delegate ()
            {
                while (true)
                {
                    PurgeInactiveControllers();
                    FindControllers(); // TODO: Instead of polling, check for controllers on HID device changed/connected event?
                    Thread.Sleep(1000 * 3);
                }
            }).Start();
        }

        public void CleanUp()
        {
            // TODO: Stop scan loop or use thread pool management interface of some sort
        }

        private void FindControllers()
        {
            // If we already have a controller, skip the search
            if (Controller != null) return;

            try
            {
                DS4Devices.findControllers();
                IEnumerable<DS4Device> devices = DS4Devices.getDS4Controllers();

                if (devices.Count() < 1) return;

                DS4Device device = devices.FirstOrDefault();

                Console.WriteLine("Controller found: " + device.MacAddress + " (" + device.ConnectionType + ")");

                Controller = new DS4Controller(device);

                OnDeviceConnectionStateChanged(Controller, true);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        private void PurgeInactiveControllers()
        {
            if (Controller == null) return;

            if (Controller.Device == null)
            {
                OnDeviceConnectionStateChanged(Controller, false);

                Controller.Purge();
                Controller = null;
            }
        }

        private void OnDeviceConnectionStateChanged(DS4Controller controller,  bool isConnected)
        {
            DeviceConnectionStateChangedEventArgs args = new DeviceConnectionStateChangedEventArgs();
            args.Controller = controller;
            args.IsConnected = isConnected;

            DeviceConnectionStateChanged?.Invoke(this, args);
        }

        public class DeviceConnectionStateChangedEventArgs : EventArgs
        {
            public DS4Controller Controller { get; set; }
            public bool IsConnected { get; set; }
        }
    }
}

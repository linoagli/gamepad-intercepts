using Gameloop.Vdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace GamePad_Intercepts
{
    class SteamUtils
    {
        private readonly string installationDirectoryPath;

        public SteamUtils(string installationDirectoryPath)
        {
            this.installationDirectoryPath = installationDirectoryPath;
        }

        public void InstallAppBanners()
        {
            // apps list file: C:\Program Files (x86)\Steam\userdata\{userId}\config\localconfig
            // steam grid images path format: C:\Program Files (x86)\Steam\userdata\{userId}\config\grid\{appId}.jpg
            // object path: UserLocalConfigStore>Software>Valve>Steam>Apps
            // steam header image download url: http://cdn.akamai.steamstatic.com/steam/apps/{appId}/header.jpg

            // TODO: Add timestamp file and only download if last timestamp is a couple day old (maybe 3 or 5)

            new Thread(delegate ()
            {
                string[] userDataDirectories = Directory.GetDirectories(Path.Combine(installationDirectoryPath, @"userdata"));

                foreach (string userDataDirectory in userDataDirectories)
                {
                    string userConfigDirectory = Path.Combine(userDataDirectory, @"config");

                    Console.WriteLine($"Parsing the user config at {userConfigDirectory}");

                    InstallUserAppBanners(userConfigDirectory);
                }
            }).Start();
        }

        private void InstallUserAppBanners(string configDirectoryPath)
        {
            string configFilePath = Path.Combine(configDirectoryPath, @"localconfig.vdf");

            if (!File.Exists(configFilePath))
            {
                Console.WriteLine($"The config file at path <{configFilePath}> does not exist. Skipping...");
                return;
            }

            dynamic config = VdfConvert.Deserialize(File.ReadAllText(configFilePath));

            string rawAppList = null;

            try
            {
                rawAppList = config.Value.Software.Valve.Steam.Apps.ToString();
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Trying legacy key...");

                try
                {
                    rawAppList = config.Value.Software.valve.Steam.Apps.ToString();
                }
                catch (KeyNotFoundException ee)
                {
                    Console.WriteLine(ee.Message);
                }
            }

            if (rawAppList == null)
            {
                Console.WriteLine("Failed to read the config file. Skipping...");
                return;
            }

            Regex regex = new Regex(@"""\d*""\s*.*\{", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(rawAppList);

            WebClient webClient = new WebClient();

            Directory.CreateDirectory(Path.Combine(configDirectoryPath, @"grid"));

            foreach (Match match in matches)
            {
                string appId = match.Value.Replace('"', ' ').Replace('{', ' ').Trim();

                Console.WriteLine($"Extracted steam app id: {appId}");

                string url = $"http://cdn.akamai.steamstatic.com/steam/apps/{appId}/header.jpg";
                string localFilePath = Path.Combine(configDirectoryPath, $@"grid\{appId}.jpg");

                Console.WriteLine($"Attemtping to download app banner from {url} to {localFilePath}");

                try
                {
                    webClient.DownloadFile(url, localFilePath);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Failed to download file from {url}");
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
    }
}

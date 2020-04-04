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
            dynamic config = VdfConvert.Deserialize(File.ReadAllText(configFilePath));

            string rawAppList = config.Value.Software.Valve.Steam.Apps.ToString();

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

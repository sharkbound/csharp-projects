using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.IO;
using UnityEngine;

namespace ResetPlayerPosOnDeath
{
    class ResetPlayerPosOnDeath : RocketPlugin<ResetPlayerPosOnDeathConfig>
    {
        public static ResetPlayerPosOnDeath Instance;

        public string playersFolderPath;

        protected override void Load()
        {
            Instance = this;

            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;

            playersFolderPath = ResetPlayerPosOnDeath.Instance.Configuration.Instance.ServerPath + @"\Players\";

            Logger.Log("ResetPlayerPosOnDeath has loaded!");
            Logger.Log("ServerPath: " + ResetPlayerPosOnDeath.Instance.Configuration.Instance.ServerPath);
            Logger.Log("players Folder Path: " + playersFolderPath);

          /*  Logger.LogError("==========================================");
            Logger.LogError("provider.path (edited): " + getServerPath() );
            Logger.LogError("=========================================="); */
        }

        protected override void Unload()
        {
            Logger.Log("ResetPlayerPosOnDeath has Unloaded!");
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
        }

        public void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            string[] directories =  System.IO.Directory.GetDirectories(playersFolderPath);

            foreach (string id in Instance.Configuration.Instance.SteamIds)
            {
                if (player.Id == id)
                {
                    foreach (string dir in directories)
                    {
                        if (dir.Contains(player.Id))
                        {
                            //Logger.Log("found player directory for " + player.Id + " at:");
                            //Logger.Log(s);

                            string deleteDir = dir + @"\" + Provider.map + @"\Player\" + "Player.dat";
                            //Logger.LogError(deleteDir);

                            if (File.Exists(deleteDir))
                            {
                                Logger.Log("deleting player.dat file for player:" + "SteamId- " + player.Id + " / name- " + player.DisplayName);
                                File.Delete(dir + @"\" + Provider.map + @"\Player\" + "Player.dat"); 
                            }
                            else
                            {
                                Logger.LogError("Failed to find player.dat for player: name( " 
                                    + player.DisplayName + " ) / id( " + player.Id + " )" 
                                    + " at path( " + dir + " )");
                            }
                        }
                    }
                }
            }
        }

        public string getServerPath()
        {
            string path;

            //path = Provider.path;
            path = string.Copy(Application.dataPath);
            //path = Application.dataPath;

            path = path.Remove(path.LastIndexOf('/'), path.LastIndexOf('a') - path.LastIndexOf('/'));
            path = path.Remove(path.LastIndexOf('a'), 1);

            path += "/Servers/";

            return path;
        }
    }
}

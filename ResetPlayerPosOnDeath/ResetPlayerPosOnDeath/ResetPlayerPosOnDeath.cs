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
        }

        protected override void Unload()
        {
            Logger.Log("ResetPlayerPosOnDeath has Unloaded!");
        }

        public void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            string[] directories =  System.IO.Directory.GetDirectories(playersFolderPath);

            bool playerIdIsFoundInList = false;

            foreach (string id in Instance.Configuration.Instance.SteamIds)
            {
                if (player.Id == id)
                {
                    foreach (string s in directories)
                    {
                        if (s.Contains(player.Id))
                        {
                            //Logger.Log("found player directory for " + player.Id + " at:");
                            //Logger.Log(s);

                            string deleteDir = s + @"\" + Provider.map + @"\Player\" + "Player.dat";
                            //Logger.LogError(deleteDir);

                            if (File.Exists(deleteDir))
                            {
                                Logger.Log("deleting player.dat file for player:" + "SteamId- " + player.Id + " / name- " + player.DisplayName);
                                File.Delete(s + @"\" + Provider.map + @"\Player\" + "Player.dat"); 
                            }
                        }
                    }
                }
            }
        }
    }
}

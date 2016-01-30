using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Rocket.Core;
using Rocket.Unturned;

namespace giveVehicleNonAdmin
{
    public class giveVehicle : RocketPlugin<GiveVehicleConfiguration>
    {
        public static giveVehicle instance = null;

        public static Dictionary<string, DateTime> IndividualCooldowns = new Dictionary<string, DateTime>();
        public static Dictionary<string, bool> FirstCommandExecution = new Dictionary<string, bool>();

        protected override void Load()
        {
            instance = this;
            Logger.Log("giveVehicle has loaded!");
            Logger.LogError("Command cooldown has been set to: " + instance.Configuration.Instance.SpawnCooldown);
            Logger.LogError("helicopter id has been set to: " + instance.Configuration.Instance.HelicopterId);
            Logger.LogError("plane id has been set to: " + instance.Configuration.Instance.planeId);
            Logger.LogError("boat id has been set to: " + instance.Configuration.Instance.BoatId);
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
        }

        protected override void Unload()
        {
            Logger.Log("giveVehicle has unloaded!");
        }

        public void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            try
            {
                FirstCommandExecution.Remove(player.DisplayName);
                IndividualCooldowns.Remove(player.DisplayName);
            }
            catch
            {

            }
        }

        public void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            try
            {
                IndividualCooldowns.Add(player.DisplayName, DateTime.Now);
                FirstCommandExecution.Add(player.DisplayName, true);
            }
            catch
            {

            }
        }
    }
}

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

        public static Dictionary<string, float> IndividualCooldowns = new Dictionary<string, float>();

        protected override void Load()
        {
            instance = this;
            Logger.Log("giveVehicle has loaded!");
            Logger.LogError("Command cooldown has been set to: " + instance.Configuration.Instance.SpawnCooldown);
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
        }

        protected override void Unload()
        {
            Logger.Log("giveVehicle has unloaded!");
        }

        void FixedUpdate()
        {
            try
            {
                foreach (var entry in IndividualCooldowns)
                {
                    if (IndividualCooldowns[entry.Key] >= 0f)
                    {
                        IndividualCooldowns[entry.Key] -= 0.016f;
                    }
                } 
            }
            catch
            {

            }
        }

        public void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            try
            {
                IndividualCooldowns.Remove(player.DisplayName);
            }
            catch
            {

            }
        }
    }
}

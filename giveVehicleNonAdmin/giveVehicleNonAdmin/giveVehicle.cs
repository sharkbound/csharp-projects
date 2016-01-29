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

namespace giveVehicleNonAdmin
{
    public class giveVehicle : RocketPlugin<GiveVehicleConfiguration>
    {
        public static giveVehicle instance = null;

        public static Dictionary<string, float> PIndividualCooldowns = new Dictionary<string, float>();
        public static Dictionary<string, int> HIndividualCooldowns = new Dictionary<string, int>();


        protected override void Load()
        {
            instance = this;
            Logger.Log("giveVehicle has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("giveVehicle has unloaded!");
        }

        void FixedUpdate()
        {
            try
            {
                foreach (var entry in PIndividualCooldowns)
                {
                    if (PIndividualCooldowns[entry.Key] > 0f)
                    {
                        PIndividualCooldowns[entry.Key] -= 0.016f;
                    }
                } 
            }
            catch
            {

            }
        }
    }
}

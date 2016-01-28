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

        protected override void Load()
        {
            instance = this;
            Logger.Log("giveVehicle has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("giveVehicle has unloaded!");
        }
    }
}

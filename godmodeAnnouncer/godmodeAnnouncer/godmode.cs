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

namespace godmodeAnnouncer
{
    class godmode : RocketPlugin<GodModeAnnounceConfig>
    {
        public static int LastVehicleCount;
        public static DateTime LastClear;
        public static bool ClearRunning = false;
        public static godmode Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("GodmodeAnnouncer has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("GodmodeAnnouncer has Unloaded!");
        }
    }
}

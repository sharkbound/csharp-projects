using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.API.Collections;
using UnityEngine;
using Rocket.Core.Plugins;
using Logger = Rocket.Core.Logging.Logger;
using System.Timers;
using SDG.Unturned;
using Rocket.Unturned.Player;
using Rocket.Unturned.Events;

namespace RocketDummy
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance { get; private set; }
        Timer timer;

        protected override void Load()
        {

        }

        protected override void Unload()
        {
        }
    }
}

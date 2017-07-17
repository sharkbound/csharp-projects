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

        protected override void Load()
        {
            ushort id = 1475;
            ItemMeleeAsset a = (ItemMeleeAsset)Assets.find(EAssetType.ITEM, id);
            Console.WriteLine($"ORIG {a.isInvulnerable}");
            Console.WriteLine("SETTING TO " + !a.isInvulnerable);
            a.isInvulnerable = !a.isInvulnerable;
            a = null;
            Console.WriteLine("NEW " + ((ItemMeleeAsset)Assets.find(EAssetType.ITEM, id)).isInvulnerable);
        }

        protected override void Unload()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Unturned.Player;
using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;

namespace EasyAmmoRocketMod
{
    public class EasyAmmo : RocketPlugin<EasyAmmoConfig>
    {
        public static EasyAmmo Instance;

        protected override void Load()
        {
            Instance = this;

            Logger.Log("EasyAmmo loaded!");
            Logger.Log("PluginEnabled : " + Instance.Configuration.Instance.PluginEnabled.ToString());
        }

        protected override void Unload()
        {
            Logger.Log("EasyAmmo Unloaded!");
        }
    }
}

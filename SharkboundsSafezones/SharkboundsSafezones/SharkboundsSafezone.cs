using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;

namespace SharkboundsSafezones
{
    public class SharkboundsSafezone : RocketPlugin<SafeZonesConfig>
    {
        protected override void Load()
        {
            Logger.Log("SharkboundsSafezone has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("SharkboundsSafezone has Unloaded!");

        }
    }
}

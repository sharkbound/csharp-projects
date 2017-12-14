using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace EasyRepCommand
{
    public class EasyRep : RocketPlugin
    {
        protected override void Load()
        {
            Logger.Log("EasyRep loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("EasyRep unloaded!");
        }
    }
}

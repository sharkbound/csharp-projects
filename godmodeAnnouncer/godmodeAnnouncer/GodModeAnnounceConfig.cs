using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Plugins;

namespace godmodeAnnouncer
{
    public class GodModeAnnounceConfig : IRocketPluginConfiguration
    {
        public int DelayBetweenClears;

        public void LoadDefaults()
        {
            DelayBetweenClears = 200;
        }
    }
}

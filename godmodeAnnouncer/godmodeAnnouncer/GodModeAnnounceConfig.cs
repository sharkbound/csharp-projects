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
        public int ClearNoticationInterval;
        public bool IgnoreVehiclesWithBarricades;

        public void LoadDefaults()
        {
            ClearNoticationInterval = 5;
            DelayBetweenClears = 400;
            IgnoreVehiclesWithBarricades = true;
        }
    }
}

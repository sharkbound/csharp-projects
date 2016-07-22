using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace AutoClear
{
    public class Config : IRocketPluginConfiguration
    {
        public int TimeUntilDespawn;
        public bool IgnoreVehiclesWithBarricades;
        public bool LogClears;
        public int Radius;

        public void LoadDefaults()
        {
            IgnoreVehiclesWithBarricades = true;
            LogClears = false;
            TimeUntilDespawn = 15;
            Radius = 370;
        }
    }
}

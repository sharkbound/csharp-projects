using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
namespace giveVehicleNonAdmin
{
    public class GiveVehicleConfiguration : IRocketPluginConfiguration
    {
        public int SpawnCooldown;

        public void LoadDefaults()
        {
            SpawnCooldown = 600;
        }
    }
}

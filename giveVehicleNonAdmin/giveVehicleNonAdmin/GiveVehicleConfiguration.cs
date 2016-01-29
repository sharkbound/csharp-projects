using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
namespace giveVehicleNonAdmin
{
    public class GiveVehicleConfiguration : IRocketPluginConfiguration
    {
        public int HeliSpawnCooldown;
        public int PlaneSpawnCooldown;

        public void LoadDefaults()
        {
            HeliSpawnCooldown = 600;
            PlaneSpawnCooldown = 600;
        }
    }
}

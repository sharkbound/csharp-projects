using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
namespace giveVehicleNonAdmin
{
    public class GiveVehicleConfiguration : IRocketPluginConfiguration
    {
        public int SpawnCooldown;
        public int planeId;
        public int HelicopterId;
        public int BoatId;

        public void LoadDefaults()
        {
            SpawnCooldown = 120;
            planeId = 92;
            HelicopterId = 93;
            BoatId = 98;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using System.Xml.Serialization;

namespace AutoClear
{
    public class Config : IRocketPluginConfiguration
    {
        public int TimeUntilDespawn;
        public bool IgnoreVehiclesWithBarricades;
        public bool LogClears;
        public bool BlacklistEnabled;
        public bool ClearVehicleDestoryListOnReload;
        public int Radius;

        [XmlArrayItem(ElementName = "Id")]
        public List<string> BlacklsitedVehicleIds;

        public void LoadDefaults()
        {
            IgnoreVehiclesWithBarricades = true;
            LogClears = true;
            BlacklistEnabled = true;
            ClearVehicleDestoryListOnReload = false;
            TimeUntilDespawn = 8;
            Radius = 450;
            BlacklsitedVehicleIds = new List<string> { "default item" };
        }
    }
}

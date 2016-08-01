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
        public int Radius;

        [XmlArrayItem(ElementName = "SteamId")]
        public List<string> SteamIdsToNotLogChat;
        [XmlArrayItem(ElementName = "WarningPoint")]
        public List<int> SpamWarningPoints;

        public void LoadDefaults()
        {
            IgnoreVehiclesWithBarricades = true;
            LogClears = true;
            TimeUntilDespawn = 15;
            Radius = 450;
            SteamIdsToNotLogChat = new List<string> { "76561198117848353" };
            SpamWarningPoints = new List<int> { 5, 10, 15, 20, 25, 30 };
        }
    }
}

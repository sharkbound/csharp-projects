using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using System.Xml.Serialization;

namespace ResetPlayerPosOnDeath
{
    public class ResetPlayerPosOnDeathConfig : IRocketPluginConfiguration
    {
        public bool PluginEnabled;

        [XmlArrayItem(ElementName = "SteamId")]
        public List<string> SteamIds;

        public string ServerPath;

        public void LoadDefaults()
        {
            PluginEnabled = true;
            SteamIds = new List<string>() { "place holder string" };
            ServerPath = "change me";
        }
    }
}

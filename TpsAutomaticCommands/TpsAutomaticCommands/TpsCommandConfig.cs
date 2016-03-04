using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using System.Xml.Serialization;


namespace TpsAutomaticCommands
{
    public class TpsCommandConfig : IRocketPluginConfiguration
    {
        public int TpsToTriggerCommands;
        public int SecondsToBroadcastWarnings;

        public bool showWarningsBeforeCommands;

        [XmlArrayItem(ElementName = "command")]
        public List<string> commands;

        public void LoadDefaults()
        {
            showWarningsBeforeCommands = true;
            TpsToTriggerCommands = 40;
            SecondsToBroadcastWarnings = 10;
            commands = new List<string>() { "/killzombies" };
        }
    }
}

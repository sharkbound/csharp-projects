using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace DynamicSlots
{
    public class SlotsConfig : IRocketPluginConfiguration
    {
        public int MaxPlayers;

        public void LoadDefaults()
        {
            MaxPlayers = 24;
        }
    }
}

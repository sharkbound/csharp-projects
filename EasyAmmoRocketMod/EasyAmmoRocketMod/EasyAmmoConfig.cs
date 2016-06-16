using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace EasyAmmoRocketMod
{
    public class EasyAmmoConfig : IRocketPluginConfiguration
    {
       public bool PluginEnabled;

        public void LoadDefaults()
        {
            PluginEnabled = true;
        }
    }
}

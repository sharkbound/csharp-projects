using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketDummy
{
    public class Config : IRocketPluginConfiguration
    {
        public string temp;

        public void LoadDefaults()
        {
            temp = "";
        }
    }
}

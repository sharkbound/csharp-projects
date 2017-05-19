using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;

namespace AdminToolz
{
    public class Config : IRocketPluginConfiguration
    {
        public string placeholder;

        public void LoadDefaults()
        {
            placeholder = "placeholder";
        }
    }
}

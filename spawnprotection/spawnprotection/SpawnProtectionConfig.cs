using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace spawnprotection
{
    public class SpawnProtectionConfig : IRocketPluginConfiguration
    {
        public int SpawnProtectionDuration;

        public void LoadDefaults()
        {
            SpawnProtectionDuration = 20;
        }
    }
}

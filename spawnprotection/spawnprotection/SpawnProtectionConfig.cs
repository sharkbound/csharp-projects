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
        public int SleepTime;
        public int ProtectionTime;
        public int ProtectionDelay;

        public void LoadDefaults()
        {
            SleepTime = 100;
            ProtectionTime = 30;
            ProtectionDelay = 200;
        }
    }
}

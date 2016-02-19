using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned;
using Rocket.API;
using SDG.Unturned;

namespace effectRepeater
{
    public class EffectRepeater : RocketPlugin<effectRepeaterConfig>
    {
        public static EffectRepeater Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("EffectRepeater has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("EffectReapeater has Unloaded!");
        }

        public void AddEffectPlayer(IRocketPlayer player, int timesToPlayEffect, int delayBetweenEffects, ushort id, DateTime initialRun)
        {
            bool firstEffectPlay = true;
            UnturnedPlayer Uplayer = (UnturnedPlayer)player;
            int timesPassed = 0;

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (timesPassed > timesToPlayEffect)
                {

                }

                if (firstEffectPlay || timesPassed <= timesToPlayEffect && (int)((DateTime.Now - initialRun).Seconds) >= delayBetweenEffects)
                {
                    Uplayer.TriggerEffect(id);
                    timesPassed++;
                }

            });
        }
    }
}

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
            Logger.Log("EffectRepeater has Unloaded!");
        }

        public void AddEffectPlayer(IRocketPlayer player, int timesToPlayEffect, double delayBetweenEffects, ushort id, DateTime initialRun, Thread th)
        {
            bool firstEffectPlay = true;
            UnturnedPlayer Uplayer = (UnturnedPlayer)player;
            int timesPassed = 0;
            while (true)
            {
                if (timesPassed > timesToPlayEffect)
                {
                    // Logger.Log("Aborting thread!");
                    th.Abort();
                }
                else if (firstEffectPlay || timesPassed <= timesToPlayEffect && (double)((DateTime.Now - initialRun).TotalSeconds) >= delayBetweenEffects)
                {
                    initialRun = DateTime.Now;
                    // Logger.Log("playing effect: " + id.ToString());
                    Uplayer.TriggerEffect(id);
                    timesPassed++;
                    firstEffectPlay = false;
                }
                else
                {
                    // double remainingTime = delayBetweenEffects - (DateTime.Now - initialRun).TotalSeconds;
                    // Logger.Log("remaining time:  " + remainingTime.ToString());
                }

                int sleepTime = 10;
                // Logger.Log("starting sleep for " + sleepTime.ToString());
                Thread.Sleep(sleepTime);
            }
                
        }

        public void PlayEffect(UnturnedPlayer player, ushort id)
        {
            player.TriggerEffect(id);
            Logger.Log("playing effect: " + id.ToString());
        }

        public void StartThread(IRocketPlayer player, int timesToPlayEffect, double delayBetweenEffects, ushort id)
        {
            Thread t = null;
            t = new Thread(() => AddEffectPlayer(player, timesToPlayEffect, delayBetweenEffects, id, DateTime.Now, t));
            t.Start();
        }
    }
}

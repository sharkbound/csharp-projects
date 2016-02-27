using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned;
using Rocket.API;
using SDG.Unturned;
using Rocket.Unturned.Chat;

namespace effectRepeater
{
    class CommandRepEff : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() { "rf" }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            IRocketPlayer p = (IRocketPlayer)UnturnedPlayer.FromName(command[3]);
            if (p == null)
            {
                UnturnedChat.Say(caller, "player not found!");
                return;
            }

            if (EffectRepeater.Instance.activeThreads.ContainsKey(p.Id))
            {
                UnturnedChat.Say(caller, p.DisplayName + " already has a effect on them!");
                UnturnedChat.Say(caller, "use /killeffect " + "\"" + p.DisplayName + "\" to stop their effect" );
                return;
            }

            //int times;
            //double delay;
            //ushort id;

            effectData eD = new effectData();

            int.TryParse(command[0], out eD.TimeToPlay);
            double.TryParse(command[1], out eD.Delay);
            ushort.TryParse(command[2], out eD.Id);
            eD.IRocketPlayer = p;

            EffectRepeater.Instance.StartThread(eD);
            UnturnedChat.Say(caller, "added effect " + eD.Id.ToString() + " to " + p.DisplayName + " with interval of " + eD.Delay.ToString() + " for " + eD.TimeToPlay.ToString() + " times!");
        }

        public string Help
        {
            get { return "plays the specified affect on a player multiple times"; }
        }

        public string Name
        {
            get { return "repeff"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "repeff" }; }
        }

        public string Syntax
        {
            get { return "<timesToPlay> <delayBetweenEffects> <effectId> <player>"; }
        }
    }
}

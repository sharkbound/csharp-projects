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
            int times;
            double delay;
            ushort id;

            int.TryParse(command[0], out times);
            double.TryParse(command[1], out delay);
            ushort.TryParse(command[2], out id);
            IRocketPlayer p = (IRocketPlayer)UnturnedPlayer.FromName(command[3]);

            EffectRepeater.Instance.StartThread(p, times, delay, id);
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

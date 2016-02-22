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
    class CommandKillEffect : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() { "kille" }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            IRocketPlayer p = (IRocketPlayer)UnturnedPlayer.FromName(command[0]);
            if (p == null)
            {
                UnturnedChat.Say(caller, "player not found!");
                return;
            }

            if (!EffectRepeater.Instance.activeThreads.ContainsKey(p.Id))
            {
                UnturnedChat.Say(caller, p.DisplayName + " does not have a effect on them!");
                return;
            }

            EffectRepeater.Instance.StopThread(p);
            UnturnedChat.Say(caller, "killed effect on " + p.DisplayName + "!");
        }

        public string Help
        {
            get { return "kills a effect on a player"; }
        }

        public string Name
        {
            get { return "killeffect"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "killeffect" }; }
        }

        public string Syntax
        {
            get { return "<player>"; }
        }
    }
}

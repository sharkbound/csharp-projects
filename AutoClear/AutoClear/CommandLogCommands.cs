using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Steamworks;

namespace AutoClear
{
    class CommandLogCommands : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Player; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (AutoClear.chatLogPlayers.Contains(player.CSteamID))
            {
                AutoClear.chatLogPlayers.Remove(player.CSteamID);
                UnturnedChat.Say(caller, "You will no longer see commands that are run.");
            }
            else
            {
                AutoClear.chatLogPlayers.Add(player.CSteamID);
                UnturnedChat.Say(caller, "You will now see all commands run.");
            }
        }

        public string Help
        {
            get { return "logs commands to players unturned chat"; }
        }

        public string Name
        {
            get { return "logcmd"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "logcmd" }; }
        }

        public string Syntax
        {
            get { return ""; }
        }
    }
}

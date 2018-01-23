using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace EasyRepCommand
{
    class CommandRep : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "rep";

        public string Help => "sets a users reputation";

        public string Syntax => "<new reputation>";

        public List<string> Aliases => new List<string> { "reputation", "rep" };

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                UnturnedChat.Say($"missing parameters: {Syntax}");
                return;
            }

            if (!int.TryParse(command[0], out int res))
            {
                UnturnedChat.Say("amount must be a valid number with no decimals");
                return;
            }

            var plr = (UnturnedPlayer)caller;
            plr.Reputation = res;
            UnturnedChat.Say($"Your reputation has been set to {res}");
        }
    }
}

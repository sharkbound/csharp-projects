using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;

namespace godmodeAnnouncer
{
    class CommandGodmodeCheck : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string> { }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer Uplayer = UnturnedPlayer.FromName(command[0]);
            if (Uplayer != null)
            {
                IRocketPlayer Rplayer = (IRocketPlayer)Uplayer;
            }

            if (Uplayer == null)
            {
                if (caller is ConsolePlayer)
                {
                    Logger.Log("player not found");
                }
                else
                {
                    UnturnedChat.Say(caller, "player not found", UnityEngine.Color.yellow);
                }
                return;
            }

            if (caller is ConsolePlayer)
            {
                if (Uplayer.Features.GodMode)
                {
                    Logger.Log(Uplayer.DisplayName + " is in godmode");
                }
                else
                {
                    Logger.Log(Uplayer.DisplayName + " is NOT in godmode");
                }
            }
            else
            {
                if (Uplayer.Features.GodMode)
                {
                    UnturnedChat.Say(caller, Uplayer.DisplayName + " is in godmode", UnityEngine.Color.yellow);
                    Logger.Log(Uplayer.DisplayName + " is in godmode");
                }
                else
                {
                    UnturnedChat.Say(caller, Uplayer.DisplayName + " is NOT in godmode", UnityEngine.Color.yellow);
                    Logger.Log(Uplayer.DisplayName + " is NOT in godmode");
                }
            }
        }

        public string Help
        {
            get { return "checks to see if someone is in godmode"; }
        }

        public string Name
        {
            get { return "gc"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> {"godmode.check"}; }
        }

        public string Syntax
        {
            get { return "<player>"; }
        }
    }
}

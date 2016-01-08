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
    class CommandVM : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string> { }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both ; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (caller is ConsolePlayer)
            {
                if (command.Length == 0 || command.Length > 1)
                {
                    Logger.Log("missing parameter or invalid parameter");
                    return;
                }

                UnturnedPlayer Uplayer = UnturnedPlayer.FromName(command[0]);
                IRocketPlayer Rplayer = (IRocketPlayer)Uplayer;

                if (Uplayer == null)
                {
                    Logger.Log("Player not found");
                    return;
                }

                if (Uplayer.Features.VanishMode)
                {
                    Uplayer.Features.VanishMode = false;
                    Logger.Log("you have disabled vanish on: " + Uplayer.DisplayName);
                    UnturnedChat.Say(Rplayer, "you are no longer in vanish", UnityEngine.Color.yellow);
                }
                else
                {
                    Uplayer.Features.VanishMode = true;
                    Logger.Log("you have enabled vanish on: " + Uplayer.DisplayName);
                    UnturnedChat.Say(Rplayer, "you are now in vanish", UnityEngine.Color.yellow);
                    Uplayer.Teleport(Uplayer);
                }
            }
            else
            {
                UnturnedPlayer player = (UnturnedPlayer)caller;

                if (command.Length == 1 && caller.HasPermission("vm.other"))
                {
                    UnturnedPlayer Uplayer = UnturnedPlayer.FromName(command[0]);
                    IRocketPlayer Rplayer = (IRocketPlayer)Uplayer;

                    if (Uplayer == null)
                    {
                        UnturnedChat.Say(caller, "player not found", UnityEngine.Color.yellow);
                        return;
                    }

                    if (Uplayer.Features.VanishMode)
                    {
                        Uplayer.Features.VanishMode = false;
                        Logger.Log(caller.DisplayName + " has disabled vanish on: " + Uplayer.DisplayName);
                        UnturnedChat.Say(Rplayer, player.DisplayName + " has taken you out of vanish", UnityEngine.Color.yellow);
                        UnturnedChat.Say(caller, "you have disabled vanish on: " + Uplayer.DisplayName, UnityEngine.Color.yellow);
                    }
                    else
                    {
                        Uplayer.Features.VanishMode = true;
                        Logger.Log(caller.DisplayName + " has enabled vanish on: " + Uplayer.DisplayName);
                        UnturnedChat.Say(Rplayer, player.DisplayName + " has put you in vanish", UnityEngine.Color.yellow);
                        UnturnedChat.Say(caller, "you have enabled vanish on: " + Uplayer.DisplayName, UnityEngine.Color.yellow);
                        Uplayer.Teleport(Uplayer);
                    }
                }
                else
                {
                    if (player.Features.VanishMode)
                    {
                        player.Features.VanishMode = false;
                        UnturnedChat.Say(caller, "you have disabled vanish", UnityEngine.Color.yellow);
                        Logger.Log(player.DisplayName + " has disabled vanish");
                    }
                    else
                    {
                        player.Features.VanishMode = true;
                        UnturnedChat.Say(caller, "you have enabled vanish", UnityEngine.Color.yellow);
                        Logger.Log(player.DisplayName + " has enabled vanish");
                        player.Teleport(player);
                    }
                }
            }
        }

        public string Help
        {
            get { return "puts yourself or the specified player in vanish"; }
        }

        public string Name
        {
            get { return "vm"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> {"vm"}; }
        }

        public string Syntax
        {
            get { return "(playerName)"; }
        }
    }
}

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
    public class CommandGodmode : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() {"gm"}; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (caller is ConsolePlayer)
            {
                if (command.Length == 0)
                {
                    Logger.Log("missing parameter");
                    return;
                }

                UnturnedPlayer player = UnturnedPlayer.FromName(command[0]);
                IRocketPlayer Rplayer = (IRocketPlayer)player;

                if (player == null )
                {
                    Logger.Log("failed to find player by the name: " + command[0]);
                    return;
                }

                if (player.Features.GodMode)
                {
                    player.Features.GodMode = false;
                    Logger.Log(player.DisplayName + " is no longer in godmode");
                    UnturnedChat.Say(Rplayer, "you are no longer in godmode", UnityEngine.Color.yellow);
                }
                else
                {
                    player.Features.GodMode = true;
                    Logger.Log(player.DisplayName + " is now in godmode");
                    UnturnedChat.Say(Rplayer, "you are now in godmode", UnityEngine.Color.yellow);
                }
            }
            else
            {
                UnturnedPlayer player = (UnturnedPlayer)caller;

                if (command.Length == 1 && caller.HasPermission("godmode.other"))
                {
                    UnturnedPlayer Uplayer = UnturnedPlayer.FromName(command[0]);
                    IRocketPlayer Rplayer = (IRocketPlayer)Uplayer;

                    if (Uplayer.Features.GodMode)
                    {
                        Uplayer.Features.GodMode = false;
                        UnturnedChat.Say(caller, "you have disabled godmode on: " + Uplayer.DisplayName, UnityEngine.Color.yellow);
                        UnturnedChat.Say(Rplayer, caller.DisplayName + " has taken you out of godmode", UnityEngine.Color.yellow);
                        Logger.Log(caller.DisplayName + " has taken " + Uplayer.DisplayName + " out of godmode");
                    }
                    else
                    {
                        Uplayer.Features.GodMode = true;
                        UnturnedChat.Say(caller, "you have enabled godmode on: " + Uplayer.DisplayName, UnityEngine.Color.yellow);
                        UnturnedChat.Say(Rplayer, caller.DisplayName + " has put you in godmode", UnityEngine.Color.yellow);
                        Logger.Log(caller.DisplayName + " has put " + Uplayer.DisplayName + " in godmode");
                    }
                    return;
                }

                if (player.Features.GodMode)
                {
                    player.Features.GodMode = false;
                    string globalMessage = player.DisplayName + " has disabled godmode";
                    Logger.Log(globalMessage);
                    UnturnedChat.Say(globalMessage, UnityEngine.Color.yellow);
                }
                else
                {
                    player.Features.GodMode = true;
                    string globalMessage = player.DisplayName + " has enabled godmode";
                    Logger.Log(globalMessage);
                    UnturnedChat.Say(globalMessage, UnityEngine.Color.yellow);
                }
            }
        }

        public string Help
        {
            get { return "so were goin in invincible ehh"; }
        }
        public string Name
        {
            get { return "godmode"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() {"godmode"}; }
        }

        public string Syntax
        {
            get { return "(player)"; }
        }
    }
}

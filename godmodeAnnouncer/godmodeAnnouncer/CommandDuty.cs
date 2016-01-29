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
    class CommandDuty : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() { "duty" }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Player; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer unturnedCaller = (UnturnedPlayer)caller;

            if (caller.IsAdmin)
            {
                Logger.Log(caller.DisplayName + " has gone off duty");
                unturnedCaller.Admin(false);
            }
            else
            {
                Logger.Log(caller.DisplayName + " has gone on duty");
                unturnedCaller.Admin(true);
            }
        }

        public string Help
        {
            get { return "puts a admin on or off duty"; }
        }

        public string Name
        {
            get { return "duty"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() {"duty"}; }
        }

        public string Syntax
        {
            get { return ""; }
        }
    }
}

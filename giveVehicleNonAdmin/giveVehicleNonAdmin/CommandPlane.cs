using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;


namespace giveVehicleNonAdmin
{
    class CommandPlane : IRocketCommand
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
        }

        public string Help
        {
            get { return "gives the player a vehicle"; }
        }

        public string Name
        {
            get { return "plane"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() {"plane"}; }
        }

        public string Syntax
        {
            get { return ""; }
        }
    }
}

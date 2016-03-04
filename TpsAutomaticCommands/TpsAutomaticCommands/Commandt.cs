using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;

namespace TpsAutomaticCommands
{
    class Commandt : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            Logger.Log(TpsAutoRunCommands.TPS.ToString());   

        }

        public string Help
        {
            get { return ":P"; }
        }

        public string Name
        {
            get { return "t"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>() { "t" }; }
        }

        public string Syntax
        {
            get { return ""; }
        }
    }
}

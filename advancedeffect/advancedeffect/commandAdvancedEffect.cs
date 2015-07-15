using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Rocket;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned;
using SDG;
using Steamworks;
using Rocket.Core.Logging;
using Rocket.Unturned.Commands;

namespace advancedeffect
{
    class commandAdvancedEffect : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() {"ae"}; }
        }

        public void Execute(Rocket.Unturned.Player.RocketPlayer caller, string[] command)
        {
            DateTime currenttime = DateTime.Now;
            DateTime delaytime;
            //ushort id2 = ushort.Parse(command[0]); // TODO how does this differ from GetUInt16Parameter() ?
            ushort? id = RocketCommandExtensions.GetUInt16Parameter(command, 0);
            int? count = RocketCommandExtensions.GetInt32Parameter(command, 1);
            float? delay = RocketCommandExtensions.GetFloatParameter(command, 2);
           // if ((command.Length < 3 && caller == null) || (command.Length < 3 && caller.HasPermission("advancedeffect")))
            if (command.Length < 3 && (caller.HasPermission("advancedeffect") || caller == null || caller.IsAdmin))
            {
                RocketChat.Say(caller, "missing parameters! command usage: <id> <amount of times> <delay between effects>");
            }
            else if (command.Length == 3 && (caller == null || caller.IsAdmin || caller.HasPermission("advancedeffect")))
            {
                for (int ii = 1; ii <= count.Value; ii++)
                {
                    delaytime = currenttime.AddMilliseconds(delay.Value);
                    bool doloop = true;
                    while (doloop)
                    {
                    continuelooping:

                        currenttime = DateTime.Now;

                        if (currenttime >= delaytime)
                        {
                           // caller.TriggerEffect(id.Value);
                            Logger.Log("the time comparison worked!");
                            doloop = false;
                        }
                        else
                        {
                            goto continuelooping;
                        }
                 }
              }
           }
           else
           {
              
               if (caller == null)
               {
                   Logger.Log("u dont have permission to use this command!");
               }
               else
               {
                   RocketChat.Say(caller, "u dont have permission to use this command!");
               }
           }
        }

        public string Help
        {
            get { return "plays the selected effect"; }
        }

        public string Name
        {
            get {return "advancedeffect"; }
        }

        public bool RunFromConsole
        {
            get { return true; }
        }

        public string Syntax
        {
            get { return "<id> <amount of times> <delay between effects>"; }
        }
    }
}

using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace godmodeAnnouncer
{
    class CommandCV : IRocketCommand
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
            bool playerFound = false;
            float foundDistance = 0;

            UnturnedPlayer Uplayer = null;
            if (!(caller is ConsolePlayer))
            {
                Uplayer = (UnturnedPlayer)caller;
            }
            int distance = -1;
            bool EnteredNumber = false;
            bool ignoreVehiclesWithBarricades = false;

          /*  if (checkIfClearIsRunning(caller))
            {
                return;
            } */

            if (command.Length == 1)
            {
                if (int.TryParse(command[0], out distance))
                {
                    EnteredNumber = true;
                }
                else if (bool.TryParse(command[0], out ignoreVehiclesWithBarricades)) { }
            }
            else if (command.Length == 2)
            {
                if (int.TryParse(command[0], out distance))
                {
                    EnteredNumber = true;
                }
                if (bool.TryParse(command[1], out ignoreVehiclesWithBarricades)) { }
            }

            new Thread(() =>
            {
                var toRemove = new List<InteractableVehicle>();

                /*  VehicleManager.Vehicles
                      //.Where( v => v.passengers.All( p => p?.player == null ) )
                            .Where(v => v.passengers.All(p => p.player == null))
                            .Where(v =>
                            {
                                if (distance == -1) return true;
                                return Vector3.Distance(v.transform.position, ((UnturnedPlayer)caller).Position) <= distance;
                            })
                            .Select(v => v.instanceID)
                            */
                foreach (var v in VehicleManager.vehicles)
                {
                    if (v == null)
                    {
                        continue;
                    }

                    if (EnteredNumber && !(caller is ConsolePlayer))
                    {
                        foundDistance = Vector3.Distance(v.transform.position, Uplayer.Position);
                        if (foundDistance <= distance)
                        {
                            foreach (var passenger in v.passengers)
                            {
                                if (passenger.player == null) { }
                                else
                                    playerFound = true;
                            }
                        }

                        if (!playerFound && foundDistance <= distance)
                        {
                            if (!checkForBarricades(v, ignoreVehiclesWithBarricades))
                            {
                                toRemove.Add(v);
                            }
                        }
                    }
                    else
                    {
                        foreach (var passenger in v.passengers)
                        {
                            if (passenger.player == null) { }
                            else
                                playerFound = true;
                        }

                        if (!playerFound)
                        {
                            if (!checkForBarricades(v, ignoreVehiclesWithBarricades))
                            {
                                toRemove.Add(v); 
                            }
                        }
                    }

                    playerFound = false;
                }

                godmode.LastVehicleCount = toRemove.Count;
                godmode.LastClear = DateTime.Now;

                LogInfo("Starting a vehicle clear! Estimated time: " + (toRemove.Count *
                    godmode.Instance.Configuration.Instance.DelayBetweenClears) / 1000 + " seconds.");
                sendMessage(caller, "Starting a vehicle clear! Estimated time: " + (toRemove.Count *
                    godmode.Instance.Configuration.Instance.DelayBetweenClears) / 1000 + " seconds.");

                int timestriggered = 1;
                int count = toRemove.Count;

                removeVehiclesTest(toRemove, ref count, ref timestriggered, caller, ignoreVehiclesWithBarricades);

                sendMessage(caller, "Removed " + toRemove.Count + " vehicles in " + (DateTime.Now - godmode.LastClear).Seconds +
                   " seconds!");

                Log("Removed " + toRemove.Count + " vehicles in " + (DateTime.Now - godmode.LastClear).Seconds + " seconds!");
                Rocket.Core.Logging.Logger.Log("Removed " + toRemove.Count + " vehicles in " + (DateTime.Now - godmode.LastClear).Seconds + " seconds!");
                //godmode.ClearRunning = false; 
            }).Start();
        }

        public string Help
        {
            get { return "clears vehicles on the server"; }
        }

        public string Name
        {
            get { return "cv"; }
        }

        public List<string> Permissions
        {
            get { return new List<string> { "cv" }; }
        }

        public string Syntax
        {
            get { return "(radius)"; }
        }

        bool checkForPassengers(InteractableVehicle v)
        {
            foreach (var passenger in v.passengers)
            {
                if (passenger.player == null) { }
                else
                    return true;

            }

            return false;
        }

        bool checkForBarricades(InteractableVehicle v, bool ignoreVehiclesWithBarricades)
        {
            byte x;
            byte y;
            ushort plant;
            BarricadeRegion region;
            if (godmode.Instance.Configuration.Instance.IgnoreVehiclesWithBarricades)
            {
                if (ignoreVehiclesWithBarricades)
                {
                    if (BarricadeManager.tryGetPlant(v.transform, out x, out y, out plant, out region))
                    {
                        if (region.drops.Count > 0)
                        {
                            return true;
                        }
                    }
                    else { }
                }
            }

            return false;
        }

        void Log(string message)
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message + "\n");
            Console.ForegroundColor = lastColor;
        }

        void LogInfo(string message)
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message + "\n");
            Console.ForegroundColor = lastColor;
        }

        void sendMessage(IRocketPlayer caller, string message)
        {
            if (!(caller is ConsolePlayer))
            {
                UnturnedChat.Say(caller, message);
            }
        }

        bool checkIfClearIsRunning(IRocketPlayer caller)
        {
            if ((DateTime.Now - godmode.LastClear).Seconds > (godmode.LastVehicleCount *
                godmode.Instance.Configuration.Instance.DelayBetweenClears) / 1000)
            {
                godmode.ClearRunning = false;
                return false;
            }
               

            if (godmode.ClearRunning)
            {
                if (!(caller is ConsolePlayer))
                {
                    sendMessage(caller, "A vehicle is already running!");
                }

                LogInfo("A vehicle clear is already running!");
                Rocket.Core.Logging.Logger.Log("A vehicle clear is already running!");

                return true;
            }
            return false;
        }

        void removeVehiclesTest(List<InteractableVehicle> toRemove, ref int count, ref int timestriggered, IRocketPlayer caller, bool ignoreVehiclesWithBarricades)
        {
            for (int ii = toRemove.Count - 1; ii >= 0; ii--)
            {
                if (count == toRemove.Count - godmode.Instance.Configuration.Instance.ClearNoticationInterval * timestriggered)
                {
                    timestriggered++;
                    //count -= godmode.Instance.Configuration.Instance.ClearNoticationInterval;
                    //LogInfo("Counts current value - " + count);
                    //LogInfo("TimesTriggered current value - " + timestriggered);

                    Rocket.Core.Logging.Logger.LogWarning("Running Clear: " +
                        (godmode.Instance.Configuration.Instance.DelayBetweenClears * count) / 1000 +
                         " seconds left, Vehicles left  " + count);

                    if (!(caller is ConsolePlayer))
                    {
                        UnturnedChat.Say(caller, "Running Clear: " +
                        (godmode.Instance.Configuration.Instance.DelayBetweenClears * count) / 1000 +
                         " seconds left, Vehicles left " + count, UnityEngine.Color.yellow);
                    }
                }

                if (checkForBarricades(toRemove[ii], ignoreVehiclesWithBarricades) || toRemove[ii] == null)
                {
                    continue;
                }

                if (!checkForPassengers(toRemove[ii]))
                {
                     VehicleManager.instance.channel.send("tellVehicleDestroy",
                                            ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER, toRemove[ii].instanceID);
                    Thread.Sleep(godmode.Instance.Configuration.Instance.DelayBetweenClears);
                }

                count--;
            };
        }

        void removeVehicles(List<InteractableVehicle> toRemove, ref int count, ref int timestriggered, IRocketPlayer caller, bool ignoreVehiclesWithBarricades)
        {
            foreach (var v in toRemove)
            {
                if (count == toRemove.Count - godmode.Instance.Configuration.Instance.ClearNoticationInterval * timestriggered)
                {
                    timestriggered++;
                    //count -= godmode.Instance.Configuration.Instance.ClearNoticationInterval;
                    //LogInfo("Counts current value - " + count);
                    //LogInfo("TimesTriggered current value - " + timestriggered);

                    Rocket.Core.Logging.Logger.LogWarning("Running Clear: " +
                        (godmode.Instance.Configuration.Instance.DelayBetweenClears * count) / 1000 +
                         " seconds left, Vehicles left  " + count);

                    if (!(caller is ConsolePlayer))
                    {
                        UnturnedChat.Say(caller, "Running Clear: " +
                        (godmode.Instance.Configuration.Instance.DelayBetweenClears * count) / 1000 +
                         " seconds left, Vehicles left " + count, UnityEngine.Color.yellow);
                    }
                }

                if (checkForBarricades(v, ignoreVehiclesWithBarricades) || v == null)
                {
                    continue;
                }

                if (!checkForPassengers(v))
                {
                    VehicleManager.instance.channel.send("tellVehicleDestroy",
                                           ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_INSTANT, v.instanceID);
                    // VehicleManager.Instance.SteamChannel.send("tellVehicleDestroy",
                    //                        ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_BUFFER, v.instanceID);
                    Thread.Sleep(godmode.Instance.Configuration.Instance.DelayBetweenClears);
                }

                count--;
            };
        }
    }
}

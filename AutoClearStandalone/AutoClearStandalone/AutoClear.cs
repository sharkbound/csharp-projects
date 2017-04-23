using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Core.Commands;
using SDG.Unturned;
using System.Threading;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.API;
using Steamworks;
using SDG.Provider;

namespace AutoClear
{
    public class AutoClear : RocketPlugin<Config>
    {
        public static Dictionary<InteractableVehicle, DateTime> VehicleData = new Dictionary<InteractableVehicle, DateTime>();
        public static AutoClear Instance;
        List<InteractableVehicle> toRemove = new List<InteractableVehicle>();
        List<InteractableVehicle> updateDateTime = new List<InteractableVehicle>();
        //List<InteractableVehicle> nullVehicles = new List<InteractableVehicle>();

        protected override void Load()
        {
            Instance = this;
            if (Instance.Configuration.Instance.ClearVehicleDestoryListOnReload)
            {
                toRemove = new List<InteractableVehicle>();
                VehicleData = new Dictionary<InteractableVehicle, DateTime>();
                updateDateTime = new List<InteractableVehicle>();
            }
            Logger.Log("AutoClear has loaded!");
        }

        protected override void Unload()
        {
            Logger.Log("AutoClear has Unloaded!");
        }

        public override Rocket.API.Collections.TranslationList DefaultTranslations
        {
            get
            {
                return new Rocket.API.Collections.TranslationList
                {
                    {"command_v_giving_console", "Giving {0} vehicle {1} ({2})"},
                    {"command_v_giving_private", "Giving you a {0} ({1})"},
                    {"command_v_giving_failed_private", "Failed giving you a {0} ({1})"},
                    {"command_generic_invalid_parameter", "Invalid parameter"}
                };
            }
        }

        void FixedUpdate()
        {
            foreach (var entry in VehicleData)
            {
                bool isNull = false;
                if (entry.Key == null)
                {
                    isNull = true;
                    toRemove.Add(entry.Key);
                }
                
                if (!isNull)
                {
                    if (checkForBarricades(entry.Key, Instance.Configuration.Instance.IgnoreVehiclesWithBarricades) || checkForPassengers(entry.Key))
                    {
                        updateDateTime.Add(entry.Key);
                    }

                    //Logger.Log((DateTime.Now - entry.Value).Seconds.ToString());
                    if ((DateTime.Now - entry.Value).Seconds >= Instance.Configuration.Instance.TimeUntilDespawn)
                    {
                        if (!checkForBarricades(entry.Key, Instance.Configuration.Instance.IgnoreVehiclesWithBarricades) && !checkForPassengers(entry.Key))
                        {
                            if (AutoClear.Instance.Configuration.Instance.LogClears)
                            {
                                Logger.LogWarning("AutoClearing vehicle: " + entry.Key.asset.vehicleName);
                            }

                            toRemove.Add(entry.Key);
                            VehicleManager.instance.channel.send("tellVehicleDestroy",
                                                       ESteamCall.ALL, ESteamPacket.UPDATE_RELIABLE_INSTANT, entry.Key.instanceID);
                        }
                    } 
                }
            }

            foreach (var v in toRemove)
            {
                VehicleData.Remove(v);
            }
            toRemove = new List<InteractableVehicle>();

          /*  for (int ii = toRemove.Count - 1; ii >= 0; ii--)
            {
                toRemove.Remove(toRemove[ii]);
            } */

            for (int jj = updateDateTime.Count - 1; jj >= 0; jj--)
            {
                VehicleData[updateDateTime[jj]] = DateTime.Now;
                updateDateTime.Remove(updateDateTime[jj]);
            }
        }

        public static bool checkForBarricades(InteractableVehicle v, bool ignoreVehiclesWithBarricades)
        {
            byte x;
            byte y;
            ushort plant;
            BarricadeRegion region;
            if (AutoClear.Instance.Configuration.Instance.IgnoreVehiclesWithBarricades)
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

        public static bool checkForPassengers(InteractableVehicle v)
        {
            foreach (var passenger in v.passengers)
            {
                if (passenger.player == null) { }
                else
                    return true;
            }

            return false;
        }
    }
}

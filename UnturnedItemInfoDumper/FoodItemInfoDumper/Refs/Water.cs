using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Items;
using SDG.Unturned;
using System.IO;
using Logger = Rocket.Core.Logging.Logger;

namespace AdminToolz
{
    public class Water : RocketPlugin<Config>
    {
        public static Water Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("Writing all Water items to file...");

            Asset[] items = Assets.find(EAssetType.ITEM);
            using (var w = new StreamWriter("WaterItems.txt"))
            {
                foreach (var i in items)
                {
                    if (i is ItemWaterAsset f)
                    {
                        w.WriteLine($"{f.itemName}\t\t{f.id}\t\t\t\tFOOD:{f.food}\t\t\t\tVIRUS:{f.virus}\t\t\t\tHEALTH:{f.health}\t\t\t\t" +
                            $"WATER:{f.water}\t\t\t\tENERGY:{f.energy}");
                    }
                }
            }

            UnloadPlugin();
        }

        protected override void Unload()
        {
            Logger.Log("Done!");
        }

        public override TranslationList DefaultTranslations => new TranslationList
        {

        };
    }
}

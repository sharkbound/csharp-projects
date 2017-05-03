using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned.Items;
using SDG.Unturned;
using System.IO;
using Logger = Rocket.Core.Logging.Logger;

namespace AdminToolz
{
    public class Plugin : RocketPlugin<Config>
    {
        public static Plugin Instance;

        protected override void Load()
        {
            Instance = this;
            Logger.Log("Writing all food items to file...");

            Asset[] items = Assets.find(EAssetType.ITEM);
            using (var w = new StreamWriter("FoodItems.txt"))
            {
                foreach (var i in items)
                {
                    if (i is ItemFoodAsset f)
                    {
                        w.WriteLine($"{f.itemName}/{f.id} -> \t\tFOOD:{f.food} VIRUS:{f.virus} HEALTH:{f.health} " +
                            $"WATER:{f.water} ENERGY:{f.energy}");
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

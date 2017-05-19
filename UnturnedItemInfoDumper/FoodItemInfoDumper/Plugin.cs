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
            Logger.Log("Writing all Food items to file...");

            Asset[] items = Assets.find(EAssetType.ITEM);
            using (var w = new StreamWriter("FoodItems.txt"))
            {
                foreach (var i in items)
                {
                    if (i is ItemFoodAsset f)
                    {
                        w.WriteLine($"{f.itemName}\t\t{f.id}\t\t\t\tFOOD:{f.food}\t\t\t\tVIRUS:{f.virus}\t\t\t\tHEALTH:{f.health}\t\t\t\t" +
                            $"WATER:{f.water}\t\t\t\tENERGY:{f.energy}");
                    }
                }
            }

            using (var w = new StreamWriter("GunItems.txt"))
            {
                foreach (var i in items)
                {
                    if (i is ItemGunAsset f)
                    {
                        w.WriteLine($"{f.itemName}\t\t{f.id}\t\t\t\tPlayer_Damage:{f.playerDamageMultiplier.damage}\t\tAnimal_Damage:{f.animalDamageMultiplier.damage}\t\tZombie_Damage:{f.zombieDamageMultiplier.damage}\t\tBarricade_Damage:{f.barricadeDamage}\t\tStructure_Damage:{f.structureDamage}\t\tVehicle_Damage:{f.vehicleDamage}\t\tRange:{f.range}\t\tFirerate:{f.firerate}\t\tAmmo_Max:{f.ammoMax}");
                    }
                }
            }

            using (var w = new StreamWriter("MeleeItems.txt"))
            {
                foreach (var i in items)
                {
                    if (i is ItemMeleeAsset f)
                    {
                        w.WriteLine($"{f.itemName}\t\t{f.id}\t\t\t\tPlayer_Damage:{f.playerDamageMultiplier.damage}\t\tAnimal_Damage:{f.animalDamageMultiplier.damage}\t\tZombie_Damage:{f.zombieDamageMultiplier.damage}\t\tBarricade_Damage:{f.barricadeDamage}\t\tStructure_Damage:{f.structureDamage}\t\tVehicle_Damage:{f.vehicleDamage}\t\tRange:{f.range}\t\tStamina_Use:{f.stamina}");
                    }
                }
            }

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

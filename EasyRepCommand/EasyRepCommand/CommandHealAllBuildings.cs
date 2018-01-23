using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using Rocket.Unturned.Chat;
using SDG.Unturned;

namespace EasyRepCommand
{
    class CommandHealAllBuildings : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        public string Name => "healallbuildings";

        public string Help => "heals all buildings";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer caller, string[] command)
        {
            for (byte i = 0; i < Regions.WORLD_SIZE; i += 1)
            {
                for (byte j = 0; j < Regions.WORLD_SIZE; j += 1)
                {
                    BarricadeRegion br = BarricadeManager.regions[i, j];
                    for (int index = 0; index < br.barricades.Count; index++)
                    {
                        BarricadeData b = br.barricades[index];
                        if (Assets.find(EAssetType.ITEM, b.barricade.id) is ItemBarricadeAsset asset && asset.build != EBuild.FARM)
                        {
                            b.barricade.health = asset.health;
                            //BarricadeManager.instance.channel.send("tellBarricadeHealth", ESteamCall.ALL,
                            //    ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[] { i, j, ushort.MaxValue, index, b.asset.quality });
                        }
                    }

                    StructureRegion sr = StructureManager.regions[i, j];
                    for (int index = 0; index < sr.structures.Count; index++)
                    {
                        StructureData s = sr.structures[index];
                        if (Assets.find(EAssetType.ITEM, s.structure.id) is ItemStructureAsset asset)
                        {
                            s.structure.health = asset.health;
                            //BarricadeManager.instance.channel.send("tellStructureHealth", ESteamCall.ALL,
                            //    ESteamPacket.UPDATE_RELIABLE_BUFFER, new object[] { i, j, ushort.MaxValue, index, s.asset.quality });
                        }
                    }
                }
            }
            UnturnedChat.Say(caller, "repaired all buildings");
        }
    }
}

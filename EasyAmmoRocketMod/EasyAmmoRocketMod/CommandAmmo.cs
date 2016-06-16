using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Items;

namespace EasyAmmoRocketMod
{
    class CommandAmmo : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string> { }; }
        }

        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Player; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            ushort ammoAmountToSpawn = (ushort)0;
            bool EnteredAmount = false;
            SDG.Unturned.ItemGunAsset currentWeapon;
            SDG.Unturned.ItemAsset currentEquiped;
            UnturnedPlayer Uplayer = (UnturnedPlayer)caller;

           if (command.Length == 1)
            {
                if (ushort.TryParse(command[0], out ammoAmountToSpawn))
                {
                    EnteredAmount = true;
                }
            }

            currentEquiped = Uplayer.Player.equipment.asset;
            if (currentEquiped == null)
            {
                UnturnedChat.Say(caller, "you dont have anything equipped!");
                return;
            }
            if (currentEquiped.ItemType != SDG.Unturned.EItemType.GUN )
            {
                UnturnedChat.Say(caller, "you dont have a gun equipped currently!");
                return;
            }

            //UnturnedChat.Say(caller, " your current equipped item is \" id: " + currentEquiped + " / " + "name: " + currentEquiped.name);
            //UnturnedChat.Say(caller, "item type: " + item.GetType().ToString());

            currentWeapon = (SDG.Unturned.ItemGunAsset)currentEquiped;
            if (currentWeapon == null)
            {
                UnturnedChat.Say(caller, "Gun asset is null!");
                return;
            }

            if (EnteredAmount)
            {
                Uplayer.GiveItem(currentWeapon.magazineID, (byte)ammoAmountToSpawn);
            }
            else
            {
                Uplayer.GiveItem(currentWeapon.magazineID, (byte)1); 
            }
        }

        public string Help
        {
            get { return "return gives you the specified number of clips for yuor current weapon."; }
        }

        public string Name
        {
            get { return "ammo"; }
        }

        public List<string> Permissions
        {
            get { return new List<string>{"ammo"}; }
        }

        public string Syntax
        {
            get { return "<amount of ammo>"; }
        }
    }
}

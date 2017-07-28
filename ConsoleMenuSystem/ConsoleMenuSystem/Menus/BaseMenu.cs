using System;
using ConsoleMenuSystem.Data;

namespace ConsoleMenuSystem.Menus
{
    class BaseMenu : IMenu
    {
        public void Action(ConsoleKeyInfo key, StoredInfo stored)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    stored.SetCurrentMenu(new StoreMenu());
                    break;
            }
        }

        public void Show() => Console.WriteLine("1) Store");
    }
}

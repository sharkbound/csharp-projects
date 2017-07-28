using System;
using ConsoleMenuSystem.Data;

namespace ConsoleMenuSystem.Menus
{
    class BuyMenu : IMenu
    {
        public void Action(ConsoleKeyInfo key, StoredInfo stored)
        {
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    stored.TotalCost += 1.30;
                    Console.Clear();
                    Console.WriteLine("Bought 1 pack of gum\n\npress any key to continue...");
                    Console.ReadKey(true);
                    break;
            }
        }

        public void Show() => Console.WriteLine("1) Buy Gum -> $1.30");
    }
}

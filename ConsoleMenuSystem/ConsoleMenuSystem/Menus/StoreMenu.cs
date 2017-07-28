using System;
using ConsoleMenuSystem.Data;

namespace ConsoleMenuSystem.Menus
{
    class StoreMenu : IMenu
    {
        public void Action(ConsoleKeyInfo key, StoredInfo stored)
        {
            switch (key.Key)
            {
                case ConsoleKey.D0:
                    Console.Clear();
                    Console.WriteLine($"Your total is {stored.TotalCost.ToString("C")}");
                    Console.ReadKey(true);
                    stored.Close = true;
                    break;

                case ConsoleKey.D1:
                    stored.SetCurrentMenu(new BuyMenu());
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.Write("Enter Discount Amount: ");
                    if (double.TryParse(Console.ReadLine(), out var discount))
                    {
                        stored.TotalCost -= stored.TotalCost * discount;
                        Console.WriteLine("\nNew total is " + stored.TotalCost);
                    }
                    else
                        Console.WriteLine("\nYou must enter a valid discount value");
                    Console.ReadKey(true);
                    break;

                case ConsoleKey.D3:
                    Console.WriteLine($"Current Cost: {stored.TotalCost.ToString("C")}");
                    Console.ReadKey(true);
                    break;
            }
        }

        public void Show() => Console.WriteLine("1) Buy Items\n2) Apply Discount\n3) View Current Cost");
    }
}

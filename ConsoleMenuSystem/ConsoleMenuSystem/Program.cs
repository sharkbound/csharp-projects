using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenuSystem.Data;

namespace ConsoleMenuSystem
{
    class Program
    {
        static bool waitForDebugKey = false;
        static void Main(string[] args)
        {
            new Program().Start();

            if (Debugger.IsAttached && waitForDebugKey)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
        
        private void Start()
        {
            Console.TreatControlCAsInput = true;
            StoredInfo stored = new StoredInfo();
            ConsoleKeyInfo key;

            while (!stored.Close)
            {
                Console.WriteLine("Press Escape to exit the program\n\n");
                Console.WriteLine($"menu index: {stored.Menus.Count - 1}\n0) Previous Menu\n");
                stored.CurrentMenu.Show();

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return;

                    case ConsoleKey.D0:
                        stored.GotoPreviousMenu();
                        break;

                    default:
                        stored.CurrentMenu.Action(key, stored);
                        break;
                }

                Console.Clear();
            }
        }
    }
}

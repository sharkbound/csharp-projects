using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    class Program
    {
      static Magic8Ball magic = new Magic8Ball();
        static void Main(string[] args)
        {
            magic.loop = true;
            

            while (magic.loop)
            {
                Console.WriteLine("Enter your question...");
                magic.question = Console.ReadLine();
                magic.shake();
                Console.WriteLine("The Magic8Ball says: {0}", magic.stringAnwser);
                SwitchMenu();
                magic.loop = false;
                magic.list = false;
                magic.menuask = true;
            }
            while (magic.list)
            {
                Console.WriteLine("YES: {0}\nNO: {1}\nMAYBE: {2}", magic.YesCount, magic.NoCount, magic.MaybeCount);
                magic.list = false;
                magic.loop = false;
                magic.menuask = true;
            }
            while (magic.menuask)
            {
                SwitchMenu();
            }
        }
        static void menu()
        {
            Console.WriteLine("choose a option...\n\n");
            Console.WriteLine("1:\t-\task again\n2:\t-\tlist anwser count\n\nEscape:\t-\tExit the application");
            magic.key = Console.ReadKey();
        }
        static void SwitchMenu()
        {
            switch(magic.key.Key)
            {
                case ConsoleKey.D1:
                    magic.loop = true;
                    magic.list = false;
                    break;
                case ConsoleKey.D2:
                    magic.list = true;
                    magic.loop = false;
                    break;
                case ConsoleKey.D3:
                    magic.loop = false;
                    magic.list = false;
                    break;
                default:
                    Console.WriteLine("that is not a option!");
                    magic.loop = false;
                    magic.list = false;
                    magic.menuask = true;
                    break;


            }
        }
    }
}

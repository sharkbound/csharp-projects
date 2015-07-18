using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Magic8Ball__magic_edition_;
using System.Diagnostics;

namespace Magic8Ball__magic_edition_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 40;
            Dictionary<string, ConsoleColor> c = new Dictionary<string, ConsoleColor>();
            c.Add("red", ConsoleColor.Red);
            c.Add("cyan", ConsoleColor.Cyan);
            c.Add("white", ConsoleColor.White);
            c.Add("yellow", ConsoleColor.Yellow);
            c.Add("green",ConsoleColor.Green);
            c.Add("mag", ConsoleColor.Magenta);

           // List<ConsoleColor> colors = new List<ConsoleColor> 
            // {ConsoleColor.Red,ConsoleColor.Yellow,ConsoleColor.White,ConsoleColor.Cyan };
            #region variables
            ConsoleKeyInfo key;
            int delay = 1000;
            string anwser = "";
            int yes = 0;
            int no = 0;
            int maybe = 0;
            #endregion
        askagain:
            color(c["cyan"]);
            Console.WriteLine("Welcome to my Magic8Ball application!");
            color(c["green"]);
            string q = Question();
        reroll:
            color(c["green"]);
            Console.WriteLine("\nCalulating the awnser to:\t\"{0}\"",q);
            color(c["white"]);
            #region random anwser
            Thread.Sleep(delay);
            Random RandomNumber = new Random();
            int RandomNum = RandomNumber.Next(9) + 1;
            switch (RandomNum)
            {
                case 1:
                    anwser = "your chances are good (yes)\n";
                    yes++;
                    break;
                case 2:
                    anwser = "i like your guts boy (yes)\n";
                    yes++;
                    break;
                case 3:
                    anwser = "for gold and glory kid, gold and glory (yes)\n";
                    yes++;
                    break;
                case 4:
                    anwser = "the iluminati say no (no)\n";
                    no++;
                    break;
                case 5:
                    anwser = "you dont have enough gold for me to awnser (no)\n";
                    no++;
                    break;
                case 6:
                    anwser = "who do u think i am?!!?!?! (no)\n";
                    no++;
                    break;
                case 7:
                    anwser = "U know, u are a wise guy. \nU have great determination, with determination like that i say you will succeed (maybe)\n";
                    maybe++;
                    break;
                case 8:
                    anwser = "belieeeeeve, belieeeeve in yourself and u will\n error: \"this is the iluminati we are coming for u!\"(maybe)\n";
                    maybe++;
                    break;
                case 9:
                    anwser = "yoooooo just try, try and try your hardest. \nAlso there is a killer with a rubber duck weapon behind u (maybe)\n";
                    maybe++;
                    break;
            }
            #endregion
            color(ConsoleColor.Red);
            Console.WriteLine("The awnser to: \"{0}\"\nIs:\n\t{1}",q,anwser);
            color(ConsoleColor.White);
        switchmenu:
            menu();
            #region menu selection 
            key = Console.ReadKey();
            Console.WriteLine("\n\n");
            switch(key.Key)
            {
                case ConsoleKey.D5:
                    color(ConsoleColor.Red);
                    Console.Clear();
                    Console.WriteLine("reseting counters...");
                    color(ConsoleColor.White);
                    yes = 0;
                    no = 0;
                    maybe = 0;
                    Thread.Sleep(700);
                    Console.Clear();
                    goto switchmenu;
                case ConsoleKey.D2:
                    Console.WriteLine("rerolling question...");
                    Console.Clear();
                    goto reroll;
                case ConsoleKey.D3:
                    Console.Clear();
                    color(ConsoleColor.Green);
                    Console.WriteLine("awnsers u got so far:\nyes: {0}\nmaybe: {1}\nno: {2}",yes,maybe,no);
                    color(ConsoleColor.White);
                    Console.WriteLine("\n\n");
                    goto switchmenu;
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("enter the delay u want...");
                    delay = int.Parse(Console.ReadLine());
                    Console.Clear();
                    goto switchmenu;
                case ConsoleKey.D1:
                    Console.Clear();
                    goto askagain;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    iluminati();
                    I_msgs();
                    Process.Start("https://www.youtube.com/watch?v=PJLSzsEjpWM&lc=z13cslwj4pu3iv14r04ccb1z4zvisjkpofs");
                    color(c["white"]);
                    goto switchmenu;
                case ConsoleKey.D7:
                    rainbow();
                    goto switchmenu;
                default:
                    Console.Clear();
                    color(c["red"]);
                    Console.WriteLine("{0} is a invalid option, please choose a valid option", key.Key);
                    color(c["white"]);
                    goto switchmenu;
            }
            #endregion 
        }
        static string Question()
        {
            Console.WriteLine("Enter your question....");
            string UserValue = Console.ReadLine();
            Console.Clear();
           // Console.WriteLine("your question was:\n\"{0}\"", UserValue);
            return UserValue;
        }
        static void menu()
        {
            Console.WriteLine("\nPress the key for the menu item u want to choose...");
            Console.WriteLine("\n1:\task another question\n2:\treroll your current question\n3:\tlist the amount of good/maybe/bad awnsers u got\n4:\tchange the delay");
            Console.WriteLine("5:\treset yes/maybe/no counters\n6:\tILUMINATI COMFIRMED!\n7:\tPretty rainbow ball :3\n\nPress escape to exit the application");
        }
        static void color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        static void iluminati()
        {
            Console.WriteLine("\t\t\t\t\t /\\");
            Console.WriteLine("\t\t\t\t        /  \\");
            Console.WriteLine("\t\t\t\t       /    \\");
            Console.WriteLine("\t\t\t\t      /      \\");
            Console.WriteLine("\t\t\t\t     / _____  \\");
            Console.WriteLine("\t\t\t\t    / /  0  \\  \\");
            Console.WriteLine("\t\t\t\t   /  -------   \\");
            Console.WriteLine("\t\t\t\t  /              \\");
            Console.WriteLine("\t\t\t\t /                \\");
            Console.WriteLine("\t\t\t\t -------------------");
        }
        static void I_msgs()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            iluminati();
            Console.WriteLine("\n\nu think u know us?");
            press();
            Console.ReadKey();
            Console.Clear();
            iluminati();
            Console.WriteLine("\n\nu only know the lies we set in place about us");
            press();
            Console.ReadKey();
            Console.Clear();
            iluminati();
            Console.WriteLine("\n\nwe know everything about u");
            press();
            Console.ReadKey();
            Console.Clear();
            iluminati();
            Console.WriteLine("\n\nwe are watching... Dont disapoint us...");
            press();
            Console.ReadKey();
            Console.Clear();
            iluminati();
            press();
            Console.ReadKey();
            Console.Clear();
        }
        static void press()
        {
            ConsoleColor prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\npress any key to continue....");
            Console.ForegroundColor = prev;
        }
        static void rainbow()
        {
            Console.Clear();
            Dictionary<string, ConsoleColor> c = new Dictionary<string, ConsoleColor>();
            c.Add("red", ConsoleColor.Red);
            c.Add("cyan", ConsoleColor.Cyan);
            c.Add("white", ConsoleColor.White);
            c.Add("yellow", ConsoleColor.Yellow);
            c.Add("green", ConsoleColor.Green);
            c.Add("mag", ConsoleColor.Magenta);
            c.Add("blue", ConsoleColor.Blue);
            c.Add("gray", ConsoleColor.Gray);
            c.Add("black", ConsoleColor.Black);
            c.Add("darkblue", ConsoleColor.DarkBlue);
            c.Add("darkcyan", ConsoleColor.DarkCyan);
            c.Add("darkgray", ConsoleColor.DarkGray);
            c.Add("darkgreen", ConsoleColor.DarkGreen);
            c.Add("darkmag", ConsoleColor.DarkMagenta);
            c.Add("darkred", ConsoleColor.DarkRed);
            c.Add("darkyellow", ConsoleColor.DarkYellow);
            ConsoleColor prev = Console.ForegroundColor;
            color(c["red"]);
            Console.WriteLine("\t\t                 00000000000000000 ");
            color(c["yellow"]);
            Console.WriteLine("\t\t            000000000000000000000000000");
            color(c["green"]);
            Console.WriteLine("\t\t       000000000000             000000000000");
            color(c["blue"]);
            Console.WriteLine("\t\t 00000000000000                     0000000000000");
            color(c["darkmag"]);
            Console.WriteLine("\t    000000000000000                             00000000000000");
            color(c["mag"]);
            Console.WriteLine("\t 0000000000000000                                 000000000000000");
            Console.WriteLine("       0000000000000000                                     000000000000000");
            Console.WriteLine("     00000000000000000                                       000000000000000");
            Console.WriteLine("    00000000000000000                                         000000000000000");
            Console.WriteLine("   00000000000000000                                           000000000000000");
            Console.WriteLine("  00000000000000000                                             000000000000000");
            Console.WriteLine(" 000000000000000000                                             000000000000000");
            Console.WriteLine(" 000000000000000000                                             000000000000000");
            Console.WriteLine(" 000000000000000000                                             00000000000000");
            Console.WriteLine("  00000000000000000                                             0000000000000");
            Console.WriteLine("   00000000000000000                                           0000000000000");
            Console.WriteLine("    00000000000000000                                         0000000000000");
            Console.WriteLine("     00000000000000000                                       0000000000000");
            Console.WriteLine("      00000000000000000                                     0000000000000");
            Console.WriteLine("       000000000000000000                                 0000000000000 ");
            color(c["darkmag"]);
            Console.WriteLine("          00000000000000000                             000000000000");
            color(c["blue"]);
            Console.WriteLine("                  00000000000                         00000000000  ");
            color(c["green"]);
            Console.WriteLine("                       000000000000              000000000000");
            color(c["yellow"]);
            Console.WriteLine("                            000000000000000000000000000");
            color(c["red"]);
            Console.WriteLine("                                 00000000000000000");
            color(prev);
            press();
            Console.ReadKey();
        }
    }
}

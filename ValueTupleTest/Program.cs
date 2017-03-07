using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTupleTest
{
    class Program : Util
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        void Start()
        {
            int midX = Console.WindowWidth / 2,
                midY = Console.WindowHeight / 2,
                x = midX, 
                y = midY;
            char printChar = '*';

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        y--;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        y++;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        x--;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        x++;
                        break;
                    case ConsoleKey.C:
                        Console.Clear();
                        x = midX; y = midY;
                        break;
                    case ConsoleKey.P:
                        Console.SetCursorPosition(0, Console.WindowHeight);
                        Console.WriteLine("Press a key to set the print charater: ");
                        printChar = Console.ReadKey(true).KeyChar;
                        break;
                }

                x = x >= Console.WindowWidth-1 ? 1 : x;
                x = x <= 0 ? Console.WindowWidth-1 : x;
                y = y >= Console.WindowHeight ? 1 : y;
                y = y <= 0 ? Console.WindowHeight : y;

                Console.SetCursorPosition(1, Console.WindowHeight);
                Console.Write($"X: {x} Y: {y} \nwidth: {Console.WindowWidth}, height: {Console.WindowHeight}");

                Console.SetCursorPosition(x, y);
                Console.Write(printChar);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        class deconstructable
        {
            public string name,
                age,
                serialNumber;

            public deconstructable(string name, string age, string serialNumber)
            {
                this.name = name;
                this.age = age;
                this.serialNumber = serialNumber;
            }

            public (int fdg, int, int) Test()
            {
                return (1, 2, 3);
            }

            public void Deconstruct(out string Name, out string Age, out string SerialNumber)
            {
                Name = name;
                Age = age;
                SerialNumber = serialNumber;
            }
        }
    }
}

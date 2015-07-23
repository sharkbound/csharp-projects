using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo k;
            int shiftnum = 1;
            int timer = 1;
            bool firstloop = false;
            bool interloop = true;
            bool doLoop = true;
            Point point = new Point();
            Point gotothis = new Point();
            MouseEventArgs mouse = new MouseEventArgs(MouseButtons.Left, 1, gotothis.X, gotothis.Y, 1);
            MousePos(ref firstloop);

            while (doLoop)
            {
            continueloop:
                Console.WriteLine("do u want to jump the cursor somewhere? [y/n]");
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("enter the place for the cursor to jump to...");
                    Console.WriteLine("enter the first coord...");
                    point.X = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter the second coord...");
                    point.Y = int.Parse(Console.ReadLine());
                    Cursor.Position = point;
                }
            set:
                Console.WriteLine("do u want to set a goto point? [y/n]");
                k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("enter the X to goto...");
                        gotothis.X = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter the Y to goto...");
                        gotothis.Y = int.Parse(Console.ReadLine());
                        point = Cursor.Position;
                        interloop = true;
                        while (interloop)
                        {
                            while (Cursor.Position.Y > gotothis.Y)
                            {
                                point.Y -= shiftnum;
                                Cursor.Position = point;
                                Console.WriteLine("moved cursor to \tY: {0}", point.Y);
                                Thread.Sleep(timer);
                            }
                            while (Cursor.Position.Y < gotothis.Y)
                            {
                                point.Y += shiftnum;
                                Cursor.Position = point;
                                Console.WriteLine("moved cursor to \tY: {0}", point.Y);
                                Thread.Sleep(timer);
                            }
                            while (Cursor.Position.X > gotothis.X)
                            {
                                point.X -= shiftnum;
                                Cursor.Position = point;
                                Console.WriteLine("moved cursor to \tX: {0}", point.X);
                                Thread.Sleep(timer);
                            }
                            while (Cursor.Position.X < gotothis.X)
                            {
                                point.X += shiftnum;
                                Cursor.Position = point;
                                Console.WriteLine("moved cursor to \tX: {0}", point.X);
                                Thread.Sleep(timer);
                            }
                            if (Cursor.Position.X == gotothis.X && Cursor.Position.Y == gotothis.Y)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("i have arrived at the entered location!");
                                Console.ForegroundColor = ConsoleColor.White;
                                // OnMouseClick(mouse);
                                interloop = false;
                            }
                        }
                        break;
                    case ConsoleKey.N:
                        break;
                    default:
                        goto set;
                }
            menu:
                Console.WriteLine("exit? [y/n]");
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.Y)
                {
                    break;
                }
                else if (k.Key == ConsoleKey.N)
                {
                    goto continueloop;
                }
                else
                {
                    goto menu;
                }
            }
        }

        private static void MousePos(ref bool firstloop)
        {
            while (firstloop)
            {
                Console.WriteLine("Cursor X: {0}, Cursor Y: {1}", Cursor.Position.X, Cursor.Position.Y);
                Thread.Sleep(100);
            }
        }
        private static void OnMouseClick(MouseEventArgs e)
        {
        }
    }
}

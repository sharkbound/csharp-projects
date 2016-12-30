using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static dotnet_6_test.StaticTest;

namespace dotnet_6_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Task Task1 = Task.Run(() =>
            {
                CheckOrMakeDir(ConsoleColor.Red, ConsoleKey.A, "[Task1]\t", "\t[Task1]\n");
            });
            Task Task2 = Task.Run(() =>
            {
                CheckOrMakeDir(ConsoleColor.Yellow, ConsoleKey.S, "[Task2]\t", "\t[Task2]\n");
                var r = new Random();
                object obj = $"obj message!";
                LogObj(obj);
            });

            Task.WaitAll(Task1, Task2);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Finished All Tasks! {RetStr()}");

            PrintAndOrderRandomNumbers();

            Console.ReadKey(true);
        }

        static string RetStr() => "RetStr()";

        static bool? NullCheck(string str)
        {
            return str?.Contains("null");
        }

        private static void PrintAndOrderRandomNumbers()
        {
            var f = new List<float> { 1, 7, 6, 4, 10, 100, 60, 50, 30.1f, 40.60f };
            var result = f.OrderBy(t => t).ToList();
            foreach (var str in result)
            {
                Console.WriteLine($"Value: {str}");
            }
        }

        static void CheckOrMakeDir(ConsoleColor ColorToUse, ConsoleKey CancelKey, string prefix = "", string suffix = "")
        {
            return;
            do
            {
                while (!Console.KeyAvailable)
                {
                    /* int count = 0;
                     for (int i = 0; i < 6; i++)
                     {
                     Entry:
                         var dirname = $"iliketrains{count}";
                         if (!Directory.Exists($"{dirname}"))
                         {
                             Directory.CreateDirectory($"{dirname}");
                             Console.WriteLine($"Created {dirname}!");
                         }
                         else
                         {
                             Console.WriteLine($"{dirname} already exist!");
                             Directory.Delete($"{dirname}");
                             goto Entry;
                         }

                         ++count;
                     }*/

                    var prevColor = Console.ForegroundColor;

                    Console.ForegroundColor = ColorToUse;
                    Console.WriteLine($"{prefix}LOOPS{suffix}");
                    Console.ForegroundColor = prevColor;

                    Thread.Sleep(10);
                }
            } while (Console.ReadKey().Key != CancelKey);

            Console.WriteLine("Escape was pressed!");
        }
    }
}

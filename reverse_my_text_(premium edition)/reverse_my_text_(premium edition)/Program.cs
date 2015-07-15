using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace reverse_my_text__premium_edition_
{
    class Program
    {
        static void Main(string[] args)
        {
            begin:
            var loop = true;
            var exist = 3;
            while (loop)
            {
                Console.TreatControlCAsInput = false;
                Console.Title = "Reverse My Text (premium edition)";
                loop = false;
                Console.WriteLine("trying to see if text file already exist....");
                if (File.Exists("textoutput.txt"))
                {
                    Console.WriteLine("Textoutput.txt found!");
                    Console.WriteLine("Enter the text to be processed...");

                    string text = Console.ReadLine();
                    char[] uservalue = text.ToCharArray();
                    char[] ReversedUserValue = text.ToCharArray();

                    Console.WriteLine("Open the text file? [y/n]");
                    ConsoleKeyInfo opentxt = Console.ReadKey();
                    opentxtfile(opentxt);

                    Console.TreatControlCAsInput = true;

                    Console.Write("u entered: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintChar(uservalue);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;

                    Reverse(ReversedUserValue);

                    PrintToFile(uservalue, ReversedUserValue);

                    if (opentxt.Key == ConsoleKey.Y)
                    {
                        Process.Start("textoutput.txt");
                    }
                    exist = 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("textoutput.txt not found... creating now!");
                    File.CreateText("textoutput.txt");
                    Console.WriteLine("close this program then reopen it..");
                    exist = 0;
                }
            }
            if (exist == 1)
            {
            menugoto:
            menu();
            ConsoleKeyInfo ExitConfirm = Console.ReadKey();
            Console.WriteLine("");
            
                switch (ExitConfirm.Key)
                {
                    case ConsoleKey.N:
                        goto begin;
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.D:
                        File.Delete("textoutput.txt");
                        break;
                    default:
                        if (ExitConfirm.Modifiers == 0)
                        {
                            Console.WriteLine("\"{0}\" is not a valid option, please enter a valid option...", ExitConfirm.Key);
                            goto menugoto; 
                        }
                        else
                        {
                            Console.WriteLine("\"{0} + {1}\" is not a valid option, please enter a valid option...", ExitConfirm.Key, ExitConfirm.Modifiers);
                            goto menugoto; 
                        }
                }
            }

            else
            {
                Console.WriteLine("Exiting application!...");
            }
        }

        static char[] ReadInput()
        {
           string foo = Console.ReadLine();
           return foo.ToCharArray();
        }
        static void Reverse(char[] CharArray)
        {
            Array.Reverse(CharArray);
        }
        static void PrintToFile(char[] data, char[] reversed)
        {
            StreamWriter writer = new StreamWriter("textoutput.txt");
            writer.WriteLine("this is the raw text:");
            writer.WriteLine(data);
            writer.WriteLine("raw text after its reversed:");
            writer.WriteLine(reversed);
            writer.Close();

        }
        static void PrintChar(char[] data)
        {
            foreach (char stuff in data)
            {
                Console.Write(stuff);
            }
        }
        static void menu()
        {
            Console.WriteLine("Choose a option then press the key that go's with that option...\n");
            Console.WriteLine("Y\t-\tExit the application");
            Console.WriteLine("N\t-\tGo back to the start of the app");
            Console.WriteLine("D\t-\tDelete textoutput.txt");
            Console.WriteLine("");
        }
        static void opentxtfile(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Y)
            {
                Console.WriteLine("The text file will open after receiving input...");
            }
            if (key.Key == ConsoleKey.N)
            {
                Console.WriteLine("Skipping opening textoutput.txt...");
            }
        }
    }
}

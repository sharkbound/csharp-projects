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
            //change
            Console.WriteLine("test");
            begin:
            var loop = true;
            var exist = 3;
            while (loop)
            {
                Console.Title = "Reverse My Text (premium edition)";
                loop = false;
                Console.WriteLine("trying to see if text file already exist....");
                if (File.Exists("textoutput.txt"))
                {
                    Console.WriteLine("Textoutput.txt found!");

                    string text = Console.ReadLine();
                    char[] uservalue = text.ToCharArray();
                    char[] ReversedUserValue = text.ToCharArray();

                    Console.Write("u entered: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    PrintChar(uservalue);
                    Console.ForegroundColor = ConsoleColor.White;

                    Array.Reverse(ReversedUserValue);

                    PrintToFile(uservalue, ReversedUserValue);
                    Process.Start("textoutput.txt");
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
            Console.WriteLine("\nwould u like to exit the program? [y/n]");
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
        static char[] Reverse(char[] CharArray)
        {
            Array.Reverse(CharArray);
            return CharArray;
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
    }

}

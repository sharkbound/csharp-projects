using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace text_writer
{
    class Program
    {
        static void Main(string[] args)
        {
          top:
            if (File.Exists("output.txt"))
            {
                Console.WriteLine("text file found...");
                Console.Title = "text reverser";
                string stringoutput = "";
                shortcutstuff shortcut = new shortcutstuff();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("enter text to be writen to the text file....");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string reply = Console.ReadLine();
                stringoutput = shortcut.writeToFile(reply);
                //Console.WriteLine(stringoutput.ToString());
                Process.Start("output.txt");
                Console.WriteLine("do u want to exit or restart script? 1=exit 2=restart");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    goto finish;
                }
                else if (choice == "2")
                {
                    goto top;
                }
            }
            else
            {
                Console.WriteLine("output.txt not found.. creating file now...");
                File.CreateText("output.txt");
                Console.WriteLine("text file created, restart me!");
                Console.WriteLine("press any key to terminate me!");
                Console.ReadLine();
            }
      finish:
          Console.WriteLine("press any key to terminate!");
            
        }
    }
}

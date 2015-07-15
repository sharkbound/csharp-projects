using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Pika
{
    class Program
    {
        static void Main(string[] args)
        {
            start:
            if (File.Exists("Pika.txt"))
            {
                StreamWriter write = new StreamWriter("Pika.txt");
                write.WriteLine("Pika?");
                write.Close();
                for (int i = 0; i < 5; i++)
                {
                    Process.Start("Pika.txt");
                }
                goto End;
            }
            else
            {
                File.CreateText("Pika.txt");
            }
            End:
             Console.WriteLine("Pikaaaa?");
            Console.ReadKey();


        }
    }
}

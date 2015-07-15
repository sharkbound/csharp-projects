using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace spyDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader decoder = new StreamReader("decodeThis.txt");
            StreamWriter Writer = new StreamWriter("WriteToMe.txt");
            string line = "";
            while(line != null)
            {

                line = decoder.ReadLine();
                if (line != null) 
                {
                   char[] message = line.ToCharArray();
                   Array.Reverse(message);
                   Console.WriteLine(message);
                   Writer.WriteLine(message);
                }
            }
            Writer.Close();
            decoder.Close();
            Console.WriteLine(".... Done!");
            Console.ReadLine();

        }
    }
}

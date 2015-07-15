using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace readingTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader myReader = new StreamReader("data.txt");
            string line = "";

            while (line != null)
            {
                line = myReader.ReadLine();
                if (line != null)
                    Console.WriteLine(line);
                
            }
            myReader.Close();
            Console.ReadLine();
        }
    }
}

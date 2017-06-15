using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarFieldMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string field;
            //field = GenerateStarField(double.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
            field = GenerateStarField(0.05, 200, 200);
            File.WriteAllText("STARFIELD.TXT", field);
            Process.Start("starfield.txt");
            //Console.WriteLine(field);
        }

        static string GenerateStarField(double density, int rows, int rowLen)
        {
            List<string> res = new List<string>();
            Random r = new Random();

            for (int i = 0; i < rows; i++)
            {
                string stars = "";
                for (int j = 0; j < rowLen; j++)
                {
                    if (r.NextDouble() <= density) stars += '*';
                    else stars += ' ';
                }
                res.Add(stars);
            }
            return string.Join("\n", res);
        }
    }
}

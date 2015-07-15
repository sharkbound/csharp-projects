using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            agency a1 = new agency();
            a1.AgencySize = 100;
            a1.AgencyName = "TIAAAN";
            a1.AgencyCountry = "mother russia";


            spy s1 = new spy();
            s1.CodeName = "Busta";
            s1.DateLastSeen = DateTime.Now;
            s1.Notes = "best spy for sneaking into enemy areas";
            s1.Spyagency = a1.AgencyName;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("gathering spy info...");
            Console.WriteLine("gathering agency info...");

            string message = a1.GetAgencyInfo();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);

            s1.DisplaySpyInfo();
            Console.WriteLine("spy code name: {0},  {1}", s1.CodeName, a1.GetAgencyInfo());

            Console.ReadKey();

        }
    }
}

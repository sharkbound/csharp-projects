using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class spy
    {
        private string notes = "";
        private string codename = "";
        private string spyAgency = "";
        private DateTime dateLastSeen;
        private agency agency;

        public agency SpiAgency
        {
            get { return agency; }
            set { agency = value; }
        }

        public string Notes
        {
            get {return notes; }
            set {notes = value;}
        }

        public string CodeName
        {
            get { return codename; }
            set { codename = value; }
        }

        public DateTime DateLastSeen
        {
            get { return dateLastSeen; }
            set { dateLastSeen = value; }
        }

        public string Spyagency
        {
            get { return spyAgency; }
            set
            {
                switch (value)
                {
                    case "TIAAAN":
                        spyAgency = value;
                        break;
                    default:
                        spyAgency = "thats agency isnt ours! arrest him!";
                        break;

                }
            }
        }
        

        public void DisplaySpyInfo()
        {
           // string spyinfo = SpiAgency.GetAgencyInfo();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("notes on the spy: {0}",Notes);
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("spy's agency: {0}", Spyagency);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("date spy was last seen: {0}",DateLastSeen);
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("spy codename: {0}",CodeName);
            Console.WriteLine("-----------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("spy code name: {0},  {1}", CodeName, spyinfo);
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class agency
    {
        

        private string agencyName;
        private string agencyCountry;
        private int agencySize;

        public string AgencyName
        {
            get { return agencyName; }
            set { agencyName = value; }
        }

        public int AgencySize
        {
            get { return agencySize; }
            set { agencySize = value; }
        }

        public string AgencyCountry
        {
            get { return agencyCountry; }
            set { agencyCountry = value; }
        }

        public string GetAgencyInfo()
        {
            string msg = "agency name: " + AgencyName + ", Agency size: " + AgencySize + ", Agency country: " + AgencyCountry;
            //Console.WriteLine(msg);
            return msg;
        }
        
    }
}

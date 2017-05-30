using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet47
{
    class JsonTemplate
    {
        public string Name { get; set; }
        public int Birthday { get; set; }
        public DateTime CurrentDT { get; set; }
        public List<int> MyNumbers { get; set; }
        public Dictionary<int, int> Dict { get; set; }

        public void LoadDefaults()
        {
            Name = "Shark";
            Birthday = 101;
            CurrentDT = DateTime.Now;
            MyNumbers = new List<int> { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
            Dict = new Dictionary<int, int>
            {
                [1] = 2,
                [3] = 1,
                [5] = 8,
                [8] = 101
            };
        }
    }
}

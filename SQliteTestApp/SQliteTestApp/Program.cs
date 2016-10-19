using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace SQliteTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SQliteHelper sqhelper = new SQliteHelper();
            sqhelper.CreateFile();

            //sqhelper.AddTable("test", new string[] { "name VARCHAR(20)", "score INT" });
            //sqhelper.AddScore("Bob", 1);
            Console.ReadKey();
        }
    }
}

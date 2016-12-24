using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Text.RegularExpressions;

namespace SQliteTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SQliteHelper sqHelper = new SQliteHelper();
            sqHelper.CreateFile();

            //sqhelper.AddTable("test", new string[] { "name VARCHAR(20)", "score INT" });
            //sqhelper.AddScore("Bob", 1);

            bool inCommandLoop = true;
            string UserInput = "";
            CommandParser cmdParser = new CommandParser();

            while (inCommandLoop)
            {
                UserInput = Console.ReadLine();
                var parameters = Regex.Split(UserInput, @"\s").ToList();
                var cmdName = parameters[0];

                if (parameters.Count > 1)
                    parameters.RemoveRange(0, 1);
                else
                    parameters = new List<string>();

                if (cmdParser.Parse(cmdName, parameters))
                {

                }
                else
                {
                    if (UserInput.ToLower() == "exit") break;
                    Console.WriteLine(string.Format("{0} is not a valid command!", UserInput));
                }
            }
        }
    }
}

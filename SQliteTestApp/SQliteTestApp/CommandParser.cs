using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQliteTestApp
{
    public class CommandParser
    {
        public bool Parse(string command, string[] parameters = null)
        {
            SQliteHelper sqHelper = new SQliteHelper();
            switch (command)
            {
                case "list":
                    var results = sqHelper.GetAllValuesFromTable("scores", "User:\n\tName: {0}\n\tScore:{1}");
                    foreach (var str in results) Console.WriteLine(str);
                    return true;
                case "adduser":
                    if (parameters.Length == 2)
                    {
                        int loopAmt = 0;
                        if (int.TryParse(parameters[1], out loopAmt))
                        {
                            DateTime now = DateTime.Now;
                            var sqliteconnection = sqHelper.GetConnectionOpen();
                            for (int ii = 0; ii < loopAmt; ii++)
                            {
                                Console.WriteLine(sqHelper.AddScore(GetRandomName(), GetRandomScore(9000), sqliteconnection));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Could not parse " + parameters[1] + " into a int!");
                        }

                        return true;
                    }

                    Console.WriteLine(sqHelper.AddScore(GetRandomName(), GetRandomScore(9000)));
                    return true;
                case "removeusers":
                    sqHelper.ConstructCommand("delete from scores where score = score").ExecuteNonQuery();
                    return true;
                default:
                    return false;
            }
        }

        public string GetRandomName()
        {
            string[] names = new string[] { "ash", "ketchum", "bob", "nick", "cage", "rocket", "raccoon", "willie", "james", "scott" };

            Random random = new Random();
            return string.Format("{0} {1}", names[random.Next(names.Length)], names[random.Next(names.Length)]);
        }

        public int GetRandomScore(int maxValue)
        {
            Random rand = new Random();
            return rand.Next(maxValue);
        }
    }
}

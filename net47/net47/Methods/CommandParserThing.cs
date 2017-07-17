using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace net47.Methods
{
    class CommandParserThing
    {
        internal static void Start()
        {
            var commands = from T in Assembly.GetExecutingAssembly().GetTypes()
                           from method in T.GetMethods()
                           let A = method.GetCustomAttribute<CommandAttribute>()
                           where A != null
                           where T.GetConstructor(Type.EmptyTypes) != null
                           select new { M = method, A = A, INST = Activator.CreateInstance(T) };

            while (true)
            {
                Console.Write(">>> ");
                string input = Console.ReadLine();
                string[] p = Regex.Matches(input, @""".*""|[^ ]+").Cast<Match>().Select(x => x.Value.Trim('"')).ToArray();

                var cmd = commands.FirstOrDefault(x => x.A.CommandName.ToLower() == p.FirstOrDefault().ToLower());
                if (cmd != null)
                {
                    cmd.M.Invoke(cmd.INST, new object[] { p.Skip(1).ToArray() });
                }
            }
        }



        private static int exec = 0;
        [Command("add")]
        public void Add(string s)
        {

        }

        [Command("echo")]
        public void Execute(string[] str)
        {
            Console.WriteLine("ECHO >> " + string.Join(" ", str));
        }
    }
}

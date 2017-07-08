using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Reflection;

namespace dotnet47
{
    class Program
    {
        Program Instance;
        static bool waitForDebugKey = false;
        static void Main(string[] args)
        {
            new Program().Start();

            if (Debugger.IsAttached && waitForDebugKey)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private void Start()
        {
        }
    }
}



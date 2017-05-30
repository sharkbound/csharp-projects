using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using static dotnet47.Methods.Util;
using System.Numerics;
using System.Threading;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace dotnet47
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();

            if (Debugger.IsAttached)
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

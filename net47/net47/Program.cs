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
using System.Globalization;
using LiteDB;

namespace dotnet47
{
    class Program
    {
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
            var db = new LiteDatabase("bankdb");
            var col = db.GetCollection<Account>("bank");

            if (!col.Exists(Query.Contains("callerid", "hacker")))
                col.Insert(new Account("hacker", 1337));
        }
    }

    class Account
    {
        public Account() { }
        public Account(string id, int bal = 0) => (CallerId, Balance) = (id, bal);

        public override string ToString() => $"{Index}: {CallerId} -> {Balance}";

        [BsonId]
        public int Index { get; set; }
        public string CallerId { get; set; }
        public int Balance { get; set; }
    }

    /*
            Random r = new Random();
            string letters = "abcdefghijklmnopqrstuvwxyz";
            letters += letters.ToUpper();

            string randomName = "";
            foreach (var _ in Enumerable.Range(0, 10))
                randomName += letters.PickRandom();

            using (LiteDatabase db = new LiteDatabase("dbd"))
            {
                var c = db.GetCollection<Account>("balances");
                c.Upsert(new Account(randomName));

                foreach (Account i in c.Find(x => x.Balance > 50))
                {
                    Console.WriteLine(c.FindById(i.Index));
                }
            }
            */
}

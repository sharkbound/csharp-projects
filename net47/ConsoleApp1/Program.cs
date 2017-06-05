using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using LiteDB;
using Core.Util;
using System.Diagnostics;

namespace Core
{
    class Person
    {
        [BsonField]
        public string name;
        [BsonField]
        public int age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            string[] names = new[] { "JIM", "BILLY", "JOE", "NULL", "ISSAC" };
            using (LiteDatabase db = new LiteDatabase("DB.litedb"))
            {
                var c = db.GetCollection<Person>();
                c.Insert(new Person { name = names[r.Next(names.Length)], age = 50 });

                foreach (var i in c.FindAll())
                    Console.WriteLine(i.age + " = " + c.Count());
            }
        }
    }
}
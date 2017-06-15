using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using LiteDB;
using System.Linq;
using MongoDB.Driver;

using MongoId = MongoDB.Bson.Serialization.Attributes.BsonIdAttribute;
using MongoObjectId = MongoDB.Bson.ObjectId;

namespace dotnet47
{
    class DBT
    {
        public static void LiteDBTest()
        {
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
                    Console.WriteLine(c.FindById(1));
                }
            }
        }

        public static void MongoDBTesting()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("Bank");
            var c = db.GetCollection<Account>("Bank");

            c.InsertMany(Enumerable.Range(0, 1000).Select(x => new Account()));

            Console.WriteLine(c.Find(x => x.Balance < 1000).Format());
        }
    }

    class Account
    {
        static Random r = new Random();
        public Account()
        {
            string alpha = "abcdefghijklmnopqrstuvwxyz"; alpha += alpha.ToUpper();
            string name = "";

            for (int i = 0; i < 15; i++)
                name += alpha.PickRandom();

            CallerId = name;
            Balance = r.Next(0, 1_000_000);
        }

        public Account(string id, int bal = 0) => (CallerId, Balance) = (id, bal);

        public override string ToString() => $"ID-{Id}: {CallerId} -> {Balance}";

        [MongoId]
        public MongoObjectId Id { get; set; }
        public string CallerId { get; set; }
        public int Balance { get; set; }
    }
}

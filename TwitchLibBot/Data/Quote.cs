using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace TwitchLibBot.Data
{
    class Quote
    {
        public string Text { get; set; }
        [BsonId]
        public int Id { get; set; }
    }
}

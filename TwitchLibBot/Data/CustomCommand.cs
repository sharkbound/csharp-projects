using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace TwitchLibBot.Data
{
    public class CustomCommand
    {
        [BsonId]
        public int Id { get; set; }
        public string CmdName { get; set; }
        public string Reponse { get; set; }
    }
}

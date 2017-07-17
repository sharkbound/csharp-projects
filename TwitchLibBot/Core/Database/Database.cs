using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using TwitchLibBot.Data;

namespace TwitchLibBot.Core.Database
{
    class Database
    {
        public static LiteDatabase DB => new LiteDatabase("TwitchData.litedb");

        // Command 
        public static LiteCollection<CustomCommand> CommandDB => DB.GetCollection<CustomCommand>(CommandDbName);
        internal static string CommandDbName => Config.Instance.ChannelName + "_Commands";

        internal static void AddOrUpdateCustomCommand(CustomCommand c) => CommandDB.Upsert(c);
        internal static void DeleteCustomCommand(CustomCommand c) => CommandDB.Delete(x => x.Id == c.Id);
        internal static CustomCommand GetCustomCommand(string cmdName) => CommandDB.FindOne(x => x.CmdName == cmdName);

        // Quote 
        public static LiteCollection<Quote> QuoteDB => DB.GetCollection<Quote>(QuoteDbName);
        internal static string QuoteDbName => Config.Instance.ChannelName + "_Quotes";

        internal static void AddOrUpdateQuote(Quote c) => QuoteDB.Upsert(c);
        internal static void DeleteQuote(Quote c) => QuoteDB.Delete(x => x.Id == c.Id);
        internal static Quote GetQuote(int id) => QuoteDB.FindById(id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using TwitchLibBot.Data;
using TwitchLibBot.Data.Resources;

namespace TwitchLibBot.Core.Database
{
    class Database
    {
        // properties
        internal static string QuoteDbName => TwitchInfo.ChannelName + "_Quotes";
        internal static string CommandDbName => TwitchInfo.ChannelName + "_Commands";

        public static LiteDatabase DB => new LiteDatabase("TwitchData.litedb");
        public static LiteCollection<CustomCommand> CommandDB => DB.GetCollection<CustomCommand>(CommandDbName);
        public static LiteCollection<Quote> QuoteDB => DB.GetCollection<Quote>(QuoteDbName);

        // Command Methods
        internal static void AddOrUpdateCustomCommand(CustomCommand c) => CommandDB.Upsert(c);
        internal static void DeleteCustomCommand(CustomCommand c) => CommandDB.Delete(x => x.Id == c.Id);
        internal static CustomCommand GetCustomCommand(string cmdName) => CommandDB.FindOne(x => x.CmdName == cmdName);

        // Quote Methods
        internal static void AddOrUpdateQuote(Quote c) => QuoteDB.Upsert(c);
        internal static void DeleteQuote(Quote c) => QuoteDB.Delete(x => x.Id == c.Id);
        internal static Quote GetQuote(int id) => QuoteDB.FindById(id);
    }
}

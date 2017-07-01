using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Models.Client;
using TwitchLibBot.Core.Helpers;
using TwitchLibBot.Data;
using TwitchLibBot.Interfaces;
using TwitchLibBot.Core.Database;

namespace TwitchLibBot.Commands
{
    class CommandQuote : IChatCommand
    {
        public string Command => "!quote";
        string usage = "!quote <quote id | random | del | add | edit> (quote id (if del or edit)) (text)";
        Random r = new Random();

        public void Execute(ChatMessage msg, string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Chat.Send(usage);
                return;
            }

            if (int.TryParse(parameters[0], out int id))
            {
                Quote quote = Database.GetQuote(id);
                if (quote != null) Chat.Send(quote.Text);
                else Chat.Send($"No quote found by id: {id}");
                return;
            }
            else if (parameters[0].ToLower() == "random")
            {
                Quote[] quotes = Database.QuoteDB.FindAll().ToArray();
                string quote = quotes.Length == 0 ? "No quotes found" : quotes[r.Next(quotes.Length)].Text;
                Chat.Send(quote);
                return;
            }

            int quoteId;
            bool isEditOrDel = parameters[0].ToLower() == "del" || parameters[0].ToLower() == "edit";
            if (!int.TryParse(parameters[1], out quoteId) && isEditOrDel)
            {
                Chat.Send("Quote ID must be numeric");
                return;
            }
            
            Quote q = Database.GetQuote(quoteId);
            switch (parameters[0].ToLower())
            {
                case "del" when parameters.Length == 2:
                    if (q != null) Database.DeleteQuote(q);
                    Chat.Send(q != null ? $"Deleted quote {quoteId}" : $"Could not find any quotes by id of {quoteId}");
                    break;

                case "add" when parameters.Length >= 1:
                    string addText = string.Join(" ", parameters.Skip(1));
                    if (q == null)
                        Database.AddOrUpdateQuote(new Quote { Text = addText });
                    Chat.Send(q == null ? $"Added quote \"{addText}\" with id: {Database.QuoteDB.FindAll().LastOrDefault().Id}" : $"Quote already exist");
                    break;

                case "edit" when parameters.Length >= 2:
                    string editText = string.Join(" ", parameters.Skip(2));
                    if (q != null)
                    {
                        q.Text = editText;
                        Database.AddOrUpdateQuote(q);
                    }
                    Chat.Send(q != null ? $"Updated quote {quoteId}" : $"Quote {quoteId} does not exist");
                    break;

                default:
                    Chat.Send("Invalid parameter, Usage: " + usage);
                    break;
            }
        }
    }
}

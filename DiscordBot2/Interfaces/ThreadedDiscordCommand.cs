using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace DiscordBot2.Interfaces
{
    public abstract class ThreadedDiscordCommand : IDiscordCommand
    {
        public abstract string Name { get; }

        public abstract string Help { get; }

        public abstract string Syntax { get; }

        public abstract string Permission { get; }

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () => await Execute(msg, parameters));
            return Task.CompletedTask;
        }

        protected abstract Task Execute(SocketUserMessage msg, string[] parameters);
    }
}

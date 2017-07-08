using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitchLibBot.Data
{
    public class Config
    {
        public Config()
        {
            ChannelName = "CHANNEL_NAME";
            Oauth = "oauth:XXXXXXXXX";
            BotNickName = "John Doe";
        }

        public string ChannelName { get; set; }
        public string Oauth { get; set; }
        public string BotNickName { get; set; }

        public static Config Instance { get; set; }

        internal static bool ConfigExist => File.Exists(ConfigFileName);
        internal const string ConfigFileName = "BotConfig.json";

        internal static void Load()
        {
            if (!ConfigExist)
            {
                File.WriteAllText(ConfigFileName, JsonConvert.SerializeObject(new Config(), Formatting.Indented));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Created the config file, edit {ConfigFileName} then start the bot again");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey(true);
                Environment.Exit(0);
            }

            if (Instance == null)
                Instance = new Config();

            JsonConvert.PopulateObject(File.ReadAllText(ConfigFileName), Instance);
        }
    }
}

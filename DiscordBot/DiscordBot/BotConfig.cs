using Newtonsoft.Json;
using System.IO;
using System;

namespace DiscordBot
{
    public class BotConfig
    {
        [JsonIgnore]
        public string ConfigDir = "config";
        [JsonIgnore]
        public string ConfigFileName = "config.json";
        [JsonIgnore]
        public string ConfigPath;

        public string Token { get; set; }
        public string OwnerID { get; set; }
        public char? CommandPrefix { get; set; }

        internal BotConfig()
        {
            ConfigPath = $"{ConfigDir}\\{ConfigFileName}";

            if (!Directory.Exists(ConfigDir)) Directory.CreateDirectory(ConfigDir);

            if (!File.Exists(ConfigPath))
            {
                loadDefaults();
                getSettingsFromConfig();
            }
            else
            {
                getSettingsFromConfig();
            }
        }

        BotConfig getDefaults()
        {
            Token = "change me";
            OwnerID = "default ownerID";
            CommandPrefix = '<';
            return this;
        }

        void getSettingsFromConfig()
        {
            // Read text from file then popular this object with those settings
            JsonConvert.PopulateObject(File.ReadAllText(ConfigPath), this);
        }

        void loadDefaults()
        {
            string json = JsonConvert.SerializeObject(getDefaults(), Formatting.Indented);
            File.AppendAllText(ConfigPath, json);
        }


    }
}
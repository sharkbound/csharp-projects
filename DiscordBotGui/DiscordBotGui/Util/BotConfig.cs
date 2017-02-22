using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscordBotGui.Util
{
    public class BotConfig
    {
        [JsonIgnore]
        public static readonly string ConfigFilePath = @"config\config.json";
        [JsonIgnore]
        public static readonly string ConfigFolderPath = @"config\";

        public string Token = "default";
        public char CommandPrefix = '.';
    }
}

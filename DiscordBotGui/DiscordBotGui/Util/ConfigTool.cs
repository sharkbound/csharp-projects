using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotGui.Util
{
    public static class ConfigTool
    {
        public static bool ConfigExist()
        {
            return File.Exists(BotConfig.ConfigFilePath);
        }

        public static void CreateConfigFile()
        {
            if (!Directory.Exists(BotConfig.ConfigFolderPath))
                Directory.CreateDirectory(BotConfig.ConfigFolderPath);

            if (!File.Exists(BotConfig.ConfigFilePath))
            {
                File.AppendAllText(BotConfig.ConfigFilePath, JsonConvert.SerializeObject(new BotConfig(), Formatting.Indented));
            }
        }

        public static string ReadConfig()
        {
            return File.ReadAllText(BotConfig.ConfigFilePath);
        }

        public static void GetConfigSettings(BotConfig cfg)
        {
            JsonConvert.PopulateObject(ReadConfig(), cfg);
        }
    }
}

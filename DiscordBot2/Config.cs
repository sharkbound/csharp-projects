using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DiscordBot2.Utils
{
    public class Config
    {
        [JsonIgnore]
        public static readonly string PermissionsFilePath = @"Config\permissions.json";
        [JsonIgnore]
        public static readonly string ConfigFilePath = @"Config\config.json";
        [JsonIgnore]
        public static readonly string ConfigFolderPath = @"Config\";


        public string Token = "default";
        public string CommandPrefix = "..";
        public bool LogChat = false;

        public static void CreateConfig()
        {
            if (!Directory.Exists(ConfigFolderPath))
                Directory.CreateDirectory(ConfigFolderPath);
            if (!File.Exists(ConfigFilePath))
                File.AppendAllText(ConfigFilePath, JsonConvert.SerializeObject(new Config(), Formatting.Indented));
        }

        public static string ReadConfigFile()
        {
            CreateConfig();
            return File.ReadAllText(ConfigFilePath);
        }

        public static Config GetConfig()
        {
            CreateConfig();
            var config = new Config();
            JsonConvert.PopulateObject(ReadConfigFile(), config);
            return config;
        }
    }
}

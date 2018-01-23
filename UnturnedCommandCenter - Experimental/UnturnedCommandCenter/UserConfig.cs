using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using UCC.Utilites;

namespace UCC
{
    class UserConfig
    {
        [JsonIgnore]
        public static UserConfig Instance { get; private set; }
        [JsonIgnore]
        public static readonly string jsonPath = "Config/Config.json";
        [JsonIgnore]
        public static readonly string ConfigFolder = "Config";

        public string Ip;
        public int Port;
        public string ServerPass;
        public string TextColor;
        public string ConsoleBGColor;

        public void LoadDefaults()
        {
            Ip = "default";
            Port = 0;
            ServerPass = "change me";
            TextColor = "#FF36CB0B";
            ConsoleBGColor = "#FF000000";
        }

        public static void Save()
        {
            DirUtil.WriteTextToFile(jsonPath, JsonConvert.SerializeObject(Instance));
        }

        public static void LoadConfig()
        {
            if (!File.Exists(jsonPath))
            {
                DirUtil.CreateDirectoryIfNotExist(ConfigFolder);

                Instance = new UserConfig();
                Instance.LoadDefaults();

                string jsonString = JsonConvert.SerializeObject(Instance, Formatting.Indented);
                DirUtil.WriteTextToFile(jsonPath, jsonString);
            }

            Instance = new UserConfig();
            JsonConvert.PopulateObject(DirUtil.ReadTextFile(jsonPath), Instance);
        }
    }
}

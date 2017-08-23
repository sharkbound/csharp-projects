using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Config.Json
{
    class JsonConfig<T> where T : class, IJsonConfig, new()
    {
        public T Instance { get; private set; }
        public string FileName { get; }
        public string CompletePath => $"{FolderName}/{FileName}.json";

        const string FolderName = "Config";

        public JsonConfig(string fileName)
        {
            FileName = fileName;
            CreateIfNotExist();
            Load();
        }
        
        public void Load() => Instance = JsonConvert.DeserializeObject<T>(File.ReadAllText(CompletePath));
        public void Save() => File.WriteAllText(CompletePath, Serialize(Instance));

        private void CreateIfNotExist()
        {
            if (!Directory.Exists(FolderName)) Directory.CreateDirectory(FolderName);
            if (!File.Exists(CompletePath))
            {
                File.Create(CompletePath).Close();
                LoadDefaults();
            }
        }

        private void LoadDefaults()
        {
            Instance = new T();
            Instance.LoadDefaults();
            Save();
        }

        private string Serialize(T inst) => JsonConvert.SerializeObject(inst, Formatting.Indented);
    }

    interface IJsonConfig
    {
        void LoadDefaults();
    }
}

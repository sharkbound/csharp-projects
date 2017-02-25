using DiscordBot2.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2
{
    public sealed class Permissions
    {
        public List<PermissionGroup> Groups = new List<PermissionGroup>();

        public static void CreateConfigIfNotExist()
        {
            if (!Directory.Exists(Config.ConfigFolderPath))
                Directory.CreateDirectory(Config.ConfigFolderPath);
            if (!File.Exists(Config.PermissionsFilePath))
                File.AppendAllText(Config.PermissionsFilePath, JsonConvert.SerializeObject(new Permissions
                {
                    Groups =
                    {
                        new PermissionGroup{ GroupName = "default"},
                        new PermissionGroup{ GroupName = "admin"}
                    }
                }, Formatting.Indented));
        }

        private static string ReadPermissionsFile()
        {
            CreateConfigIfNotExist();
            return File.ReadAllText(Config.PermissionsFilePath);
        }

        public static Permissions GetPermissions()
        {
            CreateConfigIfNotExist();
            Permissions p = new Permissions { };
            JsonConvert.PopulateObject(ReadPermissionsFile(), p);
            return p;
        }

        public static void PrintAllPermissionValues(Permissions p)
        {
            foreach (var group in p.Groups)
            {
                Logger.Log(group.GroupName);
                foreach (var mem in group.Members)
                    Logger.Log("   Member: " + mem);
                foreach (var cmd in group.Commands)
                    Logger.Log("   Command: " + cmd);
            }
        }
    }

    public class PermissionGroup
    {
        public string GroupName;
        public List<string> Members = new List<string> { };
        public List<string> Commands = new List<string> { };
    }
}

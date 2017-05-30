using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet47
{
    class TEXT
    {
        public static string JsonPath => @"C:\Users\owner\Desktop\GitHub\csharp-projects\dotnet47\dotnet47\Json\TestingJson.json";
        public static string JsonText => File.ReadAllText(JsonPath);
    }
}

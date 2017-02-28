using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordBot2.Utils
{
    public static class Command
    {
        //static Regex ReplaceTab = new Regex(@"\\t", RegexOptions.Compiled);
        //static Regex ReplaceNewline = new Regex(@"\\n", RegexOptions.Compiled);
        public static string ParseParameters(string parameter)
        {
            if (parameter.Contains(@"\n"))
                parameter = parameter.Replace(@"\n", "\n");
            if (parameter.Contains(@"\t"))
                parameter = parameter.Replace(@"\t", "\t");
            return parameter;
        }

        public static string[] ReplaceEscapeChars(string[] parameters)
        {
            string proccessing;
            for(int i = 0; i < parameters.Length; i++)
            {
                proccessing = parameters[i];
                proccessing = proccessing.Replace(@"\n", "\n");
                proccessing = proccessing.Replace(@"\t", "\t");
                parameters[i] = proccessing;
            }
            return parameters;
        }
    }
}

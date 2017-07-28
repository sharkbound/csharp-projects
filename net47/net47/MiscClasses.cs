using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net47
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CommandAttribute : Attribute
    {
        public string CommandName;
        public CommandAttribute(string cname)
        {
            CommandName = cname;
        }
    }
}

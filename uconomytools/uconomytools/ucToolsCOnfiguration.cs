using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;

namespace uconomytools
{
    public class ucToolsCOnfiguration : IRocketPluginConfiguration
    {
        public string ServerAddress;
        public string username;
        public string password;
        public int port;

        public void LoadDefaults()
        {
            ServerAddress = "localhost";
            username = "root";
            password = "password";
            port = 3306;
        }
    }
}

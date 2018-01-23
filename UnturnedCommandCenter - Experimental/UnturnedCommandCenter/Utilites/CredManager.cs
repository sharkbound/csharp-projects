using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredentialManagement;

namespace UCC.Utilites
{
    class CredManager
    {
        public static void SaveRconPass(string pass)
        {
            Credential c = new Credential()
            {
                Username = "RCON",
                Password = pass,
                Target = "rocketrcon"
            };
            c.Save();
            
            CredentialSet a = new CredentialSet(target: "rocketrcon");
        }
    }
}

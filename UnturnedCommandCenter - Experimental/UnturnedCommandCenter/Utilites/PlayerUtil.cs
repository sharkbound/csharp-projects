using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCC.Extensions;

using main = UCC.MainWindow;

namespace UCC.Utilites
{
    public class PlayerUtil
    {
        public async static Task<string[]> GetPlayerList()
        {
            await main.client.SendText("players");
            main.IgnoreNextRecieved = true;
            string recieved = await main.client.Receive();

            return recieved.Split('\n');
        }
    }
}

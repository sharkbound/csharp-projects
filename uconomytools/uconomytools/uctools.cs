using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.Core.Plugins;
using MySql.Data;

namespace uconomytools
{
    public class UcTools : RocketPlugin<ucToolsCOnfiguration>
    {
        public static UcTools instance;
        public DatabaseManager Database;

        protected override void Load()
        {
            instance = this;
            Logger.Log("uconomytools has loaded!");
            Database = new DatabaseManager();
        }

        protected override void Unload()
        {
            Logger.Log("uconomytools has Unloaded!");
        }
    }
}

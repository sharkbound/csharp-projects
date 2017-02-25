using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Utils
{
    public static class PermissionHelper
    {
        public static bool HasPermission(SocketUser caller, string permission)
        {
            List<PermissionGroup> groups = Program.perms.Groups.Where(g => g.Members.Contains(caller.Id.ToString()))?.ToList();
            if (groups.Equals(null))
            {
                groups = new List<PermissionGroup>();
            }
            groups.Add(Program.perms.Groups.SingleOrDefault(g => g.GroupName.ToLower() == "default"));

            var result = groups.Where(g => g.Commands.Contains(permission) || g.Commands.Contains("*"))?.ToList();
            return result != null && result.Count != 0;
        }
    }
}

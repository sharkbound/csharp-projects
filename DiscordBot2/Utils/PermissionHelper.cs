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
            List<PermissionGroup> groups = GetUserGroups(caller); //Program.perms.Groups.Where(g => g.Members.Contains(caller.Id.ToString()))?.ToList();
            if (groups.Equals(null))
            {
                groups = new List<PermissionGroup>();
            }
            groups.Add(Permissions.Instance.Groups.SingleOrDefault(g => g.GroupName.ToLower() == "default"));

            var result = groups.Where(g => g.Commands.Contains(permission) || g.Commands.Contains("*"))?.ToList();
            return result != null && result.Count != 0;
        }

        public static bool HasPermission(string id, string permission)
        {
            List<PermissionGroup> groups = Permissions.Instance.Groups.Where(g => g.Members.Contains(id))?.ToList();
            if (groups.Equals(null))
            {
                groups = new List<PermissionGroup>();
            }
            groups.Add(Permissions.Instance.Groups.SingleOrDefault(g => g.GroupName.ToLower() == "default"));

            var result = groups.Where(g => g.Commands.Contains(permission) || g.Commands.Contains("*"))?.ToList();
            return result != null && result.Count != 0;
        }

        public static List<PermissionGroup> GetUserGroups(SocketUser user)
        {
            //var userGroups = Program.perms.Groups.Where(g => g.Members.Contains(user.Id.ToString()))?.ToList();
            return Permissions.Instance.Groups.Where(g => g.Members.Contains(user.Id.ToString()))?.ToList();
        }
    }
}

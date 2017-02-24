using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DiscordBot2.Utils
{
    public static class ColorUtil
    {
        public static int HexToRgb(string hexcode)
        {
            return int.Parse(hexcode, NumberStyles.AllowHexSpecifier);
        }
    }
}

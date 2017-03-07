using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Media = System.Windows.Media;
using Drawing = System.Drawing;

namespace Utilities
{
    public class ColorUtil
    {
        public static (byte a, byte r, byte g, byte b) GetRgbValuesFromHex(string hex)
        {
            var c = Drawing.ColorTranslator.FromHtml($"#{hex}");
            return (c.A, c.R, c.G, c.B);
        }

        public static Media.SolidColorBrush GetSolidColorBrushFromHex(string hex)
        {
            var (a, r, g, b) = GetRgbValuesFromHex(hex);
            return new Media.SolidColorBrush(Media.Color.FromArgb(a, r, g, b));
        }
    }
}

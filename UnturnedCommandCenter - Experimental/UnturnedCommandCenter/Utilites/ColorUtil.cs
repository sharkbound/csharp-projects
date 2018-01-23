using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Media = System.Windows.Media;
using Drawing = System.Drawing;

namespace UCC.Utilites
{
    public class ColorUtil
    {
        static Random r = new Random();
        public static (byte a, byte r, byte g, byte b) GetRgbValuesFromHex(string hex)
        {
            if (!hex.Contains("#"))
                hex = hex.Insert(0, "#");

            var c = Drawing.ColorTranslator.FromHtml(hex);
            return (c.A, c.R, c.G, c.B);
        }

        public static Media.SolidColorBrush GetSolidColorBrushFromHex(string hex)
        {
            var (a, r, g, b) = GetRgbValuesFromHex(hex);
            return new Media.SolidColorBrush(Media.Color.FromArgb(a, r, g, b));
        }

        public static Media.SolidColorBrush GetSolidColorBrushFromRBG(byte a, byte r, byte g, byte b)
        {
            return new Media.SolidColorBrush(Media.Color.FromArgb(a, r, g, b));
        }

        public static Media.SolidColorBrush GetRandomColor(int aMin = 254, int aMax = 256, int rMin = 0, int rMax = 256, int gMin = 0, int gMax = 256, int bMin = 0, int bMax = 256)
        {
            return GetSolidColorBrushFromRBG(
                (byte)r.Next(aMin, aMax),
                (byte)r.Next(rMin, rMax),
                (byte)r.Next(gMin, gMax),
                (byte)r.Next(bMin, bMax));
        }
    }
}

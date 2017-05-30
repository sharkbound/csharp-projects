using System;

namespace CodingWarsSolutions
{
    public class Mumbling
    {
        public static string Accum(string s)
        {
            string ret = "";

            for (int i = 0; i < s.Length; i++)
            {
                ret += multChar(s[i], i + 1) + (i == s.Length - 1 ? "" : "-");
            }
            return ret;
        }

        static string multChar(char c, int times)
        {
            string ret = "";
            for (int i = 0; i < times; i++)
            {
                ret += (i == 0) ? Char.ToUpper(c) : Char.ToLower(c);
            }
            return ret;
        }
    }
}
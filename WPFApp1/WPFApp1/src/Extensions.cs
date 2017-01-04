using System.Windows;

namespace App.ExtensionMethods
{
    public static class Extensions
    {
        public static logging.Logger logger = new logging.Logger();

        public static string[] CutPath(this string[] str)
        {
            int index = 0;

            for (int ii = 0; ii < str.Length; ii++)
            {
                if (!str[ii].Contains(@"\")) continue;

                index = str[ii].LastIndexOf(@"\");
                str[ii] = str[ii].Remove(0, index + 1);
            }

            return str;
        }

        public static string CutPath(this string str)
        {
            if (!str.Contains(@"\")) return "";
            return str.Remove(0, str.LastIndexOf(@"\") + 1);
        }

        public static string Log(this string str)
        {
            logger.Log(str);
            return str;
        }

        public static string MsgBox(this string str)
        {
            MessageBox.Show(str);
            return str;
        }
    }
}

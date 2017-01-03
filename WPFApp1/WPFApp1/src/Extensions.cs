namespace App.ExtensionMethods
{
    public static class Extensions
    {
        public static string[] CutPath(this string[] str)
        {
            int index = 0;

            for (int ii = 0; ii < str.Length; ii++)
            {
                if (!str[ii].Contains(@"\")) continue;

                index = str[ii].LastIndexOf(@"\");
                str[ii] = str[ii].Remove(0, index+1);
            }

            return str;
        }
    }
}

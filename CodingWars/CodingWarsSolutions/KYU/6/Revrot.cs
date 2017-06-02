using System;
using System.Linq;
using System.Collections.Generic;


public class Revrot
{
    public static string RevRot(string str, int sz)
    {
        // your code
        if (sz <= 0 || string.IsNullOrEmpty(str) || sz > str.Length)
            return "";

        string[] chunks = getChunks(str, sz);
        string ret = "";

        foreach (var chunk in chunks)
        {
            int chunkSum = chunk.Select(c => (int)Math.Pow(int.Parse(c.ToString()), 3)).Sum();
            
            if (chunkSum % 2 == 0)
                ret += new string(chunk.Reverse().ToArray());
            else
                ret += chunk.Substring(1, chunk.Length - 1) + chunk[0];
        }
        return ret;
    }

    private static string[] getChunks(string str, int chunkSize)
    {
        List<string> ret = new List<string>();

        while (str.Length >= chunkSize)
        {
            ret.Add(str.Substring(0, chunkSize));
            str = str.Remove(0, chunkSize);
        }
        
        return ret.ToArray();
    }
}
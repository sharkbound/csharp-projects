using System;
using System.Linq;
using System.Collections.Generic;

public class Revrot
{
    public static string RevRot(string str, int sz)
    {
        Console.WriteLine("string passed in: " + str);
        // your code
        if (sz <= 0 || string.IsNullOrEmpty(str) || sz > str.Length)
            return "";

        string[] chunks = getChunks(str, sz);
        string ret = "";

        foreach (var chunk in chunks)
        {
            int chunkSum = chunk.Select(c => (int)Math.Pow(int.Parse(c.ToString()), 3)).Sum();
            Console.WriteLine($"chunk: {chunk} size: {sz} chunkSum: {chunkSum}");

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
        int toSkip = 0;
        int range = str.Length / chunkSize;

        for (int i = 0; i < range; i++)
        {
            string value = str.Substring(toSkip, chunkSize); //string.Join("", str.Skip(toSkip).Take(chunkSize));
            toSkip += value.Length - 1; 
            ret.Add(value);
        }

        return ret.ToArray();
    }
}
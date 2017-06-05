using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class CountingDuplicates
{
    public static int DuplicateCount(string str)
    {
        str = str.ToLower();
        var dict = new Dictionary<char, int>();

        foreach (char c in str)
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict.Add(c, 1);
        
        return dict.Count(x => x.Value > 1);
    }
}


[TestFixture]
[Ignore("not current test")]
public class CountingDuplicatesTests
{
    [Test]
    public void KataTests()
    {
        Assert.AreEqual(0, CountingDuplicates.DuplicateCount(""));
        Assert.AreEqual(0, CountingDuplicates.DuplicateCount("abcde"));
        Assert.AreEqual(2, CountingDuplicates.DuplicateCount("aabbcde"));
        Assert.AreEqual(2, CountingDuplicates.DuplicateCount("aabBcde"), "should ignore case");
        Assert.AreEqual(1, CountingDuplicates.DuplicateCount("Indivisibility"));
        Assert.AreEqual(2, CountingDuplicates.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
    }
}
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

public static class CountTheSmilies
{
    public static int CountSmileys(string[] smileys)
    {
        return smileys.Where(s => Regex.IsMatch(s, @"[;:][~-]?[)D]")).Count();
    }
}


[TestFixture]
[Ignore("not current test")]
public class SolutionTest
{
    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(CountTheSmilies.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }), 4);
        Assert.AreEqual(CountTheSmilies.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }), 2);
        Assert.AreEqual(CountTheSmilies.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }), 1);
        Assert.AreEqual(CountTheSmilies.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }), 0);
    }
}
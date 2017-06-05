using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

public class CalculateStringRotation
{
    public static int ShiftedDiff(string first, string second)
    {
        int maxTries = second.Length * 2,
            shifts = 0;

        while (shifts <= maxTries)
        {
            if (first == second)
                break;

            first = first.Last() + first.Substring(0, first.Length - 1);
            shifts++;
        }
        return shifts > maxTries ? -1 : shifts;
    }
}

[TestFixture][Ignore("not current test")]
public class CalculateStringRotationTests
{
    [Test]
    public void BasicTests()
    {
        Console.WriteLine("Test 1");
        Assert.AreEqual(4, CalculateStringRotation.ShiftedDiff("eecoff", "coffee"));
        Console.WriteLine("Test 2");
        Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("Moose", "moose"));
        Console.WriteLine("Test 3");
        Assert.AreEqual(2, CalculateStringRotation.ShiftedDiff("isn't", "'tisn"));
        Console.WriteLine("Test 4");
        Assert.AreEqual(0, CalculateStringRotation.ShiftedDiff("Esham", "Esham"));
        Console.WriteLine("Test 5");
        Assert.AreEqual(0, CalculateStringRotation.ShiftedDiff(" ", " "));
        Console.WriteLine("Test 6");
        Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("hoop", "pooh"));
        Console.WriteLine("Test 7");
        Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("  ", " "));
    }
}

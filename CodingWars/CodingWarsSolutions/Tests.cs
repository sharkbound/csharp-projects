using System;
using System.Diagnostics;
using NUnit.Framework;

[TestFixture]
public static class RevrotTests
{

    private static void testing(string actual, string expected)
    {
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public static void test1()
    {
        testing(Revrot.RevRot("1234", 0), "");
    }
    
    [Test]
    public static void test2()
    {
        testing(Revrot.RevRot("", 0), "");
    }

    [Test]
    public static void test3()
    {
        testing(Revrot.RevRot("1234", 5), "");
    }

    [Test]
    public static void test4()
    {
        string s = "733049910872815764";
        testing(Revrot.RevRot(s, 5), "330479108928157");
    }
}
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

    [Test]
    public static void test5()
    {
        Assert.AreEqual(Revrot.RevRot("123456779", 8), "23456771");
    }

    [Test]
    public static void test6()
    {
        Assert.AreEqual(Revrot.RevRot("664438769", 8), "67834466");
    }

    [Test]
    public static void test7()
    {
        Assert.AreEqual(Revrot.RevRot("66443875", 4), "44668753");
    }
}
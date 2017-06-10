using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodingWarsSolutions
{
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



    [TestFixture]
    [Ignore("not current test")]
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
}
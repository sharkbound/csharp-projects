using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingWarsSolutions
{
    public class Consecutives
    {
        public static List<int> SumConsecutives(List<int> s)
        {
            List<int> ret = new List<int>();
            int last = s[0], count = 0, index = 0;

            foreach (int c in s)
            {
                if (c != last)
                {
                    ret.Add(last * count);
                    count = 0;
                }
                last = c;
                count++;
            }

            if (last == ret.Last())
                ret[ret.Count - 1] += last;
            else
                ret.Add(last);
            
            return ret;
        }

    }



    [TestFixture]
    [Ignore("not current test")]
    public static class ConsecutivesTests
    {
        [Test]
        public static void test1()
        {
            List<int> i = new List<int> { 1, 4, 4, 4, 0, 4, 3, 3, 1 };
            List<int> o = new List<int> { 1, 12, 0, 4, 6, 1 };
            Console.WriteLine("Input: {1,4,4,4,0,4,3,3,1}");
            Console.WriteLine("out should be: { 1, 12, 0, 4, 6, 1 }");
            Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        }

        [Test]
        public static void test2()
        {
            List<int> i = new List<int> { -5, -5, 7, 7, 12, 0 };
            List<int> o = new List<int> { -10, 14, 12, 0 };
            Console.WriteLine("Input: {-5,-5,7,7,12,0}");
            Assert.AreEqual(o, Consecutives.SumConsecutives(i));
        }
    }
}


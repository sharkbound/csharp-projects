using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingWarsSolutions.KYU._4
{
    public class DoubleLinear
    {
        public static int DblLinear(int n)
        {
            var nList = new List<int> { 1 };
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                nList.Add(nList[index] * 2 + 1);
                nList.Add(nList[index] * 3 + 1);
                index++;
            }
            nList = nList.Distinct().OrderBy(x => x).ToList();
            return nList[n];
        }
    }



    [TestFixture]
    public static class DoubleLinearTests
    {

        public static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Fixed Tests DblLinear");
            testing(DoubleLinear.DblLinear(10), 22);
        }

        [Test]
        public static void test2()
        {
            testing(DoubleLinear.DblLinear(30), 91);
        }

        [Test]
        public static void test3()
        {
            testing(DoubleLinear.DblLinear(20), 57);
        }

        [Test]
        public static void test4()
        {
            testing(DoubleLinear.DblLinear(50), 175);

        }

        [Test]
        public static void testBigNumber()
        {
            testing(DoubleLinear.DblLinear(23443), 461781);
        }
    }
}

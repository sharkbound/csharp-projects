using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingWarsSolutions.KYU._5
{
    class AllThatIsOpenMustBeClosed
    {
        public static bool IsBalanced(string s, string caps)
        {
            s = string.Concat(s.Where(x => caps.Contains(x)));
            if (s.Length % 2 != 0) return false;

            List<char>
                open = caps.Where((c, i) => i % 2 == 0).ToList(),
                close = caps.Where((c, i) => i % 2 > 0).ToList();
            var pairs = new Dictionary<char, char>();
            for (int i = 0; i < open.Count; i++) pairs.Add(open[i], close[i]);
            
            var found = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (open.Contains(s[i])) found.Add(s[i]);
                else if (close.Contains(s[i]) && found.Last() == pairs.First(x => x.Value == s[i]).Key)
                {
                    found.RemoveAt(found.Count - 1);
                }
                else return false;
            }
            return true;
        }
    }

    [TestFixture][Ignore("not current test")]
    public class KataTests
    {
        [Test]
        public void ParensOnly()
        {
            Assert.AreEqual(true, AllThatIsOpenMustBeClosed.IsBalanced("(Sensei says yes!)", "()"));
        }

        [Test]
        public void test1()
        {
            Assert.AreEqual(false, AllThatIsOpenMustBeClosed.IsBalanced("(Sensei says no!", "()"));
        }

        [Test]
        public void test2()
        {

            Assert.AreEqual(true, AllThatIsOpenMustBeClosed.IsBalanced("(Sensei [says] yes!)", "()[]"));
        }

        [Test]
        public void test3()
        {
            Assert.AreEqual(false, AllThatIsOpenMustBeClosed.IsBalanced("(Sensei [says) no!]", "()[]"));
        }

        [Test]
        public void test4()
        {
            Assert.AreEqual(true, AllThatIsOpenMustBeClosed.IsBalanced("Sensei says -yes-!", "--"));
        }

        [Test]
        public void test5()
        {
            Assert.AreEqual(false, AllThatIsOpenMustBeClosed.IsBalanced("Sensei -says no!", "--"));
        }

        [Test]
        public void testNotMatchingButEven()
        {
            Assert.AreEqual(false, AllThatIsOpenMustBeClosed.IsBalanced("Sensei [{says no!]}", "[]{}"));
        }
    }

}

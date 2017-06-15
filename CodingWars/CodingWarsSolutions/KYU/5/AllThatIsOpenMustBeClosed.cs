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
            s = Regex.Replace(s, $"[^{string.Join("\\", caps)}]", "");
            if (s.Length % 2 != 0)
                return false;

            string chain = s[0].ToString();
            char[] chars = s.ToCharArray();
            
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
            }
            return true;
        }
    }

    [TestFixture]
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
    }

}

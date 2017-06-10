using NUnit.Framework;

namespace CodingWarsSolutions
{
    namespace CodingWarsSolutions
    {
        public class BouncingBall
        {
            public static int bouncingBall(double h, double bounce, double window)
            {
                if (h <= 0 || bounce >= 1 || bounce < 0 || window >= h)
                    return -1;

                int bouncesSeen = 0;
                while (h > window)
                {
                    h *= bounce;
                    bouncesSeen++;
                }

                return bouncesSeen + bouncesSeen - 1; ;
            }
        }


        [TestFixture]
        [Ignore("not current test")]
        public class BouncingBallTests
        {

            [Test]
            public void Test1()
            {
                Assert.AreEqual(3, BouncingBall.bouncingBall(3.0, 0.66, 1.5));
            }
            [Test]
            public void Test2()
            {
                Assert.AreEqual(15, BouncingBall.bouncingBall(30.0, 0.66, 1.5));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace net47.Methods
{
    public class Util
    {
        public static Stopwatch TimeExec(Action func, int times = 1_000)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++) func();
            sw.Stop();
            return sw;
        }

        public static string PadText(string input, string padding)
        {
            string middle = $"{padding} {input} {padding}";
            string row = string.Concat(Enumerable.Repeat(padding, middle.Length / padding.Length));
            return $"{row}\n{middle}\n{row}";
        }

        static Random r = new Random();
        public static IEnumerable<T> RandomItems<T>(IEnumerable<T> src, int count)
        {
            int srcCount = src.Count();
            T[] arr = src.ToArray();

            for (int i = 0; i < count; i++)
            {
                yield return arr[r.Next(srcCount)];
            }
        }

        public static BigInteger MatrixFib(int n)
        {
            BigInteger x = 1, y = 1;
            BigInteger[] mat = { 1, 1, 1, 0 };
            n--;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    (x, y) = (x * mat[0] + y * mat[1], x * mat[2] + y * mat[3]);
                }
                n >>= 1;
                (mat[0], mat[1], mat[2], mat[3]) = (mat[0] * mat[0] + mat[1] * mat[2], mat[0] * mat[1] + mat[1] * mat[3], mat[0] * mat[2] + mat[2] * mat[3], mat[1] * mat[2] + mat[3] * mat[3]);
            }
            return x;
        }
        
        public static IEnumerable<string> TranslateToPigLatin(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length == 0) continue;
                string firstpart = string.Concat(s[i].TakeWhile(x => !"aeiuo".Contains(x)));
                s[i] = (firstpart.Length > 0 ? s[i].Replace(firstpart, "") : "") + firstpart + "ay";
                yield return s[i];
            }
        }
    }
}

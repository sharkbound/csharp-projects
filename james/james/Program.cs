using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace james
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageEverySecond_HighCPU(15);
            MessageEverySecond_LowCPU(15);
        }

        static void MessageEverySecond_HighCPU(int times)
        {
            var aMomentAgo = DateTime.Now;
            long loops = 0;
            while ((DateTime.Now - aMomentAgo).TotalMilliseconds < 1000)
            {
                loops++;
            }
            Console.WriteLine("Message from MessageEverySecond_HighCPU: #{0} - {1:0,0} loops", times, loops);
            if (times > 0)
            {
                MessageEverySecond_HighCPU(times - 1);
            }
        }

        static void MessageEverySecond_LowCPU(int times)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Message from MessageEverySecond_LowCPU: #{0}", times);
            if (times > 0)
            {
                MessageEverySecond_LowCPU(times - 1);
            }
        }
    }
}

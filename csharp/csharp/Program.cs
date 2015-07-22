using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new square(13.1);
            Console.WriteLine(square.Area);
            Console.ReadLine();
        }
    }
}

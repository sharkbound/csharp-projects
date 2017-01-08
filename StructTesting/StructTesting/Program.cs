using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var pos1 = new Position(100, 100);
        }
        
        // struct is a value type variable and always contains a value,
        // also cant initialize variables

        // class is a reference type variable
        struct Position
        {
            public int x;
            public int y;

            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}

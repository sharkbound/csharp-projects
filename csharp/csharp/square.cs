using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    class square : shape 
    {
        public double length { private set; get; }
        public square(double SideLength)
        {
            length = SideLength;
        }

        public override double Area
        {
            get { return length * length; }
        }
    }
}

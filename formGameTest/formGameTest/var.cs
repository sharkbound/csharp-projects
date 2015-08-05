using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace formGameTest
{
   public class var
    {
       public SolidBrush mybrush1 = new SolidBrush(Color.Aqua);
       public Rectangle makeRectangle(int locX, int locY, int width, int height)
       {
           return new Rectangle(locX, locY, width, height);
       }
       public SolidBrush returnBrush(Color color)
       {
           return new SolidBrush(color);
       }
    }
}

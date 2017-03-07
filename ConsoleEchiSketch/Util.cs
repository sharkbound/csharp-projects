using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTupleTest
{
    public class Util
    {
        Random random = new Random();

        public int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        public int RandomInt(int max, bool includeZero = false)
        {
            int randomResult = random.Next(max);
            return randomResult == 0 && !includeZero ? 1 : randomResult;
        }

        public void PrintBottom(string msg)
        {
            Console.SetCursorPosition(0, Console.WindowHeight);
            ClearCurrentConsoleLine();
            Console.Write(msg);
        }

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(" ");
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}

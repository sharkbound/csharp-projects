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
            Console.WriteLine("String\t\t\tH(1)\tH(2)\tH(3)\tApEn(1)\tApEn(2)\tApEn(3)");
            Console.WriteLine("enter sub1=\"put stuff here\" then enter sub2=\"stuff here\"");
            string foo = Console.ReadLine();
            #region sub1=""
            int section1number = foo.IndexOf("sub1=");
            section1number = section1number + 5;
            Console.WriteLine(section1number);
            string section1text = foo.Substring(section1number,4);
            Console.WriteLine(section1text);
            #endregion
            #region sub2=""
            int section2number = foo.IndexOf("sub2=");
            section2number = section2number + 5;
            Console.WriteLine(section2number);
            string section2text = foo.Substring(section2number, 4);
            Console.WriteLine(section2text);
            #endregion
            if (section1text == "test" && section2text == "text")
            {
                Console.WriteLine("u did well :D");
            }
            string replace1 = foo.Replace("sub1=", string.Empty);
            replace1 = replace1.Replace("sub2=", string.Empty);
            Console.WriteLine(replace1);

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace dotnet47
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        Random r = new Random();
        char[] _AsciiLetters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();

        (string name, int age) getPerson()
        {
            string retName = "";
            for (int i = 0; i < 20; i++)
            {
                retName += _AsciiLetters[r.Next(0, _AsciiLetters.Length)];
            }

            return (retName, r.Next(0, 100));
        }

        private void Start()
        {

            var info = getPerson();
            Console.WriteLine($"{info.name} : {info.age}");

            foreach (char c in _AsciiLetters)
            {
                Console.Write(c);
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace text_writer
{
    class shortcutstuff
    {
        public string writeToFile(string input)
        {
            StreamWriter writeText = new StreamWriter("output.txt");
            writeText.WriteLine("this is the text before its reversed:");
            writeText.WriteLine(input);
            char[] reverse = input.ToCharArray();
            Array.Reverse(reverse);
            writeText.WriteLine("");
            writeText.WriteLine("this is the text reversed:");
            writeText.WriteLine(reverse); 
            writeText.Close();
            //Console.WriteLine(reverse);
            string outp = reverse.ToString();
           //Console.WriteLine(outp);
            return outp;
        }
    }
}

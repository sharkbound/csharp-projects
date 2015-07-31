using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class Magic8Ball
    {
       private static readonly Random r = new Random();
       public int YesCount { get; set; }
       public int NoCount { get; set; }
       public int MaybeCount { get; set; }
       public string stringAnwser { get; set; }
       public string question { get; set; }
       public ConsoleKeyInfo key { get; set; }
       public bool loop { get; set; }
       public bool list { get; set; }
       public bool menuask {get; set;}

       public void shake()
       {
           Console.ForegroundColor = ConsoleColor.Red;
           Console.WriteLine("Calculating the awnser to \"{0}\"", question);
           Console.ForegroundColor = ConsoleColor.White;
           var randomAnswer = GetRandomAnswer();
           switch (randomAnswer)
           {
               case anwser.yes:
                   YesCount++;
                   stringAnwser = "YES";
                   break;
               case anwser.no:
                   NoCount++;
                   stringAnwser = "NO";
                   break;
               case anwser.maybe:
                   MaybeCount++;
                   stringAnwser = "MAYBE";
                   break;

           }
       }

       private anwser GetRandomAnswer()
       {
           return (anwser)r.Next(1, 4);
       }
    }
}

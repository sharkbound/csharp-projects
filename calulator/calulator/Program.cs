using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int anwser = 0;
            int loop = 1;
           while (loop == 1)
            {
            loop = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("welcome to my homemade calculator!");
            Console.WriteLine("enter the first number in the equation...");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the operator...");
            string oper = Convert.ToString(Console.ReadLine());
            Console.WriteLine("enter the seconds number in the equation...");
            int num2 = Convert.ToInt32(Console.ReadLine());
            switch (oper)
            {
             case "+":
                     anwser = num1 + num2;
                     Console.WriteLine("your anwser to {0} {1} {2} is\n anwser: {3}", num1, oper, num2, anwser);
                     break;
             case "-":
                    anwser = num1 - num2;
                    Console.WriteLine("your anwser to {0} {1} {2} is\n anwser: {3}", num1, oper, num2, anwser);
                    break;
             case "*":
                    anwser = num1 * num2;
                    Console.WriteLine("your anwser to {0} {1} {2} is\n anwser: {3}", num1, oper, num2, anwser);
                    break;
             case "/":
                    anwser = num1 / num2;
                    Console.WriteLine("your anwser to {0} {1} {2} is\n anwser: {3}", num1,oper,num2,anwser);
                    break;
                default:
                    Console.WriteLine("{0} is a invalid operator, do u want to return to the start? [y/n] ", oper );
                    string userreply = Convert.ToString(Console.ReadLine());
                    if (userreply == "y")
                    {
                     loop = 1;
                      break;
                    }
                    else if (userreply == "n")
                    {
                      loop = 0;
                      goto exit;
                    }
                    break;
             }
            Console.WriteLine("do u want to exit the app? [y/n]");
            string exitconfirm = Console.ReadLine();
            if (exitconfirm == "y")
            {
                loop = 0;
            }
            else if (exitconfirm == "n")
            {
                loop = 1;
            }
        exit:
            Console.WriteLine("");
          }
        }
    }
}

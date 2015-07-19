using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigTest.Properties;

namespace ConfigTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Settings.Default.email);
            Console.WriteLine(Settings.Default.username);
            Console.WriteLine(Settings.Default.password);
            Console.ForegroundColor = ConsoleColor.White;
            string path;
            string email = "";
            string username = "";
            string password = "";
            ConsoleKeyInfo key;
            begin:
            Console.WriteLine("do you want to register or login?\n\n1:\t-\tRegister\n2:\t-\tLogin using existing account");
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    #region login
                    clear();
                    Console.WriteLine("enter your username then press enter...");
                    username = Console.ReadLine();
                    clear();
                    Console.WriteLine("enter your password then press enter...");
                    password = Console.ReadLine();
                    if (password == Settings.Default.password && username == Settings.Default.username)
                    {
                        clear();
                    loggedin:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("u have logged in as:  {0}", Settings.Default.username);
                        Console.ForegroundColor = ConsoleColor.White;
                        if (Settings.Default.email == "d")
                        {
                            Console.WriteLine("enter your email then press enter");
                            string temp = Console.ReadLine();
                            Settings.Default.email = temp;
                            Console.WriteLine("email for {0} was set to {1}", Settings.Default.username, Settings.Default.email);
                            Settings.Default.Save();
                        }
                        Console.WriteLine("\n\nwhat do you want to do?");
                        Console.WriteLine("1:\tchange password\n2:\tchange username");
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.D1)
                        {
                            Console.WriteLine("enter your email to confirm you are you");
                            string email2 = Console.ReadLine();
                            if (email2 == Settings.Default.email)
                            {
                                Console.WriteLine("enter the new password");
                                string newpass = Console.ReadLine();
                                Settings.Default.password = newpass;
                                Settings.Default.Save();
                                goto loggedin;
                            }
                            else
                            {
                                Console.WriteLine("{0} is incorrect!");
                                goto loggedin;
                            }
                        }
                        else if (key.Key == ConsoleKey.D2)
                        {
                            Console.WriteLine("enter your email to confirm you are you");
                            string email3 = Console.ReadLine();
                            if (email3 == Settings.Default.email)
                            {
                                Console.WriteLine("enter the new username");
                                string newusername = Console.ReadLine();
                                Settings.Default.username = newusername;
                                Settings.Default.Save();
                                goto loggedin;
                            }
                        }
                        else
                        {
                            clear();
                            Console.WriteLine("{0} is a invalid selection!", key.Key);
                            goto loggedin;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        clear();
                        Console.WriteLine("username \"{0}\" and password \"{1}\" do not match any accounts", username, password);
                        Console.ForegroundColor = ConsoleColor.White;
                        goto begin;
                    }
                    break;
                    #endregion
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    clear();
                    Console.WriteLine("{0} is not a valid option!", key.Key);
                    Console.ForegroundColor = ConsoleColor.White;
                    goto begin;

            }
            Console.ReadKey();
        }
        static void clear()
        {
            Console.Clear();
        }
    }
}

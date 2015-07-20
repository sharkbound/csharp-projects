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
            list();
            string username = "";
            string password = "";
            ConsoleKeyInfo key;
            begin:
            Console.WriteLine("do you want to register or login?\n\n1:\t-\tRegister\n2:\t-\tLogin using existing account");
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    #region register
                    clear();
                    Console.WriteLine("enter the username for the new user...");
                    Settings.Default.username2 = Console.ReadLine();
                    clear();
                    Console.WriteLine("enter the password for the new user...");
                    Settings.Default.password2 = Console.ReadLine();
                    clear();
                    Console.WriteLine("enter the email for the new user...");
                    Settings.Default.email2 = Console.ReadLine();
                    clear();
                    Settings.Default.Save();
                    goto begin;
                    #endregion
                case ConsoleKey.D2:
                    #region login
                    Console.WriteLine("login user first account or second account?");
                    Console.WriteLine("\n\n1:\t-   login using first account\n2:\t-   login user registered account (second account)");
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.D1)
                    {
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
                            Console.WriteLine("you are logged in as:  {0}", Settings.Default.username);
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
                                else
                                {
                                    Console.WriteLine("the email - {0} - was incorrect", email3);
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
                    }
                    #endregion
                    #region user2 login
                    else // second users login
                    {
                        clear();
                        Console.WriteLine("enter your username then press enter...");
                        username = Console.ReadLine();
                        clear();
                        Console.WriteLine("enter your password then press enter...");
                        password = Console.ReadLine();
                        if (password == Settings.Default.password2 && username == Settings.Default.username2)
                        {
                            clear();
                        loggedin:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("you are logged in as:  {0}", Settings.Default.username2);
                            Console.ForegroundColor = ConsoleColor.White;
                            if (Settings.Default.email2 == "d")
                            {
                                Console.WriteLine("enter your email then press enter");
                                string temp = Console.ReadLine();
                                Settings.Default.email2 = temp;
                                Console.WriteLine("email for {0} was set to {1}", Settings.Default.username2, Settings.Default.email2);
                                Settings.Default.Save();
                            }
                            Console.WriteLine("\n\nwhat do you want to do?");
                            Console.WriteLine("1:\tchange password\n2:\tchange username");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine("enter your email to confirm you are you");
                                string email2 = Console.ReadLine();
                                if (email2 == Settings.Default.email2)
                                {
                                    Console.WriteLine("enter the new password");
                                    string newpass = Console.ReadLine();
                                    Settings.Default.password2 = newpass;
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
                                if (email3 == Settings.Default.email2)
                                {
                                    Console.WriteLine("enter the new username");
                                    string newusername = Console.ReadLine();
                                    Settings.Default.username2 = newusername;
                                    Settings.Default.Save();
                                    goto loggedin;
                                }
                                else
                                {
                                    Console.WriteLine("the email - {0} - was incorrect", email3);
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
                    }
                    #endregion
                default:
                    #region invalid selection
                    Console.ForegroundColor = ConsoleColor.Red;
                    clear();
                    Console.WriteLine("{0} is not a valid option!", key.Key);
                    Console.ForegroundColor = ConsoleColor.White;
                    goto begin;
                    #endregion
            }
        }
        #region methods
        static void clear()
        {
            Console.Clear();
        }
        static void list()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************************************************");
            Console.WriteLine("first user email - " + Settings.Default.email);
            Console.WriteLine("first user username - " + Settings.Default.username);
            Console.WriteLine("first user password - " + Settings.Default.password);
            Console.WriteLine("*****************************************************");
            Console.WriteLine("second user email - " + Settings.Default.email2);
            Console.WriteLine("second user username - " + Settings.Default.username2);
            Console.WriteLine("second user password - " + Settings.Default.password2);
            Console.WriteLine("******************************************************");
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}

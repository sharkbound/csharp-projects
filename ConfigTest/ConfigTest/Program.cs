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
            var loginmenu = new Action(LoggedIn);
            ConsoleKeyInfo key;
        begin:
            loginmenu();
            key = RegisterOrLogin();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    #region register
                    Register();
                    goto begin;
                    #endregion
                case ConsoleKey.D2:
                    #region login
                    key = FirstLogin();
                    if (key.Key == ConsoleKey.D1)
                    {
                        Login(ref username, ref password);
                        if (password == Settings.Default.password && username == Settings.Default.username)
                        {
                            clear();
                        loggedin:
                            LoggedIn();
                            if (Settings.Default.email == "d")
                            {
                                ChangeEmail();
                            }
                            key = LoggedInMenu(key);
                            if (key.Key == ConsoleKey.D1)
                            {
                                string email2 = EmailVerify();
                                if (email2 == Settings.Default.email)
                                {
                                    ChangeUserOnePassword();
                                    //loginmenu();
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
                                string email3 = UserOneEmailConfirm();
                                if (email3 == Settings.Default.email)
                                {
                                    ChangeUsername();
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
                            BadLogin(username, password);
                            goto begin;
                        }
                    }
                    #endregion
                    #region user2 login
                    else // second users login
                    {
                        clear();
                        UserTwoLogin(ref username, ref password);
                        if (password == Settings.Default.password2 && username == Settings.Default.username2)
                        {
                            clear();
                        loggedin:
                            UserTwoLoginDialog();
                            if (Settings.Default.email2 == "d")
                            {
                                ChangeUserTwoDefaultEmail();
                            }
                            key = UserTwoLoginMenu();
                            if (key.Key == ConsoleKey.D1)
                            {
                                string email2 = UserTwoEmailConfirm();
                                if (email2 == Settings.Default.email2)
                                {
                                    ChangeUserTwoPassword();
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
                                //Console.WriteLine("enter your email to confirm you are you");
                                //string email3 = Console.ReadLine();
                                string email3 = UserTwoEmailConfirm();
                                if (email3 == Settings.Default.email2)
                                {
                                    UserTwoChangeUsername();
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
                            UserTwoBadLogin(username, password);
                            goto begin;
                        }
                    }
                    #endregion
                default:
                    #region invalid selection
                    key = InvalidFirstMenuSelection(key);
                    goto begin;
                    #endregion
            }
        }

        private static void UserTwoBadLogin(string username, string password)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            clear();
            Console.WriteLine("username \"{0}\" and password \"{1}\" do not match any accounts", username, password);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void UserTwoChangeUsername()
        {
            Console.WriteLine("enter the new username");
            string newusername = Console.ReadLine();
            Settings.Default.username2 = newusername;
            Settings.Default.Save();
        }

        private static void ChangeUserTwoPassword()
        {
            Console.WriteLine("enter the new password");
            string newpass = Console.ReadLine();
            Settings.Default.password2 = newpass;
            Settings.Default.Save();
        }

        private static string UserTwoEmailConfirm()
        {
            Console.WriteLine("enter your email to confirm you are you");
            string email2 = Console.ReadLine();
            return email2;
        }

        private static ConsoleKeyInfo UserTwoLoginMenu()
        {
            ConsoleKeyInfo key;
            Console.WriteLine("\n\nwhat do you want to do?");
            Console.WriteLine("1:\tchange password\n2:\tchange username");
            key = Console.ReadKey();
            return key;
        }

        private static void ChangeUserTwoDefaultEmail()
        {
            Console.WriteLine("enter your email then press enter");
            string temp = Console.ReadLine();
            Settings.Default.email2 = temp;
            Console.WriteLine("email for {0} was set to {1}", Settings.Default.username2, Settings.Default.email2);
            Settings.Default.Save();
        }

        private static void UserTwoLoginDialog()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("you are logged in as:  {0}", Settings.Default.username2);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void UserTwoLogin(ref string username, ref string password)
        {
            Console.WriteLine("enter your username then press enter...");
            username = Console.ReadLine();
            clear();
            Console.WriteLine("enter your password then press enter...");
            password = Console.ReadLine();
        }

        private static ConsoleKeyInfo FirstLogin()
        {
            ConsoleKeyInfo key;
            Console.WriteLine("login user first account or second account?");
            Console.WriteLine("\n\n1:\t-   login using first account\n2:\t-   login user registered account (second account)");
            key = Console.ReadKey();
            return key;
        }

        private static ConsoleKeyInfo InvalidFirstMenuSelection(ConsoleKeyInfo key)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            clear();
            Console.WriteLine("{0} is not a valid option!", key.Key);
            Console.ForegroundColor = ConsoleColor.White;
            return key;
        }

        private static void ChangeUserOnePassword()
        {
            Console.WriteLine("enter the new password");
            string newpass = Console.ReadLine();
            Settings.Default.password = newpass;
            Settings.Default.Save();
        }

        private static string UserOneEmailConfirm()
        {
            Console.WriteLine("enter your email to confirm you are you");
            string email3 = Console.ReadLine();
            return email3;
        }

        private static void ChangeUsername()
        {
            Console.WriteLine("enter the new username");
            string newusername = Console.ReadLine();
            Settings.Default.username = newusername;
            Settings.Default.Save();
        }

        private static void BadLogin(string username, string password)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            clear();
            Console.WriteLine("username \"{0}\" and password \"{1}\" do not match any accounts", username, password);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Login(ref string username, ref string password)
        {
            clear();
            Console.WriteLine("enter your username then press enter...");
            username = Console.ReadLine();
            clear();
            Console.WriteLine("enter your password then press enter...");
            password = Console.ReadLine();
        }

        private static string EmailVerify()
        {
            Console.WriteLine("enter your email to confirm you are you");
            string email2 = Console.ReadLine();
            return email2;
        }

        private static ConsoleKeyInfo LoggedInMenu(ConsoleKeyInfo key)
        {
            Console.WriteLine("\n\nwhat do you want to do?");
            Console.WriteLine("1:\tchange password\n2:\tchange username");
            key = Console.ReadKey();
            return key;
        }

        private static void ChangeEmail()
        {
            Console.WriteLine("enter your email then press enter");
            string temp = Console.ReadLine();
            Settings.Default.email = temp;
            Console.WriteLine("email for {0} was set to {1}", Settings.Default.username, Settings.Default.email);
            Settings.Default.Save();
        }

        private static void LoggedIn()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("you are logged in as:  {0}", Settings.Default.username);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Register()
        {
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
        }

        private static ConsoleKeyInfo RegisterOrLogin()
        {
            ConsoleKeyInfo key;
            Console.WriteLine("do you want to register or login?\n\n1:\t-\tRegister\n2:\t-\tLogin using existing account");
            key = Console.ReadKey();
            return key;
        }

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
    }
}

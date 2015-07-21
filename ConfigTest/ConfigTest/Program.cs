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
            // shows the menu options
            // shows the text menu for logging in
            key = RegisterOrLogin();
            // do something according to the value of key.Key
            switch (key.Key)
            {
                    // if the key 1 is pressed do this
                case ConsoleKey.D1:
                    #region register
                    // change the 2nd user's credentials to whats set here
                    Register();
                    // go back to the first menu
                    goto begin;
                    #endregion
                case ConsoleKey.D2:
                    // this is the login for the first user
                    #region user 1's login
                    // choose wether to login as first user or second user 
                    key = FirstLogin();
                    // do something for when the user presses a key
                    if (key.Key == ConsoleKey.D1)
                    {   // enter the login creduentials
                        Login(ref username, ref password);
                        //check that it matches the stored username and password
                        if (password == Settings.Default.password && username == Settings.Default.username)
                        {
                            //clear the screen
                            clear();

                        loggedin:
                            // display a welcome msg for the user with their username
                            LoggedIn();
                            //check if the user's email is default email change it to whats is entered
                            if (Settings.Default.email == "d")
                            {
                                ChangeEmail();
                            }
                            //display the menu after u login
                            key = LoggedInMenu(key);
                            // check if user presses "1" 
                            if (key.Key == ConsoleKey.D1)
                            {
                                // confirm the user is the correct user by
                                //having  the person enter the accounts email
                                string email2 = EmailVerify();
                                if (email2 == Settings.Default.email)
                                {
                                    // if the entered email is correct change the user's
                                    //password to whats entered
                                    ChangeUserOnePassword();
                                    //return to the user's menu
                                    goto loggedin;
                                }
                                    // if the entered email is wrong do this
                                else
                                {
                                    //display a message if the entered email is wrong
                                    Console.WriteLine("{0} is incorrect!");
                                    //return to the users email
                                    goto loggedin;
                                }

                            }
                                //check if the user presses 2
                            else if (key.Key == ConsoleKey.D2)
                            {
                                //see if the email they enter is the same as the stored email for
                                //user one
                                string email3 = UserOneEmailConfirm();
                                if (email3 == Settings.Default.email)
                                {
                                    //change the username to whats entered
                                    ChangeUsername();
                                    goto loggedin;
                                }
                                else
                                {
                                    //display a message if the entered email is wrong
                                    Console.WriteLine("the email - {0} - was incorrect", email3);
                                    goto loggedin;
                                }
                            }
                            //if user presses a invalid menu key do this
                            else
                            {
                                //clear the screen then display a msg then return to the user's menu
                                clear();
                                Console.WriteLine("{0} is a invalid selection!", key.Key);
                                goto loggedin;
                            }
                        }
                        //if the user enters wrong login info display a msg 
                        else
                        {
                            BadLogin(username, password);
                            goto begin;
                        }
                    }
                     // end of user 1's stuff
                    #endregion
                    #region user2 login
                    else // second users login
                    {
                        clear();
                        UserTwoLogin(ref username, ref password);  // menu to enter login crudntials
                        // check to see if the entered user and pass match stored ones
                        if (password == Settings.Default.password2 && username == Settings.Default.username2)
                        {
                            clear();
                        loggedin:
                            // greet the user when they login
                            UserTwoLoginDialog();
                            if (Settings.Default.email2 == "d") // if user 2's email is default change it
                            {
                                ChangeUserTwoDefaultEmail(); // change email to entered email
                            }
                            //menu to change password/username
                            key = UserTwoLoginMenu();
                            //if user presses 1 do this
                            if (key.Key == ConsoleKey.D1)
                            {
                                //validate the entered email
                                string email2 = UserTwoEmailConfirm();
                                if (email2 == Settings.Default.email2)
                                {
                                    //change password to whats entered
                                    ChangeUserTwoPassword();
                                    goto loggedin;
                                }
                                else
                                {
                                    // if the user enters wrong email display a message
                                    Console.WriteLine("{0} is incorrect!");
                                    goto loggedin;
                                }

                            }
                            else if (key.Key == ConsoleKey.D2)
                            {
                                //validate the entered email
                                string email3 = UserTwoEmailConfirm();
                                if (email3 == Settings.Default.email2)
                                {
                                    // change users's 2 username to whats entered
                                    UserTwoChangeUsername();
                                    goto loggedin;
                                }
                                else
                                {
                                    //display a msg saying they entered wrong email
                                    Console.WriteLine("the email - {0} - was incorrect", email3);
                                    goto loggedin;
                                }
                            }
                            else
                            {
                                // if user enters a invalid selection
                                clear();
                                Console.WriteLine("{0} is a invalid selection!", key.Key);
                                goto loggedin;
                            }
                        }
                        else
                        {
                            // if user enters wrong username/password
                            UserTwoBadLogin(username, password);
                            goto begin;
                        }
                    }
                    #endregion
                    // if user presses a key that does not have a menu selection do this
                default:
                    #region invalid selection
                    // display a msg saying what they pressed is invalid
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

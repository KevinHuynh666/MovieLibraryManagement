using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * This file is use to check input in the command line.
 * **/
namespace MovieManagement
{
    class CMD
    {
        /**
         * Check the number input when choosing in the menus. If the input is number from 0 to 5, it is correct.
         * Else it's wrong format and return the error message
         * **/
        public static int checkCommand()
        {
            int choices;
            do
            {
                // Getting the input from user in CMD
                string command = Console.ReadLine();
                // User's choice in main menu is always a 1-digit number, so the length must be 1. Else print the error message
                if (command.Length == 1)
                {
                    // If the command is within 0-5, return the number. Else print the error message
                    if ((command == "0") || (command == "1")
                        || (command == "2") || (command == "3") || (command == "4") || (command == "5"))
                    {
                        choices = Convert.ToInt32(command);
                        return choices;
                    }
                    else
                    {
                        // Print error message if the format entered is wrong
                        Console.WriteLine("Wrong format. Try again");
                    }
                }
                else
                {
                    // Print error message if the format entered is wrong
                    Console.WriteLine("Wrong format. Try again");
                }
            }
            while (true);
        }

        /**
         * Move to login screen and get username + password. 
         * **/
        public static bool loginMenu(int Case)
        {
            Console.Clear();
            // Declare variables used in the function.
            ConsoleKeyInfo key;
            string username = "";
            string password = "";
            string userPass = "";
            bool result = false;
            int breakCond = 0;

            Console.WriteLine("\nLogin screen; press the 'Esc' key to quit.");

            do
            {
                // Getting username from CMD.
                Console.Write("Username: ");
                do
                {
                    key = Console.ReadKey();
                    // If the key is "Esc", return to main menu.
                    if (key.Key == ConsoleKey.Escape)
                    {
                        // Set break condition to -1
                        breakCond = -1;
                        break;
                    }
                    // If the key is "Backspace", delete the previous character in CMD + in username holder.
                    else if (key.Key == ConsoleKey.Backspace)
                    {

                        if (username.Length > 0)
                        {
                            Console.Write(" \b");
                            username = username.Remove(username.Length - 1);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    // If the key is not "Enter", add the key to the username. 
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        username += key.KeyChar;
                    }
                    // Exit if Enter key is pressed.
                } while (key.Key != ConsoleKey.Enter);

                // Exit the login screen and return to main menu if break condition is -1.
                if (breakCond == -1) { return false; }
                Console.WriteLine();


                // Getting password
                Console.Write("Enter password: ");
                do
                {
                    key = Console.ReadKey(true);
                    // If the key is "Esc", return to main menu.
                    if (key.Key == ConsoleKey.Escape)
                    {
                        breakCond = -1;
                        break;
                    }
                    // If the key is "Backspace", delete the previous character in CMD + in password holder.
                    else if (key.Key == ConsoleKey.Backspace)
                    {

                        if (password.Length > 0)
                        {
                            Console.Write("\b \b");
                            password = password.Remove(password.Length - 1);
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }
                    // If the key is not "Enter", add the key to the password.
                    else if (key.Key != ConsoleKey.Enter)
                    {
                        Console.Write("*");
                        password += key.KeyChar;
                    }
                    // Exit if Enter key is pressed.
                } while (key.Key != ConsoleKey.Enter);

                // If breakCond is still 0, change it to 1 to dedicate that getting the user input is complete and exit the loop.
                if (breakCond == 0)
                { breakCond = 1; }

            } while (breakCond == 0);
            Console.WriteLine();

            // If break condition is -1 (press "Esc") then exit.
            if (breakCond == -1)
            {
                return false;
            }

            else
            {
                // The variable Case is used to check which login screen is this.
                //Case =1 when it's a staff login, case =2 when it's a user login.

                if (Case == 1)
                {
                    //Validate User and Validate pass is username + password for staff account.
                    if (username == StaffMenu.validateUser && password == StaffMenu.validatePass)
                    {
                        // Print out a message that the user login successfully to staff account.
                        Console.Clear();
                        Console.WriteLine("Success, directed to staff menu");
                        result = true;

                    }
                    else
                    {
                        // Print out error message either the username or password doesn't matched
                        Console.WriteLine("Incorrect username or password");
                        result = false;

                    }
                }
                else if (Case == 2)
                {
                    // Getting the password provided the username from the MemberCollection.
                    userPass = Program.Members.getPassword(username);
                    if (password == userPass)
                    {
                        // Print out a message that the user login successfully to member account.
                        Console.Clear();
                        Console.WriteLine("Success, directed to member menu");
                        Program.currentUser = username;
                        result = true;
                    }
                    else
                    {
                        // Print out error message either the username or password doesn't matched
                        Console.WriteLine("Incorrect username or password");
                        result = false;
                    }
                }
            }
            Console.ReadLine();
            return result;
        }
    }
}

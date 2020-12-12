using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This file is the code for Main Menu
 **/
namespace MovieManagement
{
    class Program
    {
        // Variable to keep track which screen the user is in.
        public static int currentScreen = 0;
        // Declare the variables for MovieCollection + MemberCollection.
        public static MemberCollection Members = new MemberCollection();
        public static MovieCollection Movies = new MovieCollection();
        // Variable to keep track of the current username.
        public static string currentUser;

        // Function the print the main menu.
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Community library");
            Console.WriteLine("===========Main Menu============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member");
            Console.WriteLine("0. Exit");
            Console.WriteLine("================================");
            Console.WriteLine();
            Console.Write("Please make a selection (1-2, or 0 to exit): ");

        }

        // The main function
        static void Main(string[] args)
        {
            int choices;
            // Status of the program. True for program still running, false for stopping the program.
            bool running = true;
            //Status of login screen. False for not logged in, true for logged in.
            bool check;

            // While loop to keep the program running
            while (running)
            {
                // Check currentScreen to print the correct menu.
                // 0 for main menu, 1 for staff menu and 2 for member menu
                if (currentScreen == 0)
                {
                    PrintMenu();
                    choices = CMD.checkCommand();
                    switch (choices)
                    {
                        // Exit the program
                        case 0:
                            Console.WriteLine("Thanks for using the app");
                            running = false;
                            break;
                        // Switch to staff's login menu.
                        case 1:
                            check = CMD.loginMenu(1);
                            // Check if the login is successful or not.
                            if (check)
                            {
                                currentScreen = 1;
                            }
                            else
                            {
                                continue;
                            }
                            break;
                        case 2:
                            check = CMD.loginMenu(2);
                            // Check if the login is successful or not.
                            if (check)
                            {
                                currentScreen = 2;
                            }
                            else
                            {
                                continue;
                            }
                            break;
                    }
                }
                else if (currentScreen == 1)
                {
                    // Print staff menu
                    StaffMenu.Menu();
                }
                else if (currentScreen == 2)
                {
                     // Print member menu
                    MemberMenu.Menu();
                }
            }
            Console.ReadLine();
        }
    }
}

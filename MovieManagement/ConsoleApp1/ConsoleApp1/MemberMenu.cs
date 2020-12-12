using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This file is the code for printing the Member Menu and the command for each choice.
 * **/
namespace MovieManagement
{
    public static class MemberMenu
    {
        // Print out member menu
        static void PrintMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Member Menu============");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Borrow a movie DVD");
            Console.WriteLine("3. Return a movie DVD");
            Console.WriteLine("4. List current borrowed movie DVDs");
            Console.WriteLine("5. Display top 10 most popular movies");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("================================");
            Console.Write("Please make a selection (1-5, or 0 to return to main menu): ");
        }

        // List the current borrowed movies
        static void listBorrowed()
        {
            Program.Members.listBorrowed();
        }

        // Display all movies
        static void displayAll()
        {
            Program.Movies.allInfo();
        }

        // Borrow a  movie
        static void borrowMovie()
        {
            Console.Clear();
            Console.WriteLine("===========Borrow a Movie============");
            Console.Write("Title of the movie you want to borrow: ");
            string title = Console.ReadLine();
            Program.Members.borrowMovie(title);
        }

        // Return a movie
        static void returnMovie()
        {
            Console.Clear();
            Console.WriteLine("===========Return a Movie============");
            Console.Write("Title of the movie you want to return: ");
            string title = Console.ReadLine();
            Program.Members.returnMovie(title);
        }

        // Get the top 10 most borrowed movies
        static void listTop10()
        {
            Program.Movies.top10();
        }

        // Print the menu and check for user's choice
        public static void Menu()
        {
            PrintMemberMenu();
            int choices = CMD.checkCommand();

            switch (choices)
            {
                case 0:
                    Program.currentScreen = 0;
                    Program.currentUser = "";
                    Console.WriteLine("Returning to main menu");
                    break;
                case 1:
                    displayAll();
                    break;
                case 2:
                    borrowMovie();
                    break;
                case 3:
                    returnMovie();
                    break;
                case 4:
                    listBorrowed();
                    break;
                case 5:
                    listTop10();
                    break;
            }
            Console.ReadLine();
        }
    }
}

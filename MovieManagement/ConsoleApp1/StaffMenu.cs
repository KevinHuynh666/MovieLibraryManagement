using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This file is the code for the Staff Menu.
 * **/
namespace MovieManagement
{
    public static class StaffMenu
    {
        // Variables to hold the username + password for staff user.
        public static string validateUser = "staff";
        public static string validatePass = "today123";

        // Print the staff menu.
        public static void PrintStaffMenu()
        {
            Console.Clear();
            Console.WriteLine("===========Staff Menu============");
            Console.WriteLine("1. Add a new movie DVD");
            Console.WriteLine("2. Remove a movie DVD");
            Console.WriteLine("3. Register a new member");
            Console.WriteLine("4. Find a registered member's phone number");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("================================");
            Console.Write("Please make a selection (1-4, or 0 to return to main menu): ");
        }

        // Function to register a new member.
        static void registerMember()
        {
            Program.Members.registerMember();
        }

        // Function to find a registered member's phone number.
        static void findNumber()
        {
            string name = "";
            Console.Clear();
            Console.WriteLine("===========Find phone number============");
            Console.Write("Member's full name: ");
            name = Console.ReadLine();

            Program.Members.findPhoneNumber(name);
        }

        // Function to add a movie.
        static void addMovie()
        {
            // Declare a temporary movie to save the information.
            Movie temp = new Movie();
            Console.Clear();
            Console.WriteLine("===========Add a movie============");

            // Get the title
            Console.Write("Title: ");
            temp.title = Console.ReadLine();

            // Get the starring
            Console.Write("Starring: ");
            temp.starring = Console.ReadLine();

            // Get the director
            Console.Write("Director: ");
            temp.director = Console.ReadLine();

            // Get the duration, if the duration is not a number it will be 0.
            Console.Write("Duration: ");
            int duration = 0;
            Int32.TryParse(Console.ReadLine(), out duration);
            temp.duration = duration;

            // Get the genre for the movie, default is Other.
            Console.WriteLine("Genre (Choose according to the number): ");
            Console.WriteLine("\t1. Drama");
            Console.WriteLine("\t2. Adventure");
            Console.WriteLine("\t3. Family");
            Console.WriteLine("\t4. Action");
            Console.WriteLine("\t5. SciFi");
            Console.WriteLine("\t6. Comedy");
            Console.WriteLine("\t7. Animated");
            Console.WriteLine("\t8. Thriller");
            Console.WriteLine("\t0. Other");
            Console.Write("Your selection: ");
            int num = 0;
            Int32.TryParse(Console.ReadLine(), out num);
            temp.genre = (Genre)num;

            // Get the classification for the movie, default is General.
            Console.WriteLine("Classification (Choose according to the number): ");
            Console.WriteLine("\t1. Parental Guidance");
            Console.WriteLine("\t2. Mature");
            Console.WriteLine("\t3. Mature Accompanied");
            Console.WriteLine("\t0. General");
            Console.Write("Your selection: ");
            num = 0;
            Int32.TryParse(Console.ReadLine(), out num);
            temp.Class = (Classification)num;

            // Get the release date, if the input is not correct the date will be 01/01/0001.
            Console.Write("Release date (MM/DD/YYYY): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime inputtedDate);
            temp.releaseDate = inputtedDate;

            // Get the number of copies.
            temp.borrowTimes = 0;
            Console.Write("Number of copies in stock: ");
            int stocks = 0;
            Int32.TryParse(Console.ReadLine(), out stocks);
            temp.quantity = stocks;
            temp.currentCopies = stocks;

            // Insert the movie into library.
            Program.Movies.Insert(temp);

            Console.WriteLine("Movie successfully added.");
        }

        // Function remove a movie from the library.
        public static void removeMovie()
        {
            Console.Clear();
            Console.WriteLine("===========Remove a movie============");
            Console.Write("Title of the movie you want to delete:");
            string title = Console.ReadLine();
            Program.Movies.removeMovie(title);
            Console.WriteLine("Movie successfully removed from library.");
        }

        // Print the menu and check for user's choice
        public static void Menu()
        {
            PrintStaffMenu();
            int choices = CMD.checkCommand();

            switch (choices)
            {
                case 0:
                    Program.currentScreen = 0;
                    Console.WriteLine("Returning to main menu");
                    break;
                case 1:
                    addMovie();
                    break;
                case 2:
                    removeMovie();
                    break;
                case 3:
                    registerMember();
                    break;
                case 4:
                    findNumber();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
            Console.ReadLine();
        }

    }
}

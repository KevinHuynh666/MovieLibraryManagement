using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This file is the code for Member class.
 * **/
namespace MovieManagement
{
    class Member
    {
        // Declare all the variables for a Member object.
        public string fullName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public Movie[] borrowedMovie = new Movie[10];
        public string password { get; set; }
        public string username { get; set; }

        // Member object constructor.
        public Member() { }

        // Function to get username using full name
        public void getUsername()
        {
            username = fullName.Replace(" ", "");
        }

        // Function to get the list of borrowed movie of the current user. 
        public void listBorrowed()
        {
            Console.Clear();
            Console.WriteLine("=====Movies being borrowed by {0}=====", this.username);
            foreach (Movie i in borrowedMovie)
            {
                if (i != null)
                {
                    Console.WriteLine(i.title);
                }
            }
        }

        // Function to add  a movie to borrowedMovie.
        public void borrowMovie(string title)
        {
            int insertPosition = -1;
            // Check if the movie is borrowed or not.
            for (int i = 0; i < borrowedMovie.Length; i++)
            {
                // Make sure it's not null before comparing
                if (borrowedMovie[i] != null)
                {
                    // If the movie is already borrowed, print out error message and send the user back to menu.
                    if (borrowedMovie[i].title == title)
                    {
                        Console.WriteLine("You already borrowed the movie");
                        return;
                    }
                }
                else
                {
                    // If the position we are checking is null, the insert position will be this position.
                    if (insertPosition == -1) { insertPosition = i; }
                }
            }

            // Getting the movie object from MovieCollection.
            Movie temp = Program.Movies.find(title);

         
            if (temp == null)
            {
                Console.WriteLine("Movie not found in the library");
            }
            else
            {
                // User can only borrow if current copies of the movie is more than 0.
                if (temp.currentCopies > 0)
                {
                    // Increase the borrow times of the movie and decrease the number of copies in the libray.
                    Program.Movies.find(title).borrowTimes++;
                    Program.Movies.find(title).currentCopies--;
                    // Insert the movie into borrowedMovie of the user and print out success message.
                    borrowedMovie[insertPosition] = temp;
                    Console.WriteLine("Successfully borrowed");
                }
                else
                {
                    // Print out error message if it is out of stock right now.
                    Console.WriteLine("The current movie is out of stock.");
                }
            }
        }

        // Return a movie copy to the library.
        public void returnMovie(string title)
        {
            int deletePosition = -1;
            // Check if the movie we want to return is in the borrowedMovie of the user.
            for (int i = 0; i < borrowedMovie.Length; i++)
            {
                // Make sure it's not null before comparing.
                if (borrowedMovie[i] != null)
                {
                    // Get the position of the movie we want to return.
                    if (borrowedMovie[i].title == title)
                    {
                        deletePosition = i;
                        break;
                    }
                }
            }

            // If delete position is -1, that means it's not in the borrowedMovies.
            if (deletePosition == -1)
            {
                Console.WriteLine("Movie not found in the borrowed movies.");
            }
            else
            {
                // Find the the movie in the library
                Movie temp = Program.Movies.find(title);
                //  If the movie is in the library, increase the currentCopies of that movie, else just skip it.
                if (temp != null)
                {
                    Program.Movies.find(title).currentCopies++;
                }
              
                borrowedMovie[deletePosition] = null;
                Console.WriteLine("Successfully returned");
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * This is the code for Movie object
 * **/
namespace MovieManagement
{
    // Enum for classification
    enum Classification : int
    {
        G = 0,
        PG = 1,
        M15 = 2,
        MA15 = 3
    }
    // Enum for genre
    enum Genre : int
    {
        Drama = 1,
        Adventure = 2,
        Family = 3,
        Action = 4,
        SciFi = 5,
        Comedy = 6,
        Animated = 7,
        Thriller = 8,
        Other = 0
    }

    class Movie
    {

        // Declare movie object's variables
        public string title { get; set; }
        public string starring { get; set; }
        public string director { get; set; }
        public int duration { get; set; }
        public int borrowTimes { get; set; }
        public int quantity { get; set; }
        public int currentCopies { get; set; }
        public Classification Class { get; set; }
        public Genre genre { get; set; }
        public DateTime releaseDate { get; set; }

        // Constructor with full info
        public Movie(string title, string starring,
                 string director, int duration, DateTime releaseDate, int quantity, int borrow,
                 Genre genre, Classification Class)
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.releaseDate = releaseDate;
            this.quantity = quantity;
            this.borrowTimes = borrow;
            this.Class = Class;
            this.genre = genre;
            this.currentCopies = this.quantity;
        }
        // Constructor for empty movie
        public Movie() { }

        // Function to show all info of a movie
        public void showInfo()
        {
            Console.WriteLine("Title: " + this.title);
            Console.WriteLine("Starring: " + this.starring);
            Console.WriteLine("Director: " + this.director);
            Console.WriteLine("Duration: " + this.duration);
            Console.WriteLine("Genre: " + this.genre);
            Console.WriteLine("Classification: " + this.Class);
            Console.WriteLine("Release date: " + releaseDate.ToString("MM'/'dd'/'yyyy"));
            Console.WriteLine("Borrowed times: " + this.borrowTimes);
            Console.WriteLine("Number of copies in stock: " + this.currentCopies);
            Console.WriteLine("=======================");
        }

    }
}

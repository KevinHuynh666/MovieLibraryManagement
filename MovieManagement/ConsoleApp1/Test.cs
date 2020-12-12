using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RandomContent
    {
        private static readonly Random random = new Random();

        public static string String() => Guid.NewGuid().ToString();

        public static int Int() => random.Next(10000);

        public static T Enum<T>()
        {
            var values = System.Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }

        public static DateTime DateTime() => System.DateTime.Now.AddDays(random.Next(1000));
    }
    class Test
    {
        //(string title, string starring, 
        //    string director, int duration, DateTime releaseDate, int quantity, 
        //    Classification Class, Genre genre)
        Movie temp = new Movie(RandomContent.String,
            RandomContent.String,
            RandomContent.String,
            RandomContent.Int,
            RandomContent.DateTime,
            RandomContent.Int,
            RandomContent.Enum<Genre>(),
            RandomContent.Enum<Classification>());
    }
}

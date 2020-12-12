using MovieManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tester
    {
        public class RandomContent
        {
            private static readonly Random random = new Random();

            public static string String() => Guid.NewGuid().ToString();

            public static int Int() => random.Next(5000000);

            public static T Enum<T>()
            {
                var values = System.Enum.GetValues(typeof(T));
                return (T)values.GetValue(random.Next(values.Length));
            }

            public static DateTime DateTime() => System.DateTime.Now.AddDays(random.Next(1000));
        }


        //public static void Main(String[] args)
        //{
        //    MovieCollection movies = new MovieCollection();
        //    Stopwatch stopWatch = new Stopwatch();
        //    stopWatch.Start();
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        Movie temp = new Movie(RandomContent.String(),
        //        RandomContent.String(),
        //        RandomContent.String(),
        //        RandomContent.Int(),
        //        RandomContent.DateTime(),
        //        RandomContent.Int(),
        //        RandomContent.Int(),
        //        RandomContent.Enum<Genre>(),
        //        RandomContent.Enum<Classification>());
        //        movies.Insert(temp);
        //    }
        //    stopWatch.Stop();

        //    var elapsed = stopWatch.Elapsed;
        //    Console.WriteLine("Elapsed time to insert: {0}", elapsed.ToString("s'.'fff"));

        //    Console.WriteLine("SEPERATOR");

        //    stopWatch = Stopwatch.StartNew();
        //    movies.top10();
        //    stopWatch.Stop();

        //    elapsed = stopWatch.Elapsed;
        //    Console.WriteLine("Elapsed time to find top 10: {0}", elapsed.ToString("s'.'fff"));
        //    Console.ReadLine();

        //}
    }
}

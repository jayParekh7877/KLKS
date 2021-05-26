using System;
using System.Linq;

namespace EventsAndDelegates
{

    //Func<MovieRating, MovieRating, int>
    //public delegate int Compare(MovieRating m1, MovieRating m2);
    /*
     * public class ClassName
     * {
     *
     * }
     */
    class Program
    {

        //public static int CompareByMovieName(MovieRating m1, MovieRating m2)
        //{
        //    return string.CompareOrdinal(m1.Name, m2.Name);
        //}


        static void Main(string[] args)
        {
            MovieRating[] movieRatings = {
                new MovieRating { Name = "12 Angry Men", Rank = 5, Rating = 8.9, YearOfRelease = 1957 },
                new MovieRating { Name = "Pulp Fiction", Rank = 8, Rating = 8.9, YearOfRelease = 1994 },
                new MovieRating { Name = "The Dark Night", Rank = 4, Rating = 9.0, YearOfRelease = 2008 },
                new MovieRating { Name = "The God Father", Rank = 2, Rating = 9.2, YearOfRelease = 1972 },
                new MovieRating { Name = "Schindler's List", Rank = 6, Rating = 8.9, YearOfRelease = 1993 },
                new MovieRating { Name = "The Lord of the Rings: The Return of the King", Rank = 7, Rating = 8.9, YearOfRelease = 2003 },
                new MovieRating { Name = "The Shawshank Redemption", Rank = 1, Rating = 9.2, YearOfRelease = 1994 },
                new MovieRating { Name = "The Good, the Bad and the Ugly", Rank = 9, Rating = 8.8, YearOfRelease = 1966 },
                new MovieRating { Name = "The God Father : Part 2", Rank = 3, Rating = 9.0, YearOfRelease = 1974 },
                new MovieRating { Name = "Fight Club", Rank = 10, Rating = 8.8, YearOfRelease = 1999 }
            };

            Console.WriteLine("Please select the option");
            Console.WriteLine("1 - alphabetically sorted highlighting old movies");
            Console.WriteLine("2 - choronologically sorted highlighting movies with over 9 rating");
            Console.WriteLine("3 - sorted by rating highlighting movies with names longer than 30 characters");



            //Func<MovieRating, MovieRating, int> compareByNameDelegate  = CompareByMovieName;
            //Compare compareByNameDelegate = new Compare(CompareByMovieName);

            //Func<MovieRating, MovieRating, int> unnamedFunction 
            //    = (m1, m2) =>
            //    {
            //        return string.CompareOrdinal(m1.Name, m2.Name);
            //    };

            var loop = true;
            while (loop)
            {
                var option = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (option)
                {
                    case '1':
                        Console.WriteLine("Alphabetically sorted highlighting old ");
                        var movieRatingsSortedBasedOnName
                        = Sort(movieRatings, 
                                (m1, m2) => string.CompareOrdinal(m1.Name, m2.Name));

                        //= Sort(movieRatings, (m1, m2) =>
                        //{
                        //    return string.CompareOrdinal(m1.Name, m2.Name);
                        //});



                        DisplayHighlightingOldMovies(movieRatingsSortedBasedOnName);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case '2':
                        //Please implement this
                        break;
                    case '3':
                        //Please implement this
                        break;
                    default:
                        loop = false;
                        break;
                }
            }
        }

        public static void DisplayHighlightingOldMovies(MovieRating[] movieRatings)
        {
            foreach (var movieRating in movieRatings)
            {
                if(movieRating.YearOfRelease < 2000) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{movieRating.Name,-50}" + $"{movieRating.Rank,-4}" + $"{movieRating.Rating,-6}" + $"{movieRating.YearOfRelease,-6}");
                Console.ResetColor();
            }
        }


        public static MovieRating[] Sort(MovieRating[] movieRatings, 
            Func<MovieRating, MovieRating,int> compareDelegate)
        {
            movieRatings = movieRatings.ToArray();

            for (int i = 0; i < movieRatings.Length; i++)
            {
                for (int j = i; j < movieRatings.Length; j++)
                {
                    if (compareDelegate.Invoke(movieRatings[i], movieRatings[j]) > 0)
                    {
                        var temp = movieRatings[i];
                        movieRatings[i] = movieRatings[j];
                        movieRatings[j] = temp;
                    }
                }
            }
            return movieRatings;
        }
    }
}

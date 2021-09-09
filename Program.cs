using System;
using System.Collections.Generic;
using System.Linq;

namespace NinetiesTV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Show> shows = DataLoader.GetShows();

            Print("All Names", Names(shows));
            Print("Alphabetical Names", NamesAlphabetically(shows));
            Print("Ordered by Popularity", ShowsByPopularity(shows));
            Print("Shows with an '&'", ShowsWithAmpersand(shows));
            Print("Latest year a show aired", MostRecentYear(shows));
            Print("Average Rating", AverageRating(shows));
            Print("Shows only aired in the 90s", OnlyInNineties(shows));
            Print("Top Three Shows", TopThreeByRating(shows));
            Print("Shows starting with 'The'", TheShows(shows));
            Print("All But the Worst", AllButWorst(shows));
            Print("Shows with Few Episodes", FewEpisodes(shows));
            Print("Shows Sorted By Duration", ShowsByDuration(shows));
            Print("Comedies Sorted By Rating", ComediesByRating(shows));
            Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
            Print("Most Episodes", MostEpisodes(shows));
            Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
            Print("Best Drama", BestDrama(shows));
            Print("All But Best Drama", AllButBestDrama(shows));
            Print("Good Crime Shows", GoodCrimeShows(shows));
            Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
            Print("Most Words in Title", WordieastName(shows));
            Print("All Names", AllNamesWithCommas(shows));
            Print("All Names with And", AllNamesWithCommasPlsAnd(shows));
            Print("All 80s Generes", GenereIn80s(shows));
            Print("Unique Generes", UniqueGeneres(shows));
            // Print("Count Shows per year", CountTheShowsPerYear(shows));
            Print("Total Run Time", TotalShowRunTime(shows));
        }

        /**************************************************************************************************
         The Exercises

         Above each method listed below, you'll find a comment that describes what the method should do.
         Your task is to write the appropriate LINQ code to make each method return the correct result.

        **************************************************************************************************/

        // 1. Return a list of each of show names.
        static List<string> Names(List<Show> shows)
        {
            return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
        }

        // 2. Return a list of show names ordered alphabetically.
        static List<string> NamesAlphabetically(List<Show> shows)
        {
            List<Show> o = shows.OrderBy(s => s.Name).ToList();
            return o.Select(s => s.Name).ToList();
        }

        // 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
        static List<Show> ShowsByPopularity(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating).ToList();
        }

        // 4. Return a list of shows whose title contains an & character.
        static List<Show> ShowsWithAmpersand(List<Show> shows)
        {
            return shows.Where(s => s.Name.Contains("&")).ToList();

        }

        // 5. Return the most recent year that any of the shows aired.
        static int MostRecentYear(List<Show> shows)
        {
            List<Show> ordered = shows.OrderByDescending(s => s.EndYear).ToList();
            return ordered[0].EndYear;

        }

        // 6. Return the average IMDB rating for all the shows.
        static double AverageRating(List<Show> shows)
        {
            return shows.Average(s => s.ImdbRating);
        }

        // 7. Return the shows that started and ended in the 90s.
        static List<Show> OnlyInNineties(List<Show> shows)
        {
            return shows.Where(s => s.EndYear < 2000 && s.StartYear > 1989).ToList();
        }

        // 8. Return the top three highest rated shows.
        static List<Show> TopThreeByRating(List<Show> shows)
        {
            List<Show> ratings = shows.OrderByDescending(s => s.ImdbRating).ToList();
            return ratings.Take(3).ToList();
        }

        // 9. Return the shows whose name starts with the word "The".
        static List<Show> TheShows(List<Show> shows)
        {
            return shows.Where(s => s.Name.StartsWith("The")).ToList();
        }

        // 10. Return all shows except for the lowest rated show.
        static List<Show> AllButWorst(List<Show> shows)
        {
            List<Show> rate = shows.OrderBy(s => s.ImdbRating).ToList();
            return rate.Skip(1).ToList();
        }

        // 11. Return the names of the shows that had fewer than 100 episodes.
        static List<Show> FewEpisodes(List<Show> shows)
        {
            return shows.Where(s => s.EpisodeCount < 100).ToList();

        }

        // 12. Return all shows ordered by the number of years on air.
        //     Assume the number of years between the start and end years is the number of years the show was on.
        static List<Show> ShowsByDuration(List<Show> shows)
        {
            return shows.OrderBy(s => (s.EndYear - s.StartYear)).ToList();
        }

        // 13. Return the names of the comedy shows sorted by IMDB rating.
        static List<String> ComediesByRating(List<Show> shows)
        {
            List<Show> rate = shows.OrderByDescending(s => s.ImdbRating).ToList();
            List<Show> com = rate.Where(s => s.Genres.Contains("Comedy")).ToList();
            return com.Select(s => s.Name).ToList();

        }

        // 14. Return the shows with more than one genre ordered by their starting year.
        static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
        {
            List<Show> list = shows.Where(s => s.Genres.Count > 1).ToList();
            return list.OrderBy(s => s.StartYear).ToList();
            // return order.Take(3).ToList();
        }

        // 15. Return the show with the most episodes.
        static Show MostEpisodes(List<Show> shows)
        {
            int number = shows.Max(s => s.EpisodeCount);
            return shows.FirstOrDefault(s => s.EpisodeCount == number);

        }

        // 16. Order the shows by their ending year then return the first 
        //     show that ended on or after the year 2000.
        static Show EndedFirstAfterTheMillennium(List<Show> shows)
        {
            List<Show> filter = shows.Where(s => s.EndYear >= 2000).ToList();
            List<Show> order = filter.OrderBy(s => s.EndYear).ToList();
            return order.FirstOrDefault(s => s.EndYear >= 2000);
        }

        // 17. Order the shows by rating (highest first) 
        //     and return the first show with genre of drama.
        static Show BestDrama(List<Show> shows)
        {
            List<Show> rate = shows.OrderByDescending(s => s.ImdbRating).ToList();
            List<Show> filter = rate.Where(r => r.Genres.Contains("Drama")).ToList();
            return filter.FirstOrDefault();
        }

        // 18. Return all dramas except for the highest rated.
        static List<Show> AllButBestDrama(List<Show> shows)
        {
            List<Show> drama = shows.Where(s => s.Genres.Contains("Drama")).ToList();
            return drama.Skip(1).ToList();
        }

        // 19. Return the number of crime shows with an IMDB rating greater than 7.0.
        static int GoodCrimeShows(List<Show> shows)
        {
            List<Show> crime = shows.Where(s => s.Genres.Contains("Crime")).ToList();
            List<Show> rate = crime.Where(c => c.ImdbRating > 7.0).ToList();
            return rate.Count;
        }

        // 20. Return the first show that ran for more than 10 years 
        //     with an IMDB rating of less than 8.0 ordered alphabetically.
        static Show FirstLongRunningTopRated(List<Show> shows)
        {
            List<Show> list = shows.Where(s => (s.StartYear - s.EndYear) >= 10 || s.ImdbRating < 8.0).ToList();
            List<Show> order = list.OrderBy(s => s.Name).ToList();
            return order.FirstOrDefault();

        }

        // 21. Return the show with the most words in the name.
        static Show WordieastName(List<Show> shows)
        {
            List<Show> most = shows.OrderBy(s => s.Name).ToList();
            List<Show> l = most.OrderByDescending(s => s.Name.ToString().Length).ToList();
            return l.FirstOrDefault();
        }

        // 22. Return the names of all shows as a single string seperated by a comma and a space.
        static string AllNamesWithCommas(List<Show> shows)
        {
            List<string> s = shows.Select(s => s.Name).ToList();
            string answer = "";
            foreach (string n in s)
            {
                answer += $"{n}, ";
            }
            return answer;
        }

        // 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
        static string AllNamesWithCommasPlsAnd(List<Show> shows)
        {
            int len = shows.Count - 1;
            int len2 = shows.Count - 2;

            List<string> last2 = new List<string>(){
                 shows[len].Name, shows[len2].Name
             };

            List<Show> cut = shows.Take(len2).ToList();
            string answer = "";
            foreach (Show n in cut)
            {
                answer += $"{n.Name.ToString()}, ";
            }
            foreach (string n in last2)
            {
                answer += $"and {n}  ";
            }
            return answer;

        }


        /**************************************************************************************************
         CHALLENGES

         These challenges are very difficult and may require you to research LINQ methods that we haven't
         talked about. Such as:

            GroupBy()
            SelectMany()
            Count()

        **************************************************************************************************/

        // 1. Return the genres of the shows that started in the 80s.
        static List<string> GenereIn80s(List<Show> shows)
        {
            List<Show> eighties = shows.Where(s => s.StartYear > 1979 && s.StartYear < 1990).ToList();
            List<string> generes = new List<string>();
            foreach (Show s in eighties)
            {
                foreach (string g in s.Genres)
                {
                    generes.Add(g.ToString());
                }
            }
            List<string> order = generes.OrderBy(g => g).ToList();


            return order;
        }

        // 2. Print a unique list of geners.

        static List<string> UniqueGeneres(List<Show> shows)
        {
            List<string> Gen = GenereIn80s(shows).Distinct().ToList();
            return Gen;

        }

        // 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)

        // static dynamic CountTheShowsPerYear (List<Show> shows)
        // {
        //     var results = shows.GroupBy(
        //         s => s.StartYear,
        //         s => s.Name,
        //         (key, y ) => new {
        //             StartYear = key,
        //             Name = y.ToList()
        //         }
        //     );
        //         return results;
            
           
        // }
        // 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
            static string TotalShowRunTime(List<Show> shows) 
            {
                List<Show> comedy = shows.Where(s => s.Genres.Contains("Comedy")).ToList();
                List<Show> notComedy = shows.Where(s => !s.Genres.Contains("Comedy")).ToList();
                int Time = 0;
                
                foreach (Show s in comedy)
                {
                    Time += s.EpisodeCount * 22;
                }

                foreach (Show s in notComedy)
                {
                    Time += s.EpisodeCount * 42;
                }
                Double Hours = Time /60;
                Double Days = Hours /24;
                return $"It will take {Time} mins to watch all of the episodes. Thats {Hours} housr or {((float)Days)} Days ";
            }
        // 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.



        /**************************************************************************************************
         There is no code to write or change below this line, but you might want to read it.
        **************************************************************************************************/

        static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

        static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

        static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

        static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

        static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
            Console.WriteLine("--------------------------------------------");
        }
    }
}
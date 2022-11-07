// The strategy design pattern is a pattern that allow us
// to define a family of algorithms that perform some tasks.
// The concrete strategy can be chosen at runtime.
namespace Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static readonly IEnumerable<Game> Games = new List<Game>()
        {
            new ("GTA V", 19.99M, 98, new DateTime(2016, 2, 26), true),
            new ("Red Dead Redemption II", 60M, 92, new DateTime(2018, 10, 26), true),
            new ("Assassin Creed: Origin", 25M, 95, new DateTime(2020, 8, 18), false),
            new ("Heroes 3", 10M, 82, new DateTime(1999, 3, 3), false),
            new ("God of War", 60M, 97, new DateTime(2018, 4, 20), true),
        };

        public static void Main()
        {
            var searchOption = FilteringType.BestGames;
            var searchWord = "Red";

            // The concrete strategy can be chosen at runtime.
            var strategy = SelectStrategy(searchOption, searchWord);
            var games = FindBy(strategy);

            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
        }

        // The strategy design pattern is a pattern that allow us
        // to define a family of algorithms that perform some tasks.
        public static Predicate<Game> SelectStrategy(FilteringType filteringType, string searchWord)
            => filteringType switch
            {
                FilteringType.ByTitle => game => game.Title.Contains(searchWord),
                FilteringType.BestGames => game => game.Rating > 95,
                FilteringType.GamesOfThisYear => game => game.ReleaseDate.Year == DateTime.Now.Year,
                FilteringType.BestDeals => game => game.Price < 25,
                _ => throw new ArgumentException("Invalid option!")
            };

        public static IEnumerable<Game> FindBy(Predicate<Game> strategy)
            => Games.Where(x => strategy(x));
    }

    public record Game(
        string Title,
        decimal Price,
        decimal Rating,
        DateTime ReleaseDate,
        bool IsAvailable);

    public enum FilteringType
    {
        ByTitle = 1,
        BestGames = 2,
        GamesOfThisYear = 4,
        BestDeals = 8
    }
}
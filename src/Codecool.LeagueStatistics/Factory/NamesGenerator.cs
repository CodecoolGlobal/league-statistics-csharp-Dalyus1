using System.IO;

namespace Codecool.LeagueStatistics.Facotry
{
    /// <summary>
    ///     Provides random names for Players and Teams
    /// </summary>
    public static class NamesGenerator
    {
        public static string GetPlayerName()
        {
            return File.ReadAllLines("PlayerNames.txt").GetRandomValue();
        }

        public static string GetTeamName()
        {
            var cities = File.ReadAllLines("CityNames.txt");
            var names = File.ReadAllLines("TeamNames.txt");

            return cities.GetRandomValue() + " " + names.GetRandomValue();
        }
    }
}

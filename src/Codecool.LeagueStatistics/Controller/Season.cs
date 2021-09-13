using System;
using System.Collections.Generic;
using Codecool.LeagueStatistics.Factory;
using Codecool.LeagueStatistics.Model;

namespace Codecool.LeagueStatistics.Controllers
{
    /// <summary>
    ///     Provides all necessary methods for season simulation
    /// </summary>
    public class Season
    {
        public List<Team> League { get; set; }

        public Season()
        {
            League = new List<Team>();
        }

        /// <summary>
        ///     Fills league with new teams and simulates all games in season.
        /// After all games played calls table to be displayed.
        /// </summary>
        public void Run()
        {
            var league = LeagueFactory.CreateLeague(6);
            foreach (var team in league)
            {
                League.Add(team);
            }
            PlayAllGames();

            // Call Display methods here
        }
        /// <summary>
        ///     Playing one round. Everyone with everyone one time. 
        /// </summary>
        public void PlayAllGames()
        {
            for (int i = 0; i < League.Count; i++)
            {
                for (int j = i+1; j < League.Count; j++)
                    if (League[i] != League[j] && League[i] != League[League.Count - 1])
                    {
                        PlayMatch(League[i], League[j]);
                    }
            }
        }
        /// <summary>
        ///     Plays single game between two teams and displays result after.
        /// </summary>
        public void PlayMatch(Team team1, Team team2)
        {
            int score_team1 = ScoredGoals(team1);
            int score_team2 = ScoredGoals(team2);
            if (score_team1 > score_team2)
            {
                team1.Wins++;
                team2.Losts++;
            }
            else if (score_team1 < score_team2)
            {
                team2.Wins++;
                team1.Losts++;
            }
            else
            {
                team1.Draws++;
                team2.Draws++;
            }
        }

        /// <summary>
        ///     Checks for each player of given team chanse to score based on skillrate.
        ///     Adds scored golas to player's and team's statistics.
        /// </summary>
        /// <param name="team">team</param>
        /// <returns>All goals scored by the team in current game</returns>
        public int ScoredGoals(Team team)
        {
            int goals = 0;
            Random rchance = new Random();
            foreach (Player player in team.Players)
            {                
                int chance = rchance.Next(0, 100);
                if( player.SkillRate >= chance)
                {
                    player.Goals++;
                    goals++;
                }
            }
            return goals;
        }
    }
}

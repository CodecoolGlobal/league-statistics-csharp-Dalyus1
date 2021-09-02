using Codecool.LeagueStatistics.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Codecool.LeagueStatistics;

namespace NunitTests
{
    [TestFixture]
    public class TestLeagueStatistics
    {
        private List<Team> _teams;
        private List<Player> _allPlayers;

        [SetUp]
        public void Setup()
        {
            var team1 = new Team()
            {
                Name = "team1",
                Division = Division.Central,
                Wins = 3,
                Draws = 3,
                Losts = 3,
            };
            var team2 = new Team()
            {
                Name = "team2",
                Division = Division.West,
                Wins = 0,
                Draws = 4,
                Losts = 5,
            };
            var team3 = new Team()
            {
                Name = "Super team3",
                Division = Division.East,
                Wins = 4,
                Draws = 0,
                Losts = 5
            };

            var player1 = new Player()
            {
                Name = "John Wick",
                Goals = 2,
                SkillRate = 11
            };
            var player2 = new Player()
            {
                Name = "Chris Griffin",
                Goals = 4,
                SkillRate = 17
            };
            var player3 = new Player()
            {
                Name = "Bruce Wayne",
                Goals = 0,
                SkillRate = 6
            };
            var player4 = new Player()
            {
                Name = "Bilbo Baggins",
                Goals = 3,
                SkillRate = 13
            };
            var player5 = new Player()
            {
                Name = "Tsubasa Ozora",
                Goals = 0,
                SkillRate = 7
            };
            var player6 = new Player()
            {
                Name = "Willy Wonka",
                Goals = 3,
                SkillRate = 18
            };
            var player7 = new Player()
            {
                Name = "Han Solo",
                Goals = 5,
                SkillRate = 19
            };

            team1.Players = new List<Player> { player1, player2, player3 };
            team2.Players = new List<Player> { player4, player5  };
            team3.Players = new List<Player> { player6, player7 };

            _allPlayers = new List<Player> { player1, player2, player3, player4, player5, player6, player7 };
            _teams = new List<Team> { team1, team2, team3 };
        }
        [Test]
        public void TestGetAllTeamsSorted()
        {
            var expectedOrder = new List<Team> { _teams[2], _teams[0], _teams[1] };
            var result = _teams.GetAllTeamsSorted();

            Assert.AreEqual(expectedOrder, result);
        }

        [Test]
        public void TestGetAllPlayers()
        {
           var expected = new List<Player> { _allPlayers[0], _allPlayers[1], _allPlayers[2], _allPlayers[3], _allPlayers[4], _allPlayers[5], _allPlayers[6] };
           var result = _teams.GetAllPlayers();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetTopTeamsWithLeastLoses()
        {
            var expected = new List<Team> { _teams[0], _teams[2] };
            var result = _teams.GetTopTeamsWithLeastLoses(2);
            
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestGetTopTeamsWithLeastLosesOutOfBoundaries()
        {
            var expected = new List<Team> { _teams[0], _teams[2], _teams[1] };
            var result = _teams.GetTopTeamsWithLeastLoses(5);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetTopScorersEachTeam()
        {
           var result = _teams.GetTopPlayersFromEachTeam();
           var expected = new List<Player> { _allPlayers[1], _allPlayers[3], _allPlayers[6]};

           Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetStrongestDivision()
        {
            var result = _teams.GetStrongestDivision();

            Assert.AreEqual(Division.East, result);
        }

        [Test]
        public void TestGetTeamsWithPlayersWithoutGoal()
        {
            var result = _teams.GetTeamsWithPlayersWithoutGoals();
            var expected = new List<Team> { _teams[0], _teams[1] };
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetPlayersWithAtLeastXGoals()
        {
            var result = _teams.GetPlayersWithAtLeastXGoals(4);
            var expected = new List<Player> { _allPlayers[1], _allPlayers[6] };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetTeamWithTheLongestName()
        {
            var result = _teams.GetTeamWithTheLongestName();
            var expected = _teams[2];
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestGetMostTalentedPlayerInDivision()
        {
            var result = _teams.GetMostTalentedPlayerInDivision(Division.West);
            var expected = _allPlayers[3];
            Assert.AreEqual(expected, result);
        }
    }
}

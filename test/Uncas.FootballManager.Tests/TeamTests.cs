using System.Linq;
using NUnit.Framework;

namespace Uncas.FootballManager.Tests
{
    [TestFixture]
    public class TeamTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(22)]
        public void Players_WhenInitiatedWithNPlayers_ContainsNPlayers(
            int players)
        {
            var team1 = new Team();
            for (int playerIndex = 0; playerIndex < players; playerIndex++)
            {
                team1.AddPlayer(new Player());
            }

            Assert.AreEqual(players, team1.Players.Count());
        }

        [Test]
        public void StartingLineup_22Players_11FirstPlayersStartingNext5Substitutes()
        {
            var team1 = new Team();
            for (int playerIndex = 0; playerIndex < 22; playerIndex++)
            {
                team1.AddPlayer(new Player { ShirtNumber = playerIndex + 1 });
            }

            Lineup lineup = team1.Lineup;
            Assert.NotNull(lineup);
            Assert.AreEqual(11, lineup.StartingPlayers.Count());
            Assert.AreEqual(5, lineup.Substitutes.Count());
            foreach (Player player in lineup.StartingPlayers)
            {
                Assert.LessOrEqual(player.ShirtNumber, 11);
            }
            foreach (Player player in lineup.Substitutes)
            {
                Assert.GreaterOrEqual(player.ShirtNumber, 12);
                Assert.LessOrEqual(player.ShirtNumber, 16);
            }
        }
    }
}
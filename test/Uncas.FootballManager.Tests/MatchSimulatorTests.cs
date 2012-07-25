using NUnit.Framework;

namespace Uncas.FootballManager.Tests
{
    [TestFixture]
    public class MatchSimulatorTests
    {
        private IMatchSimulator simulator = new MatchSimulator();

        [Test]
        public void Run_TwoTeams_SomeResult()
        {
            var team1 = new Team();
            var team2 = new Team();
            var match = new Match(team1, team2);

            MatchResult result = this.simulator.Run(match);
            Assert.NotNull(result.Winner);
        }
    }
}
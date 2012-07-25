using System.Collections.Generic;
using System.Linq;

namespace Uncas.FootballManager
{
    public class Team
    {
        private IList<Player> players = new List<Player>();
        private Lineup lineup;

        public IEnumerable<Player> Players
        {
            get { return this.players; }
        }

        public Lineup Lineup
        {
            get
            {
                if (this.lineup == null)
                {
                    this.lineup = GetDefaultLineup();
                }

                return this.lineup;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        private Lineup GetDefaultLineup()
        {
            var lineup = new Lineup(
                this.players.Take(11),
                this.players.Skip(11).Take(5));

            return lineup;
        }
    }

    public class Match
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public Match(Team team1, Team team2)
        {
            this.Team1 = team1;
            this.Team2 = team2;
        }
    }

    public class MatchSimulator : IMatchSimulator
    {
        public MatchResult Run(Match match)
        {
            return new MatchResult { Winner = match.Team1 };
        }
    }

    public interface IMatchSimulator
    {
        MatchResult Run(Match match);
    }

    public class MatchResult
    {
        public Team Winner { get; set; }
    }
}
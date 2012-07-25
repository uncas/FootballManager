using System.Collections.Generic;

namespace Uncas.FootballManager
{
    public class Lineup
    {
        public Lineup(
            IEnumerable<Player> startingPlayers,
            IEnumerable<Player> substitutes)
        {
            this.StartingPlayers = startingPlayers;
            this.Substitutes = substitutes;
        }

        public IEnumerable<Player> StartingPlayers { get; private set; }
        public IEnumerable<Player> Substitutes { get; private set; }
    }
}

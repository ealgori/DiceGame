using System;
using System.Collections.Generic;

namespace DiceGame
{
    public class Game
    {
        private readonly int maxPlayers = 6;
        private readonly Dictionary<Player, int> bets = new Dictionary<Player, int>();

        public List<Player> Players { get; private set; } = new List<Player>();
        public void AddPlayer(Player player)
        {
            if(Players.Count>=maxPlayers)
                throw new InvalidOperationException();

            Players.Add(player);
        }

        public int BetOf(Player player)
        {
            return bets[player];
        }

        public void PlaceBet(Player player, int bet)
        {
            bets.Add(player, bet);
        }
    }
}
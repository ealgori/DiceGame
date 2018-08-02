using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame
{
    public class Game
    {
        private readonly int maxPlayers = 6;

        private readonly List<Bet> bets = new List<Bet>();

        public List<Player> Players { get; private set; } = new List<Player>();

        public int LuckyNumber { get; set; }

        public void AddPlayer(Player player)
        {
            if(Players.Count>=maxPlayers)
                throw new InvalidOperationException();

            Players.Add(player);
        }

        public Bet BetOf(Player player)
        {
            return bets.FirstOrDefault(bet => bet.Player == player);
        }

        public void PlaceBet(Player player, Bet bet)
        {
            bets.Add(bet);
        }

        public bool HasBet(Player player, int number)
        {
            return bets.Any(bet => bet.Player == player && bet.Number == number);
        }

        public void Play()
        {
            foreach (var bet in bets)
            {
                if(bet.Number==LuckyNumber)
                {
                    bet.Player.Win(bet);
                }
               

            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace DiceGame
{
    public class Game
    {
        private int maxPlayers = 6;
        public List<Player> Players { get; private set; } = new List<Player>();
        public void AddPlayer(Player player)
        {
            if(Players.Count>=maxPlayers)
                throw new InvalidOperationException();

            Players.Add(player);
        }
    }
}
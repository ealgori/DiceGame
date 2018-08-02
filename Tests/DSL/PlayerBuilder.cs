using System;
using System.Collections.Generic;
using System.Text;
using DiceGame;

namespace Tests.DSL
{
    public class PlayerBuilder
    {
        private Game game;
        private int chips;
        private Casino casino;

        public Player Build()
        {
            Player player;

            if (casino != null && chips != 0)
            {
                player = new Player();
                player.Buy(casino, chips);
            }
            else
            {
                player = new Player(chips);
            }

            if (game != null)
            {
                player.Join(game);
            }


           

            return player;
        }

        public PlayerBuilder WhoJoinGame(Game newGame)
        {
            game = newGame;
            return this;
        }

        public PlayerBuilder WithAvailableChips(int chipsAmount)
        {
            chips = chipsAmount;
            return this;
        }
    }
}

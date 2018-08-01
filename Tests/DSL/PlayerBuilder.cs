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
            var player = new Player();

            if (game != null)
            {
                player.Join(game);
            }

            if (casino != null && chips != 0)
            {
                player.Buy(casino, chips);
            }

            return player;
        }

        public PlayerBuilder WhoJoinGame(Game newGame)
        {
            game = newGame;
            return this;
        }

        public PlayerBuilder ThenBuyChips(int chipsToBuy, Casino from)
        {
            chips = chipsToBuy;
            casino = from;
            return this;
        }
    }
}

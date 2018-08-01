using System;
using System.Collections.Generic;
using System.Text;
using DiceGame;

namespace Tests.DSL
{
    public class PlayersBuilder
    {
        private int amount;

        public IEnumerable<Player> Build()
        {
            for (int i = 0; i < amount; i++)
            {
                yield return new Player();
            }
        }

        public PlayersBuilder OfAmount(int amount)
        {
            this.amount = amount;
            return this;
        }
    }
}

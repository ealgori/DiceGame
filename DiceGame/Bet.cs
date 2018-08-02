using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame
{
    public class Bet
    {
        public int Amount { get; }
        public int Number { get; }
        public  Player Player { get;}

        public Bet(int amount, int number)
        {
            Amount = amount;
            Number = number;
        }

        public Bet(int amount, int number, Player player)
        {
            Amount = amount;
            Number = number;
            Player = player;
        }
    }
}

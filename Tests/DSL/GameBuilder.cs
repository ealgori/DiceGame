using DiceGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.DSL
{
    public class GameBuilder
    {
        private int luckyNumber;
        private int diceNumber = 1;

        public GameBuilder WithLuckyNumber(int luckyNumber)
        {
            this.luckyNumber = luckyNumber;
            return this;
        }

        public GameBuilder WithTwoDices()
        {
            this.diceNumber = 2;
            return this;
        }

        public Game Build()
        {
            var game = new Casino().CreateGame(0);
            game.LuckyNumber = luckyNumber;

            if (diceNumber == 2)
            {
                var stickman = new Stickman();
                stickman.AddDice(game);
            }

            return game;
        }
    }
}

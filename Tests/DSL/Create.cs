using System;
using System.Collections.Generic;
using System.Text;
using DiceGame;

namespace Tests.DSL
{
    public static class Create
    {
        public static PlayerBuilder Player => new PlayerBuilder();

        public static PlayersBuilder Players => new PlayersBuilder();
        
        public static GameBuilder Game => new GameBuilder();
    }

    public class GameBuilder
    {
        private Casino casino;
        private int luckyNumber;
        private int diceNumber = 1;

        public GameBuilder WithCasino()
        {
            casino = new Casino();
            return this;
        }

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
            Game game;

            if (casino == null)
            {
                game = new Game();
            }
            else
            {
                game = casino.CreateGame(0);
            }

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

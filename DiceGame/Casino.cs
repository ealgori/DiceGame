using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceGame
{
    public class Casino
    {
        private readonly Dictionary<int, int> twoDiceGameCoefs = new Dictionary<int, int>
        {
            {2, 36},
            {3, 18 },
            {4, 12 },
            {5, 9 },
            {6, 7 },
            {7, 6 },
            {8, 7},
            {9, 9 },
            {10, 12 },
            {11, 18 },
            {12, 36 }
        };

        public IEnumerable<object> AcceptBets(params Bet[]  bet)
        {
            return bet.Where(b => b.Amount % 5 == 0);
        }

        public Game CreateGame(int luckyNumber)
        {
            var game = new Game();
            game.LuckyNumber = luckyNumber;
            game.Casino = this;
            return game;
        }

        public int AvailableChips { get; set; }

        public int GetCoefficient(Game game)
        {
            return game.DiceCount == 2 ? twoDiceGameCoefs[game.LuckyNumber] : 6;
        }
    }
}

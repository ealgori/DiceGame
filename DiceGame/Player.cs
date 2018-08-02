using System;

namespace DiceGame
{
    public class Player
    {
        public Game CurrentGame { get; private set; }

        public int AvailableChips { get; private set; }

        public bool Winner { get; private set; }

        public void Join(Game game)
        {
            if (CurrentGame != null)
            {
                throw new InvalidOperationException();
            }

            game.AddPlayer(this);
            CurrentGame = game;
        }

        public void Leave(Game game)
        {
            if(CurrentGame==null)
                throw new InvalidOperationException();

            CurrentGame = null;
        }

        public void Buy(Casino casino, int chipsAmount)
        {
            AvailableChips += chipsAmount;
        }

        public void MakeBet(Game game, Bet bet)
        {
            if(AvailableChips < bet.Amount)
                throw new InvalidOperationException();

            if (bet.Number < 1 || bet.Number > 6)
                throw new InvalidOperationException();

            game.PlaceBet(this, new Bet(bet.Amount, bet.Number, this));
        }

        public void Win(Bet bet)
        {
            this.Winner = true;
            AvailableChips += bet.Amount * 6;
        }
    }
}
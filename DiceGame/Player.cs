using System;

namespace DiceGame
{
    public class Player
    {
        public Player()
        {

        }
        public Player(int availableChips)
        {
            AvailableChips = availableChips;
        }
        public Game CurrentGame { get; private set; }

        public int AvailableChips { get; private set; }

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
            var chips = casino.BuyChips(chipsAmount);
            AvailableChips += chips;
        }

        public void MakeBet(Game game, Bet bet)
        {
            game.PlaceBet(new Bet(bet.Amount, bet.Number, this));
            AvailableChips -= bet.Amount;
        }

        public void Win(int chips)
        {
            AvailableChips += chips;
        }
    }
}
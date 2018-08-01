using System;

namespace DiceGame
{
    public class Player
    {
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
            AvailableChips += chipsAmount;
        }
    }
}
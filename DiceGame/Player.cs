using System;

namespace DiceGame
{
    public class Player
    {
        public Game CurrentGame { get; set; }

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
    }
}
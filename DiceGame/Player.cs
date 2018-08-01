namespace DiceGame
{
    public class Player
    {
        public Game CurrentGame { get; set; }

        public void Join(Game game)
        {
            CurrentGame = game;
        }
    }
}
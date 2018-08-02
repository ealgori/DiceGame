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

   
}

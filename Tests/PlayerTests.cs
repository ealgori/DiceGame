using System;
using System.ComponentModel;
using DiceGame;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoin_ShouldSetCurrentGame()
        {
            var game = new Game();
            var player = new Player();

            player.Join(game);

            Assert.NotNull(player.CurrentGame);
        }

        [Fact]
        [Description("Я, как игрок, могу выйти из игры")]
        public void WhenLeave_ShouldSetCurrentGameToNull()
        {
            var game = new Game();
            var player = new Player();

            player.Leave(game);

            Assert.Null(player.CurrentGame);
        }
    }
}

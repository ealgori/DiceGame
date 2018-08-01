using System;
using System.ComponentModel;
using DiceGame;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        [Fact]
        [Description("Я, как игрок, могу войти в игру")]
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
            player.Join(game);

            player.Leave(game);

            Assert.Null(player.CurrentGame);
        }
        [Fact]
        [Description("Я, как игрок, не могу выйти из игры, если я в нее не входил")]
        public void WhenNotInGame_ShouldNotLeave()
        {
            var game = new Game();
            var player = new Player();

            Assert.Throws<InvalidOperationException>(()=>player.Leave(game));
        }
    }
}

using System;
using DiceGame;
using Xunit;

namespace Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenJoin_ShouldSucced()
        {
            var game = new Game();
            var player = new Player();

            player.Join(game);

            Assert.NotNull(player.CurrentGame);
        }
    }
}

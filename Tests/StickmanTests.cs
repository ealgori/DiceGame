using DiceGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace Tests
{
    public class StickmanTests
    {
        [Fact]
        [Description("Я, как крупье, могу сделать игру с двумя кубиками")]
        public void WhenMake2DicesGame_ShouldSucced()
        {
            var game = new Game();
            var stickman = new Stickman();

            stickman.AddDice(game);

            Assert.Equal(2, game.DiceCount);
        }
    }
}

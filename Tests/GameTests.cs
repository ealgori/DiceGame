using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DiceGame;
using Tests.DSL;
using Xunit;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        [Description("Я, как игра, не позволяю войти более чем 6 игрокам")]
        public void WhenJoinMore6Players_ShouldNotAllow()
        {
            var game = new Game();
            var players = Create.Players.OfAmount(6).Build();
            players.ToList().ForEach((player) => player.Join(game));
            var seventhPlayer = new Player();

            Assert.Throws<InvalidOperationException>(() => seventhPlayer.Join(game));
        }
    }
}

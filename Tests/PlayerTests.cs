using System;
using System.ComponentModel;
using DiceGame;
using Tests.DSL;
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

        [Fact]
        [Description("Я, как игрок, могу играть только в одну игру одновременно")]
        public void WhenInGame_ShouldNotJoinAnotherGame()
        {
            var game = new Game();
            var player = new Player();
            player.Join(game);

            Assert.Throws<InvalidOperationException>(() => player.Join(new Game()));
        }

        [Fact]
        [Description("Я, как игрок, могу купить фишки у казино, чтобы делать ставки")]
        public void WhenBuyChips_ShouldAddThemToAvailableChips()
        {
            var player = new Player();
            var casino = new Casino();

            player.Buy(casino, 6);

            Assert.Equal(6, player.AvailableChips);
        }

        [Fact]
        [Description("Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть")]
        public void WhenMakeBet_ShouldSuccessfullyMakeBet()
        {
            var player = new Player();
            var game = new Game();
            var casino = new Casino();
            player.Buy(casino,3);

            player.MakeBet(game, new Bet(3, 1));

            Assert.Equal(3, game.BetOf(player).Amount);
        }
        [Fact]
        [Description("Я, как игрок, не могу поставить фишек больше, чем я купил")]
        public void WhenMakeBetWithNoChips_ShouldNotSuccess()
        {
            var player = Create.Player.Build();
            var game = new Game();

            Assert.Throws<InvalidOperationException>(()=> player.MakeBet(game, new Bet(3, 1)));
        }

        [Fact]
        [Description("Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша")]
        public void WhenMakeBetToDifferentNumbers_ShouldSuccessfullyMakeBets()
        {
            var game = new Game();
            var player = Create.Player
                .WhoJoinGame(game)
                .ThenBuyChips(2, from: new Casino())
                .Build();

            player.MakeBet(game, new Bet(1, 1));
            player.MakeBet(game, new Bet(1, 2));

            Assert.True(game.HasBet(player, 1));
            Assert.True(game.HasBet(player, 2));
        }
    }

    
}

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
            var player = Create.Player.WithAvailableChips(5).Build();
            var game = Create.Game.Build();

            player.MakeBet(game, new Bet(5, 1));

            Assert.Equal(5, game.BetOf(player).Amount);
        }
        [Fact]
        [Description("Я, как игрок, не могу поставить фишек больше, чем я купил")]
        public void WhenMakeBetWithNoChips_ShouldNotSuccess()
        {
            var player = Create.Player.Build();
            var game = new Game();

            Assert.Throws<InvalidOperationException>(()=> player.MakeBet(game, new Bet(5, 1)));
        }

        [Fact]
        [Description("Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша")]
        public void WhenMakeBetToDifferentNumbers_ShouldSuccessfullyMakeBets()
        {
            var game = Create.Game.Build();
            var player = Create.Player
                .WhoJoinGame(game)
                .WithAvailableChips(15)
                .Build();

            player.MakeBet(game, new Bet(5, 1));
            player.MakeBet(game, new Bet(10, 2));

            Assert.True(game.HasBet(player, 1));
            Assert.True(game.HasBet(player, 2));
        }

        [Fact]
        [Description("Я, как игрок, могу поставить только на числа 1 - 6")]
        public void WhenPlaceBet1to6_ShouldBeAllowed()
        {
            var game =Create.Game.Build();
            var player = Create.Player
                .WhoJoinGame(game)
                .WithAvailableChips(5)
                .Build();
            var bet = new Bet(5,1);

            player.MakeBet(game,bet);

            Assert.True(game.HasBet(player, 1));
        }

        [Fact]
        [Description("Я, как игрок, не могу поставить на 0")]
        public void WhenPlaceBetTo0_ShouldNotBeAllowed()
        {
            var game = Create.Game.Build();
            var player = Create.Player
                .WhoJoinGame(game)
                .WithAvailableChips(5)
                .Build();
            var bet = new Bet(5,0);

            Assert.Throws<InvalidOperationException>(()=> player.MakeBet(game,bet));
        }

        [Fact]
        [Description("Я, как игрок, могу проиграть, если сделал неправильную ставку")]
        public void WhenMakeWrongBet_ShouldNotWin()
        {
            var game = Create.Game.WithLuckyNumber(3).Build();
            var player = Create.Player.WhoJoinGame(game).WithAvailableChips(5).Build();
            player.MakeBet(game, new Bet(5, 1));
            var startAmmount = player.AvailableChips;
            game.Play();

            Assert.Equal(startAmmount, player.AvailableChips);
        }

        [Fact]
        [Description("Я, как игрок, могу выиграть 6 ставок, если сделал правильную ставку")]
        public void WhenMakeRightBet_ShouldWin6xBets()
        {
            var game = Create.Game.WithLuckyNumber(3).Build();
            var player = Create.Player.WhoJoinGame(game).WithAvailableChips(5).Build();
            player.MakeBet(game, new Bet(5, game.LuckyNumber));
            var startAvailableChips = player.AvailableChips;

            game.Play();

            Assert.True(player.AvailableChips-startAvailableChips==6*5);
        }

        [Fact]
        [Description("Я, как игрок, могу сделать несколько ставок на разные числа и получить выигрыш по тем, которые выиграли")]
        public void WhenMakeSeveralBets_ShouldGet6xForWinnerBets()
        {
            var game = Create.Game.WithLuckyNumber(3).Build();
            var player = Create.Player.WhoJoinGame(game).WithAvailableChips(15).Build();
            player.MakeBet(game, new Bet(10, game.LuckyNumber));
            player.MakeBet(game, new Bet(5, 2));
            var startAvailableChips = player.AvailableChips;

            game.Play();

            Assert.True(player.AvailableChips-startAvailableChips==6*10);
        }

        [Fact]
        [Description("Я, как игрок, могу делать ставки на числа от 2 до 12")]
        public void WhenPlaceBet2to12InTwoDiceGame_ShouldBeAllowed()
        {
            var game = Create.Game.WithTwoDices().Build();
            var player = Create.Player
                .WhoJoinGame(game)
                .WithAvailableChips(10)
                .Build();

            player.MakeBet(game, new Bet(5, 2));

            Assert.True(game.HasBet(player, 2));
        }

        [Fact]
        [Description("Я, как игрок, не могу поставить на 1 в игре с двумя кубиками")]
        public void WhenPlaceBetTo1InTwoDicesGame_ShouldNotBeAllowed()
        {
            var game = Create.Game.WithTwoDices().Build();
            var player = Create.Player
                .WhoJoinGame(game)
                .WithAvailableChips(5)
                .Build();
            var bet = new Bet(5, 1);

            Assert.Throws<InvalidOperationException>(() => player.MakeBet(game, bet));
        }

        [Fact]
        [Description("Я, как игрок, не могу поставить на 13 в игре с двумя кубиками")]
        public void WhenPlaceBetTo13InTwoDicesGame_ShouldNotBeAllowed()
        {
            var game = Create.Game.WithTwoDices().Build();
            var player = Create.Player
                .WhoJoinGame(game)
                .WithAvailableChips(5)
                .Build();
            var bet = new Bet(5, 13);

            Assert.Throws<InvalidOperationException>(() => player.MakeBet(game, bet));
        }


    }


}

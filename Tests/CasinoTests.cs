using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DiceGame;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Tests.DSL;
using Xunit;

namespace Tests
{
    public class CasinoTests
    {
        [Fact]
        [Description("Я, как казино, принимаю только ставки, кратные 5")]
        public void WhenCheck5xBet_ShouldBeAllow()
        {
            var casino = new Casino();
            var bet = new Bet(5,1);

            var allowedBets =casino.AcceptBets(bet);

            Assert.Single(allowedBets);
            Assert.Contains(bet, allowedBets);
        }

        [Fact]
        [Description("Я, как казино, не принимаю ставки, не кратные 5")]
        public void WhenCheckNot5xBet_ShouldNotBeAllow()
        {
            var casino = new Casino();
            var bet = new Bet(6,1);

            var allowedBets =casino.AcceptBets(bet);

            Assert.Empty(allowedBets);

        }

        [Fact]
        [Description("Я, как казино, получаю фишки, которые проиграл игрок")]
        public void WhenPlayerLose_GetHisBet()
        {
            var game = Create.Game.WithCasino().WithLuckyNumber(3).Build();
            var player = Create.Player.WhoJoinGame(game).ThenBuyChips(5, game.Casino).Build();
            var startChips = game.Casino.AvailableChips;
            player.MakeBet(game, new Bet(5, 1));

            game.Play();

            Assert.True(game.Casino.AvailableChips - startChips == 5);
        }

        [Fact]
        [Description("Я, как казино, определяю выигрышный коэффициент по вероятности выпадения того или иного номера")]
        public void WhenPlayerBetTo2InTwoDiceGame_ShouldWin36xBet()
        {
            var game = Create.Game.WithCasino().WithLuckyNumber(2).WithTwoDices().Build();
            var player = Create.Player.WhoJoinGame(game).ThenBuyChips(5, from:game.Casino).Build();
            player.MakeBet(game, new Bet(5, game.LuckyNumber));
            var startAvailableChips = player.AvailableChips;
            
            game.Play();

            Assert.Equal(36 * 5, player.AvailableChips - startAvailableChips);
        }

        [Fact]
        [Description("Я, как казино, определяю выигрышный коэффициент по вероятности выпадения того или иного номера")]
        public void WhenPlayerBetTo7InTwoDiceGame_ShouldWin6xBet()
        {
            var game = Create.Game.WithCasino().WithLuckyNumber(7).WithTwoDices().Build();
            var player = Create.Player.WhoJoinGame(game).ThenBuyChips(5, from: game.Casino).Build();
            player.MakeBet(game, new Bet(5, game.LuckyNumber));
            var startAvailableChips = player.AvailableChips;

            game.Play();

            Assert.Equal(6 * 5, player.AvailableChips - startAvailableChips);
        }
    }
}

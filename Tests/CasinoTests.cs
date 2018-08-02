using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DiceGame;
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
            var casino = new Casino();
            var game = casino.CreateGame(luckyNumber: 3);
            var player = Create.Player.WhoJoinGame(game).ThenBuyChips(5, new Casino()).Build();
            var startChips = casino.AvailableChips;
            player.MakeBet(game, new Bet(5, 1));

            game.Play();

            Assert.True(casino.AvailableChips - startChips == 5);
        }


    }
}

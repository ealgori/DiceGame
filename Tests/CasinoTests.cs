using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DiceGame;
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


    }
}

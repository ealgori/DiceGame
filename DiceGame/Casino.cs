using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceGame
{
    public class Casino
    {
        public IEnumerable<object> AcceptBets(params Bet[]  bet)
        {
            return bet.Where(b => b.Amount % 5 == 0);
        }
    }
}

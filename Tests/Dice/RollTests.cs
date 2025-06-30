using Blackrazor.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackrazor.Tests.Dice
{
    public class RollTests
    {
        public static IEnumerable<object[]> RollStrings = new List<object[]>
        {
            new object[] { "1d20" },
            new object[] { "2d20" },
            new object[] { "+1d20" },
            new object[] { "-1d20" },
            new object[] { "1d20+1" },
            new object[] { "1d20-1" },
            new object[] { "1d20+1d10" },
            new object[] { "1d20-1d10" },
            new object[] { "1d20+1d10+1" },
        };

        [Theory(DisplayName = "Constructor")]
        [MemberData(nameof(RollStrings))]
        public void RollConstructor(string constructorArg)
        {
            Roll roll = new Roll(constructorArg);
            roll.Reroll();
        }
    }
}

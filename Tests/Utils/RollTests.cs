using Blackrazor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Blackrazor.Tests.Utils
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
            new object[] { "3d20+4d10+10-4" },
        };

        private readonly ITestOutputHelper Output;

        public RollTests(ITestOutputHelper output)
        {
            this.Output = output;
        }

        [Theory(DisplayName = "Constructor")]
        [MemberData(nameof(RollStrings))]
        public void RollConstructor(string constructorArg)
        {
            Dice dice = new Dice(constructorArg);
            dice.Roll();
            Output.WriteLine($"{dice} => {dice.Result}");
        }
    }
}

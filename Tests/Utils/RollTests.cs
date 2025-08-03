using Blackrazor.Utils;
using Xunit.Abstractions;

namespace Blackrazor.Tests.Utils
{
    public class RollTests(ITestOutputHelper output)
    {
        public static TheoryData<string> RollStrings => new()
        {
            "1d20",
            "2d20",
            "+1d20",
            "-1d20",
            "1d20+1",
            "1d20-1",
            "1d20+1d10",
            "1d20-1d10",
            "1d20+1d10+1",
            "3d20+4d10+10-4",
        };

        private ITestOutputHelper Output { get; } = output;

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

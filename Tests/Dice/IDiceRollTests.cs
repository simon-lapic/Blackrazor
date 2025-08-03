using Blackrazor.Dice;
using Blackrazor.Tests.Helpers;
using System.Globalization;
using Xunit.Sdk;


[assembly: RegisterXunitSerializer(typeof(TestSerializer), typeof(DieRoll), typeof(DiceCollection))]
namespace Blackrazor.Tests.Dice
{
    public class IDiceRollTests(ITestOutputHelper output)
    {
        private static IRandomnessProvider TestRNG { get; } = new TestRandomnessProvider();

        public static TheoryData<IDiceRoll, int, string> TestDice => new()
        {
            { new DieRoll(TestRNG, 1, 20), 20, "1d20 (20)" },
            { new DieRoll(TestRNG, 2, 20), 40, "2d20 (20, 20)" },
            { new DieRoll(TestRNG, 3, 20), 60, "3d20 (20, 20, 20)" },
            { new DieRoll(TestRNG, 1, 10), 10, "1d10 (10)" },
            { new DieRoll(TestRNG, 2, 10), 20, "2d10 (10, 10)" },
            { new DieRoll(TestRNG, 3, 10), 30, "3d10 (10, 10, 10)" },
            { new DieRoll(TestRNG, 1, 20, 1), 21, "1d20 (20) + 1" },
            { new DieRoll(TestRNG, 2, 20, 1), 41, "2d20 (20, 20) + 1" },
            { new DieRoll(TestRNG, 1, 20, isNegative: true), -20, "-1d20 (20)" },
            {
                new DiceCollection([new DieRoll(TestRNG, 1, 20), new DieRoll(TestRNG, 1, 4)]),
                24, "1d20 (20) + 1d4 (4)"
            },
            {
                new DiceCollection([new DieRoll(TestRNG, 1, 20), new DieRoll(TestRNG, 1, 4, isNegative:true)]),
                16, "1d20 (20) - 1d4 (4)"
            },
            {
                new DiceCollection([new DieRoll(TestRNG, 1, 20),
                    new DiceCollection([new DieRoll(TestRNG, 1, 6), new DieRoll(TestRNG, 1, 4, isNegative: true)])]),
                22, "1d20 (20) + 1d6 (6) - 1d4 (4)"
            },
            {
                new DiceCollection([new DieRoll(TestRNG, 1, 20),
                    new DiceCollection([new DieRoll(TestRNG, 1, 6), new DieRoll(TestRNG, 1, 4, isNegative: true)], isNegative:true)]),
                18, "1d20 (20) - (1d6 (6) - 1d4 (4))"
            },
        };

        private ITestOutputHelper Output { get; } = output;


        [Theory(DisplayName = "Dice Rolls")]
        [MemberData(nameof(TestDice))]
        public void SimpleDice(IDiceRoll roll, int expectedResult, string expectedResultString)
        {
            Output.WriteLine($"{roll:r}");
            Assert.Equal(expectedResult, roll.Result);
            Assert.Equal(expectedResultString, roll.ResultString);
            Assert.Equal($"{expectedResultString} = {expectedResult}", roll.ToString(true));
            Assert.Equal($"{expectedResultString} = {expectedResult}", roll.ToString("r", CultureInfo.CurrentCulture));
            Assert.Equal($"{expectedResultString} = {expectedResult}", $"{roll:r}");
        }

        /// <summary>
        /// An <see cref="IRandomnessProvider"/> implementation that always 
        /// returns the maximum value allowed
        /// </summary>
        private class TestRandomnessProvider : IRandomnessProvider
        {
            public int GetRandomNumber(int maximum)
            {
                return maximum - 1;
            }
        }
    }
}

using Blackrazor.Initiative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackrazor.Tests.Initiative
{
    public class IPositionTests
    {
        public static IEnumerable<object[]> constructorArgs = [];

        public static IEnumerable<object[]> comparisonArgs = [];

        public static IEnumerable<object[]> equalityArgs = [];

        [Theory(DisplayName = "Constructor")]
        [MemberData(nameof(constructorArgs))]
        public void Construct_IPosition(object[] positionArgs, Func<object[], IPosition> positionProvider)
        {
            IPosition position = positionProvider(positionArgs);
            Assert.NotNull(position);
        }

        [Theory(DisplayName = "Greater Than")]
        [MemberData(nameof(comparisonArgs))]
        public void GreaterThan_IPosition(IPosition position1, IPosition position2)
        {
            Assert.True(position1.CompareTo(position2) > 0);
        }

        [Theory(DisplayName = "Less Than")]
        [MemberData(nameof(comparisonArgs))]
        public void LessThan_IPosition(IPosition position2, IPosition position1)
        {
            Assert.True(position2.CompareTo(position1) < 0);
        }

        [Theory(DisplayName = "Equal To")]
        [MemberData(nameof(equalityArgs))]
        public void EqualTo_IPosition(IPosition position1, IPosition position2)
        {
            Assert.True(position1.CompareTo(position2) == 0);
        }

        [Theory(DisplayName = "Not Equal To")]
        [MemberData(nameof(comparisonArgs))]
        public void NotEqualTo_IPosition(IPosition position1, IPosition position2)
        {
            Assert.True(position2.CompareTo(position1) != 0);
        }
    }
}

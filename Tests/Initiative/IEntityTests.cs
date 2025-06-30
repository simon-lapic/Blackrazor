using Blackrazor.Initiative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blackrazor.Tests.Initiative
{
    public class IEntityTests
    {
        public static IEnumerable<object[]> constructorArgs = [];

        public static IEnumerable<object[]> comparisonArgs = [];

        [Theory(DisplayName = "Constructor")]
        [MemberData(nameof(constructorArgs))]
        public void Construct_IEntity(object[] entityArgs, Func<object[], IEntity> entityProvider)
        {
            IEntity entity = entityProvider(entityArgs);
            Assert.NotNull(entity);
        }

        [Theory(DisplayName = "Greater Than")]
        [MemberData(nameof(comparisonArgs))]
        public void GreaterThan_IEntity(IEntity entity1, IEntity entity2)
        {
            Assert.True(entity1.CompareTo(entity2) > 0);
        }

        [Theory(DisplayName = "Less Than")]
        [MemberData(nameof(comparisonArgs))]
        public void LessThan_IEntity(IEntity entity2, IEntity entity1)
        {
            Assert.True(entity1.CompareTo(entity2) < 0);
        }
    }
}

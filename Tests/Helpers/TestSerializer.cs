using Blackrazor.Dice;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using Xunit.Sdk;

namespace Blackrazor.Tests.Helpers
{
    internal class TestSerializer : IXunitSerializer
    {
        public object Deserialize(Type type, string serializedValue)
        {
            if (type == typeof(DieRoll))
                return JsonConvert.DeserializeObject<DieRoll>(serializedValue)
                    ?? throw new ArgumentException(serializedValue);
            if (type == typeof(DiceCollection))
                return JsonConvert.DeserializeObject<DiceCollection>(serializedValue)
                    ?? throw new ArgumentException(serializedValue);
            return new object();
        }

        public bool IsSerializable(Type type, object? value, [NotNullWhen(false)] out string? failureReason)
        {
            if (value is IDiceRoll)
            {
                failureReason = null;
                return true;
            }

            failureReason = "Type is not supported";
            return false;
        }

        public string Serialize(object value)
        {
            return $"{value}";
        }
    }
}

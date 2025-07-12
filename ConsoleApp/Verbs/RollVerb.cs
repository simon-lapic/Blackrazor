using Blackrazor.Utils;
using CommandLine;

namespace Blackrazor.CLI.Verbs
{
    internal class RollVerb : IVerb<RollVerbOptions>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="options"></param>
        public void Execute(RollVerbOptions options)
            => Console.WriteLine($"Result: {new Dice(options.DiceString).Result}");
    }

    [Verb("roll", aliases: ["r"], HelpText = "Rolls a set of dice and prints the result of the roll")]
    internal class RollVerbOptions : IVerbOptions
    {
        [Value(0, Required = true)]
        public string DiceString { get; set; } = "1d20";
    }
}

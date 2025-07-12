using CommandLine;

namespace Blackrazor.CLI.Verbs
{
    internal class RunVerb : IVerb<RunVerbOptions>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="options"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(RunVerbOptions options) => Console.WriteLine("GUI application is not yet implemented");
    }

    [Verb("run", HelpText = "Runs the Blackrazor GUI application")]
    internal class RunVerbOptions : IVerbOptions { }
}

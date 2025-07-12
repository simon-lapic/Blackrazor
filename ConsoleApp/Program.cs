
using Blackrazor.CLI.Verbs;
using CommandLine;
using CommandLine.Text;
using System.Reflection;

namespace Blackrazor.CLI
{
    public class Program
    {
        private static Type[] LoadVerbs()
            => Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() is not null)
                .ToArray();

        private static void DisplayHelp<T>(ParserResult<T> result)
        {
            Console.WriteLine(HelpText.AutoBuild(result, h =>
            {
                h.AdditionalNewLineAfterOption = false;
                h.Heading = "Blackrazor CLI";
                h.Copyright = "";
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e));
        }

        public static void Main(string[] args)
        {
            var parser = new Parser(with => with.HelpWriter = null);
            var parserResult = parser.ParseArguments(args, LoadVerbs());

            parserResult.WithParsed<RunVerbOptions>(new RunVerb().Execute)
                .WithParsed<RollVerbOptions>(new RollVerb().Execute)
                .WithNotParsed(errors => DisplayHelp(parserResult));
        }
    }
}
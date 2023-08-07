using CommandLine;

namespace Finstar_test.Utils
{
    public class CommandLineOptions
    {

        [Option('i', "input", Required = true, HelpText = "path to *.txt with query sql")]
        public string? InputPath { get; set; }

        [Option('o', "output", Required = true, HelpText = "path to save *.csv result of query")]
        public string? OutputPath { get; set; }
    }
}

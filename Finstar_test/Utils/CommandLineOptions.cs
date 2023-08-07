using CommandLine;
using System.ComponentModel;

namespace Finstar_test.Utils
{
    public class CommandLineOptions
    {

        [Option('i', "input", Required = false, HelpText = "path to *.txt with query sql", Default = "./Examples/input.txt")]
        public string? InputPath { get; set; }

        [Option('o', "output", Required = false, HelpText = "path to save *.csv result of query", Default = "./Examples/output.csv")]
        public string? OutputPath { get; set; }
    }
}

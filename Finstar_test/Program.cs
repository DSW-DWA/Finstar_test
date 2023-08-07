using System;
using System.Configuration;
using CommandLine;
using Finstar_test.DataAccess;
using Finstar_test.Models;
using Finstar_test.Services;
using Finstar_test.Utils;

try
{
    CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
        .WithParsed<CommandLineOptions>(o =>
        {
            if (o.InputPath == null || o.OutputPath == null)
            {
                throw new Exception("Arguments input and output would be not null");
            }

            if (!File.Exists(o.InputPath))
            {
                throw new Exception("Input file didn'e exist");
            }

            if (!new FileInfo(o.InputPath).Extension.Equals(".txt"))
            {
                throw new Exception("Input file need to be only *.txt");
            }

            var sqlQuery = FileService.ReadQueryFromFile(o.InputPath);
            var result = QueryExecutor.ExecuteQuery(sqlQuery, ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);

            FileService.WriteResultToCsv(result, o.OutputPath);

            Console.WriteLine("Query executed successfully.");
        });
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
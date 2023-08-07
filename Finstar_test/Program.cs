using System;
using CommandLine;
using Finstar_test.DataAccess;
using Finstar_test.Models;
using Finstar_test.Services;
using Finstar_test.Utils;
using Finstar_test;

try
{
    CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
        .WithParsed<CommandLineOptions>(o =>
        {
            if (o.InputPath == null || o.OutputPath == null)
            {
                throw new Exception("Arguments input and output would be not null");
            }


            AppConfig.Load();

            var sqlQuery = FileService.ReadQueryFromFile(o.InputPath);
            QueryResult result = QueryExecutor.ExecuteQuery(sqlQuery);

            FileService.WriteResultToCsv(result, o.OutputPath);

            Console.WriteLine("Query executed successfully.");
        });
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
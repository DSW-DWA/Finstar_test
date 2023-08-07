using Finstar_test.DataAccess;
using Finstar_test.Models;
using Finstar_test.Services;
using Finstar_test.Utils;

try
{
    AppConfig.Load();

    var sqlQuery = FileService.ReadQueryFromFile(AppConfig.InputFilePath);
    QueryResult result = QueryExecutor.ExecuteQuery(sqlQuery);

    FileService.WriteResultToCsv(result, AppConfig.OutputFilePath);

    Console.WriteLine("Query executed successfully.");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
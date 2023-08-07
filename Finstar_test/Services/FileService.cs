using Finstar_test.Models;
using System.Data;

namespace Finstar_test.Services
{
    class FileService
    {
        public static string ReadQueryFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public static void WriteResultToCsv(QueryResult result, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (DataRow row in result.ResultTable.Rows)
                {
                    writer.WriteLine(string.Join(",", row.ItemArray));
                }
            }
        }
    }
}

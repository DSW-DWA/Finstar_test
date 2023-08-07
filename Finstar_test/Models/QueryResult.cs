using System.Data;

namespace Finstar_test.Models
{
    public class QueryResult
    {
        public DataTable ResultTable { get; }

        public QueryResult(DataTable resultTable)
        {
            ResultTable = resultTable;
        }
    }
}

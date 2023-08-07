using System.Data;

namespace Finstar_test.Models
{
    class QueryResult
    {
        public DataTable ResultTable { get; }

        public QueryResult(DataTable resultTable)
        {
            ResultTable = resultTable;
        }
    }
}

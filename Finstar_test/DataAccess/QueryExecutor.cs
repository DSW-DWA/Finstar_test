using Finstar_test.Models;
using Finstar_test.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Finstar_test.DataAccess
{
    class QueryExecutor
    {
        public static QueryResult ExecuteQuery(string query)
        {
            using (var connection = new DatabaseContext(AppConfig.ConnectionString).CreateConnection())
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    return new QueryResult(dataTable);
                }
            }
        }
    }
}

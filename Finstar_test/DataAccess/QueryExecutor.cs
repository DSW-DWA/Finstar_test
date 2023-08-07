using Finstar_test.Models;
using Finstar_test.Utils;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Finstar_test.DataAccess
{
    public class QueryExecutor
    {
        public static QueryResult ExecuteQuery(string query, string connectionString)
        {
            using (var connection = new DatabaseContext(connectionString).CreateConnection())
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

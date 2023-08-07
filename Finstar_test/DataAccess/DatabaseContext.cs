using Microsoft.Data.SqlClient;

namespace Finstar_test.DataAccess
{
    public class DatabaseContext
    {
        private string _connectionString;

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

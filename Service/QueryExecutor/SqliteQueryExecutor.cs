using System.Data.Common;
using System.Data;

namespace Service.QueryExecutor
{
    public class SqliteQueryExecutor : IQueryExecutor
    {
        public DbName Name => DbName.SQLite;

        public DataTable Execute(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
            DataTable dataTable = new();
            dataTable.Load(reader);
            return dataTable;
        }
    }
}

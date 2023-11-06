using System.Data;
using System.Data.Common;

namespace Service.QueryPlan
{
    public class SqliteQueryPlanAnalyzer : IQueryPlanAnalyzer
    {
        public DbName Name => DbName.SQLite;

        public DataTable Analyze(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "EXPLAIN QUERY PLAN " + query;
            DbDataReader reader = command.ExecuteReader();
            DataTable dataTable = new();
            dataTable.Load(reader);
            return dataTable;
        }
    }
}
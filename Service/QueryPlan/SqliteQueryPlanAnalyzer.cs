using Service.QueryParser;
using System.Data;
using System.Data.Common;

namespace Service.QueryPlan
{
    public class SqliteQueryPlanAnalyzer : IQueryPlanAnalyzer
    {
        public DbName Name => DbName.SQLite;

        private readonly IQueryParser queryParser;

        public SqliteQueryPlanAnalyzer(Func<DbName, IQueryParser> queryParserFactory)
        {
            this.queryParser = queryParserFactory(Name);
        }


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
            queryParser.FindTransactionInQuery(connection, query);
            return dataTable;
        }
    }
}
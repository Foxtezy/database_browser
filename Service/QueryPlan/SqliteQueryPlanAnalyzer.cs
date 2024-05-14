using Service.Logger;
using Service.QueryParser;
using System.Data;
using System.Data.Common;

namespace Service.QueryPlan
{
    public class SqliteQueryPlanAnalyzer : IQueryPlanAnalyzer
    {
        public DbName Name => DbName.SQLite;

        private readonly IQueryParser queryParser;

        private readonly IQueryLogger logger;

        public SqliteQueryPlanAnalyzer(Func<DbName, IQueryParser> queryParserFactory, IQueryLogger logger)
        {
            this.queryParser = queryParserFactory(Name);
            this.logger = logger;
        }


        public DataTable Analyze(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "EXPLAIN QUERY PLAN " + query;
            logger.Log(command.CommandText);
            DbDataReader reader = command.ExecuteReader();
            DataTable dataTable = new();
            dataTable.Load(reader);
            queryParser.FindTransactionInQuery(connection, query);
            return dataTable;
        }
    }
}

using PluginBase.Logger;
using PluginBase.QueryParser;
using PluginBase.QueryPlan;
using System.Data;
using System.Data.Common;

namespace SqlitePlugin.QueryPlan
{
    public class SqliteQueryPlanAnalyzer : IQueryPlanAnalyzer
    {

        private readonly IQueryParser queryParser;

        private readonly IQueryLogger logger;

        public SqliteQueryPlanAnalyzer(IQueryParser queryParser, IQueryLogger logger)
        {
            this.queryParser = queryParser;
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

using PluginBase.Logger;
using PluginBase.QueryParser;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using System.Data;
using System.Data.Common;

namespace PSQLPlugin.QueryPlan
{
    public class PSQLQueryPlanAnalyzer : IQueryPlanAnalyzer
    {

        private readonly IQueryParser queryParser;

        private readonly ITransactionExecutor transactionExecutor;

        private readonly IQueryLogger logger;

        public PSQLQueryPlanAnalyzer(IQueryParser queryParser, IQueryLogger logger, ITransactionExecutor transactionExecutor)
        {
            this.queryParser = queryParser;
            this.logger = logger;
            this.transactionExecutor = transactionExecutor;
        }


        public DataTable Analyze(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            transactionExecutor.BeginTransaction(connection);
            DbCommand command = connection.CreateCommand();
            command.CommandText = "EXPLAIN ANALYZE " + query;
            logger.Log(command.CommandText);
            DbDataReader reader = command.ExecuteReader();
            DataTable dataTable = new();
            dataTable.Load(reader);
            transactionExecutor.RollbackTransaction(connection);
            queryParser.FindTransactionInQuery(connection, query);
            return dataTable;
        }
    }
}
using System.Data.Common;
using System.Data;
using PluginBase.QueryExecutor;
using PluginBase.QueryParser;
using PluginBase.Logger;

namespace SqlitePlugin.QueryExecutor
{
    public class SqliteQueryExecutor : IQueryExecutor
    {

        private readonly IQueryParser queryParser;

        private readonly ICsvExporter csvExporter;

        private readonly IQueryLogger logger;

        public SqliteQueryExecutor(IQueryParser queryParser, ICsvExporter csvExporter, IQueryLogger logger)
        {
            this.queryParser = queryParser;
            this.csvExporter = csvExporter;
            this.logger = logger;
        }

        public StreamReader Execute(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;
            logger.Log(query);
            DbDataReader reader = command.ExecuteReader();
         
            csvExporter.DataReaderToCsvFile(reader, "tmp.csv", ":");
            queryParser.FindTransactionInQuery(connection, query);
            return new StreamReader("tmp.csv"); ;
        }
    }
}

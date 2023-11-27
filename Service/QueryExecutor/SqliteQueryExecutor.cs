using System.Data.Common;
using System.Data;
using Service.Transaction;
using Service.QueryParser;
using Service.Logger;
using Service.TransactionManager;
using System.IO;

namespace Service.QueryExecutor
{
    public class SqliteQueryExecutor : IQueryExecutor
    {
        public DbName Name => DbName.SQLite;

        private readonly IQueryParser queryParser;

        private readonly ICsvExporter csvExporter;

        private readonly IQueryLogger logger;

        public SqliteQueryExecutor(Func<DbName, IQueryParser> queryParserFactory, ICsvExporter csvExporter, IQueryLogger logger)
        {
            this.queryParser = queryParserFactory(Name);
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

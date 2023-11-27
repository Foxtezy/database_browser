using System.Data.Common;
using System.Data;
using Service.Transaction;
using Service.QueryParser;
using Service.TransactionManager;
using System.IO;

namespace Service.QueryExecutor
{
    public class SqliteQueryExecutor : IQueryExecutor
    {
        public DbName Name => DbName.SQLite;

        private readonly IQueryParser queryParser;

        private readonly ICsvExporter csvExporter;

        public SqliteQueryExecutor(Func<DbName, IQueryParser> queryParserFactory, ICsvExporter csvExporter)
        {
            this.queryParser = queryParserFactory(Name);
            this.csvExporter = csvExporter;

        }

        public StreamReader Execute(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;
            DbDataReader reader = command.ExecuteReader();
         
            csvExporter.DataReaderToCsvFile(reader, "tmp.csv", ":");

            return new StreamReader("tmp.csv"); ;
        }
    }
}

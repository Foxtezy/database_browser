using System.Data.Common;
using System.Data;
using Service.Transaction;
using Service.QueryParser;
using Service.TransactionManager;

namespace Service.QueryExecutor
{
    public class SqliteQueryExecutor : IQueryExecutor
    {
        public DbName Name => DbName.SQLite;

        private readonly IQueryParser queryParser;

        public SqliteQueryExecutor(Func<DbName, IQueryParser> queryParserFactory)
        {
            this.queryParser = queryParserFactory(Name);
        }

        //Поддержать обработку больших запросов
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
            queryParser.FindTransactionInQuery(connection, query);
            return dataTable;
        }
    }
}

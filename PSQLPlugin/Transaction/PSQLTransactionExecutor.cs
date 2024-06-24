using PluginBase.Transaction;
using PluginBase.TransactionManager;
using System;
using System.Data;
using System.Data.Common;


namespace PSQLPlugin.Transaction
{
    public class PSQLTransactionExecutor : ITransactionExecutor
    {

        private readonly ITransactionManager transactionManager;

        public PSQLTransactionExecutor(ITransactionManager transactionManager) => this.transactionManager = transactionManager;

        public void BeginTransaction(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "BEGIN TRANSACTION";
            command.ExecuteNonQuery();
            transactionManager.InTransaction(true);
        }

        public void CommitTransaction(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "COMMIT TRANSACTION";
            command.ExecuteNonQuery();
            transactionManager.InTransaction(false);
        }

        public void RollbackTransaction(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "ROLLBACK TRANSACTION";
            command.ExecuteNonQuery();
            transactionManager.InTransaction(false);
        }

        public bool TransactionStatus(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT statement_timestamp() - now() > interval '1 millisecond';";
            DbDataReader ans = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(ans);
            return (bool)dt.Rows[0].ItemArray[0];
        }
    }
}

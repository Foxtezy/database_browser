using PluginBase.Transaction;
using PluginBase.TransactionManager;
using System;
using System.Data;
using System.Data.Common;


namespace SqlitePlugin.Transaction
{
    public class SqliteTransactionExecutor : ITransactionExecutor
    {

        private readonly ITransactionManager transactionManager;

        public SqliteTransactionExecutor(ITransactionManager transactionManager) => this.transactionManager = transactionManager;

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
            try
            {
                DbTransaction transaction = connection.BeginTransaction();
                transaction.Rollback();
            } catch (Exception)
            {
                return true;
            }
            return false;
        }
    }
}

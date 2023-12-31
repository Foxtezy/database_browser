﻿using Service.TransactionManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Transaction
{
    public class SqliteTransactionExecutor : ITransactionExecutor
    {
        public DbName Name => DbName.SQLite;

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

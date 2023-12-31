﻿using Microsoft.VisualBasic;
using Service.Transaction;
using Service.TransactionManager;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.QueryParser
{
    public class SqliteQueryParser : IQueryParser
    {
        public DbName Name => DbName.SQLite;

        private readonly ITransactionExecutor transactionExecutor;

        private readonly ITransactionManager transactionManager;

        public SqliteQueryParser(Func<DbName, ITransactionExecutor> transactionExecutorFactory, ITransactionManager transactionManager)
        {
            this.transactionExecutor = transactionExecutorFactory(Name);
            this.transactionManager = transactionManager;
        }

        // Find transaction in query and change transaction manager status
        public void FindTransactionInQuery(DbConnection connection, string query)
        {
            string[] words = query.Split(new[] { ' ', ';', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "BEGIN" || words[i] == "COMMIT" || words[i] == "ROLLBACK")
                {
                    transactionManager.InTransaction(transactionExecutor.TransactionStatus(connection));
                    return;
                }
            }
        }
    }
}

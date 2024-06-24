using Microsoft.VisualBasic;
using PluginBase.QueryParser;
using PluginBase.Transaction;
using PluginBase.TransactionManager;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlitePlugin.QueryParser
{
    public class SqliteQueryParser : IQueryParser
    {

        private readonly ITransactionExecutor transactionExecutor;

        private readonly ITransactionManager transactionManager;

        public SqliteQueryParser(ITransactionExecutor transactionExecutor, ITransactionManager transactionManager)
        {
            this.transactionExecutor = transactionExecutor;
            this.transactionManager = transactionManager;
        }

        // Find transaction in query and change transaction manager status
        public void FindTransactionInQuery(DbConnection connection, string query)
        {
            string[] words = query.Split(new[] { ' ', ';', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToUpper() == "BEGIN" || words[i].ToUpper() == "COMMIT" || words[i].ToUpper() == "ROLLBACK")
                {
                    transactionManager.InTransaction(transactionExecutor.TransactionStatus(connection));
                    return;
                }
            }
        }
    }
}

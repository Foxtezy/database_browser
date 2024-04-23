using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.Transaction
{
    public interface ITransactionExecutor
    {
        void BeginTransaction(DbConnection connection);

        void CommitTransaction(DbConnection connection);

        void RollbackTransaction(DbConnection connection);

        bool TransactionStatus(DbConnection connection);
    }
}

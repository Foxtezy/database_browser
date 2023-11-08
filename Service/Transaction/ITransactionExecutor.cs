using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Transaction
{
    public interface ITransactionExecutor : IDbOperation
    {
        void BeginTransaction(DbConnection connection);

        void CommitTransaction(DbConnection connection);

        void RollbackTransaction(DbConnection connection);
    }
}

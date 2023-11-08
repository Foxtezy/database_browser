using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionManager
{
    public class TransactionManager : ITransactionManager
    {

        private bool InTransactionFlag = false;

        public void InTransaction(bool inTransaction) => InTransactionFlag = inTransaction;

        public bool IsInTransaction() => InTransactionFlag;
    }
}

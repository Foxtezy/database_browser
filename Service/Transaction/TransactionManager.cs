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

        // You can add EventHandler Notify += handler
        public event EventHandler? Notify;

        // Generates notify
        public void InTransaction(bool inTransaction)
        {
            InTransactionFlag = inTransaction;
            Notify?.Invoke(this, EventArgs.Empty);
        }

        public bool IsInTransaction() => InTransactionFlag;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.TransactionManager
{
    public class TransactionManager : ITransactionManager
    {

        private bool InTransactionFlag = false;

        private event EventHandler? Notify;

        public void AddEventHandler(EventHandler handler) => Notify += handler;

        // Generates notify
        public void InTransaction(bool inTransaction)
        {
            if (InTransactionFlag != inTransaction)
            {
                InTransactionFlag = inTransaction;
                Notify?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                InTransactionFlag = inTransaction;
            }
        }

        public bool IsInTransaction() => InTransactionFlag;
    }
}

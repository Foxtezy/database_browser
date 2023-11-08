using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionManager
{

    public interface ITransactionManager
    {
        bool IsInTransaction();

        void InTransaction(bool inTransaction);
    }
}

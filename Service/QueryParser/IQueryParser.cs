using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.QueryParser
{
    public interface IQueryParser : IDbOperation
    {
        void FindTransactionInQuery(DbConnection connection, string query);
    }
}

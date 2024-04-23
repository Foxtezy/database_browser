using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.QueryParser
{
    public interface IQueryParser
    {
        void FindTransactionInQuery(DbConnection connection, string query);
    }
}

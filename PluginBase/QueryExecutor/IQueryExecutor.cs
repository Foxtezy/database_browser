using System.Data.Common;
using System.Data;

namespace PluginBase.QueryExecutor
{
    public interface IQueryExecutor
    {
        StreamReader Execute(DbConnection connection, string query);
    }
}

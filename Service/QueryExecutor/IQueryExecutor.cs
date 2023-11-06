using System.Data.Common;
using System.Data;

namespace Service.QueryExecutor
{
    public interface IQueryExecutor : IDbOperation
    {
        DataTable Execute(DbConnection connection, string query);
    }
}

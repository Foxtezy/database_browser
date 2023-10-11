using System.Data.Common;
using System.Data;

namespace PlanAnal.QueryExecutor
{
    public interface IQueryExecutor : IDbOperation
    {
        DataTable Execute(DbConnection connection, string query);
    }
}

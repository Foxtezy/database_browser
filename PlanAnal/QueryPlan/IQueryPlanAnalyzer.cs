using System.Data;
using System.Data.Common;

namespace PlanAnal.QueryPlan
{
    public interface IQueryPlanAnalyzer : IDbOperation
    {

        DataTable Analyze(DbConnection connection, string query);
    }
}

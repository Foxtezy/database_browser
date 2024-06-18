using System.Data;
using System.Data.Common;

namespace PluginBase.QueryPlan
{
    public interface IQueryPlanAnalyzer
    {
        QueryPlanRepresentation Analyze(DbConnection connection, string query);
    }
}

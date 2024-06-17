using System.Data;
using System.Data.Common;

namespace PluginBase.QueryPlan
{
    public interface IQueryPlanAnalyzer
    {

        DataTable Analyze(DbConnection connection, string query);
    }
}

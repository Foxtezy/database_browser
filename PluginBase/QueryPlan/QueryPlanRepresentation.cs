using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.QueryPlan
{
    public class QueryPlanRepresentation
    {
        public QueryPlanNode Root;
        public string AdditionalInfo;

        public QueryPlanRepresentation(QueryPlanNode root, string additionalInfo)
        {
            Root = root;
            AdditionalInfo = additionalInfo;
        }
    }
}

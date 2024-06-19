﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.QueryPlan
{
    public class QueryPlanNode
    {
        public string Text { get; set; }
        public List<QueryPlanNode> Children { get; set; } = new List<QueryPlanNode>();
    }
}

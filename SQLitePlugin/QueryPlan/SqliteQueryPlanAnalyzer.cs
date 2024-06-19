
using PluginBase.Logger;
using PluginBase.QueryParser;
using PluginBase.QueryPlan;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace SqlitePlugin.QueryPlan
{
    public class SqliteQueryPlanAnalyzer : IQueryPlanAnalyzer
    {

        private readonly IQueryParser queryParser;

        private readonly IQueryLogger logger;

        public SqliteQueryPlanAnalyzer(IQueryParser queryParser, IQueryLogger logger)
        {
            this.queryParser = queryParser;
            this.logger = logger;
        }


        public QueryPlanRepresentation Analyze(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            DbCommand command = connection.CreateCommand();
            command.CommandText = "EXPLAIN QUERY PLAN " + query;
            logger.Log(command.CommandText);
            DbDataReader reader = command.ExecuteReader();
            DataTable dataTable = new();
            dataTable.Load(reader);
            queryParser.FindTransactionInQuery(connection, query);
            return Parse(dataTable);
        }

        private static QueryPlanRepresentation Parse(DataTable queryPlan)
        {
            Dictionary<long, QueryPlanNode> nodes = new();
            nodes.Add(0, new QueryPlanNode { Text = "Root" });
            // 0 - id, 1 - parent, 2 - notused, 3 - detail
            foreach (DataRow row in queryPlan.Rows) 
            {
                var node = new QueryPlanNode();
                node.Text = (string)row.ItemArray[3];
                long parent = (long)row.ItemArray[1];
                nodes[parent].Children.Add(node);
                nodes.Add((long)row.ItemArray[0], node);
            }
            return new QueryPlanRepresentation(nodes[0], "");
        }
    }
}
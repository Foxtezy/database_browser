
using PluginBase.Logger;
using PluginBase.QueryParser;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PSQLPlugin.QueryPlan
{
    public class PSQLQueryPlanAnalyzer : IQueryPlanAnalyzer
    {

        private readonly IQueryParser queryParser;

        private readonly ITransactionExecutor transactionExecutor;

        private readonly IQueryLogger logger;

        public PSQLQueryPlanAnalyzer(IQueryParser queryParser, IQueryLogger logger, ITransactionExecutor transactionExecutor)
        {
            this.queryParser = queryParser;
            this.logger = logger;
            this.transactionExecutor = transactionExecutor;
        }

        public QueryPlanRepresentation Analyze(DbConnection connection, string query)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            transactionExecutor.BeginTransaction(connection);
            DbCommand command = connection.CreateCommand();
            command.CommandText = "EXPLAIN ANALYZE " + query;
            logger.Log(command.CommandText);
            DbDataReader reader = command.ExecuteReader();
            QueryPlanRepresentation result = Parse(ConvertToString(reader));
            transactionExecutor.RollbackTransaction(connection);
            queryParser.FindTransactionInQuery(connection, query);
            return result;
        }

        private static string ConvertToString(DbDataReader reader)
        {

            var sb = new StringBuilder();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    sb.Append(reader[i]?.ToString());
                }
                sb.AppendLine(); // Переход на новую строку для следующей записи
            }
            reader.Close();
            return sb.ToString();
        }

        private static QueryPlanRepresentation Parse(string queryPlan)
        {
            var lines = queryPlan.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string additionalInfo = lines[lines.Length - 2] + Environment.NewLine + lines[lines.Length - 1];
            var strLines = lines.ToList();
            strLines.RemoveAt(strLines.Count - 1);
            strLines.RemoveAt(strLines.Count - 1);
            lines = strLines.ToArray();
            int index = 0;
            return new QueryPlanRepresentation(ParseNode(lines, ref index), additionalInfo);
        }

        private static QueryPlanNode ParseNode(string[] lines, ref int index)
        {
            var nodeText = new List<string>();
            var currentLine = lines[index];
            var parentLine = currentLine;
            nodeText.Add(currentLine.Trim());
            index++;

            var node = new QueryPlanNode
            {
                Text = string.Join(" ", nodeText)
            };

            while (index < lines.Length)
            {
                currentLine = lines[index];
                if (IsChildNode(currentLine, parentLine))
                {
                    var childNode = ParseNode(lines, ref index);
                    node.Children.Add(childNode);
                }
                else if (GetIndent(parentLine) < GetIndent(currentLine))
                {
                    nodeText.Add(currentLine.Trim());
                    node.Text = string.Join(" ", nodeText);
                    index++;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        private static bool IsChildNode(string currentLine, string parentText)
        {
            // Определяем, является ли текущая строка дочерним узлом
            // Дочерний узел начинается с "->" и имеет больший уровень отступа, чем родительский узел
            int parentIndent = GetIndent(parentText);
            int currentIndent = GetIndent(currentLine);

            return currentLine.Trim().StartsWith("->") && currentIndent > parentIndent;
        }

        private static int GetIndent(string line)
        {
            int indent = 0;
            while (indent < line.Length && line[indent] == ' ')
            {
                indent++;
            }
            return indent;
        }
    }
}
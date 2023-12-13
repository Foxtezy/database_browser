using DBrowser.Models;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.ConnectionService;
using Service.QueryExecutor;
using Service.QueryPlan;
using Service.Transaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBrowser.Controllers
{
    public class OpenSQLitController
    {
        private IConnectionService connectionService;
        private IQueryPlanAnalyzer planAnalyzer;
        private IQueryExecutor queryExecutor;
        private DbName dbName = DbName.SQLite;
        public OpenSQLitController(ServiceProvider serviceProvider)
        {
            var factConnection = serviceProvider.GetService<Func<DbName, IConnectionService>>();
            var factAnalyzer = serviceProvider.GetService<Func<DbName, IQueryPlanAnalyzer>>();
            var factQueryExecutor = serviceProvider.GetService<Func<DbName, IQueryExecutor>>();
            connectionService = factConnection!(dbName);
            planAnalyzer = factAnalyzer!(dbName);
            queryExecutor = factQueryExecutor!(dbName);
        }
        public void openDataBase(string filename)
        {
            DataBase dataBase = new DataBase(filename);
            var connection = connectionService.Connect(dataBase.GetCredentials());
            string queryOfDBSceme = "SELECT t.name AS tbl_name, c.name, c.type, " +
                                        "FROM sqlite_master AS t, " +
                                        "pragma_table_info(t.name) AS c " +
                                        "WHERE t.type = 'table'";
            StreamReader DBSceme = queryExecutor.Execute(connection, queryOfDBSceme);
            List<string> columns = new List<string>();
            List<List<string>> rows = new List<List<string>>();
            Boolean isSucc = parse(DBSceme, columns, rows);
            if (!isSucc)
            {
                // не получается достать схему бд
            }
            foreach (List<string> row in rows)
            {
                Table table;
                if (!dataBase.getTables().TryGetValue(row[0], out table))
                {
                    table = new Table(row[0]);
                    dataBase.getTables().Add(row[0], table);
                }
                table.addColumn(row[1], row[2]);
            }
            
        }

        private static Boolean parse(StreamReader sr, List<string> columns, List<List<string>> rows)
        {
            var str = sr.ReadLine();
            if (str == null)
            {
                return false;
            }
            columns.AddRange(str.Split(":"));
            while ((str = sr.ReadLine()) != null)
            {
                rows.Add(new List<string>(str.Split(":")));
            }
            return true;
        }
    }
}

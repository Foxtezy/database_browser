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
            updateColumnNames(dataBase);
            var connection = connectionService.Connect(dataBase.GetCredentials());
            string queryOfDBSceme = "SELECT DISTINCT t.name AS tbl_name, c.name, c.type, c.dflt_value, c.pk " +
                                        "FROM sqlite_master AS t, " +
                                        "pragma_table_info(t.name) AS c " +
                                        "WHERE t.type = 'table'";
            DataTable DBSceme = queryExecutor.Execute(connection, queryOfDBSceme);
            Debug.WriteLine(DBSceme.Rows[0][0]);
        }
    
        private void updateColumnNames(DataBase dataBase)
        {
            var connection = connectionService.Connect(dataBase.GetCredentials());
            string queryOfUniqueTablesNames = "SELECT DISTINCT t.name " +
                                        "FROM sqlite_master AS t " +
                                        "WHERE t.type = 'table'";
            DataTable DBSceme = queryExecutor.Execute(connection, queryOfUniqueTablesNames);
            foreach(DataRow row in DBSceme.Rows)
            {
                string columnName = row[0].ToString();
                dataBase.getTables().Add(columnName, new Table(columnName));
            }
        }
    
    }
}

using DBrowser.Models;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.ConnectionService;
using Service.QueryExecutor;
using Service.QueryPlan;
using Service.Transaction;
using Service.TransactionManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        private ITransactionExecutor transactionExecutor;
        private DbName dbName = DbName.SQLite;
        private DbConnection connection;
        public OpenSQLitController(ServiceProvider serviceProvider)
        {
            var factConnection = serviceProvider.GetService<Func<DbName, IConnectionService>>();
            var factAnalyzer = serviceProvider.GetService<Func<DbName, IQueryPlanAnalyzer>>();
            var factQueryExecutor = serviceProvider.GetService<Func<DbName, IQueryExecutor>>();
            var factTransaction = serviceProvider.GetService<Func<DbName, ITransactionExecutor>>();
            var transactionManager = serviceProvider.GetService<ITransactionManager>();
            transactionManager!.AddEventHandler((sen, arg) => MessageBox.Show($"Transaction: {transactionManager.IsInTransaction()}"));
            connectionService = factConnection!(dbName);
            planAnalyzer = factAnalyzer!(dbName);
            queryExecutor = factQueryExecutor!(dbName);
            transactionExecutor = factTransaction!(dbName);
        }
        public void openDataBase(string filename)
        {
            DataBase dataBase = new DataBase(filename);
            this.connection = connectionService.Connect(dataBase.GetCredentials());
        }

        public bool hasConnection()
        {
            return connection != null;
        }
        public DbConnection GetDbConnection()
        {
            return connection;
        }
        public IQueryPlanAnalyzer GetQueryPlanAnalyzer()
        {
            return planAnalyzer;
        }
        public ITransactionExecutor GetITransactionExecutor()
        {
            return transactionExecutor;
        }
        public IQueryExecutor GetQueryExecutor()
        {
            return queryExecutor;
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

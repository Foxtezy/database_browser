using DBrowser.Models;
using Microsoft.Extensions.DependencyInjection;
using Service;
using PluginBase.ConnectionService;
using PluginBase.QueryExecutor;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using PluginBase.TransactionManager;
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
using System.Reflection;
using DBrowser.Forms;

namespace DBrowser.Controllers
{
    public class OpenDbController
    {
        private IConnectionService connectionService;
        private IQueryPlanAnalyzer planAnalyzer;
        private IQueryExecutor queryExecutor;
        private ITransactionExecutor transactionExecutor;
        private ITransactionManager transactionManager;
        private DbConnection connection;
        public OpenDbController(IServiceProvider serviceProvider)
        {
            var factConnection = serviceProvider.GetService<IConnectionService>();
            var factAnalyzer = serviceProvider.GetService<IQueryPlanAnalyzer>();
            var factQueryExecutor = serviceProvider.GetService<IQueryExecutor>();
            var factTransact = serviceProvider.GetService<ITransactionExecutor>();
            this.transactionManager = serviceProvider.GetService<ITransactionManager>();
            connectionService = factConnection;
            planAnalyzer = factAnalyzer;
            queryExecutor = factQueryExecutor;
            transactionExecutor = factTransact;
        }
        public void openDataBase()
        {
            ConnectionCredentials cred = getFilledCredentials(connectionService.GetNecessaryFields());
            try
            {
                this.connection = connectionService.Connect(cred);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ConnectionCredentials getFilledCredentials(List<string> necessaryFields)
        {
            ConnectionCredentials credentials = new();
            DynamicCredentialForm dynamicCredentialForm = new DynamicCredentialForm(necessaryFields, credentials);
            DialogResult result = dynamicCredentialForm.ShowDialog();

            return credentials;
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

        public ITransactionManager GetTransactionManager()
        {
            return transactionManager;
        }
        public IQueryExecutor GetQueryExecutor()
        {
            return queryExecutor;
        }
        public ITransactionExecutor GetTransactionExecutor()
        {
            return transactionExecutor;
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

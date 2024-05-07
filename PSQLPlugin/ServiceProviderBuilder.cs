using Microsoft.Extensions.DependencyInjection;
using PluginBase;
using PluginBase.ConnectionService;
using PluginBase.Logger;
using PluginBase.QueryExecutor;
using PluginBase.QueryParser;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using PluginBase.TransactionManager;
using PSQLPlugin.ConnectionService;
using PSQLPlugin.QueryExecutor;
using PSQLPlugin.QueryParser;
using PSQLPlugin.QueryPlan;
using PSQLPlugin.Transaction;
using System;

namespace PSQLPlugin
{
    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        public string DbName => "PostgreSQL";

        private static readonly IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IQueryPlanAnalyzer, PSQLQueryPlanAnalyzer>()
                .AddSingleton<IQueryExecutor, PSQLQueryExecutor>()
                .AddSingleton<IQueryParser, PSQLQueryParser>()
                .AddSingleton<IConnectionService, PSQLConnectionService>()
                .AddSingleton<ITransactionManager, TransactionManager>()
                .AddSingleton<ITransactionExecutor, PSQLTransactionExecutor>()
                .AddSingleton<IQueryLogger, QueryLogger>()
                .AddSingleton<ICsvExporter, CsvExporter>()
                .BuildServiceProvider();

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}

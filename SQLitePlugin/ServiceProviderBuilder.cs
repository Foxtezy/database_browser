using Microsoft.Extensions.DependencyInjection;
using PluginBase;
using PluginBase.ConnectionService;
using PluginBase.Logger;
using PluginBase.QueryExecutor;
using PluginBase.QueryParser;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using PluginBase.TransactionManager;
using SqlitePlugin.ConnectionService;
using SqlitePlugin.QueryExecutor;
using SqlitePlugin.QueryParser;
using SqlitePlugin.QueryPlan;
using SqlitePlugin.Transaction;
using System;

namespace SQLitePlugin
{
    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        public string DbName => "SQLite";

        private static readonly IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IQueryPlanAnalyzer, SqliteQueryPlanAnalyzer>()
                .AddSingleton<IQueryExecutor, SqliteQueryExecutor>()
                .AddSingleton<IQueryParser, SqliteQueryParser>()
                .AddSingleton<IConnectionService, SqliteConnectionService>()
                .AddSingleton<ITransactionManager, TransactionManager>()
                .AddSingleton<ITransactionExecutor, SqliteTransactionExecutor>()
                .AddSingleton<IQueryLogger, QueryLogger>()
                .AddSingleton<ICsvExporter, CsvExporter>()
                .BuildServiceProvider();

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}

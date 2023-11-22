using Microsoft.Extensions.DependencyInjection;
using Service.ConnectionService;
using Service.Logger;
using Service.QueryExecutor;
using Service.QueryParser;
using Service.QueryPlan;
using Service.Transaction;
using Service.TransactionManager;
using Service;

namespace DBrowser
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(buildServiceProvider()));
        }

        static ServiceProvider buildServiceProvider()
        {
            return new ServiceCollection()
            .AddSingleton<IQueryPlanAnalyzer, SqliteQueryPlanAnalyzer>()
            .AddSingleton(
                factory => (Func<DbName, IQueryPlanAnalyzer?>)
                    (key => factory.GetServices<IQueryPlanAnalyzer>().FirstOrDefault(o => o.Name == key))
            )
            .AddSingleton<IQueryExecutor, SqliteQueryExecutor>()
            .AddSingleton(
                factory => (Func<DbName, IQueryExecutor?>)
                    (key => factory.GetServices<IQueryExecutor>().FirstOrDefault(o => o.Name == key))
            )
            .AddSingleton<IQueryParser, SqliteQueryParser>()
            .AddSingleton(
                factory => (Func<DbName, IQueryParser?>)
                    (key => factory.GetServices<IQueryParser>().FirstOrDefault(o => o.Name == key))
            )
            .AddSingleton<IConnectionService, SqliteConnectionService>()
            .AddSingleton(
                factory => (Func<DbName, IConnectionService?>)
                    (key => factory.GetServices<IConnectionService>().FirstOrDefault(o => o.Name == key))
            )
            .AddSingleton<ITransactionManager, TransactionManager>()
            .AddSingleton<ITransactionExecutor, SqliteTransactionExecutor>()
            .AddSingleton(
                factory => (Func<DbName, ITransactionExecutor?>)
                    (key => factory.GetServices<ITransactionExecutor>().FirstOrDefault(o => o.Name == key))
            )
            .AddSingleton<IQueryLogger, QueryLogger>()
            .BuildServiceProvider();
        }
    }
}
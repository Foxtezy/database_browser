using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryPlan;
using Service.QueryExecutor;
using System.Data;
using Service.ConnectionService;
using Service.Transaction;
using Service.TransactionManager;
using Service.QueryParser;
using Service.Logger;

var serviceProvider = buildServiceProvider();

DbName dbName = DbName.SQLite;

var factPlan = serviceProvider.GetService<Func<DbName, IQueryPlanAnalyzer>>();
var factConnection = serviceProvider.GetService<Func<DbName, IConnectionService>>();
var factTransaction = serviceProvider.GetService<Func<DbName, ITransactionExecutor>>();
var transactionManager = serviceProvider.GetService<ITransactionManager>();
var factQueryExecutor = serviceProvider.GetService<Func<DbName, IQueryExecutor>>();

IQueryPlanAnalyzer pa = factPlan!(dbName);
IConnectionService cs = factConnection!(dbName);
ITransactionExecutor te = factTransaction!(dbName);
IQueryExecutor qe = factQueryExecutor!(dbName);

transactionManager!.AddEventHandler((sen, arg) => Console.WriteLine($"Transaction: {transactionManager.IsInTransaction()}"));

ConnectionCredentials connCred = new();
connCred.Path = "C:\\Program Files (x86)\\DB Browser for SQLite\\test.db";
using var connection = cs.Connect(connCred);

string command = "SELECT DISTINCT t.name AS tbl_name, c.name, c.type, c.dflt_value, c.pk " +
                                        "FROM sqlite_master AS t, " +
                                        "pragma_table_info(t.name) AS c " +
                                        "WHERE t.type = 'table'";
// SELECT t.name AS tbl_name, c.name, c.type, c.dflt_value, c.pk
//FROM sqlite_master AS t,
//     pragma_table_info(t.name) AS c
//WHERE t.type = 'table';
S dt = qe.Execute(connection, command);
Console.WriteLine(dt.Columns[0].ToString() + dt.Columns[1].ToString());


//te.CommitTransaction(connection);


static void print(DataTable dt)
{
    foreach (DataColumn column in dt.Columns)
    {
        Console.Write("\t{0}", column.ColumnName);
    }
    Console.WriteLine();
    foreach (DataRow row in dt.Rows)
    {
        var cells = row.ItemArray;
        foreach (object? cell in cells)
            Console.Write("\t{0}", cell);
        Console.WriteLine();
    }
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


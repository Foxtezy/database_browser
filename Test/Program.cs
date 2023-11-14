using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryPlan;
using Service.QueryExecutor;
using System.Data;
using Service.ConnectionService;
using Service.Transaction;
using Service.TransactionManager;


var serviceProvider = buildServiceProvider();

DbName dbName = DbName.SQLite;

var factPlan = serviceProvider.GetService<Func<DbName, IQueryPlanAnalyzer>>();
var factConnection = serviceProvider.GetService<Func<DbName, IConnectionService>>();
var factTransaction = serviceProvider.GetService<Func<DbName, ITransactionExecutor>>();

IQueryPlanAnalyzer pa = factPlan!(dbName);
IConnectionService cs = factConnection!(dbName);
ITransactionExecutor te = factTransaction!(dbName);

ConnectionCredentials connCred = new();
connCred.Path = "C:\\Users\\nmaho\\Downloads\\chinook\\chinook.db";
using var connection = cs.Connect(connCred);

string command = "SELECT ar.ArtistId, ar.Name, al.Title FROM artists AS ar JOIN albums AS al ON al.ArtistId = ar.ArtistId";

te.BeginTransaction(connection);
DataTable dt = pa.Analyze(connection, command);
te.CommitTransaction(connection);

print(dt);


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
    .BuildServiceProvider();
}


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
var factExec = serviceProvider.GetService<Func<DbName, IQueryExecutor>>();

IQueryPlanAnalyzer pa = factPlan!(dbName);
IConnectionService cs = factConnection!(dbName);
ITransactionExecutor te = factTransaction!(dbName);
IQueryExecutor qe = factExec!(dbName);

transactionManager!.AddEventHandler((sen, arg) => Console.WriteLine($"Transaction: {transactionManager.IsInTransaction()}"));

ConnectionCredentials connCred = new();
connCred.Path = "C:\\Program Files (x86)\\DB Browser for SQLite\\test.db";
using var connection = cs.Connect(connCred);

string command = "SELECT t.name AS tbl_name, c.name, c.type " +
                                        "FROM sqlite_master AS t, " +
                                        "pragma_table_info(t.name) AS c " +
                                        "WHERE t.type = 'table'";

StreamReader sr = qe.Execute(connection, command);
//print(sr);
List<string> columns = new List<string>();
List<List<string>> rows = new List<List<string>>();
Boolean isSucc = parse(sr, columns, rows);

foreach (List<string> row in rows)
{
    foreach (string cell in row)
    {
        Console.WriteLine(cell);
    }
}


static Boolean parse(StreamReader sr, List<string> columns, List<List<string>> rows) 
{
    var str = sr.ReadLine();
    if (str == null)
    {
        return false;
    }
    columns.AddRange(str.Split(":"));
    while((str = sr.ReadLine()) != null)
    {
        rows.Add(new List<string>(str.Split(":")));
    }
    return true;
}

static void print(StreamReader sr)
{
    while (!sr.EndOfStream)
    {
        Console.WriteLine(sr.ReadLine());
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
    .AddSingleton<ICsvExporter, CsvExporter>()
    .BuildServiceProvider();
}


using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryPlan;
using Service.QueryExecutor;
using System.Data;
using Service.ConnectioService;

var serviceProvider = new ServiceCollection()
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
    .BuildServiceProvider();

DbName dbName = DbName.SQLite;

var fact = serviceProvider.GetService<Func<DbName, IQueryPlanAnalyzer>>();
var factConnection = serviceProvider.GetService<Func<DbName, IConnectionService>>();

IQueryPlanAnalyzer pa = fact!(dbName);
IConnectionService cs = factConnection!(dbName);

using var connection = cs.Connect(new ConnectionCredentials("C:\\Users\\nmaho\\Downloads\\chinook\\chinook.db"));

string command = "SELECT ar.ArtistId, ar.Name, al.Title FROM artists AS ar JOIN albums AS al ON al.ArtistId = ar.ArtistId";

DataTable dt = pa.Analyze(connection, command);

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


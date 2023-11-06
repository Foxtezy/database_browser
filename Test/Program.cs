using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryPlan;
using Service.QueryExecutor;
using System.Data;



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
    .BuildServiceProvider();


var fact = serviceProvider.GetService<Func<DbName, IQueryPlanAnalyzer>>();

using var connection = new SqliteConnection("Data Source=C:\\Users\\nmaho\\Downloads\\chinook\\chinook.db;Mode=ReadWrite");
string command = "SELECT ar.ArtistId, ar.Name, al.Title FROM artists AS ar JOIN albums AS al ON al.ArtistId = ar.ArtistId";
IQueryPlanAnalyzer pa = fact!(DbName.SQLite);
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


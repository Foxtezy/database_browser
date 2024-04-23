using Microsoft.Extensions.DependencyInjection;
using PluginBase.ConnectionService;
using PluginBase.QueryExecutor;
using Service;
using System.Reflection;




PluginLoader p = new();

Dictionary<string, IServiceProvider> plugins = p.getServiceProviders();
 
IServiceProvider s = plugins["SQLite"];
IConnectionService? cs = s.GetService<IConnectionService>();
IQueryExecutor? qe = s.GetService<IQueryExecutor>();


ConnectionCredentials connCred = new();
connCred.Path = "C:\\Users\\nmaho\\Downloads\\chinook\\chinook.db";
using var connection = cs.Connect(connCred);

string command = "SELECT * FROM artists";

StreamReader sr = qe.Execute(connection, command);
print(sr);

static void print(StreamReader sr)
{
    while (!sr.EndOfStream)
    {
        Console.WriteLine(sr.ReadLine());
    }
}




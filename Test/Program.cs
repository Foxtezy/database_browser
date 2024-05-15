using Microsoft.Extensions.DependencyInjection;
using PluginBase.ConnectionService;
using PluginBase.QueryExecutor;
using Service;
using System.Reflection;

/**
 * Как подключить плагины?
 * Сначала нужно собрать библиотеку с плагином. Пример: Правой кнопкой нажать на SQLitePlugin в SolutionExplorer и нажать Build 
 * Dllи будут лежать в <PluginName>/bin/Debug/net6.0
 * Их нужно скопировать в папку Plugins библиотеки из которой будут вызываться плагины (DBrowser/bin/Debug/net6.0/Plugins/<PluginName>)
 * ВАЖНО!!! Папка с dll плагина должна называться так-же как и сам плагин (SQLitePlugin/PSQLPlugin)
*/

PluginLoader p = new();

Dictionary<string, IServiceProvider> plugins = p.getServiceProviders();

IServiceProvider s = plugins["PostgreSQL"];
IConnectionService? cs = s.GetService<IConnectionService>();
IQueryExecutor? qe = s.GetService<IQueryExecutor>();


ConnectionCredentials connCred = new();
//connCred.Path = "C:\\Users\\nmaho\\Downloads\\chinook\\chinook.db";
connCred.Path = "localhost:5432";
connCred.DatabaseName = "postgres";
connCred.Username = "postgres";
connCred.Password = "postgres";
using var connection = cs.Connect(connCred);

//string command = "SELECT * FROM artists";
string command = "SELECT * FROM SHOPS";

StreamReader sr = qe.Execute(connection, command);
print(sr);

static void print(StreamReader sr)
{
    while (!sr.EndOfStream)
    {
        Console.WriteLine(sr.ReadLine());
    }
}

/*IServiceProvider s = new ServiceProviderBuilder().GetServiceProvider();
IConnectionService? cs = s.GetService<IConnectionService>();
IQueryExecutor? qe = s.GetService<IQueryExecutor>();

ConnectionCredentials connCred = new();
connCred.Path = "localhost:5432";
connCred.DatabaseName = "postgres";
connCred.Username = "postgres";
connCred.Password = "postgres";
using var connection = cs.Connect(connCred);

string command = "SELECT * FROM SHOPS";

StreamReader sr = qe.Execute(connection, command);
print(sr);

static void print(StreamReader sr)
{
    while (!sr.EndOfStream)
    {
        Console.WriteLine(sr.ReadLine());
    }
}*/




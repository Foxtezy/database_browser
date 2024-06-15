using Microsoft.Data.Sqlite;
using PluginBase.ConnectionService;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlitePlugin.ConnectionService
{
    public class SqliteConnectionService : IConnectionService
    {

        public DbConnection Connect(ConnectionCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.Path))
            {
                throw new ArgumentException("Path must be non empty", nameof(credentials.Path));
            }
            return new SqliteConnection($"Data Source={credentials.Path};Mode=ReadWrite");
        }
        public List<string> GetNecessaryFields()
        {
            return new List<string>() {"Path"};
        }
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ConnectioService
{
    public class SqliteConnectionService : IConnectionService
    {
        public DbName Name => DbName.SQLite;

        public DbConnection Connect(ConnectionCredentials credentials)
        {
             return new SqliteConnection($"Data Source={credentials.Path};Mode=ReadWrite");
        }
    }
}

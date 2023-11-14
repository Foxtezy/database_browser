using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ConnectionService
{
    public class SqliteConnectionService : IConnectionService
    {
        public DbName Name => DbName.SQLite;

        public DbConnection Connect(ConnectionCredentials credentials)
        {
            if (string.IsNullOrEmpty(credentials.Path))
            {
                throw new ArgumentException("Path must be non empty", nameof(credentials.Path));
            }
            return new SqliteConnection($"Data Source={credentials.Path};Mode=ReadWrite");
        }
    }
}

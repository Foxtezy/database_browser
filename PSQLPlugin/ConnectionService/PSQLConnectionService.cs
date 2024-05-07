using Npgsql;
using PluginBase.ConnectionService;
using System;
using System.Data.Common;

namespace PSQLPlugin.ConnectionService
{
    public class PSQLConnectionService : IConnectionService
    {

        public DbConnection Connect(ConnectionCredentials creds)
        {
            if (string.IsNullOrEmpty(creds.Path))
            {
                throw new ArgumentException("Path must be non empty", nameof(creds.Path));
            }
            if (string.IsNullOrEmpty(creds.Username))
            {
                throw new ArgumentException("Username must be non empty", nameof(creds.Username));
            }
            if (string.IsNullOrEmpty(creds.Password))
            {
                throw new ArgumentException("Password must be non empty", nameof(creds.Password));
            }
            if (string.IsNullOrEmpty(creds.DatabaseName))
            {
                throw new ArgumentException("DatabaseName must be non empty", nameof(creds.DatabaseName));
            }
            
            return new NpgsqlDataSourceBuilder($"Host={creds.Path};Username={creds.Username};Password={creds.Password};Database={creds.DatabaseName}").Build().OpenConnection(); ;
        }
    }
}

using Service.ConnectionService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBrowser.Models
{
    public class DataBase
    {
        private Dictionary<string, Table> tables = new Dictionary<string, Table>();
        private ConnectionCredentials credentials { get; set; }
        public DataBase(string filename)
        {
            credentials = new ConnectionCredentials();
            credentials.Path = filename;
        }
        public Dictionary<string, Table> getTables()
        {
            return tables;
        }
        
        public ConnectionCredentials GetCredentials()
        {
            return credentials;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ConnectioService
{
    public class ConnectionCredentials
    {
        public string Path { get; }

        public ConnectionCredentials(string path) => Path = path;
    }
}

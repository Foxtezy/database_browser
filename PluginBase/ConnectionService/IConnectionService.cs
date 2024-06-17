using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.ConnectionService
{
    public interface IConnectionService
    {
        DbConnection Connect(ConnectionCredentials credentials);
        List<string> GetNecessaryFields();
    }
}

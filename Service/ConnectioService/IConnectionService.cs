using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ConnectioService
{
    public interface IConnectionService : IDbOperation
    {
        DbConnection Connect(ConnectionCredentials credentials);
    }
}

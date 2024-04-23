using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase
{
    public interface IServiceProviderBuilder
    {
        string DbName { get; }

        IServiceProvider GetServiceProvider();
    }
}

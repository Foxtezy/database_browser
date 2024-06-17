using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginBase.Logger
{
    public interface IQueryLogger : IObservable
    {
        void Log(string query);
    }
}

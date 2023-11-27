using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.QueryExecutor
{
    public interface ICsvExporter
    {
        void DataReaderToCsvFile(DbDataReader dataReader, string path, string separator);
    }
}

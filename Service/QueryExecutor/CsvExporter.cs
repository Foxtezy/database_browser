using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.QueryExecutor
{
    public class CsvExporter : ICsvExporter
    {
        public void DataReaderToCsvFile(DbDataReader dataReader, string path, string separator)
        {
            using StreamWriter sw = new(path);

            StringBuilder sb = new();
            for (int index = 0; index < dataReader.FieldCount; index++)
            {
                if (dataReader.GetName(index) != null)
                    sb.Append(dataReader.GetName(index));

                if (index < dataReader.FieldCount - 1)
                    sb.Append(separator);
            }
            sw.WriteLine(sb.ToString());

            while (dataReader.Read())
            {
                sb = new StringBuilder();
                for (int index = 0; index < dataReader.FieldCount - 1; index++)
                {
                    if (!dataReader.IsDBNull(index))
                    {
                        string value = dataReader.GetValue(index).ToString();
                        if (dataReader.GetFieldType(index) == typeof(String))
                        {
                            if (value.IndexOf("\"") >= 0)
                                value = value.Replace("\"", "\"\"");
                            if (value.IndexOf(separator) >= 0)
                                value = "\"" + value + "\"";
                        }
                        sb.Append(value);
                    }

                    if (index < dataReader.FieldCount - 1)
                        sb.Append(separator);
                }

                if (!dataReader.IsDBNull(dataReader.FieldCount - 1))
                    sb.Append(dataReader.GetValue(dataReader.FieldCount - 1).ToString().Replace(separator, " "));

                sw.WriteLine(sb.ToString());
            }
            dataReader.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBrowser.Models
{
    public class Table
    {
        private string name;
        private Dictionary<string, string> columns = new Dictionary<string, string>();
        public Table(string name)
        {
            this.name = name;
        }
        public void addColumn(string column, string type)
        {
            columns.Add(column, type);
        }
        public Dictionary<string, string> getColumns() {  
            return columns;
        }
    }
}

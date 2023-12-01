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
        private Dictionary<string, DataType> columnsTypes = new Dictionary<string, DataType>();
        public Table(string name)
        {
            this.name = name;
        }
        public void addColumnType(string column, DataType type)
        {
            columnsTypes.Add(column, type);
        }
        public Dictionary<string, DataType> getColumnsTypes() {  
            return columnsTypes;
        }
    }
}

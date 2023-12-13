using DBrowser.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBrowser.Controllers
{
    internal class ShowResultController
    {
        TextBox showResultTextBox;
        public ShowResultController(TextBox showResultTextBox)
        {
           this.showResultTextBox = showResultTextBox;
        }

        public void Show(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void Show(StreamReader streamReader)
        {
            String result = streamReader.ReadToEnd();
            showResultTextBox.Text = result;
        }
    }
}

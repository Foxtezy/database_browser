﻿using DBrowser.Models;
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
        private TextBox showResultTextBox;
        public ShowResultController(TextBox showResultTextBox)
        {
           this.showResultTextBox = showResultTextBox;
        }

        public void Show(DataTable dataTable)
        {
            showResultTextBox.Text = "";
            foreach(DataColumn  dataColumn in dataTable.Columns)
            {
                showResultTextBox.Text += (dataColumn.ColumnName + " ");
            }
            showResultTextBox.Text += "\n";
            foreach (DataRow dataRow in dataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    showResultTextBox.Text = showResultTextBox.Text.Insert(showResultTextBox.Text.Length, item.ToString() + " ");
                }
                showResultTextBox.Text += "\n";
            }
        }
        public String getResultContent()
        {
            return this.showResultTextBox.Text;
        }
        public void Show(StreamReader streamReader)
        {
            showResultTextBox.Text = "";
            String result = streamReader.ReadToEnd();
            showResultTextBox.Text = result;
            streamReader.Close();
        }
    }
}

﻿using DBrowser.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Service;
using PluginBase.QueryExecutor;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using PluginBase.TransactionManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace DBrowser
{
    public partial class UserControl1 : UserControl
    {
        private QueryEditorController queryEditorController;
        private ShowResultController showResultController;
        private FileController fileController;
        private OpenSQLitController openSQLitController;
        private TabPage tabPage;
        private string filePath;
        private ToolStripLabel responseTime;
        private ToolStripLabel hasTransaction;
        private string baseResponseTimeText = "Время получения ответа: ";
        public UserControl1(TabPage tabPage, OpenSQLitController openSQLitController, string filePath, ToolStripLabel transactionStatus)
        {
            InitializeComponent();
            this.queryEditorController = new QueryEditorController(queryEditorTextBox);
            this.showResultController = new ShowResultController(showResultTextBox);
            this.fileController = new FileController();
            this.openSQLitController = openSQLitController;
            this.tabPage = tabPage;
            this.filePath = filePath;
            this.responseTime = new ToolStripLabel();
            responseTime.Text = baseResponseTimeText;

        }
        private void queryPlanToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (!checkDataBaseConnection())
            {
                return;
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            IQueryPlanAnalyzer qp = openSQLitController.GetQueryPlanAnalyzer();
            if (qp != null)
            {
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    responseTime.Text = baseResponseTimeText;
                    DataTable dataTableResult = qp.Analyze(connection, queryEditorController.getQueryContent());
                    showResultController.Show(dataTableResult);
                    stopwatch.Stop();
                    long time = stopwatch.ElapsedMilliseconds;
                    responseTime.Text += time.ToString() + "ms";
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Query executor is null");
            }

        }


        private void очиститьToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            queryEditorController.removeQueryText();
            responseTime.Text = baseResponseTimeText;
        }
        private void отправитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkDataBaseConnection())
            {
                return;
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            IQueryExecutor qe = openSQLitController.GetQueryExecutor();
            if (qe != null)
            {
                try
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    responseTime.Text = baseResponseTimeText;
                    StreamReader sr = qe.Execute(connection, queryEditorController.getQueryContent());
                    showResultController.Show(sr);
                    stopwatch.Stop();
                    long time = stopwatch.ElapsedMilliseconds;
                    responseTime.Text += time.ToString() + "ms";
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Query executor is null");
            }


        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.filePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "SQL Files (*.sql)|*.sql";
                saveFileDialog.Title = "Save SQL File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.filePath = saveFileDialog.FileName;
                    fileController.WriteInFile(filePath, queryEditorController.getQueryContent());
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    tabPage.Text = fileName;
                }
            }
            else
            {
                fileController.WriteInFile(filePath, queryEditorController.getQueryContent());
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                tabPage.Text = fileName;
            }
        }

        public void AddQueryFromFile(string filePath)
        {
            this.filePath = filePath;
            queryEditorController.setContent(fileController.ReadFromFile(filePath));
            tabPage.Text = Path.GetFileNameWithoutExtension(filePath);
        }

        private void queryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!tabPage.Text.EndsWith("*"))
            {
                tabPage.Text = tabPage.Text.Insert(tabPage.Text.Length, "*");
            }
        }

        private void saveQueryResponse(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SQL response (*.txt)|*.txt";
            saveFileDialog.Title = "Save SQL response file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileController.WriteInFile(saveFileDialog.FileName, showResultController.getResultContent());
            }
        }

        private bool checkDataBaseConnection()
        {
            if (!openSQLitController.hasConnection())
            {
                MessageBox.Show("Необходимо подключение");
                return false;
            }
            return true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }



        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void statusStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

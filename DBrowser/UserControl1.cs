using DBrowser.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryExecutor;
using Service.QueryPlan;
using Service.Transaction;
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
        private bool inTransaction;
        private ToolStripLabel responseTime;
        private string baseResponseTimeText = "Время получения ответа: ";
        public UserControl1(TabPage tabPage, OpenSQLitController openSQLitController, string filePath)
        {
            InitializeComponent();
            this.queryEditorController = new QueryEditorController(queryEditorTextBox);
            this.showResultController = new ShowResultController(showResultTextBox);
            this.fileController = new FileController();
            this.openSQLitController = openSQLitController;
            this.tabPage = tabPage;
            this.filePath = filePath;
            this.inTransaction = false;
            this.responseTime = new ToolStripLabel();
            responseTime.Text = baseResponseTimeText;
            statusStrip1.Items.Add(this.responseTime);

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
                Stopwatch stopwatch = Stopwatch.StartNew();
                responseTime.Text = baseResponseTimeText;
                DataTable dataTableResult = qp.Analyze(connection, queryEditorController.getQueryContent());
                showResultController.Show(dataTableResult);
                stopwatch.Stop();
                long time = stopwatch.ElapsedMilliseconds;
                responseTime.Text += time.ToString() + "ms";
            }
            else
            {
                MessageBox.Show("Query executor is null");
            }

        }
        private void BeginTransaction_Click(object sender, EventArgs e)
        {
            if (!checkDataBaseConnection() || inTransaction)
            {
                return;
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            ITransactionExecutor te = openSQLitController.GetTransactionExecutor();
            te!.BeginTransaction(connection);
            транзакцияToolStripMenuItem.Text = транзакцияToolStripMenuItem.Text + " ✓";
            inTransaction = true;
        }

        private void CommitTransaction_Click(object sender, EventArgs e)
        {
            if (!checkDataBaseConnection() || !inTransaction)
            {
                return;
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            ITransactionExecutor te = openSQLitController.GetTransactionExecutor();
            te!.CommitTransaction(connection);
            транзакцияToolStripMenuItem.Text = транзакцияToolStripMenuItem.Text.Replace(" ✓", "");
            inTransaction = false;
        }

        private void RollbackTransaction_Click(object sender, EventArgs e)
        {
            if (!checkDataBaseConnection() || !inTransaction)
            {
                return;
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            ITransactionExecutor te = openSQLitController.GetTransactionExecutor();
            te!.RollbackTransaction(connection);
            транзакцияToolStripMenuItem.Text = транзакцияToolStripMenuItem.Text.Replace(" ✓", "");
            inTransaction = false;
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
                Stopwatch stopwatch = Stopwatch.StartNew();
                responseTime.Text = baseResponseTimeText;
                StreamReader sr = qe.Execute(connection, queryEditorController.getQueryContent());
                showResultController.Show(sr);
                stopwatch.Stop();
                long time = stopwatch.ElapsedMilliseconds;
                responseTime.Text += time.ToString() + "ms";
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
            tabPage.Text= Path.GetFileNameWithoutExtension(filePath);
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
    }
}

using DBrowser.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryExecutor;
using Service.QueryPlan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        public UserControl1(TabPage tabPage, OpenSQLitController openSQLitController, string filePath)
        {
            InitializeComponent();
            this.queryEditorController = new QueryEditorController(queryEditorTextBox);
            this.showResultController = new ShowResultController(showResultTextBox);
            this.fileController = new FileController();
            this.openSQLitController = openSQLitController;
            this.tabPage = tabPage;
            this.filePath = filePath;
        }

        private void начатьТранзакциюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void queryPlanToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            if (!openSQLitController.hasConnection())
            {
                MessageBox.Show("Необходимо подключение");
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            IQueryPlanAnalyzer qp = openSQLitController.GetQueryPlanAnalyzer();
            if (qp != null)
            {
                DataTable dataTableResult = qp.Analyze(connection, queryEditorController.getQueryContent());
                showResultController.Show(dataTableResult);
            }
            else
            {
                MessageBox.Show("Query executor is null");
            }

        }

        private void очиститьToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            queryEditorController.removeQueryText();
        }
        private void отправитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!openSQLitController.hasConnection())
            {
                MessageBox.Show("Необходимо подключение");
            }
            DbConnection connection = openSQLitController.GetDbConnection();
            IQueryExecutor qe = openSQLitController.GetQueryExecutor();
            if (qe != null)
            {
                StreamReader sr = qe.Execute(connection, queryEditorController.getQueryContent());
                showResultController.Show(sr);
            }
            else
            {
                MessageBox.Show("Query executor is null");
            }


        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filePath == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "SQL Files (*.sql)|*.sql";
                saveFileDialog.Title = "Save SQL File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.filePath = saveFileDialog.FileName;
                    fileController.writeInFile(filePath, queryEditorController.getQueryContent());
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    tabPage.Text = fileName;
                }
            }
            else
            {
                fileController.writeInFile(filePath, queryEditorController.getQueryContent());
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                tabPage.Text = fileName;
            }

        }

        private void queryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!tabPage.Text.EndsWith("*"))
            {
                tabPage.Text = tabPage.Text.Insert(tabPage.Text.Length, "*");
            }
        }
    }
}

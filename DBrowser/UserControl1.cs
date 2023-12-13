using DBrowser.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.QueryExecutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private ServiceProvider serviceProvider;
        private TabPage tabPage;
        private string filePath;
        public UserControl1(TabPage tabPage, ServiceProvider serviceProvider, string filePath)
        {
            InitializeComponent();
            this.queryEditorController = new QueryEditorController(queryEditorTextBox);
            this.showResultController = new ShowResultController(showResultTextBox);
            this.fileController = new FileController();
            this.serviceProvider = serviceProvider;
            this.tabPage = tabPage;
            this.filePath = filePath;
        }

        private void начатьТранзакциюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void очиститьToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            queryEditorController.removeQueryText();
        }
        private void отправитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

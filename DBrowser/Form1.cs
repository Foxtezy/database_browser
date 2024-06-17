using DBrowser.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Service;
using PluginBase.ConnectionService;
using PluginBase.QueryPlan;
using PluginBase.Transaction;
using PluginBase.TransactionManager;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using DBrowser.ViewModels;

namespace DBrowser
{
    public partial class Form1 : Form
    {
        private OpenDbController openDataBaseController;
        private ToolStripLabel transactionStatus = new ToolStripLabel();
        private Form1ViewModel form1ViewModel;
        private IServiceProvider current_plugin;
        public Form1()
        {
            this.form1ViewModel = new Form1ViewModel(this);
            InitializeComponent();
            this.current_plugin = form1ViewModel.ChoosePlugin();


            
            openDataBaseController = new OpenDbController(current_plugin);
            var managerTransaction = openDataBaseController.GetTransactionManager();
            statusStrip1.Items.Add(transactionStatus);
            setTransactionStatus(managerTransaction.IsInTransaction());
            managerTransaction.AddEventHandler((sen, arg) => setTransactionStatus(managerTransaction.IsInTransaction()));

            tabControl1.TabPages.Clear();
            tabControl1.SelectedIndexChanged += SelectedTabForNewPage;
            TabPage newPage = new TabPage();
            newPage.Text = "+";
            newPage.Click += newQuery_Click;
            tabControl1.TabPages.Add(newPage);
            newQuery_Click(null, EventArgs.Empty);

            this.StartPosition = FormStartPosition.WindowsDefaultLocation;

            ToolStripMenuItem QueryItem = new ToolStripMenuItem("Запрос");
            var newQuery = new ToolStripMenuItem()
            {
                Name = "Новый запрос",
                Text = "Новый запрос"
            };
            var openQuery = new ToolStripMenuItem()
            {
                Name = "Открыть запрос",
                Text = "Открыть запрос"
            };

            newQuery.Click += newQuery_Click;
            openQuery.Click += openQuery_Click;
            QueryItem.DropDownItems.Add(newQuery);
            QueryItem.DropDownItems.Add(openQuery);
            menuStrip1.Items.Add(QueryItem);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += aboutItem_Click;
            menuStrip1.Items.Add(aboutItem);
            
        }
        void newQuery_Click(object sender, EventArgs e)
        {
            TabPage newQuery = new TabPage();
            newQuery.Text = "Новый запрос";
            UserControl1 frm = new UserControl1(newQuery, this.openDataBaseController, "", this.transactionStatus);
            newQuery.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
            tabControl1.TabPages.Add(newQuery);
            tabControl1.SelectedTab = newQuery;
        }
        void newQuery_Click(object sender, EventArgs e, string filePath)
        {
            TabPage newQuery = new TabPage();
            newQuery.Text = "Новый запрос";
            UserControl1 frm = new UserControl1(newQuery, this.openDataBaseController, "", this.transactionStatus);
            newQuery.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
            tabControl1.TabPages.Add(newQuery);
            tabControl1.SelectedTab = newQuery;
            frm.AddQueryFromFile(filePath);
        }
        void openQuery_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы SQL (*.sql)|*.sql;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                newQuery_Click(null, EventArgs.Empty, openFileDialog.FileName);
            }
        }
        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("О программе");
        }

        private void BeginTransaction_Click(object sender, EventArgs e)
        {
            DbConnection connection = openDataBaseController.GetDbConnection();
            ITransactionExecutor te = openDataBaseController.GetTransactionExecutor();
            ITransactionManager tm = openDataBaseController.GetTransactionManager();
            if (tm.IsInTransaction() == false)
            {
                te!.BeginTransaction(connection);
            }
            else
            {
                noteAboutTransactionStatus();
            }
        }

        private void CommitTransaction_Click(object sender, EventArgs e)
        {

            DbConnection connection = openDataBaseController.GetDbConnection();
            ITransactionExecutor te = openDataBaseController.GetTransactionExecutor();
            ITransactionManager tm = openDataBaseController.GetTransactionManager();
            if (tm.IsInTransaction() == true)
            {
                te!.CommitTransaction(connection);
            }
            else
            {
                noteAboutTransactionStatus();
            }
        }
        private void setTransactionStatus(bool status)
        {
            transactionStatus.Text = $"Transaction: {status}";
            if (status)
            {
                транзакцияToolStripMenuItem.Text = $"Transaction ✓"; 
            }
            else
            {
                транзакцияToolStripMenuItem.Text = $"Transaction";
            }
        }


        private void RollbackTransaction_Click(object sender, EventArgs e)
        {
            DbConnection connection = openDataBaseController.GetDbConnection();
            ITransactionExecutor te = openDataBaseController.GetTransactionExecutor();

            ITransactionManager tm = openDataBaseController.GetTransactionManager();
            if (tm.IsInTransaction() == true)
            {
                te!.RollbackTransaction(connection);
                транзакцияToolStripMenuItem.Text = транзакцияToolStripMenuItem.Text.Replace(" ✓", "");
            }
            else
            {
                noteAboutTransactionStatus();
            }
        }
        private void noteAboutTransactionStatus()
        {
            MessageBox.Show("Unavaivable action for current transaction status", "Check transaction status", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void queryPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void сохрнитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьРезультатЗапросаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void подключениеКБДToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openDataBaseController.openDataBase();
        }

        private void SelectedTabForNewPage(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                newQuery_Click(null, EventArgs.Empty);
            }
        }

        private void нетToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
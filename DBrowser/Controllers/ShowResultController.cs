using DBrowser.Models;
using Microsoft.VisualBasic;
using PluginBase.QueryPlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser.Controllers
{
    internal class ShowResultController
    {
        private Panel showResultPanel;
        private string responseText;
        public ShowResultController(Panel showResultPanel)
        {
           this.showResultPanel = showResultPanel;
        }

        private TreeNode AddNodeToTreeView(TreeNode parent, QueryPlanNode newNodeModel)
        {

            TreeNode newTreeNode = new TreeNode(newNodeModel.Text);

            foreach (QueryPlanNode child in newNodeModel.Children)
            {
                AddNodeToTreeView(newTreeNode, child);
            }

            if (parent == null)
            {
                return newTreeNode;
            }
            parent.Nodes.Add(newTreeNode);
            return parent;
        }

        public string Show(QueryPlanRepresentation queryPlanRepresentation)
        {
            this.responseText = null;
            string additionalInfo = queryPlanRepresentation.AdditionalInfo;
            QueryPlanNode rootModel = queryPlanRepresentation.Root;
            TreeNode rootNode = AddNodeToTreeView(null, rootModel);
            TreeView treeView = new TreeView();
            treeView.Dock = DockStyle.Fill;
            treeView.Nodes.Add(rootNode);
            showResultPanel.Controls.Clear();
            showResultPanel.Controls.Add(treeView);
            return additionalInfo;

        }
        public String getResultContent()
        {
            if (responseText == null)
            {
                MessageBox.Show("Can't save the tree in the file yet");
                return "";
            }
            return this.responseText;
        }
        public string Show(StreamReader streamReader)
        {
            String result = streamReader.ReadToEnd();
            streamReader.Close();
            this.responseText = result;
            string[] rows = result.Split("\r\n");
            int tables = 0;
            string[] columnNames = new string[0];
            if (rows.Length != 0)
            {
                tables = rows[0].Split(":").Length;
                columnNames = rows[0].Split(":");
            }
            var dataGreed = new DataGridView();
            dataGreed.Dock = DockStyle.Fill;
            dataGreed.Name = "dataGridViewNAME";
            dataGreed.ColumnCount = tables;
            
            for(int i = 0; i <  tables; i++) 
            {
                dataGreed.Columns[i].Name = columnNames[i];
            }

            for(int i = 1; i < rows.Length; i++)
            {
                string[] row = rows[i].Split(":");
/*                for(int j = 0; i < row.Length; i++)
                {
                    if (row[j].GetType().IsArray)
                    {
                        string newString = String.Join(", ", row[j]);
                        row[j] = newString;
                    }
                }
*/
                dataGreed.Rows.Add(row);
            }
            showResultPanel.Controls.Clear();
            showResultPanel.Controls.Add(dataGreed);
            return $"Columns: {rows.Length}";
        }
    }
}

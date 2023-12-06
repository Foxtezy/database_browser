using DBrowser.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser
{
    public partial class UserControl1 : UserControl
    {
        private QueryEditorController queryEditorController;
        private ShowResultController showResultController;

        public UserControl1()
        {
            InitializeComponent();
            this.queryEditorController = new QueryEditorController(queryEditorTextBox);
            this.showResultController = new ShowResultController(showResultTextBox);
        }



        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void начатьТранзакциюToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void удалитьСодержимоеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            queryEditorController.removeQueryText();
        }
    }
}

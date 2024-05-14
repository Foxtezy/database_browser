using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBrowser.Controllers
{
    internal class QueryEditorController
    {
        private TextBox currentTextBox;
        //private QueryParse queryParse = null;
        public QueryEditorController(TextBox textBox) 
        {
            this.currentTextBox = textBox;
        //    this.queryParse = new QueryParse();
        }

        public void removeQueryText()
        {
            this.currentTextBox.Text = "";
        }

        public void setContent(string newContent)
        {
            this.currentTextBox.Text = newContent;
        }
        
        public string getQueryContent()
        {
            return this.currentTextBox.Text;
        }
        /*
        private class QueryParse
        {
            public bool checkQueryMisstakes()
            {
                return true; // TODO 
            }
        }
        */

    }
}

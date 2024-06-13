using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DBrowser.Forms;

namespace DBrowser.ViewModels
{
    internal class Form1ViewModel
    {
        Form form1;
        IServiceProvider plugin;
        
        public Form1ViewModel(Form form1)
        {
            this.form1 = form1;
        }

        public void SetPlugin(IServiceProvider plugin)
        {
            this.plugin = plugin;
        }

        public IServiceProvider GetPlugin()
        {
            return this.plugin;
        }

        public IServiceProvider ChoosePlugin()
        {
            var choose_window = new ChosePluginForm(this);
            choose_window.ShowDialog();
            return this.plugin;
        }


    }
}

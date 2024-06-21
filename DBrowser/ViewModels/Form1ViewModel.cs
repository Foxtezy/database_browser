using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using DBrowser.Forms;
using Microsoft.Extensions.DependencyInjection;
using PluginBase.ConnectionService;
using PluginBase.QueryExecutor;

namespace DBrowser.ViewModels
{
    public class Form1ViewModel
    {
        Form form1;
        IServiceProvider plugin;
        string lastPluginName;


        public Form1ViewModel(Form form1)
        {
            this.form1 = form1;
        }

        public void SetPluginName(string name)
        {
            this.lastPluginName = name;
        }

        public IServiceProvider GetPlugin()
        {
            return this.plugin;
        }

        public IServiceProvider ChoosePlugin()
        {
            
            var choose_window = new ChosePluginForm(this);
            choose_window.ShowDialog();

            PluginLoader p = new();

            Dictionary<string, IServiceProvider> plugins = p.getServiceProviders();
            

            if (lastPluginName != null)
            {
                var s = plugins[lastPluginName];
                return s;
            }
            else
            {
                return null;   
            }

        }


    }
}

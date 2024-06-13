using DBrowser.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser.Forms
{
    public partial class ChosePluginForm : Form
    {
        private Form1ViewModel form1ViewModel;
        public ChosePluginForm(Form1ViewModel form1ViewModel)
        {
            this.form1ViewModel = form1ViewModel;
            InitializeComponent();
        }

        private void Update_button__Click(object sender, EventArgs e)
        {
            PluginLoader loader = new PluginLoader();
            DirectoryInfo[] plugins_directories = loader.GetPluginDirectories();
            plugins_list.Items.Clear();
            for (int i = 0; i < plugins_directories.Length; i++)
            {
                plugins_list.Items.Add(plugins_directories[i].Name, false);
            }
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {

        }
    }
}

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
        private string selectedPlugin;
        private ICollection<string> plugin_names;
        public ChosePluginForm(Form1ViewModel form1ViewModel)
        {
            InitializeComponent();
            this.form1ViewModel = form1ViewModel;
            UpdatePlugins();
        }

        private void Update_button__Click(object sender, EventArgs e)
        {
            UpdatePlugins();
        }

        private void UpdatePlugins()
        {
            PluginLoader p = new();

            Dictionary<string, IServiceProvider> plugins = p.getServiceProviders();
            plugin_names = plugins.Keys.ToList();
            plugins_list.Items.Clear();
            foreach (string name in plugin_names)
            {
                plugins_list.Items.Add(name, false);
                selectedPlugin = name;
            }
            plugin_label.Text = $"Выбран плагин: {this.selectedPlugin}";
        }

        private void ChosePluginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1ViewModel.SetPluginName(selectedPlugin);
        }

        private void Accept_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Plugin_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                selectedPlugin = plugins_list.Items[e.Index].ToString();

                plugins_list.ItemCheck -= Plugin_list_ItemCheck;

                // Снять отметку со всех элементов
                for (int i = 0; i < plugins_list.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        plugins_list.SetItemChecked(i, false);
                    }
                }

                // Вернуть обработчик событий
                plugins_list.ItemCheck += Plugin_list_ItemCheck;
            }
            plugin_label.Text = $"Выбран плагин: {this.selectedPlugin}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

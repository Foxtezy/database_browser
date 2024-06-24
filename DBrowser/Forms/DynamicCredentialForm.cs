using PluginBase.ConnectionService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser.Forms
{
    public partial class DynamicCredentialForm : Form
 {
        private List<string> fieldsList;
        private List<Tuple<Label, TextBox>> labelTextBoxPairs;
        private ConnectionCredentials emptyCredentials;

        public DynamicCredentialForm(List<string> fields, ConnectionCredentials emptyCredentials)
        {
            this.emptyCredentials = emptyCredentials;
            InitializeComponent();

            this.fieldsList = fields;

            this.labelTextBoxPairs = new List<Tuple<Label, TextBox>>();
            InitializeTextBoxes();
            InitializeButtons();
            int formHeight = 30 + fieldsList.Count * 30 + 100;
            this.Size = new System.Drawing.Size(480, formHeight);
        }

        private void InitializeTextBoxes()
        {
            int startY = 30;
            int spacing = 30;

            
            for (int i = 0; i < fieldsList.Count; i++)
            {
                
                Label label = new Label();
                label.Text = fieldsList[i];
                label.Location = new System.Drawing.Point(20, startY + i * spacing);
                label.Size = new System.Drawing.Size(100, 20);
                this.Controls.Add(label);

                
                TextBox textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(130, startY + i * spacing);
                textBox.Size = new System.Drawing.Size(200, 20);
                textBox.TextChanged += new EventHandler(TextBox_TextChanged); // Добавление обработчика события
                this.Controls.Add(textBox);

                if (label.Text.Equals("Path"))
                {
                    Button browseButton = new Button();
                    browseButton.Text = "Browse";
                    browseButton.Location = new System.Drawing.Point(340, startY + i * spacing);
                    browseButton.Size = new System.Drawing.Size(75, 23);
                    browseButton.Click += new EventHandler((sender, e) =>
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            textBox.Text = openFileDialog.FileName;
                        }
                    });
                    this.Controls.Add(browseButton);
                }

                
                labelTextBoxPairs.Add(new Tuple<Label, TextBox>(label, textBox));
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                var pair = labelTextBoxPairs.Find(p => p.Item2 == textBox);
                if (pair != null)
                {
                    string fieldName = pair.Item1.Text;
                    string newValue = textBox.Text;

                    Type type = emptyCredentials.GetType();
                    PropertyInfo propertyInfo = type.GetProperty(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(emptyCredentials, newValue);                       
                    }
                }
            }
        }

        private void InitializeButtons()
        {
            
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new System.Drawing.Point(130, 30 + fieldsList.Count * 30 + 20);
            okButton.Click += new EventHandler(OkButton_Click);
            this.Controls.Add(okButton);

            
            Button cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Location = new System.Drawing.Point(230, 30 + fieldsList.Count * 30 + 20);
            cancelButton.Click += new EventHandler(CancelButton_Click);
            this.Controls.Add(cancelButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            List<string> inputData = new List<string>();
            foreach (var pair in labelTextBoxPairs)
            {
                inputData.Add(pair.Item2.Text);
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}

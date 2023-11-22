using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace DBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.TabPages.Clear();
            TabPage newPage = new TabPage();
            newPage.Text = "+";
            newPage.Click += newQuery_Click;
            tabControl1.TabPages.Add(newPage);

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

            void aboutItem_Click(object sender, EventArgs e)
            {
                MessageBox.Show("О программе");
            }



        }
        void newQuery_Click(object sender, EventArgs e)
        {
            TabPage newQuery = new TabPage();
            newQuery.Text = "Новый запрос";
            UserControl1 frm = new UserControl1();
            newQuery.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
            tabControl1.TabPages.Add(newQuery);
            newQuery.Select();
        }
        void openQuery_Click(object sender, EventArgs e)
        {
            TabPage newQuery = new TabPage();
            newQuery.Text = "файл";
            UserControl1 frm = new UserControl1();
            newQuery.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
            tabControl1.TabPages.Add(newQuery);
        }

        private void Form1_Load(object sender, EventArgs e)
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
    }
}
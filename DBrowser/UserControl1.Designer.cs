namespace DBrowser
{
    partial class UserControl1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            удалитьToolStripMenuItem1 = new ToolStripMenuItem();
            отправитьToolStripMenuItem = new ToolStripMenuItem();
            начатьТранзакциюToolStripMenuItem = new ToolStripMenuItem();
            queryPlanToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { удалитьToolStripMenuItem, удалитьToolStripMenuItem1, отправитьToolStripMenuItem, начатьТранзакциюToolStripMenuItem, queryPlanToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(810, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(78, 20);
            удалитьToolStripMenuItem.Text = "Сохранить";
            удалитьToolStripMenuItem.Click += удалитьToolStripMenuItem_Click;
            // 
            // удалитьToolStripMenuItem1
            // 
            удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            удалитьToolStripMenuItem1.Size = new Size(63, 20);
            удалитьToolStripMenuItem1.Text = "Удалить";
            // 
            // отправитьToolStripMenuItem
            // 
            отправитьToolStripMenuItem.Name = "отправитьToolStripMenuItem";
            отправитьToolStripMenuItem.Size = new Size(77, 20);
            отправитьToolStripMenuItem.Text = "Отправить";
            // 
            // начатьТранзакциюToolStripMenuItem
            // 
            начатьТранзакциюToolStripMenuItem.Name = "начатьТранзакциюToolStripMenuItem";
            начатьТранзакциюToolStripMenuItem.Size = new Size(82, 20);
            начатьТранзакциюToolStripMenuItem.Text = "Транзакция";
            начатьТранзакциюToolStripMenuItem.Click += начатьТранзакциюToolStripMenuItem_Click;
            // 
            // queryPlanToolStripMenuItem
            // 
            queryPlanToolStripMenuItem.Name = "queryPlanToolStripMenuItem";
            queryPlanToolStripMenuItem.Size = new Size(77, 20);
            queryPlanToolStripMenuItem.Text = "Query plan";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Size = new Size(810, 570);
            splitContainer1.SplitterDistance = 281;
            splitContainer1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(810, 281);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(810, 285);
            textBox1.TabIndex = 0;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Name = "UserControl1";
            Size = new Size(810, 594);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem1;
        private ToolStripMenuItem отправитьToolStripMenuItem;
        private ToolStripMenuItem начатьТранзакциюToolStripMenuItem;
        private ToolStripMenuItem queryPlanToolStripMenuItem;
        private SplitContainer splitContainer1;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
    }
}

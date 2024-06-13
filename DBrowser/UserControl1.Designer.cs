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
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            очиститьToolStripMenuItem = new ToolStripMenuItem();
            отправитьToolStripMenuItem = new ToolStripMenuItem();
            queryPlanToolStripMenuItem = new ToolStripMenuItem();
            сохранитьОтветToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            queryEditorTextBox = new TextBox();
            showResultTextBox = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem, очиститьToolStripMenuItem, отправитьToolStripMenuItem, queryPlanToolStripMenuItem, сохранитьОтветToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(810, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            сохранитьToolStripMenuItem.Size = new Size(78, 20);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // очиститьToolStripMenuItem
            // 
            очиститьToolStripMenuItem.Checked = true;
            очиститьToolStripMenuItem.CheckState = CheckState.Checked;
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Size = new Size(71, 20);
            очиститьToolStripMenuItem.Text = "Очистить";
            очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
            // 
            // отправитьToolStripMenuItem
            // 
            отправитьToolStripMenuItem.Name = "отправитьToolStripMenuItem";
            отправитьToolStripMenuItem.Size = new Size(77, 20);
            отправитьToolStripMenuItem.Text = "Отправить";
            отправитьToolStripMenuItem.Click += отправитьToolStripMenuItem_Click;
            // 
            // queryPlanToolStripMenuItem
            // 
            queryPlanToolStripMenuItem.Checked = true;
            queryPlanToolStripMenuItem.CheckOnClick = true;
            queryPlanToolStripMenuItem.CheckState = CheckState.Checked;
            queryPlanToolStripMenuItem.Name = "queryPlanToolStripMenuItem";
            queryPlanToolStripMenuItem.Size = new Size(77, 20);
            queryPlanToolStripMenuItem.Text = "Query plan";
            queryPlanToolStripMenuItem.Click += queryPlanToolStripMenuItem_Click;
            // 
            // сохранитьОтветToolStripMenuItem
            // 
            сохранитьОтветToolStripMenuItem.Name = "сохранитьОтветToolStripMenuItem";
            сохранитьОтветToolStripMenuItem.Size = new Size(110, 20);
            сохранитьОтветToolStripMenuItem.Text = "Сохранить ответ";
            сохранитьОтветToolStripMenuItem.Click += saveQueryResponse;
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
            splitContainer1.Panel1.Controls.Add(queryEditorTextBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(showResultTextBox);
            splitContainer1.Size = new Size(810, 570);
            splitContainer1.SplitterDistance = 281;
            splitContainer1.TabIndex = 1;
            // 
            // queryEditorTextBox
            // 
            queryEditorTextBox.AcceptsReturn = true;
            queryEditorTextBox.AcceptsTab = true;
            queryEditorTextBox.Dock = DockStyle.Fill;
            queryEditorTextBox.Location = new Point(0, 0);
            queryEditorTextBox.Multiline = true;
            queryEditorTextBox.Name = "queryEditorTextBox";
            queryEditorTextBox.ScrollBars = ScrollBars.Both;
            queryEditorTextBox.Size = new Size(810, 281);
            queryEditorTextBox.TabIndex = 1;
            queryEditorTextBox.TextChanged += queryTextBox_TextChanged;
            // 
            // showResultTextBox
            // 
            showResultTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            showResultTextBox.Location = new Point(0, 0);
            showResultTextBox.Multiline = true;
            showResultTextBox.Name = "showResultTextBox";
            showResultTextBox.ReadOnly = true;
            showResultTextBox.ScrollBars = ScrollBars.Both;
            showResultTextBox.Size = new Size(810, 282);
            showResultTextBox.TabIndex = 0;
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
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem отправитьToolStripMenuItem;
        private ToolStripMenuItem queryPlanToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TextBox showResultTextBox;
        private TextBox queryEditorTextBox;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private ToolStripMenuItem сохранитьОтветToolStripMenuItem;
        private StatusStrip statusStrip1;
    }
}

namespace DBrowser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            menuStrip1 = new MenuStrip();
            подключитьсяToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохрнитьКакToolStripMenuItem = new ToolStripMenuItem();
            сохранитьФайлToolStripMenuItem = new ToolStripMenuItem();
            автосохранениеToolStripMenuItem = new ToolStripMenuItem();
            отключеноToolStripMenuItem = new ToolStripMenuItem();
            минToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            автосохранениеToolStripMenuItem1 = new ToolStripMenuItem();
            нетToolStripMenuItem = new ToolStripMenuItem();
            минToolStripMenuItem1 = new ToolStripMenuItem();
            подключениеКБДToolStripMenuItem = new ToolStripMenuItem();
            открытьРезультатЗапросаToolStripMenuItem = new ToolStripMenuItem();
            историяToolStripMenuItem = new ToolStripMenuItem();
            транзакцияToolStripMenuItem = new ToolStripMenuItem();
            начатьToolStripMenuItem = new ToolStripMenuItem();
            завершитьToolStripMenuItem = new ToolStripMenuItem();
            отменитьИзмененияToolStripMenuItem = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            tabControl1 = new TabControl();
            statusStrip1 = new StatusStrip();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(150, 125);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { подключитьсяToolStripMenuItem, подключениеКБДToolStripMenuItem, открытьРезультатЗапросаToolStripMenuItem, историяToolStripMenuItem, транзакцияToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // подключитьсяToolStripMenuItem
            // 
            подключитьсяToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохрнитьКакToolStripMenuItem, настройкиToolStripMenuItem });
            подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            подключитьсяToolStripMenuItem.Size = new Size(59, 20);
            подключитьсяToolStripMenuItem.Text = "Проект";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(154, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохрнитьКакToolStripMenuItem
            // 
            сохрнитьКакToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьФайлToolStripMenuItem, автосохранениеToolStripMenuItem });
            сохрнитьКакToolStripMenuItem.Name = "сохрнитьКакToolStripMenuItem";
            сохрнитьКакToolStripMenuItem.Size = new Size(154, 22);
            сохрнитьКакToolStripMenuItem.Text = "Сохранить как";
            сохрнитьКакToolStripMenuItem.Click += сохрнитьКакToolStripMenuItem_Click;
            // 
            // сохранитьФайлToolStripMenuItem
            // 
            сохранитьФайлToolStripMenuItem.Name = "сохранитьФайлToolStripMenuItem";
            сохранитьФайлToolStripMenuItem.Size = new Size(165, 22);
            сохранитьФайлToolStripMenuItem.Text = "Сохранить файл";
            // 
            // автосохранениеToolStripMenuItem
            // 
            автосохранениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { отключеноToolStripMenuItem, минToolStripMenuItem });
            автосохранениеToolStripMenuItem.Name = "автосохранениеToolStripMenuItem";
            автосохранениеToolStripMenuItem.Size = new Size(165, 22);
            автосохранениеToolStripMenuItem.Text = "Автосохранение";
            // 
            // отключеноToolStripMenuItem
            // 
            отключеноToolStripMenuItem.CheckOnClick = true;
            отключеноToolStripMenuItem.Name = "отключеноToolStripMenuItem";
            отключеноToolStripMenuItem.Size = new Size(138, 22);
            отключеноToolStripMenuItem.Text = "Отключено";
            // 
            // минToolStripMenuItem
            // 
            минToolStripMenuItem.Name = "минToolStripMenuItem";
            минToolStripMenuItem.Size = new Size(138, 22);
            минToolStripMenuItem.Text = "5 мин";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { автосохранениеToolStripMenuItem1 });
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(154, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // автосохранениеToolStripMenuItem1
            // 
            автосохранениеToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { нетToolStripMenuItem, минToolStripMenuItem1 });
            автосохранениеToolStripMenuItem1.Name = "автосохранениеToolStripMenuItem1";
            автосохранениеToolStripMenuItem1.Size = new Size(165, 22);
            автосохранениеToolStripMenuItem1.Text = "Автосохранение";
            // 
            // нетToolStripMenuItem
            // 
            нетToolStripMenuItem.Checked = true;
            нетToolStripMenuItem.CheckOnClick = true;
            нетToolStripMenuItem.CheckState = CheckState.Checked;
            нетToolStripMenuItem.Name = "нетToolStripMenuItem";
            нетToolStripMenuItem.Size = new Size(106, 22);
            нетToolStripMenuItem.Text = "Нет";
            нетToolStripMenuItem.Click += нетToolStripMenuItem_Click;
            // 
            // минToolStripMenuItem1
            // 
            минToolStripMenuItem1.Checked = true;
            минToolStripMenuItem1.CheckOnClick = true;
            минToolStripMenuItem1.CheckState = CheckState.Checked;
            минToolStripMenuItem1.Name = "минToolStripMenuItem1";
            минToolStripMenuItem1.Size = new Size(106, 22);
            минToolStripMenuItem1.Text = "5 мин";
            // 
            // подключениеКБДToolStripMenuItem
            // 
            подключениеКБДToolStripMenuItem.Name = "подключениеКБДToolStripMenuItem";
            подключениеКБДToolStripMenuItem.Size = new Size(87, 20);
            подключениеКБДToolStripMenuItem.Text = "База данных";
            подключениеКБДToolStripMenuItem.Click += подключениеКБДToolStripMenuItem_Click;
            // 
            // открытьРезультатЗапросаToolStripMenuItem
            // 
            открытьРезультатЗапросаToolStripMenuItem.Name = "открытьРезультатЗапросаToolStripMenuItem";
            открытьРезультатЗапросаToolStripMenuItem.Size = new Size(169, 20);
            открытьРезультатЗапросаToolStripMenuItem.Text = "Открыть результат запроса";
            открытьРезультатЗапросаToolStripMenuItem.Click += открытьРезультатЗапросаToolStripMenuItem_Click;
            // 
            // историяToolStripMenuItem
            // 
            историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            историяToolStripMenuItem.Size = new Size(66, 20);
            историяToolStripMenuItem.Text = "История";
            // 
            // транзакцияToolStripMenuItem
            // 
            транзакцияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { начатьToolStripMenuItem, завершитьToolStripMenuItem, отменитьИзмененияToolStripMenuItem });
            транзакцияToolStripMenuItem.Name = "транзакцияToolStripMenuItem";
            транзакцияToolStripMenuItem.Size = new Size(82, 20);
            транзакцияToolStripMenuItem.Text = "Транзакция";
            // 
            // начатьToolStripMenuItem
            // 
            начатьToolStripMenuItem.Name = "начатьToolStripMenuItem";
            начатьToolStripMenuItem.Size = new Size(191, 22);
            начатьToolStripMenuItem.Text = "Начать";
            начатьToolStripMenuItem.Click += BeginTransaction_Click;
            // 
            // завершитьToolStripMenuItem
            // 
            завершитьToolStripMenuItem.Name = "завершитьToolStripMenuItem";
            завершитьToolStripMenuItem.Size = new Size(191, 22);
            завершитьToolStripMenuItem.Text = "Завершить";
            завершитьToolStripMenuItem.Click += CommitTransaction_Click;
            // 
            // отменитьИзмененияToolStripMenuItem
            // 
            отменитьИзмененияToolStripMenuItem.Name = "отменитьИзмененияToolStripMenuItem";
            отменитьИзмененияToolStripMenuItem.Size = new Size(191, 22);
            отменитьИзмененияToolStripMenuItem.Text = "Отменить изменения";
            отменитьИзмененияToolStripMenuItem.Click += RollbackTransaction_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 3, 4, 3);
            tabPage2.Size = new Size(1176, 358);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 250);
            tabPage1.Size = new Size(1176, 371);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 27);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1184, 399);
            tabControl1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 416);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1184, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ItemClicked += statusStrip1_ItemClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 438);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "DBrowser";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem подключитьсяToolStripMenuItem;
        private ToolStripMenuItem сохрнитьКакToolStripMenuItem;
        private ToolStripMenuItem сохранитьФайлToolStripMenuItem;
        private ToolStripMenuItem автосохранениеToolStripMenuItem;
        private ToolStripMenuItem отключеноToolStripMenuItem;
        private ToolStripMenuItem минToolStripMenuItem;
        private ToolStripMenuItem подключениеКБДToolStripMenuItem;
        private ToolStripMenuItem открытьРезультатЗапросаToolStripMenuItem;
        private ToolStripMenuItem историяToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem автосохранениеToolStripMenuItem1;
        private ToolStripMenuItem нетToolStripMenuItem;
        private ToolStripMenuItem минToolStripMenuItem1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabControl tabControl1;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem транзакцияToolStripMenuItem;
        private ToolStripMenuItem начатьToolStripMenuItem;
        private ToolStripMenuItem завершитьToolStripMenuItem;
        private ToolStripMenuItem отменитьИзмененияToolStripMenuItem;
        private StatusStrip statusStrip1;
    }
}
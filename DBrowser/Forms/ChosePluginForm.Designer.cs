namespace DBrowser.Forms
{
    partial class ChosePluginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            plugins_list = new CheckedListBox();
            update_button = new Button();
            accept_button = new Button();
            cancel_button = new Button();
            SuspendLayout();
            // 
            // plugins_list
            // 
            plugins_list.FormattingEnabled = true;
            plugins_list.Location = new Point(34, 37);
            plugins_list.Name = "plugins_list";
            plugins_list.Size = new Size(173, 256);
            plugins_list.TabIndex = 0;
            // 
            // update_button
            // 
            update_button.Location = new Point(283, 139);
            update_button.Name = "update_button";
            update_button.Size = new Size(156, 44);
            update_button.TabIndex = 1;
            update_button.Text = "Обновить";
            update_button.UseVisualStyleBackColor = true;
            update_button.Click += Update_button__Click;
            // 
            // accept_button
            // 
            accept_button.Location = new Point(399, 295);
            accept_button.Name = "accept_button";
            accept_button.Size = new Size(79, 23);
            accept_button.TabIndex = 2;
            accept_button.Text = "Применить";
            accept_button.UseVisualStyleBackColor = true;
            accept_button.Click += Accept_button_Click;
            // 
            // cancel_button
            // 
            cancel_button.Location = new Point(314, 295);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(79, 23);
            cancel_button.TabIndex = 3;
            cancel_button.Text = "Отмена";
            cancel_button.UseVisualStyleBackColor = true;
            cancel_button.Click += Cancel_button_Click;
            // 
            // ChosePluginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 330);
            Controls.Add(cancel_button);
            Controls.Add(accept_button);
            Controls.Add(update_button);
            Controls.Add(plugins_list);
            Name = "ChosePluginForm";
            Text = "ChosePluginForm";
            ResumeLayout(false);
        }

        #endregion

        private CheckedListBox plugins_list;
        private Button update_button;
        private Button accept_button;
        private Button cancel_button;
    }
}
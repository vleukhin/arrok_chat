namespace arrok__chat
{
    partial class settings_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings_form));
            this.settings_menu_listbox = new System.Windows.Forms.ListBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.personal_panel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ldir_txt = new System.Windows.Forms.TextBox();
            this.select_ldir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddir_txt = new System.Windows.Forms.TextBox();
            this.select_ddir = new System.Windows.Forms.Button();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.personal_panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // settings_menu_listbox
            // 
            this.settings_menu_listbox.FormattingEnabled = true;
            this.settings_menu_listbox.Items.AddRange(new object[] {
            "Персонализация"});
            this.settings_menu_listbox.Location = new System.Drawing.Point(12, 12);
            this.settings_menu_listbox.Name = "settings_menu_listbox";
            this.settings_menu_listbox.Size = new System.Drawing.Size(120, 199);
            this.settings_menu_listbox.TabIndex = 0;
            this.settings_menu_listbox.SelectedIndexChanged += new System.EventHandler(this.settings_menu_listbox_SelectedIndexChanged);
            // 
            // save_btn
            // 
            this.save_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save_btn.Location = new System.Drawing.Point(261, 233);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 1;
            this.save_btn.Text = "Сохранить";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Location = new System.Drawing.Point(465, 233);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 2;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // personal_panel
            // 
            this.personal_panel.Controls.Add(this.groupBox2);
            this.personal_panel.Controls.Add(this.groupBox1);
            this.personal_panel.Location = new System.Drawing.Point(142, 15);
            this.personal_panel.Name = "personal_panel";
            this.personal_panel.Size = new System.Drawing.Size(398, 196);
            this.personal_panel.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ldir_txt);
            this.groupBox2.Controls.Add(this.select_ldir);
            this.groupBox2.Location = new System.Drawing.Point(3, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 61);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Папка для логов";
            // 
            // ldir_txt
            // 
            this.ldir_txt.Location = new System.Drawing.Point(6, 29);
            this.ldir_txt.Name = "ldir_txt";
            this.ldir_txt.ReadOnly = true;
            this.ldir_txt.Size = new System.Drawing.Size(347, 20);
            this.ldir_txt.TabIndex = 0;
            // 
            // select_ldir
            // 
            this.select_ldir.Location = new System.Drawing.Point(359, 26);
            this.select_ldir.Name = "select_ldir";
            this.select_ldir.Size = new System.Drawing.Size(27, 23);
            this.select_ldir.TabIndex = 2;
            this.select_ldir.Text = "...";
            this.select_ldir.UseVisualStyleBackColor = true;
            this.select_ldir.Click += new System.EventHandler(this.select_ldir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ddir_txt);
            this.groupBox1.Controls.Add(this.select_ddir);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 61);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Папка для закрузки";
            // 
            // ddir_txt
            // 
            this.ddir_txt.Location = new System.Drawing.Point(6, 29);
            this.ddir_txt.Name = "ddir_txt";
            this.ddir_txt.ReadOnly = true;
            this.ddir_txt.Size = new System.Drawing.Size(347, 20);
            this.ddir_txt.TabIndex = 0;
            // 
            // select_ddir
            // 
            this.select_ddir.Location = new System.Drawing.Point(359, 26);
            this.select_ddir.Name = "select_ddir";
            this.select_ddir.Size = new System.Drawing.Size(27, 23);
            this.select_ddir.TabIndex = 2;
            this.select_ddir.Text = "...";
            this.select_ddir.UseVisualStyleBackColor = true;
            this.select_ddir.Click += new System.EventHandler(this.select_ddir_Click);
            // 
            // settings_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 268);
            this.Controls.Add(this.personal_panel);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.settings_menu_listbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settings_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки - ";
            this.personal_panel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox settings_menu_listbox;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Panel personal_panel;
        private System.Windows.Forms.TextBox ddir_txt;
        private System.Windows.Forms.Button select_ddir;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ldir_txt;
        private System.Windows.Forms.Button select_ldir;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
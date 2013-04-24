namespace arrok__chat
{
    partial class transferfile_form
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transferfile_form));
            this.bw_reciver = new System.ComponentModel.BackgroundWorker();
            this.send_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label = new System.Windows.Forms.Label();
            this.choosefile_btn = new System.Windows.Forms.Button();
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ofd_sendfile = new System.Windows.Forms.OpenFileDialog();
            this.lbl_state = new System.Windows.Forms.Label();
            this.bw_sender = new System.ComponentModel.BackgroundWorker();
            this.sfd_receivefile = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bw_reciver
            // 
            this.bw_reciver.WorkerReportsProgress = true;
            this.bw_reciver.WorkerSupportsCancellation = true;
            this.bw_reciver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_reciver_DoWork);
            this.bw_reciver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_reciver_ProgressChanged);
            // 
            // send_btn
            // 
            this.send_btn.Enabled = false;
            this.send_btn.Location = new System.Drawing.Point(62, 147);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(122, 24);
            this.send_btn.TabIndex = 0;
            this.send_btn.Text = "Отправить";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(299, 147);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(122, 24);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.label);
            this.groupBox.Controls.Add(this.choosefile_btn);
            this.groupBox.Controls.Add(this.txt_filepath);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(454, 82);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Файл";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(6, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(210, 17);
            this.label.TabIndex = 2;
            this.label.Text = "Выберите файл для отправки:";
            // 
            // choosefile_btn
            // 
            this.choosefile_btn.Location = new System.Drawing.Point(391, 45);
            this.choosefile_btn.Name = "choosefile_btn";
            this.choosefile_btn.Size = new System.Drawing.Size(44, 23);
            this.choosefile_btn.TabIndex = 1;
            this.choosefile_btn.Text = "...";
            this.choosefile_btn.UseVisualStyleBackColor = true;
            this.choosefile_btn.Click += new System.EventHandler(this.choosefile_btn_Click);
            // 
            // txt_filepath
            // 
            this.txt_filepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filepath.Enabled = false;
            this.txt_filepath.Location = new System.Drawing.Point(6, 46);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(379, 20);
            this.txt_filepath.TabIndex = 0;
            this.txt_filepath.TextChanged += new System.EventHandler(this.txt_filepath_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 122);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(441, 19);
            this.progressBar.TabIndex = 1;
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_state.Location = new System.Drawing.Point(18, 102);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(54, 17);
            this.lbl_state.TabIndex = 3;
            this.lbl_state.Text = "dasdas";
            // 
            // bw_sender
            // 
            this.bw_sender.WorkerReportsProgress = true;
            this.bw_sender.WorkerSupportsCancellation = true;
            this.bw_sender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_sender_DoWork);
            this.bw_sender.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_sender_ProgressChanged);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // transferfile_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 183);
            this.Controls.Add(this.lbl_state);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.send_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "transferfile_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.transferfile_form_FormClosing);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog ofd_sendfile;
        public System.ComponentModel.BackgroundWorker bw_reciver;
        public System.ComponentModel.BackgroundWorker bw_sender;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.Button choosefile_btn;
        public System.Windows.Forms.Label lbl_state;
        public System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.SaveFileDialog sfd_receivefile;
        public System.Windows.Forms.Timer timer;
    }
}
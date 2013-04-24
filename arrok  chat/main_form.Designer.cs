namespace arrok__chat
{
    partial class main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.send_btn = new System.Windows.Forms.Button();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.users_listbox = new System.Windows.Forms.ListBox();
            this.user_conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.user_conMenu_caption = new System.Windows.Forms.ToolStripMenuItem();
            this.user_conMenu_sendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.user_conMenu_secretChat = new System.Windows.Forms.ToolStripMenuItem();
            this.игратьВToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кНБToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.user_conMenu_info = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.main_menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_open_ddir = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_open_ldir = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.main_menu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.users_label = new System.Windows.Forms.Label();
            this.textMessages = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ts_name = new System.Windows.Forms.ToolStripDropDownButton();
            this.ts_name_win = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_name_new = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_color = new System.Windows.Forms.ToolStripButton();
            this.ts_close_sc = new System.Windows.Forms.ToolStripButton();
            this.ts_enter_chanel = new System.Windows.Forms.ToolStripSplitButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.main_chat = new System.Windows.Forms.TabPage();
            this.board = new System.Windows.Forms.TabPage();
            this.PBboard = new System.Windows.Forms.PictureBox();
            this.refresher = new System.Windows.Forms.Timer(this.components);
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tray_conmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tray_maximize = new System.Windows.Forms.ToolStripMenuItem();
            this.tray_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.CDgraph = new System.Windows.Forms.ColorDialog();
            this.TSpaint = new System.Windows.Forms.ToolStrip();
            this.TSBpen = new System.Windows.Forms.ToolStripButton();
            this.TSBline = new System.Windows.Forms.ToolStripButton();
            this.TSBelips = new System.Windows.Forms.ToolStripButton();
            this.TSBrectangle = new System.Windows.Forms.ToolStripButton();
            this.TSCBlinethickness = new System.Windows.Forms.ToolStripComboBox();
            this.BTNcolor = new System.Windows.Forms.ToolStripButton();
            this.BTNBoardFill = new System.Windows.Forms.ToolStripButton();
            this.LBLfill = new System.Windows.Forms.ToolStripLabel();
            this.BTNfill = new System.Windows.Forms.ToolStripButton();
            this.BTNClear = new System.Windows.Forms.ToolStripButton();
            this.statusBar.SuspendLayout();
            this.user_conMenu.SuspendLayout();
            this.main_menu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.main_chat.SuspendLayout();
            this.board.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBboard)).BeginInit();
            this.tray_conmenu.SuspendLayout();
            this.TSpaint.SuspendLayout();
            this.SuspendLayout();
            // 
            // send_btn
            // 
            this.send_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.send_btn.Location = new System.Drawing.Point(495, 347);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(90, 33);
            this.send_btn.TabIndex = 0;
            this.send_btn.Text = "Отправить";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textMessage
            // 
            this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textMessage.Location = new System.Drawing.Point(12, 360);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(438, 20);
            this.textMessage.TabIndex = 1;
            this.textMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMessage_KeyPress);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusBar.Location = new System.Drawing.Point(0, 404);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(622, 22);
            this.statusBar.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // users_listbox
            // 
            this.users_listbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.users_listbox.ContextMenuStrip = this.user_conMenu;
            this.users_listbox.FormattingEnabled = true;
            this.users_listbox.Location = new System.Drawing.Point(465, 77);
            this.users_listbox.Name = "users_listbox";
            this.users_listbox.Size = new System.Drawing.Size(120, 264);
            this.users_listbox.TabIndex = 4;
            this.users_listbox.SelectedIndexChanged += new System.EventHandler(this.users_listbox_SelectedIndexChanged);
            this.users_listbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.users_listbox_MouseDown);
            // 
            // user_conMenu
            // 
            this.user_conMenu.BackColor = System.Drawing.SystemColors.Window;
            this.user_conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.user_conMenu_caption,
            this.user_conMenu_sendFile,
            this.user_conMenu_secretChat,
            this.игратьВToolStripMenuItem,
            this.toolStripSeparator1,
            this.user_conMenu_info});
            this.user_conMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.user_conMenu.Name = "user_conMenu";
            this.user_conMenu.Size = new System.Drawing.Size(165, 121);
            this.user_conMenu.Opening += new System.ComponentModel.CancelEventHandler(this.user_conMenu_Opening);
            // 
            // user_conMenu_caption
            // 
            this.user_conMenu_caption.BackColor = System.Drawing.Color.Blue;
            this.user_conMenu_caption.BackgroundImage = global::arrok__chat.Properties.Resources.Безимени_1;
            this.user_conMenu_caption.ForeColor = System.Drawing.Color.White;
            this.user_conMenu_caption.Name = "user_conMenu_caption";
            this.user_conMenu_caption.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.user_conMenu_caption.Size = new System.Drawing.Size(167, 23);
            this.user_conMenu_caption.Text = "caption";
            this.user_conMenu_caption.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.user_conMenu_caption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.user_conMenu_caption_MouseMove);
            // 
            // user_conMenu_sendFile
            // 
            this.user_conMenu_sendFile.Name = "user_conMenu_sendFile";
            this.user_conMenu_sendFile.Size = new System.Drawing.Size(164, 22);
            this.user_conMenu_sendFile.Text = "Отправить файл";
            this.user_conMenu_sendFile.Click += new System.EventHandler(this.user_conMenu_sendFile_Click);
            // 
            // user_conMenu_secretChat
            // 
            this.user_conMenu_secretChat.Name = "user_conMenu_secretChat";
            this.user_conMenu_secretChat.Size = new System.Drawing.Size(164, 22);
            this.user_conMenu_secretChat.Text = "Секретный чат";
            this.user_conMenu_secretChat.Click += new System.EventHandler(this.user_conMenu_secretChat_Click);
            // 
            // игратьВToolStripMenuItem
            // 
            this.игратьВToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кНБToolStripMenuItem});
            this.игратьВToolStripMenuItem.Name = "игратьВToolStripMenuItem";
            this.игратьВToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.игратьВToolStripMenuItem.Text = "Играть в...";
            // 
            // кНБToolStripMenuItem
            // 
            this.кНБToolStripMenuItem.Name = "кНБToolStripMenuItem";
            this.кНБToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.кНБToolStripMenuItem.Text = "КНБ";
            this.кНБToolStripMenuItem.Click += new System.EventHandler(this.KNB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // user_conMenu_info
            // 
            this.user_conMenu_info.Name = "user_conMenu_info";
            this.user_conMenu_info.Size = new System.Drawing.Size(164, 22);
            this.user_conMenu_info.Text = "Информация";
            // 
            // main_menu
            // 
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_file,
            this.main_menu_about});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(622, 24);
            this.main_menu.TabIndex = 5;
            this.main_menu.Text = "menuStrip1";
            // 
            // main_menu_file
            // 
            this.main_menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.main_menu_settings,
            this.main_menu_open_ddir,
            this.main_menu_open_ldir,
            this.main_menu_exit});
            this.main_menu_file.Name = "main_menu_file";
            this.main_menu_file.Size = new System.Drawing.Size(48, 20);
            this.main_menu_file.Text = "Файл";
            // 
            // main_menu_settings
            // 
            this.main_menu_settings.Image = global::arrok__chat.Properties.Resources.Yahoo_Widget_Engine;
            this.main_menu_settings.Name = "main_menu_settings";
            this.main_menu_settings.Size = new System.Drawing.Size(286, 22);
            this.main_menu_settings.Text = "Настройки";
            this.main_menu_settings.Click += new System.EventHandler(this.main_menu_settings_Click);
            // 
            // main_menu_open_ddir
            // 
            this.main_menu_open_ddir.Image = global::arrok__chat.Properties.Resources.Flashget;
            this.main_menu_open_ddir.Name = "main_menu_open_ddir";
            this.main_menu_open_ddir.Size = new System.Drawing.Size(286, 22);
            this.main_menu_open_ddir.Text = "Открыть папку с принятыми файлами";
            this.main_menu_open_ddir.Click += new System.EventHandler(this.main_menu_open_ddir_Click);
            // 
            // main_menu_open_ldir
            // 
            this.main_menu_open_ldir.Image = global::arrok__chat.Properties.Resources.Notepad__;
            this.main_menu_open_ldir.Name = "main_menu_open_ldir";
            this.main_menu_open_ldir.Size = new System.Drawing.Size(286, 22);
            this.main_menu_open_ldir.Text = "Открыть папку с логами";
            this.main_menu_open_ldir.Click += new System.EventHandler(this.main_menu_open_ldir_Click);
            // 
            // main_menu_exit
            // 
            this.main_menu_exit.Image = global::arrok__chat.Properties.Resources.Windows_Turn_Off;
            this.main_menu_exit.Name = "main_menu_exit";
            this.main_menu_exit.Size = new System.Drawing.Size(286, 22);
            this.main_menu_exit.Text = "Выход";
            this.main_menu_exit.Click += new System.EventHandler(this.main_menu_exit_Click);
            // 
            // main_menu_about
            // 
            this.main_menu_about.Name = "main_menu_about";
            this.main_menu_about.Size = new System.Drawing.Size(94, 20);
            this.main_menu_about.Text = "О программе";
            // 
            // users_label
            // 
            this.users_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.users_label.AutoSize = true;
            this.users_label.Location = new System.Drawing.Point(462, 52);
            this.users_label.Name = "users_label";
            this.users_label.Size = new System.Drawing.Size(86, 13);
            this.users_label.TabIndex = 6;
            this.users_label.Text = "Пользователи: ";
            // 
            // textMessages
            // 
            this.textMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textMessages.BackColor = System.Drawing.SystemColors.Window;
            this.textMessages.Location = new System.Drawing.Point(0, 0);
            this.textMessages.Name = "textMessages";
            this.textMessages.ReadOnly = true;
            this.textMessages.Size = new System.Drawing.Size(430, 276);
            this.textMessages.TabIndex = 7;
            this.textMessages.Text = "";
            this.textMessages.TextChanged += new System.EventHandler(this.textMessages_TextChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_name,
            this.ts_color,
            this.ts_close_sc,
            this.ts_enter_chanel});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(622, 25);
            this.toolStrip.TabIndex = 8;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ts_name
            // 
            this.ts_name.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_name.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_name_win,
            this.ts_name_new});
            this.ts_name.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_name.Name = "ts_name";
            this.ts_name.Size = new System.Drawing.Size(52, 22);
            this.ts_name.Text = "Name";
            this.ts_name.ToolTipText = "Имя";
            // 
            // ts_name_win
            // 
            this.ts_name_win.Name = "ts_name_win";
            this.ts_name_win.Size = new System.Drawing.Size(241, 22);
            this.ts_name_win.Text = "Использовать Windows-имя ()";
            this.ts_name_win.Click += new System.EventHandler(this.ts_name_win_Click);
            // 
            // ts_name_new
            // 
            this.ts_name_new.Name = "ts_name_new";
            this.ts_name_new.Size = new System.Drawing.Size(241, 22);
            this.ts_name_new.Text = "Новое имя...";
            this.ts_name_new.Click += new System.EventHandler(this.ts_name_new_Click);
            // 
            // ts_color
            // 
            this.ts_color.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_color.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_color.Name = "ts_color";
            this.ts_color.Size = new System.Drawing.Size(23, 22);
            this.ts_color.Text = "Цвет в чате";
            this.ts_color.Paint += new System.Windows.Forms.PaintEventHandler(this.ts_color_change_Paint);
            this.ts_color.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // ts_close_sc
            // 
            this.ts_close_sc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_close_sc.Enabled = false;
            this.ts_close_sc.Image = global::arrok__chat.Properties.Resources.Windows_Close_Program;
            this.ts_close_sc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_close_sc.Name = "ts_close_sc";
            this.ts_close_sc.Size = new System.Drawing.Size(23, 22);
            this.ts_close_sc.Text = "Закрыть канал";
            this.ts_close_sc.Click += new System.EventHandler(this.ts_close_sc_Click);
            // 
            // ts_enter_chanel
            // 
            this.ts_enter_chanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_enter_chanel.Image = global::arrok__chat.Properties.Resources.AIM;
            this.ts_enter_chanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_enter_chanel.Name = "ts_enter_chanel";
            this.ts_enter_chanel.Size = new System.Drawing.Size(32, 22);
            this.ts_enter_chanel.Text = "Присоединиться к каналу чата";
            this.ts_enter_chanel.ButtonClick += new System.EventHandler(this.ts_enter_chanel_ButtonClick);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.main_chat);
            this.tabControl.Controls.Add(this.board);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(12, 52);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(438, 302);
            this.tabControl.TabIndex = 9;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // main_chat
            // 
            this.main_chat.Controls.Add(this.textMessages);
            this.main_chat.Location = new System.Drawing.Point(4, 22);
            this.main_chat.Name = "main_chat";
            this.main_chat.Padding = new System.Windows.Forms.Padding(3);
            this.main_chat.Size = new System.Drawing.Size(430, 276);
            this.main_chat.TabIndex = 0;
            this.main_chat.Tag = "0";
            this.main_chat.Text = "Общий чат";
            this.main_chat.UseVisualStyleBackColor = true;
            // 
            // board
            // 
            this.board.Controls.Add(this.PBboard);
            this.board.Location = new System.Drawing.Point(4, 22);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(430, 276);
            this.board.TabIndex = 1;
            this.board.Tag = "0";
            this.board.Text = "Доска";
            this.board.UseVisualStyleBackColor = true;
            // 
            // PBboard
            // 
            this.PBboard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PBboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBboard.Location = new System.Drawing.Point(0, 0);
            this.PBboard.Name = "PBboard";
            this.PBboard.Size = new System.Drawing.Size(430, 276);
            this.PBboard.TabIndex = 1;
            this.PBboard.TabStop = false;
            this.PBboard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PBboard_MouseMove);
            this.PBboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PBboard_MouseDown);
            this.PBboard.Paint += new System.Windows.Forms.PaintEventHandler(this.PBboard_Paint);
            this.PBboard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PBboard_MouseUp);
            // 
            // refresher
            // 
            this.refresher.Interval = 1000;
            this.refresher.Tick += new System.EventHandler(this.refresher_Tick);
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.trayicon.BalloonTipText = "Превед! я подсказко!";
            this.trayicon.BalloonTipTitle = "чототутнетак!";
            this.trayicon.ContextMenuStrip = this.tray_conmenu;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "Arrok Chat";
            this.trayicon.Visible = true;
            this.trayicon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseClick);
            // 
            // tray_conmenu
            // 
            this.tray_conmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tray_maximize,
            this.tray_exit});
            this.tray_conmenu.Name = "tray_conmenu";
            this.tray_conmenu.Size = new System.Drawing.Size(136, 48);
            // 
            // tray_maximize
            // 
            this.tray_maximize.Name = "tray_maximize";
            this.tray_maximize.Size = new System.Drawing.Size(135, 22);
            this.tray_maximize.Text = "Развернуть";
            this.tray_maximize.Click += new System.EventHandler(this.tray_maximize_Click);
            // 
            // tray_exit
            // 
            this.tray_exit.Name = "tray_exit";
            this.tray_exit.Size = new System.Drawing.Size(135, 22);
            this.tray_exit.Text = "Выход";
            this.tray_exit.Click += new System.EventHandler(this.tray_exit_Click);
            // 
            // TSpaint
            // 
            this.TSpaint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBpen,
            this.TSBline,
            this.TSBelips,
            this.TSBrectangle,
            this.TSCBlinethickness,
            this.BTNcolor,
            this.BTNBoardFill,
            this.LBLfill,
            this.BTNfill,
            this.BTNClear});
            this.TSpaint.Location = new System.Drawing.Point(0, 49);
            this.TSpaint.Name = "TSpaint";
            this.TSpaint.Size = new System.Drawing.Size(622, 25);
            this.TSpaint.TabIndex = 10;
            this.TSpaint.Text = "TSpaint";
            this.TSpaint.Visible = false;
            // 
            // TSBpen
            // 
            this.TSBpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBpen.Image = global::arrok__chat.Properties.Resources._080849_glossy_black_icon_business_pen_crayon;
            this.TSBpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBpen.Name = "TSBpen";
            this.TSBpen.Size = new System.Drawing.Size(23, 22);
            this.TSBpen.Text = "Фломастер";
            this.TSBpen.Click += new System.EventHandler(this.TSBpen_Click);
            // 
            // TSBline
            // 
            this.TSBline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBline.Image = global::arrok__chat.Properties.Resources._070900_glossy_black_icon_alphanumeric_minus_sign_simple;
            this.TSBline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBline.Name = "TSBline";
            this.TSBline.Size = new System.Drawing.Size(23, 22);
            this.TSBline.Text = "Линия";
            this.TSBline.Click += new System.EventHandler(this.TSBline_Click);
            // 
            // TSBelips
            // 
            this.TSBelips.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBelips.Image = global::arrok__chat.Properties.Resources._018710_glossy_black_icon_symbols_shapes_shapes_circle_frame;
            this.TSBelips.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBelips.Name = "TSBelips";
            this.TSBelips.Size = new System.Drawing.Size(23, 22);
            this.TSBelips.Text = "Кружок";
            this.TSBelips.Click += new System.EventHandler(this.TSBelips_Click);
            // 
            // TSBrectangle
            // 
            this.TSBrectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBrectangle.Image = global::arrok__chat.Properties.Resources.rec;
            this.TSBrectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBrectangle.Name = "TSBrectangle";
            this.TSBrectangle.Size = new System.Drawing.Size(23, 22);
            this.TSBrectangle.Text = "Квадратик";
            this.TSBrectangle.Click += new System.EventHandler(this.TSBrectangle_Click);
            // 
            // TSCBlinethickness
            // 
            this.TSCBlinethickness.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "50",
            "100"});
            this.TSCBlinethickness.Name = "TSCBlinethickness";
            this.TSCBlinethickness.Size = new System.Drawing.Size(121, 25);
            this.TSCBlinethickness.TextChanged += new System.EventHandler(this.TSCBlinethickness_TextChanged);
            this.TSCBlinethickness.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TSCBlinethickness_KeyPress);
            // 
            // BTNcolor
            // 
            this.BTNcolor.BackColor = System.Drawing.Color.Black;
            this.BTNcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTNcolor.ForeColor = System.Drawing.Color.White;
            this.BTNcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNcolor.Name = "BTNcolor";
            this.BTNcolor.Size = new System.Drawing.Size(71, 22);
            this.BTNcolor.Text = "Цвет кисти";
            this.BTNcolor.Click += new System.EventHandler(this.BTNcolor_Click);
            // 
            // BTNBoardFill
            // 
            this.BTNBoardFill.BackColor = System.Drawing.Color.White;
            this.BTNBoardFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTNBoardFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNBoardFill.Name = "BTNBoardFill";
            this.BTNBoardFill.Size = new System.Drawing.Size(72, 22);
            this.BTNBoardFill.Text = "Цвет доски";
            this.BTNBoardFill.Click += new System.EventHandler(this.BTNBoardFill_Click);
            // 
            // LBLfill
            // 
            this.LBLfill.Name = "LBLfill";
            this.LBLfill.Size = new System.Drawing.Size(48, 22);
            this.LBLfill.Text = "Режим:";
            // 
            // BTNfill
            // 
            this.BTNfill.BackColor = System.Drawing.Color.Gainsboro;
            this.BTNfill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTNfill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNfill.Name = "BTNfill";
            this.BTNfill.Size = new System.Drawing.Size(50, 22);
            this.BTNfill.Text = "Контур";
            this.BTNfill.Click += new System.EventHandler(this.BTNfill_Click);
            // 
            // BTNClear
            // 
            this.BTNClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BTNClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTNClear.Name = "BTNClear";
            this.BTNClear.Size = new System.Drawing.Size(63, 22);
            this.BTNClear.Text = "Очистить";
            this.BTNClear.Click += new System.EventHandler(this.BTNClear_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 426);
            this.Controls.Add(this.TSpaint);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.users_label);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.users_listbox);
            this.Controls.Add(this.main_menu);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.send_btn);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.main_menu;
            this.MinimumSize = new System.Drawing.Size(630, 460);
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A®®Ѻk ©ha†";
            this.Deactivate += new System.EventHandler(this.main_form_Deactivate);
            this.Load += new System.EventHandler(this.main_form_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.user_conMenu.ResumeLayout(false);
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.main_chat.ResumeLayout(false);
            this.board.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBboard)).EndInit();
            this.tray_conmenu.ResumeLayout(false);
            this.TSpaint.ResumeLayout(false);
            this.TSpaint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox users_listbox;
        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem main_menu_file;
        private System.Windows.Forms.ToolStripMenuItem main_menu_settings;
        private System.Windows.Forms.ToolStripMenuItem main_menu_exit;
        private System.Windows.Forms.ToolStripMenuItem main_menu_about;
        private System.Windows.Forms.ContextMenuStrip user_conMenu;
        private System.Windows.Forms.Label users_label;
        private System.Windows.Forms.RichTextBox textMessages;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton ts_color;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem user_conMenu_info;
        private System.Windows.Forms.ToolStripDropDownButton ts_name;
        private System.Windows.Forms.ToolStripMenuItem ts_name_win;
        private System.Windows.Forms.ToolStripMenuItem ts_name_new;
        private System.Windows.Forms.ToolStripMenuItem user_conMenu_sendFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage main_chat;
        private System.Windows.Forms.ToolStripMenuItem user_conMenu_secretChat;
        private System.Windows.Forms.ToolStripButton ts_close_sc;
        private System.Windows.Forms.Timer refresher;
        private System.Windows.Forms.ToolStripMenuItem main_menu_open_ddir;
        private System.Windows.Forms.ToolStripMenuItem main_menu_open_ldir;
        private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.ContextMenuStrip tray_conmenu;
        private System.Windows.Forms.ToolStripMenuItem tray_maximize;
        private System.Windows.Forms.ToolStripMenuItem tray_exit;
        private System.Windows.Forms.ToolStripMenuItem user_conMenu_caption;
        private System.Windows.Forms.ToolStripSplitButton ts_enter_chanel;
        public System.Windows.Forms.TabPage board;
        public System.Windows.Forms.PictureBox PBboard;
        public System.Windows.Forms.ColorDialog CDgraph;
        private System.Windows.Forms.ToolStrip TSpaint;
        private System.Windows.Forms.ToolStripButton TSBpen;
        private System.Windows.Forms.ToolStripButton TSBline;
        private System.Windows.Forms.ToolStripButton TSBelips;
        private System.Windows.Forms.ToolStripButton TSBrectangle;
        private System.Windows.Forms.ToolStripComboBox TSCBlinethickness;
        private System.Windows.Forms.ToolStripButton BTNcolor;
        private System.Windows.Forms.ToolStripButton BTNBoardFill;
        private System.Windows.Forms.ToolStripLabel LBLfill;
        private System.Windows.Forms.ToolStripButton BTNfill;
        private System.Windows.Forms.ToolStripButton BTNClear;
        private System.Windows.Forms.ToolStripMenuItem игратьВToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кНБToolStripMenuItem;
    }
}


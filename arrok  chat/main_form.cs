using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace arrok__chat
{
    public partial class main_form : Form
    {
        private bool done = true;
        static private UdpClient client;
        public static IPAddress groupAddress;
        public static int localPort;
        public static int remotePort;
        public static int ttl;
        public static CUser meme;
        public f_GameKNB f;

        private bool STARTpaint = false;
        private Color BoardFill = Color.FromArgb(255, 255, 255);
        private int xP, yP, xN, yN, xPt, yPt;
        private string REGIMEpaint = "pen";
        private Pen P_Pen;   

        static private IPEndPoint remoteEP;
        static  private UnicodeEncoding encoding = new UnicodeEncoding();
        private string message;
        Thread receiver = null;

        transferfile_form[] rf= new transferfile_form[1];
        public CUser me;
        public List<CUser> users = new List<CUser>();

        public int selected_user = -1;

        public static FileStream LogFileStream;
        public static StreamWriter LogStreamWriter;


        public main_form()
        {
            InitializeComponent();         
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            try
            {
                me = new CUser(System.Environment.UserName);

                groupAddress = IPAddress.Parse("234.0.0.1");
                localPort = 7777;
                remotePort = 7777;
                ttl = 32;

                if (Properties.Settings.Default.ID != "")
                {
                    me.ID = Properties.Settings.Default.ID;
                    me.name = Properties.Settings.Default.Name;
                    me.color = Color.FromArgb(Properties.Settings.Default.Color);
                }
                RefreshChanelMenu();

                if (Properties.Settings.Default.LogDir == "")
                {
                    Properties.Settings.Default.LogDir = System.Environment.CurrentDirectory + "\\logs";
                }
                if (!Directory.Exists(Properties.Settings.Default.LogDir))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.LogDir);
                }
                if (Properties.Settings.Default.DownloadDir == "")
                {
                    Properties.Settings.Default.DownloadDir = System.Environment.CurrentDirectory + "\\downloads";
                }
                if (!Directory.Exists(Properties.Settings.Default.DownloadDir))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.DownloadDir);
                }

                IPHostEntry ips = Dns.GetHostEntry(Dns.GetHostName());
                int y =0;
                foreach (IPAddress ip in ips.AddressList)
                {
                    if (!ip.IsIPv6LinkLocal) me.IP = ips.AddressList[y];
                    y++;
                }

                ts_name.Text = me.name;
                ts_name.DropDown.Items[0].Text = "Использовать Windows-имя (" + System.Environment.UserName + ")";
                this.WriteLog("***** Начало журнала ("+ DateTime.Now +") *****","Общий чат",true);

                meme = me;

                this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint |  ControlStyles.UserPaint, true);
                PBboard.Image = Image.FromFile(Environment.CurrentDirectory + @"\white.bmp");
                P_Pen = new Pen(BTNcolor.BackColor, 1);
                P_Pen.StartCap = LineCap.Round;
                P_Pen.EndCap = LineCap.Round;
                TSCBlinethickness.SelectedIndex = 0;   
            }
            catch
            {
                MessageBox.Show("Ошибка конфигурации!", "Ошибка!");
            }
            try
            {
                client = new UdpClient(localPort);
                client.JoinMulticastGroup(groupAddress, ttl);
                remoteEP = new IPEndPoint(groupAddress, remotePort);

                receiver = new Thread(new ThreadStart(Listener));
                receiver.IsBackground = true;
                receiver.Start();

                SendData("i","");
            }
            catch
            {
                MessageBox.Show("Приложение уже запущенно", "Ошибка!");
                Environment.Exit(0);
            }
            UsersListAdd(me);
            refresher.Start();
        }
        public void RefreshChanelMenu()
        {
            ts_enter_chanel.DropDownItems.Clear();
            foreach (string s in Properties.Settings.Default.chanels.Split('|'))
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(s);
                tsmi.Click += new EventHandler(tsmi_Click);
                if (s.Trim() != "") ts_enter_chanel.DropDownItems.Add(tsmi);
            }
            ts_enter_chanel.DropDownItems.Add(new ToolStripSeparator());
            ToolStripMenuItem tsmi_clear = new ToolStripMenuItem("Очистить историю каналов");
            tsmi_clear.Click += new EventHandler(tsmi_clear_Click);
            tsmi_clear.Image = Properties.Resources.Ad_Aware;
            ts_enter_chanel.DropDownItems.Add(tsmi_clear);
        }

        void tsmi_clear_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.chanels = "";
            save_settings();
            RefreshChanelMenu();
        }

        void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            CreateChanel(tsmi.Text);
        }
        public void WriteLog(string message, string name, bool eob)
        {
            LogFileStream = new FileStream(Properties.Settings.Default.LogDir + @"\"+name+".txt", FileMode.OpenOrCreate);
            LogStreamWriter = new StreamWriter(LogFileStream);
            LogFileStream.Seek(0, SeekOrigin.End);
            if (!eob)
            {
                LogStreamWriter.WriteLine(message);
            }
            else
            {
                LogStreamWriter.WriteLine("");
                LogStreamWriter.WriteLine(message);
                LogStreamWriter.WriteLine("");
            }
            LogStreamWriter.Flush();
            LogFileStream.Flush();

            LogStreamWriter.Close();
            LogFileStream.Close();
        }

        static public void SendData(string msg_type, string msg)
        {
            string dat = "|" + msg_type + "|" + meme.ToString() + msg; 
            byte[] data = encoding.GetBytes(dat);
            client.Send(data, data.Length, remoteEP);
        }
        private void Listener()
        {
            done = false;
            try
            {
                EventWaitHandle pSleepEvent = new EventWaitHandle(false, EventResetMode.ManualReset);
                while (!done)
                {
                    IPEndPoint ep = null;
                    if (client.Available > 0)
                    {
                        byte[] buffer = client.Receive(ref ep);
                        message = encoding.GetString(buffer);                   
                        this.Invoke(new MethodInvoker(DisplayResivedMessage));
                    }
                    else
                    {
                        if (!done)
                        {
                            pSleepEvent.WaitOne(20);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SendData("o","");

            client.DropMulticastGroup(groupAddress);
            client.Close();
                        
        }
        private void DisplayResivedMessage()
        {
            string MsgType = message.Split('|')[1];
            string user = message.Split('|')[2];
            string user_name = user.Split('¶')[1];
            string user_id = user.Split('¶')[2];
            int user_color = Convert.ToInt32(user.Split('¶')[3]);
            IPAddress user_ip = IPAddress.Parse(user.Split('¶')[4]);
            int user_pen_color = Convert.ToInt32(user.Split('¶')[5]);
            int user_pen_width = Convert.ToInt32(user.Split('¶')[6]);
            string user_paint_type = user.Split('¶')[7];
            Pen p = new Pen(Color.FromArgb(user_pen_color), user_pen_width);
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;
            string time = DateTime.Now.ToString("t");

            CUser sender_user = new CUser(user_name, user_id, Color.FromArgb(user_color), user_ip,p,user_paint_type);

            switch (MsgType)
            {
                //Вход в чат
                case "i":
                    AddText(textMessages," ***" + sender_user.name + " вошёл в чат***\n", "system","null");
                    SendData("r",'|' + sender_user.ID);
                    if (me.ID != sender_user.ID && GetUserByID(sender_user.ID)==null) UsersListAdd(sender_user);
                break;
                //Выход из чата
                case "o":
                    AddText(textMessages, " ***" + GetUserByID(sender_user.ID).name + " вышел из чата***\n", "system", "null");
                    if (GetUserByID(sender_user.ID)!=null) UsersListRemove(sender_user.ID);
                break;
                //Сообщение в общий чат
                case "m":
                    AddText(textMessages, message.Split('|')[3] + "\n", "user", sender_user.ID);
                    toolStripStatusLabel1.Text = "Последнее сообщение полученно " + time;
                    
                break;
                //Сообщение о присутсвии в чате
                case "r":
                    if (me.ID == (message.Split('|')[3]) & me.ID != sender_user.ID) UsersListAdd(sender_user);
                break;
                //Смена цвета чата
                case "cc":
                    SetUserColor(sender_user.ID, user_color);
                    AddText(textMessages, " ***Пользователь " + sender_user.name + " сменил свой цвет чата***\n", "system", sender_user.ID);
                break;
                //Смена имени
                case "nc":
                    AddText(textMessages, " ***Пользователь сменил своё имя (" + GetUserByID(sender_user.ID).name + "->" + message.Split('|')[3] + ")***\n", "system", "null");
                    GetUserByID(sender_user.ID).name = message.Split('|')[3];
                    users_listbox.Items[GetUserPos(sender_user.ID)] = message.Split('|')[3];
                    ts_name.Text = me.name;
                    if (PageIsSet(sender_user) != null) PageIsSet(sender_user).Text = sender_user.name;
                break;
                //Прием файла
                case "sf":
                if (me.ID == (message.Split('|')[3]))
                {
                    int k = GetFormNum();
                    rf[k] = new transferfile_form(me, sender_user, Convert.ToInt32(message.Split('|')[7]), message.Split('|')[4], message.Split('|')[8], k,Int32.Parse( message.Split('|')[9]));
                    rf[k].Show();
                }
                break;
                //Подтверждение приема
                case "rf":
                if (me.ID == (message.Split('|')[3]))
                {
                    int n = Int32.Parse(message.Split('|')[5]);
                    if (rf[n] != null) {
                         rf[n].heformnum = Int32.Parse(message.Split('|')[6]);
                         rf[n].bw_sender.RunWorkerAsync();}
                }
                break;
                //Отказ от файла
                case "cf":
                if (me.ID == (message.Split('|')[3]))
                {
                    int n=Int32.Parse(message.Split('|')[4]);
                    rf[n].lbl_state.Text = "Пользователь отказался от вашего файла";
                    rf[n].send_btn.Enabled = true;
                    rf[n].choosefile_btn.Enabled = true;
                }
                break;
                //Прерывание передачи
                case "fc":
                if (me.ID == (message.Split('|')[3]))
                {
                    int n = Int32.Parse(message.Split('|')[4]);
                    if (rf[n] != null)
                    rf[n].client.Close();
                }
                break;
                //Создание секретного чата
                case "nsc":
                if (me.ID == (message.Split('|')[3]))
                {
                   CreateSecretChat(sender_user);
                }
                break;
                //Сообщение в секретный чат
                case "scm":
                    if (me.ID == (message.Split('|')[3]))
                    {
                        if (PageIsSet(sender_user) == null) { CreateSecretChat(sender_user); }
                        AddText(tabControl.TabPages["tab"+sender_user.ID].Controls["rtb"+sender_user.ID] as RichTextBox, message.Split('|')[4] + "\n", "user", sender_user.ID);
                        if (tabControl.TabPages["tab" + sender_user.ID] != tabControl.SelectedTab)
                        {
                            tabControl.TabPages["tab" + sender_user.ID].Tag = 1;
                        }
                    }
                    tabControl.SelectedTab.Text = tabControl.SelectedTab.Text;
                    toolStripStatusLabel1.Text = "Последнее сообщение полученно " + time;
                break;
                //Запрос обновления списка пользователей
                case "rl":
                     SendData("rla","|"+sender_user.ID);
                break;
                //Ответ на запрос обновления списка пользователей
                case "rla":
                    if (me.ID == (message.Split('|')[3]))
                    {
                        if (GetUserByID(sender_user.ID) != null) GetUserByID(sender_user.ID).Refresh();
                        else UsersListAdd(sender_user);
                    }
                break;
                //Сообщения в канал
                case "chm":
                if (PageIsSet(message.Split('|')[3])!=null)
                {
                    AddText(tabControl.TabPages["Chanel_tab_" + message.Split('|')[3]].Controls["Chanel_rtb_" + message.Split('|')[3]] as RichTextBox, message.Split('|')[4] + "\n", "user", sender_user.ID);
                }
                break;
                //Рисование
                case "d":
                if (sender_user.ID != me.ID)
                {
                    int x1 = Convert.ToInt32(message.Split('|')[3]);
                    int y1 = Convert.ToInt32(message.Split('|')[4]);
                    int x2 = Convert.ToInt32(message.Split('|')[5]);
                    int y2 = Convert.ToInt32(message.Split('|')[6]);
                    switch (message.Split('|')[7])
                    {
                        case "p": PaintLINE(x1, y1, x2, y2, sender_user.P_Pen);
                            break;
                        case "l": PaintLINE(x1, y1, x2, y2, sender_user.P_Pen);
                            break;
                        case "e": PaintEllips(x1, y1, x2, y2, sender_user.P_Pen,sender_user.paint_type);
                            break;
                        case "r": PaintRectangle(x1, y1, x2, y2, sender_user.P_Pen, sender_user.paint_type);
                            break;                        
                    }
                    PBboard.Refresh();
                    toolStripStatusLabel1.Text = "Последний 'художник' " + sender_user.name;
                }
                break;
                //Смена вида рисования
                case "pc":
                    GetUserByID(sender_user.ID).P_Pen = sender_user.P_Pen;
                    GetUserByID(sender_user.ID).paint_type = sender_user.paint_type;
                break;
                //Отчистка доски
                case "bc":
                    PBboard.Image = Image.FromFile(Environment.CurrentDirectory + @"\white.bmp");
                    toolStripStatusLabel1.Text = "Последний 'художник' " + sender_user.name;
                break;
                #region knb
                //Предложение сыграть в игру КНБ
                case "g_knb":
                if (me.ID == (message.Split('|')[3]))
                {
                    DialogResult d = MessageBox.Show(sender_user.name + " предлагает Вам сыграть в КНБ, высогласны?", "Предложение развлечься", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        SendData("g_knb_yes", "|" + sender_user.ID);
                        f = new f_GameKNB(sender_user, me);
                        f.Show();
                    }
                    else
                    {
                        SendData("g_knb_no", "|" + sender_user.ID);
                    }
                }
                break;
                //Пользователь согласился играть в КНБ
                case "g_knb_yes":
                if (me.ID == (message.Split('|')[3]))
                {
                    f = new f_GameKNB(sender_user, me);
                    f.Show();
                }
                break;
                //Пользователь отказался играть в КНБ
                case "g_knb_no":
                if (me.ID == (message.Split('|')[3]))
                {
                    MessageBox.Show(sender_user.name + " отказался играть с вами!");
                }
                break;
                //Пользователь выбрал элемент КНБ
                case "g_knb_vybral":
                if (me.ID == (message.Split('|')[3]) || me.ID == sender_user.ID)
                {
                    if (me.ID == (message.Split('|')[3]))
                    {
                        f.prot_vybor = (message.Split('|')[4]);
                        f.l_K.Visible = false;
                        f.l_N.Visible = false;
                        f.l_B.Visible = false;
                    }
                    if (((f.my_vybor != "") && (me.ID == message.Split('|')[3])) || ((f.prot_vybor != "") && (me.ID == sender_user.ID)))
                    {
                        switch (f.prot_vybor)
                        {
                            case "K": f.l_choose.Image = arrok__chat.Properties.Resources.web; break;
                            case "N": f.l_choose.Image = arrok__chat.Properties.Resources.cut; break;
                            case "B": f.l_choose.Image = arrok__chat.Properties.Resources.copy; break;
                        }
                        if (((f.my_vybor == "K") && (f.prot_vybor == "N")) || ((f.my_vybor == "N") && (f.prot_vybor == "B")) || ((f.my_vybor == "B") && (f.prot_vybor == "K")))
                        {
                            MessageBox.Show("Вы выйграли");
                            f.l_my_number.Text = (Convert.ToInt32(f.l_my_number.Text) + 1).ToString();
                        }
                        else if (f.prot_vybor == f.my_vybor)
                        { 
                            MessageBox.Show("Ничья");
                            f.l_my_number.Text = (Convert.ToInt32(f.l_my_number.Text) + 1).ToString();
                            f.l_prot_number.Text = (Convert.ToInt32(f.l_prot_number.Text) + 1).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Вы проиграли");
                            f.l_prot_number.Text = (Convert.ToInt32(f.l_prot_number.Text) + 1).ToString();
                        }
                        f.l_K.Visible = true;
                        f.l_N.Visible = true;
                        f.l_B.Visible = true;
                        f.l_choose.Image = arrok__chat.Properties.Resources.user;
                        f.b_K.Visible = true;
                        f.b_N.Visible = true;
                        f.b_B.Visible = true;
                        f.b_choose.BackgroundImage = arrok__chat.Properties.Resources.user;
                        f.b_choose.Enabled = false;
                        f.my_vybor = "";
                        f.prot_vybor = "";
                    }
                }  
                break;
                #endregion

            }            
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (textMessage.Text.Trim() != "")
            {
                send();
            }
            else
            {
                textMessage.Text = "";
                textMessage.Focus();
            }
        }
        private void send() 
        {
            if (tabControl.SelectedTab.Name == "main_chat")
            {
                SendData("m","|" + textMessage.Text.Trim());
            }
            else
            {
                if (tabControl.SelectedTab.Name.Substring(0, 3) == "tab")
                {
                    CUser user = GetUserByID(tabControl.SelectedTab.Name.Substring(3));
                    if (user != null)
                    {
                        SendData("scm", "|" + user.ID + "|" + textMessage.Text.Trim());
                        if (tabControl.SelectedTab.Name != "tab" + me.ID) AddText(tabControl.SelectedTab.Controls[0] as RichTextBox, textMessage.Text.Trim() + "\n", "user", me.ID);
                    }
                    else
                    {
                        AddText(tabControl.SelectedTab.Controls[0] as RichTextBox, "*** Пользователь не в сети ***\n", "system", "null");
                    }
                }
                else
                {
                    SendData("chm","|" + tabControl.SelectedTab.Name.Substring(11) + "|" + textMessage.Text.Trim());
                }
                
            }
            textMessage.Clear();
            textMessage.Focus();
        }
        private void StopListener()
        {
            done = true;
            receiver.Join();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!done) StopListener();
            save_settings();
            WriteLog("***** Конец журнала (" + DateTime.Now + ") *****", "Общий чат", true);
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Name != "main_chat")
                {
                    //WriteLog("***** Конец журнала (" + DateTime.Now + ") *****", GetUserByID(tp.Name.Substring(3)).name+".txt", true);
                }
            }
        }
        private void textMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (textMessage.Text.Trim() != "")
                {
                    send();
                }
                else
                {
                    textMessage.Text = "";
                    textMessage.Focus();
                }
            }
        }
        private void UsersListAdd(CUser new_user)
        {
            users.Add(new_user);
            users_listbox.Items.Add(new_user.name);
            if (new_user.ID == me.ID) users[0] = me;
            users_label.Text = "Пользователи: " + users_listbox.Items.Count;
        }
        private void UsersListRemove(string AID)
        {
            users_listbox.Items.RemoveAt(GetUserPos(AID));
            users.Remove(GetUserByID(AID));
            users_label.Text = "Пользователи: " + users_listbox.Items.Count;
        }     
        private void main_menu_settings_Click(object sender, EventArgs e)
        {
            settings_form sf = new settings_form();
            sf.ShowDialog();
        }
        public CUser GetUserByID(string AID)
        {
            foreach (CUser us in users)
            {
                if (us.ID == AID) return us;
            }
            return null;
        }
        public int GetUserPos(string AID)
        {
            int u = -1;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].ID == AID) u=i;
            }
            return u;
        }
        private void textMessages_TextChanged(object sender, EventArgs e)
        {
            RichTextBox t = sender as RichTextBox;
            t.SelectionStart = t.TextLength;
            t.ScrollToCaret();
        }
        public void AddText(RichTextBox rtb, string message, string MsgType, string AID)
        {
            string time = "[" + DateTime.Now.ToString("t")+ "] ";
            rtb.AppendText(time);
            switch (MsgType)
            {
                case "system":
                    rtb.Select(0, 0);
                    rtb.AppendText(message);
                    WriteLog(time + message, "Общий чат",false);
                    rtb.Select(rtb.Text.Length - message.Length, rtb.Text.Length);
                    rtb.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    rtb.Select(rtb.Text.Length - message.Length, rtb.Text.Length);
                    if (AID == "null") rtb.SelectionColor = Color.Black;
                    else rtb.SelectionColor = GetUserByID(AID).color;
                break;

                case "user":
                    rtb.AppendText(GetUserByID(AID).name + ": ");
                    //findsmilies(rtb, message);
                    rtb.AppendText(message);
                    if (GetUserByID(rtb.Name.Substring(3)) != null)
                    {
                        WriteLog(time + GetUserByID(AID).name + ": " + message, GetUserByID(rtb.Name.Substring(3)).name, false);
                    }
                    else
                    {
                        if (tabControl.SelectedTab.Name =="main_chat") WriteLog(time + GetUserByID(AID).name + ": " + message, "Общий чат", false);
                        else
                            if (tabControl.SelectedTab.Name != "board") WriteLog(time + GetUserByID(AID).name + ": " + message, tabControl.SelectedTab.Name.Substring(11), false);
                    }
                    rtb.Select(rtb.Text.Length - message.Length, message.Length);
                    rtb.SelectionColor = GetUserByID(AID).color;
                break;
            }
        }
        //private void findsmilies(RichTextBox rtb, string message)
        //{
        //    int find = message.IndexOf("!!!");
        //    while (find != -1)
        //    {
        //        rtb.AppendText(message.Substring(0, find));
        //        message = message.Substring(find + 3);
        //        Image i = Image.FromFile(@"C:\NoraD\Учёба\III курс\2 сем\Разработка и стандартизация\arrok chat\exclamation-mark12.gif");
        //        Clipboard.SetDataObject(i);
        //        rtb.ReadOnly = false;
        //        rtb.Paste();
        //        rtb.ReadOnly = true;
        //        find = message.IndexOf("!!!");
        //        Clipboard.Clear();
        //    }
        //    rtb.AppendText(message);
        //}
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                me.color = colorDialog.Color;
                SendData("cc","");
            }
        }
        private void SetUserColor(string AID, int argb)
        {
            GetUserByID(AID).color = Color.FromArgb(argb);
        }
        private void users_listbox_MouseDown(object sender, MouseEventArgs e)
        {
            users_listbox.SelectedIndex = users_listbox.IndexFromPoint(e.Location) ;
        }
        private void user_conMenu_Opening(object sender, CancelEventArgs e)
        {
            if (users_listbox.SelectedIndex == -1) e.Cancel = true;
            else
            {
                if (users[users_listbox.SelectedIndex].ID == me.ID) user_conMenu.Items[2].Enabled = false;
                else user_conMenu.Items[2].Enabled = true;
                user_conMenu.Items[0].Text = users[users_listbox.SelectedIndex].name;
                 
            }
        }
        private void main_menu_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ts_color_change_Paint(object sender, PaintEventArgs e)
        {
            Rectangle border = new Rectangle(2, 2, 20, 19);
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Gray);
            p.Width = 2;
            g.DrawRectangle(p, border);
            Rectangle col = new Rectangle(8, 8, 8, 7);
            p.Color = me.color;
            p.Width = 10;
            g.DrawRectangle(p, col);
        }
        public void save_settings()
        {
            Properties.Settings.Default.Name = me.name;
            Properties.Settings.Default.Color = me.color.ToArgb();
            Properties.Settings.Default.ID = me.ID;
            Properties.Settings.Default.Save();
        }
        private void ts_name_new_Click(object sender, EventArgs e)
        {
            dialog_form nnf = new dialog_form("NewName");
            if (nnf.ShowDialog() == DialogResult.OK)
            {
                SendData("nc", "|" + nnf.textbox.Text);
            }
        }
        private void ts_name_win_Click(object sender, EventArgs e)
        {
            if (me.name != System.Environment.UserName)
            {
                SendData("nc", "|" + System.Environment.UserName);
            }
        }
        private void user_conMenu_sendFile_Click(object sender, EventArgs e)
        {
            int k = GetFormNum(); 
            rf[k] = new transferfile_form(me,users[users_listbox.SelectedIndex],k);
            rf[k].Show();
        }
        private void user_conMenu_secretChat_Click(object sender, EventArgs e)
        {
            CreateSecretChat(users[users_listbox.SelectedIndex]);
        }
        private TabPage PageIsSet(CUser user)
        {
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Name == "tab" + user.ID) { return tp; }
            }
            return null;
        }
        private TabPage PageIsSet(string name)
        {
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Name == "Chanel_tab_" + name) { return tp; }
            }
            return null;
        }
        private void CreateSecretChat(CUser user)
        {
            if (PageIsSet(user) != null) { tabControl.SelectedTab = PageIsSet(user); }
            else 
            {
                this.WriteLog("***** Начало журнала (" + DateTime.Now + ") *****", user.name,true);
                tabControl.TabPages.Add(SecretChatPage(user));
                tabControl.SelectTab("tab" + user.ID);
                SendData("nsc", "|" + user.ID);
            }
            textMessage.Focus();
        }     
        private TabPage SecretChatPage(CUser user)
        {

            TabPage tp = new TabPage(user.name);
            tp.Name = "tab"+user.ID;
            tp.Tag = 0;

            RichTextBox rtb = new RichTextBox();
            tp.Controls.Add(rtb);
            rtb.Name = "rtb" + user.ID;
            rtb.Width = tp.Width;
            rtb.Height = tp.Height ;
            rtb.ReadOnly = true;
            rtb.BackColor = Color.White;
            rtb.Anchor = textMessages.Anchor;
            rtb.TextChanged += new EventHandler(rtb_TextChanged);
            return tp;
        }
        void rtb_TextChanged(object sender, EventArgs e)
        {
            RichTextBox t = sender as RichTextBox;
            t.SelectionStart = t.TextLength;
            t.ScrollToCaret();
        }
        private void ts_close_sc_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name != "main_chat")
            {
                if (tabControl.SelectedTab.Name.Substring(0, 3) == "tab") this.WriteLog("***** Конец журнала (" + DateTime.Now + ") *****", GetUserByID(tabControl.SelectedTab.Name.Substring(3)).name, true);
                else this.WriteLog("***** Конец журнала (" + DateTime.Now + ") *****", tabControl.SelectedTab.Name.Substring(11), true);
                tabControl.SelectedTab.Dispose();
            }     
        }
        private void refresher_Tick(object sender, EventArgs e)
        {
            foreach (CUser us in users)
            {
                us.LifeCount -= 1;
            }
            SendData("rl","");
            //for (int i = 0; i < 1000; i++)
            //{
                
            //}
            synh();
        }
        private void synh()
        {
            users_listbox.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].LifeCount > 0 )
                {
                    users_listbox.Items.Add(users[i].name);
                }
                else users.RemoveAt(GetUserPos(users[i].ID));
            }

            if (selected_user > users_listbox.Items.Count - 1) users_listbox.SelectedIndex = users_listbox.Items.Count - 1;
            else users_listbox.SelectedIndex = selected_user;
            users_label.Text = "Пользователи: " + users_listbox.Items.Count;
        }

        private void users_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_user = users_listbox.SelectedIndex;
        }
        private int GetFormNum()
        {
            int n=0;
            foreach (transferfile_form frm in rf)
            {
                if (frm == null) return n;
                n += 1;
            }
            transferfile_form[] rff=new transferfile_form[rf.Length];
            rf.CopyTo(rff, 0);
            rf= new transferfile_form[rff.Length + 1];
            rff.CopyTo(rf, 0);
            return n;
        }
        private void main_menu_open_ddir_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = null;
            try
            {
                Process.Start(Properties.Settings.Default.DownloadDir);
            }
            catch (Exception) { }
            finally
            {
                if (startInfo != null) startInfo = null;
            }
        }
        private void main_menu_open_ldir_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = null;
            try
            {
                Process.Start(Properties.Settings.Default.LogDir);
            }
            catch (Exception) { }
            finally
            {
                if (startInfo != null) startInfo = null;
            }
        }
        private void main_form_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState==FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                trayicon.ShowBalloonTip(5000);
            }
        }
        private void trayicon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left){
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.ShowInTaskbar = false;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }
        private void tray_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tray_maximize_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void user_conMenu_caption_MouseMove(object sender, MouseEventArgs e)
        {
             user_conMenu.Items[1].Select();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "main_chat" || tabControl.SelectedTab.Name == "board")
            {
                ts_close_sc.Enabled = false;
            }
            else
            {
                ts_close_sc.Enabled = true;
            }
            tabControl.SelectedTab.Tag = 0;
            tabControl.SelectedTab.Text = tabControl.SelectedTab.Text;
            if (tabControl.SelectedIndex == 1)
            {
                TSpaint.Visible = true;
                toolStrip.Visible = false;
                textMessage.Visible = false;
                send_btn.Visible = false;
            }
            else
            {
                TSpaint.Visible = false;
                toolStrip.Visible = true;
                textMessage.Visible = true;
                send_btn.Visible = true;
            }
        }

        private void ts_enter_chanel_ButtonClick(object sender, EventArgs e)
        {
            dialog_form df = new dialog_form("NewChanel");
            if (df.ShowDialog() == DialogResult.OK)  
            {
                CreateChanel(df.textbox.Text);
                
            }
            
        }
        private void CreateChanel(string chanel_name)
        {
            if (PageIsSet(chanel_name) != null) { tabControl.SelectedTab = PageIsSet(chanel_name); }
            else
            {
                this.WriteLog("***** Начало журнала (" + DateTime.Now + ") *****", chanel_name, true);
                tabControl.TabPages.Add(ChanelPage(chanel_name));
                tabControl.SelectTab("Chanel_tab_" + chanel_name);
            }
            textMessage.Focus();
            bool cis = false;
            foreach (string s in Properties.Settings.Default.chanels.Split('|'))
            {
                if (s == chanel_name) cis = true;
            }
            if (!cis) Properties.Settings.Default.chanels += "|" + chanel_name;
            save_settings();
            RefreshChanelMenu();
        }
        private TabPage ChanelPage(string name)
        {
            TabPage tp = new TabPage(name);
            tp.Tag = 0;
            tp.Name = "Chanel_tab_" + name;

            RichTextBox rtb = new RichTextBox();
            tp.Controls.Add(rtb);
            rtb.Name = "Chanel_rtb_" + name;
            rtb.Width = tp.Width;
            rtb.Height = tp.Height;
            rtb.ReadOnly = true;
            rtb.BackColor = Color.White;
            rtb.Anchor = textMessages.Anchor;
            rtb.TextChanged += new EventHandler(rtb_TextChanged);
            return tp;
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            if (tabControl.TabPages[e.Index].Tag.ToString() == "0")
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            }
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(tabControl.TabPages[e.Index].Text, Font, Brushes.Black, e.Bounds, stringFormat);
        }

        #region board
        private void PaintLINE(int X1, int Y1, int X2, int Y2,Pen p)
        {
            Graphics GraphObject = Graphics.FromImage(PBboard.Image);
            if (X1 == X2 && Y1 == Y2) 
                GraphObject.FillEllipse(p.Brush, X1 - p.Width / 2, Y1 - p.Width / 2, p.Width, p.Width);
            else 
                GraphObject.DrawLine(p, X1, Y1, X2, Y2);
            PBboard.Invalidate();
            GraphObject.Dispose();
        }
        private void PaintEllips(int X1, int Y1, int wd, int hg,Pen p,string pt)
        {
            Graphics GraphObject = Graphics.FromImage(PBboard.Image);
            if (pt == "Контур") 
                GraphObject.DrawEllipse(p, X1, Y1, wd, hg);
            else 
                GraphObject.FillEllipse(p.Brush, X1, Y1, wd, hg);
            PBboard.Invalidate();
            GraphObject.Dispose();
        }
        private void PaintRectangle(int X1, int Y1, int wd, int hg,Pen p,string pt)
        {
            Graphics GraphObject = Graphics.FromImage(PBboard.Image);
            if (pt == "Контур") 
                GraphObject.DrawRectangle(p, X1, Y1, wd, hg);
            else 
                GraphObject.FillRectangle(p.Brush, X1, Y1, wd, hg);
            PBboard.Invalidate();
            GraphObject.Dispose();
        }

        private void PBboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (STARTpaint)
            {
                xN = e.X;
                yN = e.Y;
                if (REGIMEpaint == "pen")
                {
                    PaintLINE(xP, yP, xN, yN, P_Pen);
                    SendData("d","|" + xP + "|" + yP + "|" + e.X + "|" + e.Y + "|p|");
                    xP = xN;
                    yP = yN;                    
                }
                PBboard.Refresh();
                toolStripStatusLabel1.Text = "Последний 'художник' " + me.name;
            }
        }

        private void PBboard_MouseDown(object sender, MouseEventArgs e)
        {
            xP = e.X;
            yP = e.Y;
            STARTpaint = true;
        }
        private void PBboard_MouseUp(object sender, MouseEventArgs e)
        {
            STARTpaint = false;
            switch (REGIMEpaint)
            {
                case "pen":
                    PaintLINE(xP, yP, e.X, e.Y, P_Pen);
                    SendData("d","|" + xP + "|" + yP + "|" + e.X + "|" + e.Y + "|p|");
                    break;
                case "line":
                    PaintLINE(xP, yP, e.X, e.Y, P_Pen);
                    SendData("d", "|" + xP + "|" + yP + "|" + e.X + "|" + e.Y + "|l|");
                    break;
                case "elips":
                    PaintEllips(xP, yP, e.X - xP, e.Y - yP, P_Pen, BTNfill.Text);
                    SendData("d","|" + xP + "|" + yP + "|" + (e.X - xP) + "|" + (e.Y - yP) + "|e|");
                    break;
                case "rectangle":
                    PaintRectangle(xPt, yPt, xN - xPt, yN - yPt, P_Pen, BTNfill.Text);
                    SendData("d","|" + xPt + "|" + yPt + "|" + (xN - xPt) + "|" + (yN - yPt) + "|r|");
                    break;                
            }
        }

        private void TSBpen_Click(object sender, EventArgs e)
        {
            REGIMEpaint = "pen";
        }
        private void TSBline_Click(object sender, EventArgs e)
        {
            REGIMEpaint = "line";
        }
        private void TSBelips_Click(object sender, EventArgs e)
        {
            REGIMEpaint = "elips";
        }
        private void TSBrectangle_Click(object sender, EventArgs e)
        {
            REGIMEpaint = "rectangle";
        }
        private void TSCBlinethickness_TextChanged(object sender, EventArgs e)
        {
            if (TSCBlinethickness.Text != "")
            {
                if (TSCBlinethickness.Text == "0")
                    TSCBlinethickness.Text = "1";
                P_Pen.Width=Convert.ToInt32(TSCBlinethickness.Text);
                try
                {
                    me.P_Pen.Width = Convert.ToInt32(TSCBlinethickness.Text);
                    SendData("pc","");
                }
                catch { };
            }
        }

        private void PBboard_Paint(object sender, PaintEventArgs e)
        {
            if (STARTpaint == false)
            {
                return;
            }
            else
            {
                switch (REGIMEpaint)
                {
                    case "line":
                        e.Graphics.DrawLine(P_Pen, xP, yP, xN, yN);
                        break;
                    case "elips":
                        int doubleWidth = (int)P_Pen.Width;
                        int ellipseHeight = yN - yP;
                        int ellipseWidth = xN - xP;
                        if (Math.Abs(ellipseHeight) < doubleWidth || Math.Abs(ellipseWidth) < doubleWidth)
                            e.Graphics.FillEllipse(P_Pen.Brush, xP - doubleWidth / 2, yP - doubleWidth / 2, ellipseWidth + doubleWidth, ellipseHeight + doubleWidth);
                        else
                        {
                            if (BTNfill.Text == "Контур") 
                                e.Graphics.DrawEllipse(P_Pen, xP, yP, ellipseWidth, ellipseHeight);
                            else 
                                e.Graphics.FillEllipse(P_Pen.Brush, xP, yP, ellipseWidth, ellipseHeight);
                        }
                        break;
                    case "rectangle":
                        xPt = xP;
                        yPt = yP;
                        if (xN < xP)
                        {
                            xPt = xN;
                            xN = xP;
                        }
                        if (yN < yP)
                        {
                            yPt = yN;
                            yN = yP;
                        }
                        if (BTNfill.Text == "Контур") 
                            e.Graphics.DrawRectangle(P_Pen, xPt, yPt, xN - xPt, yN - yPt);
                        else 
                            e.Graphics.FillRectangle(P_Pen.Brush, xPt, yPt, xN - xPt, yN - yPt);
                        break;
                }
            }
        }

        private void TSCBlinethickness_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TSCBlinethickness.Text.Length == 0)
            {
                if ((e.KeyChar < 49 || e.KeyChar > 57) && e.KeyChar != 8)
                    e.Handled = true;
            }
            else
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                    e.Handled = true;
            }
        }

        private void BTNcolor_Click(object sender, EventArgs e)
        {
            if (CDgraph.ShowDialog() == DialogResult.OK)
            {
                BTNcolor.BackColor = CDgraph.Color;
                if (BTNcolor.BackColor == Color.White) BTNcolor.ForeColor = Color.Black;
                else BTNcolor.ForeColor = Color.White;
                P_Pen.Color = BTNcolor.BackColor;
                me.P_Pen.Color = BTNcolor.BackColor;
                SendData("pc","");
            }
        }

        private void BTNfill_Click(object sender, EventArgs e)
        {
            if (BTNfill.Text == "Контур") BTNfill.Text = "Заполнение";
            else BTNfill.Text = "Контур";
            me.paint_type = BTNfill.Text;
            SendData("pc","");
        }

        private void BTNBoardFill_Click(object sender, EventArgs e)
        {
            if (CDgraph.ShowDialog() == DialogResult.OK)
            {
                MemoryStream pMemoryStream = new MemoryStream(1024*1024*1);
                PBboard.Image.Save(pMemoryStream, ImageFormat.Bmp);
                PBboard.Image.Dispose();  
                Image OldtoNewPicture = Image.FromStream(pMemoryStream);
    
                Graphics GraphObjectFILL = Graphics.FromImage(OldtoNewPicture);
                ColorMap[] ChangeColor = new ColorMap[1];
                ChangeColor[0] = new ColorMap();
                ChangeColor[0].OldColor = BoardFill;
                ChangeColor[0].NewColor = CDgraph.Color;
                BTNBoardFill.BackColor = CDgraph.Color;
                if (BTNBoardFill.BackColor == Color.White) BTNBoardFill.ForeColor = Color.Black;
                else BTNBoardFill.ForeColor = Color.White;
                BoardFill = CDgraph.Color;                
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetRemapTable(ChangeColor);
                GraphObjectFILL.DrawImage(OldtoNewPicture, new Rectangle(0, 0, OldtoNewPicture.Width, OldtoNewPicture.Height), 0, 0, OldtoNewPicture.Width, OldtoNewPicture.Height, GraphicsUnit.Pixel, imageAttr);

                MemoryStream pInputMemoryStream = new MemoryStream();
                OldtoNewPicture.Save(pInputMemoryStream, ImageFormat.Bmp);

                PBboard.Image = Image.FromStream(pInputMemoryStream);
                OldtoNewPicture.Dispose();
                GraphObjectFILL.Dispose();
            }
        }

        private void BTNClear_Click(object sender, EventArgs e)
        {
            PBboard.Image = Image.FromFile(Environment.CurrentDirectory + @"\white.bmp");
            SendData("bc","");
        }
        
        #endregion   
        public void KNB_Click(object sender, EventArgs e)
        {
            SendData("g_knb","|" + users[users_listbox.SelectedIndex].ID);
        }

    }
}

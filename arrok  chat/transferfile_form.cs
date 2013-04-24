using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace arrok__chat
{
    public partial class transferfile_form : Form
    {
        public int meformnum;
        public int heformnum;
        public bool flag=false;
        public TcpClient client;
        private bool senderr;
        private CUser me;
        private CUser he;
        string file;
        private int port;
        public string download_dir;
        public long file_length;
        private string file_size;
        public transferfile_form(CUser mme, CUser hhe, int men)
        {
            InitializeComponent();
            timer.Stop();
            senderr = true;
            CheckForIllegalCrossThreadCalls = false;
            me=mme;
            he=hhe;
            meformnum = men;
            Random r = new Random();
            this.port = r.Next(5000) + 6000;
            this.Text = "Отправка файла - "+hhe.name;
            lbl_state.Text = "Ожидание...";
        }
        public transferfile_form(CUser mme, CUser hhe, int pport, string rfile, string file_l,int men, int hen)
        {
            InitializeComponent();
            senderr = false;
            me = mme;
            he = hhe;
            timer.Stop();
            meformnum = men;
            heformnum = hen;
            this.port = pport;
            file = rfile;
            send_btn.Text = "Принять";
            CheckForIllegalCrossThreadCalls = false;
            download_dir = Properties.Settings.Default.DownloadDir;
            txt_filepath.Text = download_dir+@"\"+rfile;
            file_length = Convert.ToInt64(file_l);
            if (file_length > 1048576)
                file_size = ((double)file_length / 1048576).ToString("#.##")+" Mb";
            else
                file_size = ((double)file_length / 1024).ToString("#.##")+ " Kb";
            label.Text = "Пользователь " + he.name + " хочет переслать вам файл [" + file_size + "]";
            this.Text = "Прием файла - " + rfile;
            lbl_state.Text = "Ожидание...";
        }
        private void choosefile_btn_Click(object sender, EventArgs e)
        {
            if (send_btn.Text == "Принять") {
                sfd_receivefile.FileName = this.file;
                sfd_receivefile.InitialDirectory = Properties.Settings.Default.DownloadDir;
                if (sfd_receivefile.ShowDialog() == DialogResult.OK) txt_filepath.Text = sfd_receivefile.FileName;              
            }
            else
            if (ofd_sendfile.ShowDialog() == DialogResult.OK) txt_filepath.Text = ofd_sendfile.FileName;              
        }
        private void send_btn_Click(object sender, EventArgs e)
        {            
            choosefile_btn.Enabled = false;
            switch (send_btn.Text)
            {
                case "Отправить":
                    lbl_state.Text = "Ожидание подтверждения...";
                    file = txt_filepath.Text;
                    IPAddress userIP = he.IP;
                    FileInfo fi = new FileInfo(file);
                    file_length = fi.Length;
                    main_form.SendData("sf", "|" + he.ID + "|" + fi.Name + "|" + fi.Length + "|" + fi.FullName + "|" + port + "|" + fi.Length+"|"+meformnum);
                    send_btn.Enabled = false;
                break;
                case "Открыть папку...":
                    ProcessStartInfo startInfo = null;
                    try
                    {                       
                        startInfo = new ProcessStartInfo("Explorer");
                        startInfo.UseShellExecute = false;
                        startInfo.CreateNoWindow = true;
                        startInfo.Arguments = @"/select," + txt_filepath.Text;
                        Process.Start(startInfo);
                    }
                    catch (Exception) { }
                    finally
                    {
                        if (startInfo != null) startInfo = null;
                    }
                break;
                case "Принять":
                    lbl_state.Text = "Соединение...";
                    main_form.SendData("rf","|" + he.ID + "|" + file+"|"+heformnum+"|"+meformnum);
                    send_btn.Enabled = false;
                    timer.Start();
                    bw_reciver.RunWorkerAsync();
                break;
            }
        }
        public void SendFile()
        {
            if (client != null)
                client.Close();
            IPEndPoint IPep = new IPEndPoint(me.IP, port);
            client = new TcpClient(IPep);
            if (client.Connected)
                client.Client.Disconnect(true);
            client.Connect(new IPEndPoint(he.IP, port+1));
            NetworkStream writerStream = client.GetStream();
            BinaryFormatter format = new BinaryFormatter();
            byte[] buf = new byte[8192];
            long count;
            FileStream fs = new FileStream(file, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            long k = fs.Length;
            format.Serialize(writerStream, k.ToString());
            float i = 0;
            float h = file_length / 8192;
            h = 100 / h;
            lbl_state.Text = "Отправка файла...";
            try
            {
                while ((count = br.Read(buf, 0, 8192)) > 0)
                {
                    format.Serialize(writerStream, buf);
                    i += h;
                    bw_sender.ReportProgress(Convert.ToInt32(Math.Floor(i)));
                }
                lbl_state.Text = "Готово";
                cancel_btn.Text = "Закрыть";
            }
            catch
            {
                lbl_state.Text = "Передача прервана";
                send_btn.Enabled = true;
                choosefile_btn.Enabled = true;
            }
            finally
            {
                writerStream.Close();
                client.Close();
                br.Close();
                fs.Close();
            }
        }
        public void ReciveFile()
        {
            TcpListener clientListener = new TcpListener(me.IP,port+1);
            clientListener.Start();
            client = clientListener.AcceptTcpClient();
            NetworkStream readerStream = client.GetStream();
            BinaryFormatter outformat = new BinaryFormatter();
            FileStream fs = new FileStream(txt_filepath.Text, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);
            long count;
            count = long.Parse(outformat.Deserialize(readerStream).ToString());
            long i = 0;
            float j = 0;
            float h = file_length / 8192;
            h = 100 / h;
            lbl_state.Text = "Получение...";
            try
            {
                for (; i < count; i += 8192)
                {
                    j += h;
                    bw_reciver.ReportProgress(Convert.ToInt32(Math.Floor(j)));
                    byte[] buf = (byte[])(outformat.Deserialize(readerStream));
                    bw.Write(buf);
                }
                lbl_state.Text = "Готово";
                send_btn.Enabled = true;
                send_btn.Text = "Открыть папку...";
                cancel_btn.Text = "Закрыть";
            }
            catch
            {
                lbl_state.Text = "Передача прервана";
            }
            finally
            {
                readerStream.Close();
                bw.Close();
                fs.Close();
                client.Close();
                clientListener.Stop();
            }
        }
        private void bw_reciver_DoWork(object sender, DoWorkEventArgs e)
        {
            this.ReciveFile();
        }
        private void bw_sender_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendFile();
        }
        private void bw_sender_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= 100)
            {
                progressBar.Value = e.ProgressPercentage;
            }
            else progressBar.Value = 100;
        }
        private void bw_reciver_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage <= 100)
            {
                progressBar.Value = e.ProgressPercentage;
            }
            else progressBar.Value = 100;
        }
        private void txt_filepath_TextChanged(object sender, EventArgs e)
        {
            send_btn.Enabled = true;
        }
        private void Cancel()
        {
            if (!senderr && !bw_reciver.IsBusy && cancel_btn.Text == "Отмена")
                main_form.SendData("cf","|" + he.ID+"|"+heformnum);
            if (client != null && !senderr) { 
               client.Close();
            }
            if (client != null && senderr && bw_sender.IsBusy)
            {
                flag = true;
                main_form.SendData("fc","|" + he.ID+"|"+heformnum);
                port += 2;
                client.Client.Disconnect(true);
                client.Close();
            }
            else flag = false;
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            
            this.Cancel();
            if (!flag)
            {
                this.Dispose();
                this.Close();
            }
        }
        private void transferfile_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cancel();
            if (flag) e.Cancel = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {         
            if (client==null)
            {
                lbl_state.Text = "Таймаут соединения";
                if (senderr)  send_btn.Enabled = true;
                else cancel_btn.Text = "Закрыть";
            }
            timer.Stop();
        }
    }
}

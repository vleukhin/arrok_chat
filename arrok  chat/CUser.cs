using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Drawing2D;

namespace arrok__chat
{
    public class CUser
    {
        public string name;
        public IPAddress IP;
        public string ID;
        public Color color;
        public Pen P_Pen;
        public int LifeCount;
        public string paint_type;

        public CUser(string AName)
        {
            Random r = new Random();
            this.name = AName;
            this.ID = Guid.NewGuid().ToString();
            this.color = Color.Black;
            this.LifeCount = 7;
            P_Pen = new Pen(Color.Black, 1);
            P_Pen.StartCap = LineCap.Round;
            P_Pen.EndCap = LineCap.Round;
            paint_type = "Контур";
        }
        public CUser(string AName,string AID, Color cc, IPAddress ip,Pen p,string pt)
        {
            this.name = AName;
            this.ID = AID;
            this.color = cc;
            this.IP = ip;
            this.LifeCount = 7;
            this.P_Pen = p;
            paint_type = pt; 
        }
        override public string ToString()
        {
            return "¶" + name +
                   "¶" + ID +
                   "¶" + Convert.ToString(color.ToArgb()) +
                   "¶" + IP +
                   "¶" + Convert.ToString(P_Pen.Color.ToArgb()) +
                   "¶" + Convert.ToString(P_Pen.Width)+
                   "¶" + paint_type;
        }
        public void Refresh()
        {
            this.LifeCount = 7;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace arrok__chat
{
    public partial class f_GameKNB : Form
    {
        public string my_vybor = "";
        public string prot_vybor = "";
        CUser protiv;
        CUser me;

        public f_GameKNB(CUser user_protiv, CUser user_me)
        {
            InitializeComponent();
            protiv = user_protiv;
            me = user_me;
        }

        private void GameKNB_Load(object sender, EventArgs e)
        {

        }

        private void b_K_Click(object sender, EventArgs e)
        {
            b_choose.BackgroundImage = arrok__chat.Properties.Resources.web;
            b_choose.Enabled = true;
            b_choose.Tag = "0";
        }

        private void b_N_Click(object sender, EventArgs e)
        {
            b_choose.BackgroundImage = arrok__chat.Properties.Resources.cut;
            b_choose.Enabled = true;
            b_choose.Tag = "1";
        }

        private void b_B_Click(object sender, EventArgs e)
        {
            b_choose.BackgroundImage = arrok__chat.Properties.Resources.copy;
            b_choose.Enabled = true;
            b_choose.Tag = "2";
        }

        private void b_choose_Click(object sender, EventArgs e)
        {
            b_K.Visible = false;
            b_N.Visible = false;
            b_B.Visible = false;
            switch (b_choose.Tag.ToString())
            {
                case "0": my_vybor = "K";
                    break;
                case "1": my_vybor = "N";
                    break;
                case "2": my_vybor = "B";
                    break;
            }
            main_form.SendData("g_knb_vybral", "|" + protiv.ID + "|" + my_vybor);
            b_choose.Enabled = false;
        }
    }
}

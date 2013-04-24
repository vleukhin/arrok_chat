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
    public partial class settings_form : Form
    {
        public settings_form()
        {
            InitializeComponent();       
            settings_menu_listbox.SelectedIndex = 0;
            this.Text = "Настройки - " + settings_menu_listbox.Items[settings_menu_listbox.SelectedIndex].ToString();
            ddir_txt.Text = Properties.Settings.Default.DownloadDir;
            ldir_txt.Text = Properties.Settings.Default.LogDir;
        }

        private void settings_menu_listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = "Настройки - " + settings_menu_listbox.Items[settings_menu_listbox.SelectedIndex].ToString();
           
            switch (settings_menu_listbox.SelectedIndex)
            {
                case 0:
                    
                break;
                case 1:
                  
                break;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DownloadDir = ddir_txt.Text;
        }

        private void select_ddir_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = ddir_txt.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                ddir_txt.Text = fbd.SelectedPath;
            }
        }

        private void select_ldir_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = ldir_txt.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                ddir_txt.Text = fbd.SelectedPath;
            }
        }
    }
}

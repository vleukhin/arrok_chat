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
    public partial class dialog_form : Form
    {
        public dialog_form()
        {
            InitializeComponent();
            textbox.Focus();
        }
        public dialog_form(string mode)
            : this()
        {
            switch (mode)
            {
                case ("NewName"):
                    label1.Text = "Введите новое имя:";
                    this.Text = "Новое имя";
                break;
                case ("NewChanel"):
                    label1.Text = "Введите название канала:";
                    this.Text = "Новый канал";
                break;
            }
        }

        private void new_name_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textbox.Text == "") this.DialogResult = DialogResult.Cancel;
        }
    }
}

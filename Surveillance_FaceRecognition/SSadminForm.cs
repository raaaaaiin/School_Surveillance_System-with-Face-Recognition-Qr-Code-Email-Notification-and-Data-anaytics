﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    public partial class SSadminForm : Form
    {
        SSmenu _main;
        public SSadminForm(SSmenu ths)
        {
            InitializeComponent();
            _main = ths;
        }

        private void Showall(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            SSadminrecord _all = new SSadminrecord() { TopLevel = false};
            panel11.Controls.Add(_all);
            _all.Show();
            panel6.BackColor = Color.FromArgb(45, 45, 45);
            panel4.BackColor = Color.FromArgb(50,50,50);
            panel7.BackColor = Color.Gold;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            SSadminadddata _manage = new SSadminadddata() { TopLevel = false };
            panel11.Controls.Add(_manage);
            _manage.Show();
            panel6.BackColor = Color.Gold;
            panel4.BackColor = Color.FromArgb(50, 50, 50);
            panel7.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel11.Controls.Clear();
            SSmassdataupdate _massupdate = new SSmassdataupdate() { TopLevel = false };
            panel11.Controls.Add(_massupdate);
            _massupdate.Show();
            panel6.BackColor = Color.FromArgb(45, 45, 45);
            panel4.BackColor = Color.Gold;
            panel7.BackColor = Color.FromArgb(45, 45, 45);
        }
    }
}

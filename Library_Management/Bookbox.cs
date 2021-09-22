using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Studentbox : Form
    {
        Notifbar _notif;
        Function _func = new Function();
        static int count = 0;
        Color native;
        public Studentbox(Notifbar ths)
        {
            _notif = ths;
            InitializeComponent();
            bunifuPictureBox1.BorderRadius = 25;
            if ((count % 2) == 0)
            {
                panel1.BackColor = Color.FromArgb(49,49,49);
                count++;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(45,45,45);
                count++;
            }
            native = panel1.BackColor;
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Gold;
        }

        private void bunifuButton1_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = native;
        }
    }
}

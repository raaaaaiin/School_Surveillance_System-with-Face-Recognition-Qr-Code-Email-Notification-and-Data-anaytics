using System;
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
    public partial class SSsectionBox : Form
    {
        DataHandler cache = new DataHandler();
        public string SectionName;
        public string StudentCount;
        public string Sched;
        public string Adviser;
        public string AdviserEmail;
        notificationBar _notif;
        SSmenu _menu;
        function _func = new function();
        public static int count = 0;
        Color native;
        public string identify;

        Bitmap objBitmap;
        public SSsectionBox(SSmenu ths)
        {
            
            process();
            count++;
            _menu = ths;
            
           
        }
       public void process()
        {
           

        }
        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
           
                //_menu.showStdFrm(this.id);
           
            
            
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void bunifuShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void goldy(object sender, EventArgs e)
        {
            
            label2.ForeColor = Color.FromArgb(45, 45, 45);
            label3.ForeColor = Color.FromArgb(45, 45, 45);
            label4.ForeColor = Color.FromArgb(45, 45, 45);
        }

        private void normaly(object sender, EventArgs e)
        {
            
            label2.ForeColor = Color.Silver;
            label3.ForeColor = Color.Silver;
            label4.ForeColor = Color.Silver;
        }

        private void bunifuPictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}

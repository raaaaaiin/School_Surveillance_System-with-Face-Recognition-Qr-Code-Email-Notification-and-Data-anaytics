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
    public partial class SSclientUser : Form
    {
        function _func = new function();

        Bitmap objBitmap;
        public SSclientUser(string uid, string name, string status, string section)
        {
            string count = _func.getPendingViolation(uid);

            InitializeComponent();
            label3.Text = "Name: " + name;
            label2.Text = "Status: " + status;
            label1.Text = "Section: " + section;
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));

            path += '\\';
            bunifuPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                objBitmap = new Bitmap(Image.FromFile(path + "Student\\" + uid + ".jpeg"), new Size(150, 150));

            }
            catch
            {
                objBitmap = new Bitmap(Image.FromFile(path + "Student\\default.jpeg"), new Size(150, 150));

            }
            bunifuPictureBox1.Image = objBitmap;

            if (count.Equals("0"))
            {
                label4.Hide();
            }
            else
            {
                label4.Show();
                label4.Text = "Violation: " + count;
            }
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
          
        }

        private void normaly(object sender, EventArgs e)
        {
            
          
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class SSstudentBox : Form
    {
        DataHandler cache = new DataHandler();
        public string fullname;
        public string section;
        public string id;
        notificationBar _notif;
        SSmenu _menu;
        function _func = new function();
        public static int count = 0;
        Color native;
        public string identify;

        Bitmap objBitmap;
        public SSstudentBox(SSmenu ths, string name, string section, string id, string identifier)
        {
            InitializeComponent();
            this.fullname = name;
            this.section = section;
            this.id = id;
            identify = identifier;
            process();
            count++;
            _menu = ths;
            bunifuPictureBox1.BorderRadius = 23;
           
        }
       public void process()
        {
            if ((count % 2) == 0)
            {
                panel1.BackColor = Color.FromArgb(50, 50, 50);
                label1.BackColor = Color.FromArgb(50, 50, 50);
                label2.BackColor = Color.FromArgb(50, 50, 50);
                bunifuButton1.OnIdleState.FillColor = Color.FromArgb(45, 45, 45);
                bunifuButton1.OnIdleState.BorderColor = Color.FromArgb(45, 45, 45);
            }
            label1.Text = fullname;
            label2.Text = section;
            if (identify.Equals("STD"))
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));

                path += '\\';
                bunifuPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    objBitmap = new Bitmap(Image.FromFile(path + "Images\\" + id + ".jpeg"), new Size(150, 150));
                    
                }
                catch
                {
                    objBitmap = new Bitmap(Image.FromFile(path + "Images\\default.jpeg"), new Size(150, 150));

                }
                bunifuPictureBox1.Image = objBitmap;
            }
            else
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));

                path += '\\';
                bunifuPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    objBitmap = new Bitmap(Image.FromFile(path + "Books\\" + id + ".jpeg"), new Size(150, 150));
                
                }
                catch
                {
                    objBitmap = new Bitmap(Image.FromFile(path + "Books\\default.jpeg"), new Size(150, 150));
                   
                }
                bunifuPictureBox1.Image = objBitmap;
            }

        }
        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (identify.Equals("STD"))
            {
                _menu.showStdFrm(this.id);
            }
            else
            {
                _menu.showbookFrm(this.id);
            }
            
            
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
            panel2.BackColor = Color.Gold;
        }

        private void normaly(object sender, EventArgs e)
        {
            panel2.BackColor = native;
        }

        private void bunifuPictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

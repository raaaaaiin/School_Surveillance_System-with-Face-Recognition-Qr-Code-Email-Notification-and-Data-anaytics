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
    public partial class SSnextback : Form
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
        public SSnextback(SSmenu ths, string name, string section, string id, string identifier)
        {
            InitializeComponent();
            this.fullname = name;
            this.section = section;
            this.id = id;
            identify = identifier;
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
            if (identify.Equals("STD"))
            {
                _menu.showStdFrm(this.id);
                MessageBox.Show("STD");
            }
            else
            {
                _menu.showstdinfoFrm(this.id);
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
    }
}

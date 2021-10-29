using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    public partial class LFRInputName : Form
    {
        public string userName;
        fileHandler _file = new fileHandler();
        function _func = new function();
        DataHandler _cache = new DataHandler();
        Bitmap objBitmap;

        private string id = "";
        public LFRInputName()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void InputName_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            userName = bunifuMetroTextbox2.Text;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.id = bunifuMetroTextbox2.Text;
            _func.Editstudent(id);
                loaddata();
            
        }
       
        public void loaddata()
        {
           
            lastname.Text = _cache.returnslctd_staff(2);
            middlename.Text = _cache.returnslctd_staff(1);
            gradelevel.Text = _cache.returnslctd_staff(4) + " " + _cache.returnslctd_staff(10) + " " + _cache.returnslctd_staff(5);
            firstname.Text = _cache.returnslctd_staff(0);
            label17.Text = _cache.returnslctd_staff(2) + " " + _cache.returnslctd_staff(0) + " " + _cache.returnslctd_staff(1);
            _func.fill("year", year, "stud_year");
         
            year.Text = _cache.returnslctd_staff(4);
            program.Text = _cache.returnslctd_staff(10);
            section.Text = _cache.returnslctd_staff(5);
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
       

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void verifyText(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "Enter Student Number")
            {
                bunifuMetroTextbox2.Text = "";
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}

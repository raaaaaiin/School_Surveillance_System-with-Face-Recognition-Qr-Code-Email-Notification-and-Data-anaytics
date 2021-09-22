using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Library_Management
{
    public partial class editStudentinfo : Form
    {
        menu _main;
        fileHandler _file = new fileHandler();
        function _func = new function();
        DataHandler _cache = new DataHandler();
        Bitmap objBitmap;
        private string id = "";
        public editStudentinfo(menu ths)
        {
            InitializeComponent();
            _func.Editstudent(id);
            _main = ths;
            bunifuPictureBox1.BorderRadius = 27;
            
        }
        public void changedata(string id)
        {
            _func.Editstudent(id);
            this.id = id;
            loaddata();
        }
        public void changedata2(string id)
        {
            
        }
        public void loaddata()
        {
            Username.Text = _cache.returnslctd_std(7);
            Password.Text = _cache.returnslctd_std(8);
            Confirmpass.Text =  _cache.returnslctd_std(8);
            lastname.Text = _cache.returnslctd_std(2);
            middlename.Text = _cache.returnslctd_std(1);
            gradelevel.Text = _cache.returnslctd_std(4) + " " + _cache.returnslctd_std(10) + " " + _cache.returnslctd_std(5) ;
            firstname.Text = _cache.returnslctd_std(0);
            label17.Text = _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1);
            _func.fill("year", year, "stud_year");
            if (_cache.returnslctd_std(9).ToString().Equals("Admin")){
                Adminchk();
            }
            else
            {
                Studentchk();
            }
            year.Text = _cache.returnslctd_std(4);
            program.Text = _cache.returnslctd_std(10);
            section.Text = _cache.returnslctd_std(5);
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


        private void EditStdInf_Load(object sender, EventArgs e)
        {

            
        }

        

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Password.isPassword = false;
            Confirmpass.isPassword = false;

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            changedata2(this.id);

        }

       

        private void Student(object sender, EventArgs e)
        {
            Studentchk();
        }

        private void Admin(object sender, EventArgs e)
        {
            Adminchk();
        }
        public void Studentchk()
        {
            bunifuGradientPanel1.GradientBottomLeft = Color.Gold;
            bunifuRadioButton1.OutlineColor = Color.Gold;
            bunifuRadioButton1.RadioColor = Color.Gold;
            bunifuGradientPanel2.GradientBottomLeft = Color.White;
            bunifuRadioButton2.OutlineColor = Color.White;
            bunifuRadioButton2.RadioColor = Color.White;
            if (bunifuRadioButton1.Checked == true)
            {
                bunifuRadioButton2.Checked = false;
            }
            else
            {
                bunifuRadioButton2.Checked = false;
                bunifuRadioButton1.Checked = true;
            }
        }
        public void Adminchk()
        {
            bunifuGradientPanel1.GradientBottomLeft = Color.White;
            bunifuRadioButton1.OutlineColor = Color.White;
            bunifuRadioButton1.RadioColor = Color.White;
            bunifuGradientPanel2.GradientBottomLeft = Color.Gold;
            bunifuRadioButton2.OutlineColor = Color.Gold;
            bunifuRadioButton2.RadioColor = Color.Gold;
            if (bunifuRadioButton2.Checked == true)
            {

            }
            else
            {
                bunifuRadioButton1.Checked = false;
                bunifuRadioButton2.Checked = true;
            }
        }
        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            if (Password.Text.Equals(Confirmpass.Text))
            {
                if (bunifuRadioButton1.Checked == true)
                {
                    _func.updatestudentacc(id, Username.Text, Confirmpass.Text, "Student");

                }
                else
                {
                    _func.updatestudentacc(id, Username.Text, Confirmpass.Text, "Admin");
                }
            }
            else
            {
                Messagebox MessageBox = new Messagebox("Password does not match!");MessageBox.Show();
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            _func.delStud(_cache.returnslctd_std(0), _cache.returnslctd_std(1), _cache.returnslctd_std(2), _cache.returnslctd_std(3));
            _func.loadDataStud();
            _main.showMenu2("STD");
            
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            string dest = "";
            DialogResult result = openFileDialog1.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    string source = openFileDialog1.FileName;
                    Bitmap resize = new Bitmap(Image.FromFile(source), new Size(150, 150));
                    dest = _file.path + "Images\\" + id + ".jpeg";
                    resize.Save(dest, ImageFormat.Jpeg);
                }
            }
            catch
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                string source = openFileDialog1.FileName;
                Bitmap resize = new Bitmap(Image.FromFile(source), new Size(150, 150));
                dest = _file.path + "Images\\" + id + ".jpeg";
                File.Delete(dest);
                resize.Save(dest, ImageFormat.Jpeg);
            }
            loaddata();
            _func.loadDataStud();
            _main.showMenu2("STD");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            _func.Updatestudent(id, firstname.Text, middlename.Text, lastname.Text, suffix.Text, year.Text, section.Text, studsy.Text,program.Text);
            loaddata();
            _func.loadDataStud();
            _main.showMenu2("STD");
        }

        private void year2d_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", program, "stud_program", "where year = '" + year.Text + "'");
        }

        private void program_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("section", section, "stud_section", "where year = '" + year.Text + "' and program = '" + program.Text + "' order by section");
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

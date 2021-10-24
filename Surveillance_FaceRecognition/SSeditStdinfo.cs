using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Surveillance_FaceRecognition
{
    public partial class SSeditStdinfo : Form
    {
        fileHandler _file = new fileHandler();
        function _func = new function();
        DataHandler _cache = new DataHandler();
        SSmenu _main;
        Bitmap objBitmap;
        private string id = "";
        public SSeditStdinfo(SSmenu ths)
        {
            InitializeComponent();
            bunifuPictureBox1.BorderRadius = 0;
            
            _main = ths;
            
        }
        public void changedata(string id)
        {

            _func.editStd(id);
            
            loaddata();

            
        }
       
        public void loaddata()
        {
            wholeName.Text = _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1);
            firstname.Text = _cache.returnslctd_std(0);
            lastname.Text = _cache.returnslctd_std(2);
            middlename.Text = _cache.returnslctd_std(1);
            suffix.Text = _cache.returnslctd_std(3);
            gradelevel.Text = _cache.returnslctd_std(4) + " " + _cache.returnslctd_std(10) + " " + _cache.returnslctd_std(5);
            _func.fill("year", year, "stud_year");
            year.Text = _cache.returnslctd_std(4);
            program.Text = _cache.returnslctd_std(10);
            section.Text = _cache.returnslctd_std(5);
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));
            path += '\\';
            bunifuPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                objBitmap = new Bitmap(Image.FromFile(path + "Student\\" + id + ".jpeg"), new Size(150, 150));
            }
            catch
            {
                objBitmap = new Bitmap(Image.FromFile(path + "Student\\default.jpeg"), new Size(150, 150));
            }
            bunifuPictureBox1.Image = objBitmap;
        }


        private void EditStdInf_Load(object sender, EventArgs e)
        {

            
        }

        

        private void bunifuButton2_Click(object sender, EventArgs e)
        {


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
            
        }
        public void Adminchk()
        {
          
        }
        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {
           // _func.fill("category", Category, "book_categ", " Order by Category ASC");
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Goldy(object sender, EventArgs e)
        {
            

        }

        private void plainey(object sender, EventArgs e)
        {

            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            _func.delBooks(_cache.returnslctd_std(1),_cache.returnslctd_std(2));
            _func.loadDataStd();
            _main.showMenu2("Book");
            this.Hide();
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            //_func.updateBookinfo(id, booktitle.Text, author.Text, page.Text, qty.Text, info.Text);
            _func.loadDataStd();
            _main.showMenu2("Book");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            //_func.addBookscateg(id,Category.Text);
            loaddata();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

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
                    dest = _file.path + "Books\\" + id + ".jpeg";
                    resize.Save(dest, ImageFormat.Jpeg);
                }
            }
            catch
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                string source = openFileDialog1.FileName;
                Bitmap resize = new Bitmap(Image.FromFile(source), new Size(150, 150));
                dest = _file.path + "Book\\" + id + ".jpeg";
                File.Delete(dest);
                resize.Save(dest, ImageFormat.Jpeg);
            }
            loaddata();
        
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

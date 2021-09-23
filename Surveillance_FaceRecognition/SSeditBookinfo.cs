using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Surveillance_FaceRecognition
{
    public partial class SSeditBookinfo : Form
    {
        fileHandler _file = new fileHandler();
        function _func = new function();
        DataHandler _cache = new DataHandler();
        SSmenu _main;
        Bitmap objBitmap;
        private string id = "";
        public SSeditBookinfo(SSmenu ths)
        {
            InitializeComponent();
            bunifuPictureBox1.BorderRadius = 0;

            _main = ths;
            
        }
        public void changedata(string id)
        {

            
            _func.Editbook(id);
            loaddata();

            
        }
       
        public void loaddata()
        {
            this.id = _cache.returnslctd_book(0);
            setcateg.Items.Clear();
            Category.Items.Clear();
            _func.fill("category", setcateg, "book_categ_data", "where book_id = '" + this.id + "' Order by Category ASC");
            _func.fill("category", Category, "book_categ"," Order by Category ASC");

            label17.Text = _cache.returnslctd_book(1);
            booktitle.Text = _cache.returnslctd_book(1);
            author.Text = _cache.returnslctd_book(2);
            page.Text = _cache.returnslctd_book(3);
            //index 4 = categ
            info.Text = _cache.returnslctd_book(4);
            qty.Text = _cache.returnslctd_book(5);
            try
            {
                latest_borrow.Text = _cache.returnslctd_book(7);
                latest_return.Text = _cache.returnslctd_book(8);
                date_borrowed.Text = _cache.returnslctd_book(9);
                date_return.Text = _cache.returnslctd_book(10);

            }
            catch
            {
                latest_borrow.Text = "";
                latest_return.Text = "";
                date_borrowed.Text = "";
                date_return.Text = "";

            }
            
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));
            path += '\\';
            bunifuPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {

                objBitmap = new Bitmap(Image.FromFile(path + "Books\\" + id + ".jpeg"), new Size(300, 300));
                
            }
            catch 
            {
                objBitmap = new Bitmap(Image.FromFile(path + "Books\\default.jpeg"), new Size(300, 300));
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
            _func.fill("category", Category, "book_categ", " Order by Category ASC");
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Goldy(object sender, EventArgs e)
        {
            bunifuGradientPanel1.GradientBottomLeft = Color.Gold;

        }

        private void plainey(object sender, EventArgs e)
        {

            bunifuGradientPanel1.GradientBottomLeft = Color.White;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            _func.delBooks(_cache.returnslctd_book(1),_cache.returnslctd_book(2));
            _func.loadDataBook();
            _main.showMenu2("Book");
            this.Hide();
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            _func.updateBookinfo(id, booktitle.Text, author.Text, page.Text, qty.Text, info.Text);
            _func.loadDataBook();
            _main.showMenu2("Book");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            _func.addBookscateg(id,Category.Text);
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

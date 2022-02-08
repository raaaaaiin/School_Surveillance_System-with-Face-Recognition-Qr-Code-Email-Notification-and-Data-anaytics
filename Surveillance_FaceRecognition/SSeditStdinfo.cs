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
            wholeName.Text = "";
            firstname.Text = "";
            lastname.Text = "";
            middlename.Text = "";
            suffix.Text = "";
            emailadd.Text = "";

            Yeard.Text = "";
            Progd.Text = "";
            secD.Text = "";
            lastseen.Text = "";
            lastseentime.Text = "";
            islate.Text = "";
            previousabsent.Text = "";
            previousstatus.Text = "";

            sy.Text = "";
            workingDay.Text = "";
            contact.Text = "";
            emailadd.Text = "";
            info.Text = "";

            info.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            info.ScrollBars = ScrollBars.Vertical;
            // Allow the TAB key to be entered in the TextBox control.
            info.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            info.AcceptsTab = true;
            this.id = _cache.returnslctd_std(11);
            wholeName.Text = _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1);
            firstname.Text = _cache.returnslctd_std(0);
            lastname.Text = _cache.returnslctd_std(2);
            middlename.Text = _cache.returnslctd_std(1);
            suffix.Text = _cache.returnslctd_std(3);
            emailadd.Text = _cache.returnslctd_std(4) + " " + _cache.returnslctd_std(7) + " " + _cache.returnslctd_std(5);
            _func.fill("year", Yeard, "stud_year");
            Yeard.Text = _cache.returnslctd_std(4);
            Progd.Text = _cache.returnslctd_std(7);
            secD.Text = _cache.returnslctd_std(5);
            StdNo.Text = id;
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
            lastseen.Text = _cache.returnslctd_std(13) + " " + _cache.returnslctd_std(12) + " " + _cache.returnslctd_std(14);
            lastseentime.Text = _cache.returnslctd_std(9);
            islate.Text = _cache.returnslctd_std(15);
            previousabsent.Text = _cache.returnslctd_std(17);
            previousstatus.Text = _cache.returnslctd_std(18);

            sy.Text = _cache.returnslctd_std(6);
            workingDay.Text = _func.WorkingDay(_cache.returnslctd_std(16));
            contact.Text = _cache.returnslctd_std(20);
            emailadd.Text = _cache.returnslctd_std(19);
            info.Text = _func.showInformation(_cache.returnslctd_std(11));


            if (_cache.returnuser_std(8).Equals("Staff"))
            {
                bunifuButton1.Enabled = false;
                bunifuButton2.Enabled = false;
            }
            else
            {

            }
        }

        public void getListofWorkingday()
        {

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
            _func.delStd(_cache.returnslctd_std(11));
            _func.loadDataStd();
            _main.showMenu2("Book");
            SSMessagebox MessageBox;
            SSMessagebox show = new SSMessagebox("Data Deleted Successfuly");
            this.Hide();
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            //_func.updateBookinfo(id, booktitle.Text, author.Text, page.Text, qty.Text, info.Text);
            
         
            _func.updateStd(id, firstname.Text, middlename.Text, lastname.Text, suffix.Text, Progd.Text, Yeard.Text, secD.Text, sy.Text, emailadd.Text, contact.Text);
            _func.loadDataStd();
            _main.showMenu2("Book");
            SSMessagebox MessageBox;
            SSMessagebox show = new SSMessagebox("Data Updated Successfuly");
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
                    dest = _file.path + "Student\\" + id + ".jpeg";
                    resize.Save(dest, ImageFormat.Jpeg);
                }
            }
            catch
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                string source = openFileDialog1.FileName;
                Bitmap resize = new Bitmap(Image.FromFile(source), new Size(150, 150));
                dest = _file.path + "Student\\" + id + ".jpeg";
                File.Delete(dest);
                resize.Save(dest, ImageFormat.Jpeg);
            }
            loaddata();

            loaddata();
            _func.loadDataStd();
            _main.showMenu2("Book");
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void mobile_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Progd.Items.Clear();
            secD.Items.Clear();
            _func.fill("program", Progd, "stud_program", "where year = '" + Yeard.Text + "'");

            
        }

        private void program_SelectedIndexChanged(object sender, EventArgs e)

        {
            secD.Items.Clear();
            _func.fill("Section", secD, "stud_section", "where year = '" + Yeard.Text + "' and program = '" + Progd.Text + "'");
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            SSviolation newvio = new SSviolation(id);
            newvio.Show();
        }
    }
}

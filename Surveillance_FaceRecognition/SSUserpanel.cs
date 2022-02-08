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
    public partial class SSUserpanel : Form
    {
        LFRForm1 scanner;

        public int facecount;
        public int latecount;
        public int ontimecount;
        public SSUserpanel(LFRForm1 asd)
        {
            InitializeComponent();
            scanner = asd;
            scanner.studentshower = this;
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SSUserpanel_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
        public void addLate()
        {
            latecount += 1;
            bunifuButton1.Text = latecount.ToString();
        }
        public void addfacecount()
        {
            facecount += 1;
            bunifuButton2.Text = facecount.ToString();
        }

        public void addOntime()
        {
            ontimecount += 1;
            bunifuButton3.Text = ontimecount.ToString();


        }
        public void show(string uid,string name, string status,string section) {
            SSclientUser _user = new SSclientUser(uid,name,status, section) { TopLevel = false };


            flowLayoutPanel1.Controls.Add(_user);
            _user.Show();
            flowLayoutPanel1.ScrollControlIntoView(_user);
        }
    }
}

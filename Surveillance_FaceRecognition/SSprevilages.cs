using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    public partial class SSprevilages : Form
    {
        int counter = 0;
        bool[] isPressed = { false, false, false, false, false, false, false, false };
        bool isResetable = false;

        SSmenu _main;
        function _func = new function();
        public SSprevilages(SSmenu ths)
        {
            InitializeComponent();
            _main = ths;



        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {




        }
        private void lightup(System.Windows.Forms.Panel Lit)
        {
            panelbooks.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneladd.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);
            panelrecord.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);
            Lit.BackColor = Color.Gold;

        }
        private void lightup()
        {
            panelbooks.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneladd.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);
            panelrecord.BackColor = Color.FromArgb(100, 32, 32, 32);
            paneledit.BackColor = Color.FromArgb(100, 32, 32, 32);

        }

        private void previlages_Load(object sender, EventArgs e)
        {
            lightup();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {

            _main.reset();

            _main.addstdstaff();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            _main.reset();
            _main.hide();
            _func.loadDataStd();
            _main.showMenu2("Book");
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton8_Click(object sender, EventArgs e)
        {
            _main.reset();
            _main.hide();
            _func.loadDataStd();
            _main.showMenu2("STD");

        }

        


       


        private void Records_Click(object sender, EventArgs e)
        {
            _main.reset();
            _main.showRecord();
        }

        private void adminlogout_Click(object sender, EventArgs e)
        {
            _main.reset();
            _main.Dispose();
            SSlogIn _log = new SSlogIn();
            _log.Show();
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {

            _main.reset();
            _func.loadDataStud();
            _main.addstud();


        }

        private async void bunifuTileButton2_Click_1(object sender, EventArgs e)
        {


            SSMessagebox _messagebox = new SSMessagebox("Loading Please Wait");

            _messagebox.Show();
            await Task.Delay(100);
            
            _main.InitiateCamera();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
   
}

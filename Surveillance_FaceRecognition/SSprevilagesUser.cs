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
    public partial class SSprevilagesUser : Form
    {
        bool[] isPressed = {false,false,false,false,false,false,false,false};
        bool isResetable = false;
        LFRForm1 show = new LFRForm1();
        SSmenu _main;
        function _func = new function();
        public SSprevilagesUser(SSmenu ths)
        {
            InitializeComponent();
            _main = ths;
           


        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            lightup(panelbooks);

            if (isPressed[0] == false)
            {

                _main.hide();
                _func.loadDataStd();
                if (isPressed[3] == true)
                {
                    _main.offCam();
                    isPressed[3] = false;
                }
                reset();
                _main.showMenu2("Book");
                isPressed[0] = true;


            }
            
            
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
            _func.loadDataStud();
            lightup(paneladd);
            if (isPressed[1] == false)
            {
                _main.reset();
                if (isPressed[3] == true)
                {
                    _main.offCam();
                    isPressed[3] = false;
                }
                reset();
                _main.addstud();
                isPressed[1] = true;
                

            }

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            lightup(panelbooks);

            _main.reset();
                _main.hide();
                _func.loadDataStd();
               
                    _main.offCam();
                    
                _main.showMenu2("Book");
                


            
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton8_Click(object sender, EventArgs e)
        {
            _main.hide();
            _func.loadDataStd();
            _main.offCam();
            _main.showMenu2("Book");


        }

        private void Return_Click(object sender, EventArgs e)
        {
         
        }

        private void Profile_Click(object sender, EventArgs e)
        {
       
        }


        private void Logout_Click_1(object sender, EventArgs e)
        {
           
        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void reset()
        {
           for (int i = 0; i != isPressed.Length; i++)
            {
                isPressed[i] = false;
            }
        }

        private void Records_Click(object sender, EventArgs e)
        {
            _main.showRecord();
        }

        private void adminlogout_Click(object sender, EventArgs e)
        {
            _main.Dispose();
            SSlogIn _log = new SSlogIn();
            _log.Show();
        }

        private void bunifuTileButton1_Click_1(object sender, EventArgs e)
        {
            
            
                    _main.offCam();
                   
                _main.addstdstaff();
               

            
            
        }

        private async void bunifuTileButton2_Click_1(object sender, EventArgs e)
        {
            _main.reset();
            show.Stop();
            await Task.Delay(100);
            show.Dispose();

            show = new LFRForm1();
            _main.showRecSurv(show);

            show.Show();
        }

        private void bunifuTileButton1_Click_2(object sender, EventArgs e)
        {
            EmailSender _emailsend = new EmailSender();
            _emailsend.Show();
        }
    }
}

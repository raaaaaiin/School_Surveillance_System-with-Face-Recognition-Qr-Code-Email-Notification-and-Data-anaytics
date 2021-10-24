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
    public partial class SSlogIn : Form
    {
        connection _con;
        function _func = new function();
        fileHandler _filehandler =  new fileHandler();
        public SSlogIn()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

            bool auth = false;
            _func.logIn(Textbox1.Text, Textbox2.Text);
            auth = _func.authentication();
            if (auth == true)
            {
                SSmenu manu = new SSmenu();
                manu.setrole = _func.role;
                manu.preInit();
                manu.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }

            }
            catch
            {
                MessageBox.Show("Connection to Database Failed!");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _filehandler.readFile();
                _con = new connection();
                _con.checkCon();

                label1.Text = "Connection Success";

                _func.loadDataStud();
                _func.loadDataStd();
            }
            catch
            {
                label1.Text = "Connection Failed";
                panel1.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SSdbConfiguration _new = new SSdbConfiguration(this);
            _new.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LFRForm1 reg = new LFRForm1();
            reg.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class logIn : Form
    {
        connection _con;
        function _func = new function();
        fileHandler _filehandler =  new fileHandler();
        public logIn()
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
                menu manu = new menu();
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
                _func.loadDataBook();
            }
            catch
            {
                label1.Text = "Connection Failed";
                panel1.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConfiguration _new = new dbConfiguration(this);
            _new.Show();
            this.Hide();
        }
    }
}

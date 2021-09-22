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
    public partial class dbConfiguration : Form
    {
        fileHandler _handler = new fileHandler();
        connection _con = new connection();
        logIn mainlogin;
        public dbConfiguration(logIn loginform)
        {
            InitializeComponent();
            mainlogin = loginform;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            try{
                _con.setCon(Address.Text, Database.Text, User.Text, Pass.Text);
                _con.checkCon();
                MessageBox.Show("Connection for " + User.Text + " on database " + Database.Text + " Is connected successfully");
            }
            catch
            {
                MessageBox.Show("Connection failed!");
            }
           
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            _handler.dataTransfer[0] = "false";
            _handler.dataTransfer[1] = User.Text;
            _handler.dataTransfer[2] = Pass.Text;
            _handler.dataTransfer[3] = Address.Text;
            _handler.dataTransfer[4] = Port.Text;
            _handler.dataTransfer[5] = Database.Text;
            _handler.createProperties();
            mainlogin.Refresh();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}

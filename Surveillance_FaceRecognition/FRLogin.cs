using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Surveillance_FaceRecognition
{
    public partial class FRLogin : Form
    {
        SqlConnection con;
        public FRLogin()
        {
            InitializeComponent();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Reyn\Desktop\FaceRecProOV\MyDb.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = "";
            string querry = "select * from Register_User where user_name='" + textBox1.Text + "' AND pwd='" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usertype = dr["user_type"].ToString();

            }
            else
            {

                MessageBox.Show("Invalid Credintials");
            }
            if (usertype.Equals("Admin"))
            {

                FRMakeRegistered mr = new FRMakeRegistered();
                mr.Show();
            }
            else
            {
                this.Hide();
                FRMainForm fp = new FRMainForm();
                fp.Show();

            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    class connection 
    {
        public static string isUsing,port, add, db, user, pass;
        public MySqlDataAdapter adp;
        public static MySqlConnection con;
        public MySqlConnection condupe;
        public MySqlCommand com;
        public MySqlDataReader reader;
        public DataSet ds;
        public DataTable dt;
        public connection()
        {
            condupe = con;
            /*add = "localhost";
            db = "lib_mgmt";
            user = "root";
            pass = "root";*/
           
            
           
        }
        public void setCon(string add, string db,string user,string pass)
        {
            con = new MySqlConnection("server=" + add +
            ";database=" + db + ";" +
            "uid=" + user + "" +
            ";pwd=" + pass + ";");
            com = new MySqlCommand();
        }
        public void checkCon()
        {
            con.Open();
            con.Close();
            MessageBox.Show("Hello, world.");
        }

    }
}

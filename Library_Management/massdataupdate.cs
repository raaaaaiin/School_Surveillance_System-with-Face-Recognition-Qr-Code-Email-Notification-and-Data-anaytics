using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient; 


namespace Library_Management
{
    public partial class massdataupdate : Form
    {
        fileHandler _file = new fileHandler();
        connection _con = new connection();
        function _func = new function();
        QuestionBox qb;
        Boolean record = true;
        public massdataupdate()
        {
            InitializeComponent();
            
        }

        private void adminrecord_Load(object sender, EventArgs e)
        {

            reload();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
           
            string file = _file.path + "backup.sql";
            using (MySqlConnection conn = _con.condupe)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                        Messagebox MessageBox = new Messagebox("Data Export success!");
                    }
                }
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
        }

        private void bunifuDropdown6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            string file = _file.path + "backup.sql";
            using (MySqlConnection conn = _con.condupe)
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();

                        Messagebox MessageBox = new Messagebox("Data Export success!");
                    }
                }
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            MessageBox.Show(year1.Text + prog1.Text + sec1.Text);
            _con.com.CommandText = "SELECT Concat(Last_Name,' ',First_Name,' ',Middle_name) As Student_Name,Concat(stud_level,' ',stud_program,' ',stud_section)As Section,Borrowed_book as Book_Title,isReturned FROM `stud_info` inner join book_records on stud_info.uid = book_records.student_id where isReturned = 'false' and stud_level = '"+year1.Text+"' and stud_program = '"+prog1.Text+"' and stud_section ='"+sec1.Text+"' and stud_sy = '"+sy1.Text+"'";
            _con.reader = _con.com.ExecuteReader();
            while (_con.reader.Read())
            {
                MessageBox.Show("LOL");
                qb = new QuestionBox("'" + _con.reader[0] + "' Did not return a book!");
                qb.ShowDialog();

            }
            _con.condupe.Close();
            reload();

        }
        public void reload()
        {
           
            _func.fill("year", year1, "stud_year");
            _func.fill("year", year2, "stud_year");

            _func.fill("year", year3, "stud_year");
           
            fill_sy(sy3);
        }

        private void year2d_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "SELECT Concat(Last_Name,' ',First_Name,' ',Middle_name) As Student_Name,Concat(stud_level,' ',stud_program,' ',stud_section)As Section,Borrowed_book as Book_Title,isReturned FROM `stud_info` inner join book_records on stud_info.uid = book_records.student_id where isReturned = 'false' and stud_level = '" + year2.Text + "' and stud_program = '" + prog2.Text + "' and stud_section ='" + sec2.Text + "' and stud_sy = '" + sy2.Text + "'";
            _con.reader = _con.com.ExecuteReader();
            while (_con.reader.Read())
            {
                record = true;
                qb = new QuestionBox("'" + _con.reader[0] + "' Did not return a book!");
                qb.ShowDialog();

            }
            
            _con.condupe.Close();
            if (record == false)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Update user_info set stud_level = '" + year3.Text + "' ,stud_program= '" + prog3.Text + "' ,stud_section= '" + sec3.Text + "', stud_sy ='"+sy3.Text+"' where stud_level = '" + year2.Text + "' and stud_program = '" + prog2.Text + "' and stud_section ='" + sec2.Text + "' and stud_sy = '" + sy2.Text + "'";
                _con.com.ExecuteNonQuery();
                Messagebox MessageBox = new Messagebox("Updated Successfully"); MessageBox.Show();
                _con.condupe.Close();
            }
                reload();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
 
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            

        }

        private void ccfill_SelectedIndexChanged(object sender, EventArgs e)
        {

            }

    


      

     

   
        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDropdown12_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", prog1, "stud_program", "where year = '" + year1.Text + "'");
        }

        private void bunifuDropdown11_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("section", sec1, "stud_section", "where year = '" + year1.Text + "' and program = '" + prog1.Text + "' order by section");
        }

        private void year2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", prog2, "stud_program", "where year = '" + year2.Text + "'");
        }

        private void year3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", prog3, "stud_program", "where year = '" + year3.Text + "'");
        }

        private void prog2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("section", sec2, "stud_section", "where year = '" + year2.Text + "' and program = '" + prog2.Text + "'");
        }

        private void prog3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("section", sec3, "stud_section", "where year = '" + year3.Text + "' and program = '" + prog3.Text + "'");
        }

        private void sec6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sec3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sec1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("stud_sy", sy1, "stud_info", "Where stud_section = '" + sec1.Text + "' and stud_level = '"+year1.Text+"' and stud_program = '"+prog1.Text+"'  Limit 1");
        }

        private void prog5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void fill_sy(Bunifu.UI.WinForms.BunifuDropdown dropdown)
        {
            string ret = "";
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            int yy = datevalue.Year % 100;
            for (int i = -5; i <= 0;i++)
            {
                ret = (yy - (i + 3)).ToString().ToString() + "-" + (yy - (i + 2));
                dropdown.Items.Add(ret);
            }
        }

        private void sy2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sec2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("stud_sy", sy2, "stud_info", "Where stud_section = '" + sec2.Text + "' and stud_level = '" + year2.Text + "' and stud_program = '" + prog2.Text + "'  Limit 1");

        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Surveillance_FaceRecognition
{
    public partial class SSadminadddata : Form
    {
        connection _con = new connection();
        function _func = new function();
        public SSadminadddata()
        {
            InitializeComponent();
           
        }

        private void adminrecord_Load(object sender, EventArgs e)
        {

            reload();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
        }

        private void bunifuDropdown6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try { _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into stud_year values('"+year.Text+"')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            SSMessagebox show = new SSMessagebox("Data Inserted Successfuly");
            show.Show();
            reload();} catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try { _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into stud_program values('" + yeard.Text + "','" + program.Text + "')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            SSMessagebox show = new SSMessagebox("Data Inserted Successfuly");
            reload();} catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
        }
        public void reload()
        {
            yeard.Items.Clear();
            year2d.Items.Clear();
            _func.fill("year", yeard, "stud_year");
            _func.fill("year", year2d, "stud_year");
            _func.fill("year", yeardfill, "stud_year");
            _func.fill("year", yeard2fill, "stud_year");
            _func.fill("year", SchedDay1, "stud_year");
            _func.fill("year", yeard3fill, "stud_year");
            _func.fill("year", yearz, "stud_year");
        }

        private void year2d_SelectedIndexChanged(object sender, EventArgs e)
        {
            progd.Items.Clear();
            progd.Text = "";
            _func.fill("program", progd, "stud_program", "where year = '" + year2d.Text + "'");
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try { _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into stud_section (Section, Year, Program) values('"+sec.Text+"','" + year2d.Text + "','"+progd.Text+"')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            SSMessagebox show = new SSMessagebox("Data Inserted Successfuly");
            show.Show();
            reload();} catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
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

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try {SSQuestionBox Questionbox = new SSQuestionBox("Confirmation to Remove selected year!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From stud_year where year = '" + yeardfill.Text + "'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                SSMessagebox show = new SSMessagebox("Data Deleted Successfuly");
                reload();
            }
            else
            {
                
            } } catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
            
        }

        private void yeard2fill_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", programdfill, "stud_program","where year = '"+yeard2fill.Text+"'");
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try {SSQuestionBox Questionbox = new SSQuestionBox("Confirmation to delete program of the selected year!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From stud_program Where program = '" + programdfill.Text + "' and year = '"+yeard2fill.Text+"'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                SSMessagebox show = new SSMessagebox("Data Deleted Successfuly");
                reload();
            }
            else
            {

            } } catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try {SSQuestionBox Questionbox = new SSQuestionBox("Confirmation to Section inside the program of selected year!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From stud_section Where program = '" + progd1fill.Text + "' and year = '" + yeard3fill.Text + "' and section = '"+secdfill.Text+"'";
                _con.com.ExecuteNonQuery();
                SSMessagebox show = new SSMessagebox("Data Deleted Successfuly");
                _con.condupe.Close();
                reload();
            }
            else
            {

            } } catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
        }

        private void yeard3fill_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", progd1fill, "stud_program", "where year = '" + yeard3fill.Text + "'");

        }

        private void progd1fill_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("section", secdfill, "stud_section", "where year = '" + yeard3fill.Text + "' and program = '"+progd1fill.Text+"'");

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void secdfill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string secId = _func.getSectionID(SchedDay1.Text, SchedDay2.Text, SchedDay3.Text);
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "insert into std_sched (SecID, Day, Time) values('" + secId + "','" + SchedDay4.Text + "','" + SchedDay5.Text + "')";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                SSMessagebox show = new SSMessagebox("Data Inserted Successfuly");
                show.Show();
                reload();
            }
            catch(Exception ex)
            {
                SSMessagebox show = new SSMessagebox("Invalid input");
            }
            
        }

        private void SchedDay2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("section", SchedDay3, "stud_section", "where year = '" + SchedDay1.Text + "' and program = '"+ SchedDay2.Text+"'");
        }

        private void SchedDay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchedDay2.Items.Clear();
            SchedDay2.Text = "";
            _func.fill("program", SchedDay2, "stud_program", "where year = '" + SchedDay1.Text + "'");
        }

        private void SchedTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secid = _func.getfill("secID", "stud_section", $"where year = '{yearz.Text}' and Section = '{secz.Text}' and program = '{progz.Text}'");
            _func.fill("Time", timez, "std_sched", $"where SecID = '{secid}' And Day = '{dayz.Text}'");
        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            SSMessagebox MessageBox;
            try { string secid = _func.getfill("secID", "stud_section", $"where year = '{yearz.Text}' and Section = '{secz.Text}' and program = '{progz.Text}'");
            SSQuestionBox Questionbox = new SSQuestionBox("Confirmation to Delete the sched!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = $"Delete From std_sched Where secID = '{secid}' and day = '{dayz.Text}' and time = '{timez.Text}'";
                _con.com.ExecuteNonQuery();
                SSMessagebox show = new SSMessagebox("Data Deleted Successfuly");
                _con.condupe.Close();
                reload();
            }
            else
            {

            }} catch (Exception Ex) { MessageBox = new SSMessagebox("Failed"); MessageBox.Show(); }
            
        }

        private void secz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secid = _func.getfill("secID", "stud_section", $"where year = '{yearz.Text}' and Section = '{secz.Text}' and program = '{progz.Text}'");
            _func.fill("Day", dayz, "std_sched", $"where SecID = '{secid}'");
        }

        private void SchedDay3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void yearz_SelectedIndexChanged(object sender, EventArgs e)
        {
            progz.Items.Clear();
            progz.Text = "";
            _func.fill("program", progz, "stud_program", "where year = '" + yearz.Text + "'");
        }

        private void progz_SelectedIndexChanged(object sender, EventArgs e)
        {
            secz.Items.Clear();
            secz.Text = "";
            _func.fill("section", secz, "stud_section", "where year = '" + yearz.Text + "' and program = '" + progz.Text + "'");
        }

        private void timez_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SchedDay5_OnValueChanged(object sender, EventArgs e)
        {
            
        }

        private void SchedDay5_MouseClick(object sender, MouseEventArgs e)
        {
            if (SchedDay5.Text.Equals("00:00"))
            {
                SchedDay5.Text = "";
            }
        }
    }
}

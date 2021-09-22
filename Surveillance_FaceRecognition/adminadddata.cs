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
    public partial class adminadddata : Form
    {
        connection _con = new connection();
        function _func = new function();
        public adminadddata()
        {
            InitializeComponent();
            ddfill.Enabled = false;
        }

        private void adminrecord_Load(object sender, EventArgs e)
        {

            reload();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into book_categ values('"+categ.Text+"')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            reload();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
        }

        private void bunifuDropdown6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into stud_year values('"+year.Text+"')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            reload();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into stud_program values('" + yeard.Text + "','" + program.Text + "')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            reload();
        }
        public void reload()
        {
            yeard.Items.Clear();
            year2d.Items.Clear();
            categfill.Items.Clear();
            ccfill.Items.Clear();
            _func.fill("year", yeard, "stud_year");
            _func.fill("year", year2d, "stud_year");
            _func.fill("category", categfill, "book_categ");
            _func.fill("creditscore", ccfill, "borrow_duration");
            _func.fill("year", yeardfill, "stud_year");
            _func.fill("year", yeard2fill, "stud_year");

            _func.fill("year", yeard3fill, "stud_year");
        }

        private void year2d_SelectedIndexChanged(object sender, EventArgs e)
        {
            progd.Items.Clear();
            progd.Text = "";
            _func.fill("program", progd, "stud_program", "where year = '" + year2d.Text + "'");
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into stud_section values('"+sec.Text+"','" + year2d.Text + "','"+progd.Text+"')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            reload();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            _con.condupe.Open();
            _con.com = _con.condupe.CreateCommand();
            _con.com.CommandType = System.Data.CommandType.Text;
            _con.com.CommandText = "insert into borrow_duration values('" + cc.Text + "','"+dd.Text+"')";
            _con.com.ExecuteNonQuery();
            _con.condupe.Close();
            reload();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            QuestionBox Questionbox = new QuestionBox("Confirmation to Delete Category Data!");
            Questionbox.ShowDialog();

            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From book_categ Where category = '" + categfill.Text + "'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                reload();
            }
            else
            {

            }
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            QuestionBox Questionbox = new QuestionBox("Confirmation to Delete Credit score data!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From borrow_duration Where creditscore = '" + ccfill.Text + "'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                reload();
            }
            else
            {

            }

        }

        private void ccfill_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddfill.Text = _func.getfill("duration", "borrow_duration","where creditscore = '"+ccfill.Text+"'");
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            QuestionBox Questionbox = new QuestionBox("Confirmation to Remove selected year!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From stud_year where year = '" + yeardfill.Text + "'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                reload();
            }
            else
            {
                
            }
            
        }

        private void yeard2fill_SelectedIndexChanged(object sender, EventArgs e)
        {
            _func.fill("program", programdfill, "stud_program","where year = '"+yeard2fill.Text+"'");
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            QuestionBox Questionbox = new QuestionBox("Confirmation to delete program of the selected year!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From stud_program Where program = '" + programdfill.Text + "' and year = '"+yeard2fill.Text+"'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                reload();
            }
            else
            {

            }
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            QuestionBox Questionbox = new QuestionBox("Confirmation to Section inside the program of selected year!");
            Questionbox.ShowDialog();
            if (Questionbox.answer == true)
            {
                _con.condupe.Open();
                _con.com = _con.condupe.CreateCommand();
                _con.com.CommandType = System.Data.CommandType.Text;
                _con.com.CommandText = "Delete From stud_section Where program = '" + progd1fill.Text + "' and year = '" + yeard3fill.Text + "' and section = '"+secdfill.Text+"'";
                _con.com.ExecuteNonQuery();
                _con.condupe.Close();
                reload();
            }
            else
            {

            }
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
    }
}

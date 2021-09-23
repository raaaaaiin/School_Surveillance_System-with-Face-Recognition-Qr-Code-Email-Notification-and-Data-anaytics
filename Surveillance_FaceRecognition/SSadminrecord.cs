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

namespace Surveillance_FaceRecognition
{
    public partial class SSadminrecord : Form
    {
        string table = "";
        string column = "";
        string parameter = "";
        string search = "";
        connection _con = new connection();
        public SSadminrecord()
        {
            InitializeComponent();
        }

        private void adminrecord_Load(object sender, EventArgs e)
        {
           
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.BackColor = Color.FromArgb(27,27,27);
                string fullquery = "Select " + column + " from " + table + " " + parameter + "";
                _con.adp = new MySqlDataAdapter();
                _con.adp.SelectCommand = new MySqlCommand(fullquery, _con.condupe);
                _con.dt = new DataTable();
                _con.adp.Fill(_con.dt);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = _con.dt;
                dataGridView1.DataSource = bSource;
            }
            catch
            {
                SSMessagebox MessageBox = new SSMessagebox("There is no selected filter!"); MessageBox.Show();
            }
           
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            search = searchbar.Text;
            if (Category.Text.Equals("Book"))
            {
                table = "book";
                column = "title,Author,page,quantity";
                parameter = "where " +
                    "title = '" + search + "' or " +
                    "Author = '" + search + "' or " +
                    "page = '" + search + "' or " +
                    "quantity = '" + search + "'";
            }
            else if (Category.Text.Equals("Records"))
            {
                table = "book_records inner join stud_info on book_records.Student_id = stud_info.UID ";
                column = "Concat(stud_info.Last_Name,' ',stud_info.First_Name,' ',SUBSTRING(stud_info.Middle_Name,1,1),'. ',stud_info.suffix) as Borrower,book_records.Borrowed_book as Book,book_records.isReturned as Returned,book_records.expected_return as Deadline,book_records.borrow_duration as Duration";
                parameter = "where " +
                   "UID = '" + search + "' or " +
                       "First_Name = '" + search + "' or " +
                       "Middle_name = '" + search + "' or " +
                       "Last_Name = '" + search + "' or " +
                       "suffix = '" + search + "' or " +
                       "stud_level = '" + search + "' or " +
                       "stud_section = '" + search + "' or " +
                       "stud_sy = '" + search + "' or " +
                       "user_prvlg = '" + search + "' or " +
                       "concat(First_Name,' ',Middle_Name,' ',Last_Name) = '" + search + "' or " +
                       "concat(Last_Name,' ',First_Name,' ',Middle_Name) = '" + search + "' or " +
                       "concat(stud_section,' ',stud_level) = '" + search + "' or " +
                       "concat(stud_level,' ',stud_section) = '" + search + "' or " +
                       "concat(stud_section,' ',stud_sy) = '" + search + "' or " +
                       "concat(stud_sy,' ',stud_section) = '" + search + "' or " +
                       "concat(user_prvlg,' ',Last_Name) = '" + search + "'";
            }
            else if (Category.Text.Equals("Section"))
            {
                table = "stud_section";
                column = "Year,Program,Section";
                parameter = "where year='"+search+"' or program='"+ search + "'or section='"+ search + "'";
            }
            else if (Category.Text.Equals("User"))
            {
                table = "stud_info";
                column = "Concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.',suffix) as FullName,Concat(Stud_level,' ',stud_program,' ',stud_section) as Section, user_prvlg as Role";
                parameter = "where " +
                   "UID = '" + search + "' or " +
                       "First_Name = '" + search + "' or " +
                       "Middle_name = '" + search + "' or " +
                       "Last_Name = '" + search + "' or " +
                       "suffix = '" + search + "' or " +
                       "stud_level = '" + search + "' or " +
                       "stud_section = '" + search + "' or " +
                       "stud_sy = '" + search + "' or " +
                       "user_prvlg = '" + search + "' or " +
                       "concat(First_Name,' ',Middle_Name,' ',Last_Name) = '" + search + "' or " +
                       "concat(Last_Name,' ',First_Name,' ',Middle_Name) = '" + search + "' or " +
                       "concat(stud_section,' ',stud_level) = '" + search + "' or " +
                       "concat(stud_level,' ',stud_section) = '" + search + "' or " +
                       "concat(stud_section,' ',stud_sy) = '" + search + "' or " +
                       "concat(stud_sy,' ',stud_section) = '" + search + "' or " +
                       "concat(user_prvlg,' ',Last_Name) = '" + search + "'";

            }
            else if (Category.Text.Equals("Borrowed book"))
            {
                table = "book_records";
            }
            else if (Category.Text.Equals("Returned Book"))
            {
                table = "book_records";
            }else if (Category.Text.Equals("Category"))
            {
                table = "book_categ";
                column = "category";
            }
            else
            {
               
            }
            string fullquery = "Select " + column + " from " + table + " " + parameter + "";
            _con.adp = new MySqlDataAdapter();
            _con.adp.SelectCommand = new MySqlCommand(fullquery, _con.condupe);
            _con.dt = new DataTable();
            _con.adp.Fill(_con.dt);
            BindingSource bSource = new BindingSource();
            bSource.DataSource = _con.dt;
            dataGridView1.DataSource = bSource;
            parameter = "";
        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            parameter = "";
            if (Category.Text.Equals("Book")) {
                table = "book";
                column = "title,Author,page,quantity";

            }
            else if (Category.Text.Equals("Records"))
            {
                table = "book_records inner join stud_info on book_records.Student_id = stud_info.UID";
                column = "Concat(stud_info.Last_Name,' ',stud_info.First_Name,' ',SUBSTRING(stud_info.Middle_Name,1,1),'. ',stud_info.suffix) as Borrower,book_records.Borrowed_book as Book,book_records.isReturned as Returned,book_records.expected_return as Deadline,book_records.borrow_duration as Duration";

            }
            else if (Category.Text.Equals("Section"))
            {
                table = "stud_section";
                column = "Year,Program,Section";

            }
            else if (Category.Text.Equals("User"))
            {
                table = "stud_info";
                column = "Concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'. ',suffix) as FullName,Concat(Stud_level,' ',stud_program,' ',stud_section) as Section, user_prvlg as Role";
               }
            else if (Category.Text.Equals("Borrowed Book"))
            {
                table = "`stud_info` inner join book_records on stud_info.uid = book_records.student_id where isReturned = 'false'";
                column = "Concat(Last_Name, ' ', First_Name, ' ', Middle_name) As Student_Name, Concat(stud_level, ' ', stud_program, ' ', stud_section)As Section, Borrowed_book as Book_Title,isReturned";
            }
            else if (Category.Text.Equals("Returned Book"))
            {
                table = "`stud_info` inner join book_records on stud_info.uid = book_records.student_id where isReturned = 'true'";
                column = "Concat(Last_Name, ' ', First_Name, ' ', Middle_name) As Student_Name, Concat(stud_level, ' ', stud_program, ' ', stud_section)As Section, Borrowed_book as Book_Title,isReturned";
            }
            if (Category.Text.Equals("Category"))
            {
                table = "book_categ";
                column = "category";
            }

        }
    }
}

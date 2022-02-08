using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    public partial class EmailSender : Form
    {
        public string userName;
        fileHandler _file = new fileHandler();
        function _func = new function();
        DataHandler _cache = new DataHandler();
        Bitmap objBitmap;
        string email;
        string[] advisoryname;
        string[] advisoryprogram;
        string[] advisorysection;
        string[] advisoryid;
        string[] advisorylevel;
        string[] advisoryemail;
        string[] advisorysy;
        string sy;
        bool selectadviser;


        private string id = "";
        public EmailSender()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void InputName_Load(object sender, EventArgs e)
        {
            _func.fill("year", yeard, "stud_year");
            advisoryid = _func.getarray("UID", "UID", "stud_info", "");
            advisoryname = _func.getarray("UID", "concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.')", "stud_info", "order by Last_Name asc");
            advisoryprogram = _func.getarray("UID", "stud_program", "stud_info", "order by Last_Name asc");
            advisorysection = _func.getarray("UID", "stud_section", "stud_info", "order by Last_Name asc");
            advisorylevel = _func.getarray("UID", "stud_level", "stud_info", "order by Last_Name asc");
            advisoryemail = _func.getarray("UID", "Email", "stud_info", "order by Last_Name asc");
            advisorysy = _func.getarray("UID", "stud_sy", "stud_info", "order by Last_Name asc");
            _func.fill("concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.')", Adviser, "stud_info", "order by Last_Name asc");
            BindingSource theBindingSource = new BindingSource();
            theBindingSource.DataSource = advisoryname;
            Adviser.DataSource = theBindingSource.DataSource;
            selectadviser = false;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
         
            
        }
       
        public void loaddata()
        {
           
            
        }
       

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void verifyText(object sender, EventArgs e)
        {
           
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lastname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string month = metroDateTime1.Value.ToString("MMMM");
            string year = metroDateTime1.Value.ToString("yyyy");
            string day = metroDateTime1.Value.ToString("dd");
            email = _func.getfill("email", "stud_info", $"where stud_level = '{yeard.Text}' and stud_program = '{programd.Text}' and stud_section = '{secd.Text}'");
            _func.emailBuilder(day, month, year, yeard.Text, programd.Text, secd.Text, syy.Text, email);
            MessageBox.Show("Email send successfully", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
            programd.Items.Clear();
            programd.Text = "";
            _func.fill("program", programd, "stud_program", "where year = '" + yeard.Text + "'");
        }

        private void program_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            _func.fill("section", secd, "stud_section", "where year = '" + yeard.Text + "' and program = '" + programd.Text + "'");
        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            string month = metroDateTime1.Value.ToString("MMMM");
            string year = metroDateTime1.Value.ToString("yyyy");
            string day = metroDateTime1.Value.ToString("dd");
            if (bunifuMetroTextbox1.Text.Equals(""))
            {

            }
            else
            {

            email = bunifuMetroTextbox1.Text;
            }
            
           
            _func.emailBuilder(day, month, year, yeard.Text, programd.Text, secd.Text, syy.Text, email);
            MessageBox.Show("Email send successfully", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void secd_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            _func.fill("stud_sy", syy, "stud_info", "Where stud_section = '" + secd.Text + "' and stud_level = '" + yeard.Text + "' and stud_program = '" + programd.Text + "'  Limit 1");
            



        }

        private void Adviser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = Adviser.SelectedIndex;
            if (selectadviser == true)
            {
                email = advisoryemail[selected];
            }
            else
            {
                programd.Text = advisoryprogram[selected];
                yeard.Text = advisorylevel[selected];
                secd.Text = advisorysection[selected];
                syy.Text = advisorysy[selected];
                email = advisoryemail[selected];
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string month = metroDateTime1.Value.ToString("MMMM"); 
            string year = metroDateTime1.Value.ToString("yyyy");
            string day = metroDateTime1.Value.ToString("dd");
            for (int i = 0; i < advisoryid.Length; i++)
            {

                email = advisoryemail[i];
                _func.emailBuilder(day, month, year, advisorylevel[i], advisoryprogram[i], advisorysection[i], syy.Text, advisoryemail[i]);
            }
            MessageBox.Show("Email send successfully", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void syy_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectadviser = true;
        }
    }
}

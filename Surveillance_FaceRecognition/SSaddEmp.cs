using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
  
    public partial class AddstudentForm : Form
    {
        fileHandler _file = new fileHandler();
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton bonepu;
        public bool pressed = false;
        static int count = 0;

        SSmenu main;
         function _func = new function();
        public AddstudentForm(SSmenu ths)
        {
            InitializeComponent();
            bunifuButton1.Enabled = false;
            main = ths;
            if ((count % 2) == 0)
            {
                panel1.BackColor = Color.FromArgb(245, 245, 245); ;
                count++;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(235, 235, 235);
                count++;
            }

           

           
        }

        private void bunifuDropdown3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
            Switch(true);
            try{ _func.delStud(FirstNameText.Text, MiddleNameText.Text, LastNameText.Text, SuffixText.Text); } catch { MessageBox.Show("Invalid Input"); }
            bunifuButton2.Enabled = true;
            bonepu = bunifuButton1;
            timer1.Start();
        }

        private void Addstudent_Load(object sender, EventArgs e)
        {
            _func.fill("year", Yeard, "stud_year", " Order by year Asc");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            accountType.SelectedIndex.Equals(accountType.Items[0]);
            try
            {
                string secid = "";
                string year = Yeard.Text;
                string program = Progd.Text;
                string sec = secD.Text;
                string sy = "";
                string priv = accountType.Text;
                String sDate = DateTime.Now.ToString();
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                int yy = datevalue.Year % 100;
                int mn = datevalue.Month;

                if (mn <= 5)
                {
                    sy = (yy - 1).ToString() + "-" + (yy).ToString();
                } else if (mn >= 6)
                {
                    sy = (yy).ToString() + "-" + (yy + 1).ToString();
                }

                if (pressed == true) {
                }
                else
                {

                    main.addstud();
                }

                Switch(false);
                pressed = true;
                bonepu = bunifuButton2;
                bunifuButton1.Enabled = true;
                if (year == null || sec == null || program == null)
                {
                    secid = "Not yet assigned";
                }
                else
                {
                     secid = _func.getSectionID(year, program, sec);

                }
                _func.addStudent(LastNameText.Text, FirstNameText.Text, MiddleNameText.Text, SuffixText.Text, year, sec, program, priv, sy, secid);
               
                timer1.Start();
            } catch(Exception ex) { //SSMessagebox MessageBox = new SSMessagebox("Invalid Input!");
                                    MessageBox.Show(ex.ToString()); }
           
            
        }
        public void Switch(Boolean indicator)
        {

            SuffixText.Enabled = indicator;
            LastNameText.Enabled = indicator;
            FirstNameText.Enabled = indicator;
            MiddleNameText.Enabled = indicator;
            Yeard.Enabled = indicator;
            Progd.Enabled = indicator;
            secD.Enabled = indicator;
            accountType.Enabled = indicator;
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bunifuButton1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bunifuButton1.Enabled = true;
        }

        private void LastNameText_Click(object sender, EventArgs e)
        {
            if (LastNameText.Text.Equals("LastName"))
            {
                LastNameText.Text = "";
            }
        }

        private void FirstNameText_Click(object sender, EventArgs e)
        {
            if (FirstNameText.Text.Equals("FirstName"))
            {
                FirstNameText.Text = "";
            }
        }

        private void MiddleNameText_Click(object sender, EventArgs e)
        {
            MiddleNameText.Text = "";
        }

        private void SuffixText_Click(object sender, EventArgs e)
        {
            if (SuffixText.Text.Equals("Suffix"))
            {
                SuffixText.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bonepu.Enabled = false;
            timer1.Stop();
        }

        private void Yeard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Progd.Items.Clear();
            _func.fill("program", Progd, "stud_program", "where year = '"+Yeard.Text+"'");
        }

        private void Progd_SelectedIndexChanged(object sender, EventArgs e)
        {
            secD.Items.Clear();
            _func.fill("Section", secD, "stud_section", "where year = '" + Yeard.Text + "' and program = '"+Progd.Text+"'");
        }

        private void SuffixText_Enter(object sender, EventArgs e)
        {
            SuffixText.Text = "";
        }

        private void LastNameText_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void MiddleNameText_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void accountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FirstNameText_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void secD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SuffixText_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}

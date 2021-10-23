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
    public partial class SSaddStd : Form
    {
        public bool pressed = false;
        static int count = 0;
        SSmenu _main;
        function _func = new function();
        bool indicator;
        public string id = "";
        Bunifu.UI.WinForms.BunifuButton.BunifuButton selectedbutton;
        public Bunifu.UI.WinForms.BunifuButton.BunifuButton bonepu;
        public SSaddStd(SSmenu ths)
        {
            InitializeComponent();
            bunifuButton2.Enabled = false;
            _main = ths;
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

       

        
        private void Switch(bool indicator)
        {
            SuffixText.Enabled = indicator;
            LastNameText.Enabled = indicator;
            FirstNameText.Enabled = indicator;
            MiddleNameText.Enabled = indicator;
            Yeard.Enabled = indicator;
            Progd.Enabled = indicator;
            secD.Enabled = indicator;
            STDNumber.Enabled = indicator;


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }

        private void pg_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

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
        private void Yeard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Progd.Items.Clear();
            _func.fill("program", Progd, "stud_program", "where year = '" + Yeard.Text + "'");
        }

        private void Progd_SelectedIndexChanged(object sender, EventArgs e)
        {
            secD.Items.Clear();
            _func.fill("Section", secD, "stud_section", "where year = '" + Yeard.Text + "' and program = '" + Progd.Text + "'");
        }

        private void SuffixText_Enter(object sender, EventArgs e)
        {
            SuffixText.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            selectedbutton.Enabled = false;
            timer1.Stop();
        }

        private void categ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                string year = Yeard.Text;
                string program = Progd.Text;
                string sec = secD.Text;
                string sy = "";
                string stdID = STDNumber.Text;
                String sDate = DateTime.Now.ToString();
                DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
                int yy = datevalue.Year % 100;
                int mn = datevalue.Month;

                if (mn <= 5)
                {
                    sy = (yy - 1).ToString() + "-" + (yy).ToString();
                }
                else if (mn >= 6)
                {
                    sy = (yy).ToString() + "-" + (yy + 1).ToString();
                }

                if (pressed == true)
                {
                }
                else
                {

                    _main.addStd();
                }

                Switch(false);
                pressed = true;
                bonepu = bunifuButton2;
                bunifuButton2.Enabled = true;
                try
                {
                    _func.addStd(stdID, LastNameText.Text, FirstNameText.Text, MiddleNameText.Text, SuffixText.Text, year, sec, program, sy);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                selectedbutton = bunifuButton3;
                timer1.Start();
            }
            catch(Exception ex) { SSMessagebox MessageBox = new SSMessagebox("Invalid Input!"); MessageBox.Show(); }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Switch(true);
            try { _func.delStd(STDNumber.Text);;
            } catch { }

            bunifuButton3.Enabled = true;
            selectedbutton = bunifuButton2;
            timer1.Start();
        }

        private void SSaddStd_Load(object sender, EventArgs e)
        {
            _func.fill("year", Yeard, "stud_year", " Order by year Asc");
            selectedbutton = bunifuButton2;

        }

        private void Yeard_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Progd.Items.Clear();
            _func.fill("program", Progd, "stud_program", "where year = '" + Yeard.Text + "'");
        }

        private void Progd_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            secD.Items.Clear();
            _func.fill("Section", secD, "stud_section", "where year = '" + Yeard.Text + "' and program = '" + Progd.Text + "'");
        } 

        private void secD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SuffixText_Click_1(object sender, EventArgs e)
        {
            
        }

        private void MiddleNameText_MouseClick(object sender, MouseEventArgs e)
        {
            if (MiddleNameText.Text.Equals("Middle Name"))
            {
                MiddleNameText.Text = "";
            }
        }
    }
}

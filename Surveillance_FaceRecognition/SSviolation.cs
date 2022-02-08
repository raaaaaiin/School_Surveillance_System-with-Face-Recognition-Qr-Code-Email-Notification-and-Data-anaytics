using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Surveillance_FaceRecognition
{
    public partial class SSviolation : Form
    {
        public string userName;
        fileHandler _file = new fileHandler();
        function _func = new function();
        DataHandler _cache = new DataHandler();
        Bitmap objBitmap;
        string[] vioid;
      
        ArrayList Violation = new ArrayList();
        bool selectadviser;


        private string id = "";
        public SSviolation(string id)
        {
            InitializeComponent();
            info.Multiline = true;
            // Add vertical scroll bars to the TextBox control.
            info.ScrollBars = ScrollBars.Vertical;
            // Allow the TAB key to be entered in the TextBox control.
            info.AcceptsReturn = true;
            // Allow the TAB key to be entered in the TextBox control.
            info.AcceptsTab = true;
            this.id = id;
            _func.editStd(id);
            name.Text = _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1);
            yeard.Text = _cache.returnslctd_std(4);
            programd.Text = _cache.returnslctd_std(7);
            secd.Text = _cache.returnslctd_std(5);
            syy.Text = _cache.returnslctd_std(6);
            _func.fill("concat(violation, ' @ ', date)", remVio, "violation", "where studentid = '" + id + "' and remark = 'Pending'");
            info.Text = _func.showViolation(id);
            vioid = _func.getarray("id","id","violation", "where studentid = '" + id + "' and remark = 'Pending'");
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
          

            _func.addViolation(id,name.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),addVio.Text);

            SSMessagebox show = new SSMessagebox("Violation Added");
            show.Show();
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
            try
            {
                _func.deleteViolation(vioid[remVio.SelectedIndex]);
                SSMessagebox show = new SSMessagebox("Violation Removed");
                show.Show();
                _func.fill("violation", remVio, "violation", "where studentid = '" + id + "' and remark = 'Pending'");
                info.Text = _func.showViolation(id);
                vioid = _func.getarray("id", "id", "violation", "where studentid = '" + id + "' and remark = 'Pending'");
                _func.fill("concat(violation, ' @ ', date)", remVio, "violation", "where studentid = '" + id + "' and remark = 'Pending'");
            }
            catch(Exception ex)
            {
                SSMessagebox show = new SSMessagebox("Error please reload the student violation form");
                show.Show();
            }
            
        }

        private void secd_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            _func.fill("stud_sy", syy, "stud_info", "Where stud_section = '" + secd.Text + "' and stud_level = '" + yeard.Text + "' and stud_program = '" + programd.Text + "'  Limit 1");
            



        }

        private void Adviser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (selectadviser == true)
            {
            }
            else
            {
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void syy_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectadviser = true;
        }

        private void remVio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

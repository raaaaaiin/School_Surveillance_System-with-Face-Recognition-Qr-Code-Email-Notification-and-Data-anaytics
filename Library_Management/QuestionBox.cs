using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class QuestionBox : Form
    {
        public bool answer = false;
        public QuestionBox(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            answer = true;
            this.Close();
        }

        private void bunifuButton2_Click_1(object sender, EventArgs e)
        {
            answer = false;
            this.Close();
        }
    }
}

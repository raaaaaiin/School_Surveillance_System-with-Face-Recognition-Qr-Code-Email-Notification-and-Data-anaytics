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
    public partial class SSMessagebox : Form
    {
        public SSMessagebox(string text)
        {
            InitializeComponent();
            label1.Text = text;
            timer1.Start();
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

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

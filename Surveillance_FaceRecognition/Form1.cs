using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace Surveillance_FaceRecognition
{
    public partial class Form1 : Form
    {
        function _func = new function();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            _func.emailBuilder("14","November","2021","1","BSCS","203","21-22","marcraineer0089@gmail.com");

        }
    }
}

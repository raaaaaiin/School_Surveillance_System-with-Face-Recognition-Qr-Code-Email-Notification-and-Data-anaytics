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
    public partial class addBooks : Form
    {
        public bool pressed = false;
        static int count = 0;
        menu _main;
        function _func = new function();
        bool indicator;
        public string id = "";
        Bunifu.UI.WinForms.BunifuButton.BunifuButton selectedbutton;
        public addBooks(menu ths)
        {
            InitializeComponent();
            _func.fill("Category", categ,"book_categ", " Order by Category ASC");
            bunifuButton1.Enabled = false;
            bunifuButton6.Enabled = false;
            categ.Enabled = false;
            _main = ths;
            if ((count % 2) == 0)
            {
                panel4.BackColor = Color.FromArgb(45,45,45);
                count++;
            }
            else
            {
                panel4.BackColor = Color.FromArgb(50,50,50);
                count++;
            }

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            try
            {
                _func.addBooks(title.Text, author.Text, categ.Text, pg.Text, qty.Text);
                
                if (pressed == false)
                {
                    _main.addbook();

                }
                id = _func.readIdBook(title.Text, author.Text);
                pressed = true;
                selectedbutton = bunifuButton5;
                bunifuButton6.Enabled = true;
                timer1.Start();
                Switch(false);
            }
            catch { MessageBox.Show("May error ka"); }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            Switch(true);
            try { _func.delBooks(title.Text, author.Text); } catch { }

            bunifuButton5.Enabled = true;
            selectedbutton = bunifuButton6;
            timer1.Start();
        }
        private void Switch(bool indicator)
        {
            title.Enabled = indicator;
            author.Enabled = indicator;
            pg.Enabled = indicator;
            categ.Enabled = !indicator;
            bunifuButton1.Enabled = !indicator;


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try {
                _func.addBookscateg(id,categ.Text);
                
            }
            catch
            {

            }


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

        private void timer1_Tick(object sender, EventArgs e)
        {
            selectedbutton.Enabled = false;
            timer1.Stop();
        }

        private void categ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

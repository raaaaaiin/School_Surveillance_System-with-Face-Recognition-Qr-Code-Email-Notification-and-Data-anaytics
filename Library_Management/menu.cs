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
    public partial class menu : Form
    {
        static notificationBar _notif;
        static int upcontrol = 1;
        public string setrole = "";
        public editStudentinfo _stdInfBox;
        public editBookinfo _bookInfBox;
        public adminForm _adminForm;
        public menu()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            notif.Hide();
            booksmenu.Hide();
           
          if(setrole.Equals("Admin"))
            {
                previlages _priv = new previlages(this);
                _priv.TopLevel = false;
                _priv.TopMost = true;
                prvlg.Controls.Add(_priv);
                _priv.Show();
            }
            else
            {
                MessageBox.Show("There is no role such as : " + setrole);
            }
           
            timer1.Start();
            label1.Text = "Library management: Connected to Database2.accdb : Developed by Raineer Filosopo";

        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Time : " + DateTime.Now.ToString("HH:mm:ss");
        }
        public void addstud()
        {
            AddstudentForm _add = new AddstudentForm(this);
            _add.TopLevel = false;
            _add.TopMost = true;
            panel2.Controls.Add(_add);
            _add.Show();
            _add.Top = upcontrol * 68;
            upcontrol = upcontrol + 1;
            if (upcontrol >= 9)
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                upcontrol = 0;
                addstud();
            }

            
        }
        public void addbook()
        {
            addBooks _addbooks = new addBooks(this);
            _addbooks.TopLevel = false;
            _addbooks.TopMost = true;
            panel2.Controls.Add(_addbooks);
            _addbooks.Show();
            _addbooks.Top = upcontrol * 68;
            upcontrol = upcontrol + 1;
            if (upcontrol >= 9)
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                upcontrol = 0;
                addbook();
            }

        }

        public void reset()
        {
            panel2.Controls.Clear();
            notif.Hide();
            booksmenu.Hide();
            upcontrol = 0;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showMenu2(string identifier)
        {
            
            notif.Show();
            _notif.Show();
            _notif.forshow(identifier);
            booksmenu.Show();


        }

        public void showMenu2()
        {

           _notif = new notificationBar(this);
            _notif.forinitiatebox();
            _notif.TopLevel = false;
            _notif.TopMost = true;
            notif.Controls.Add(_notif);
            

        }
      
        private void notif_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showStdFrm(string id)
        {
            _stdInfBox.changedata(id);
            showStdEdit();
        }
        public void hide()
        {
            _bookInfBox.Hide();
            _stdInfBox.Hide();
        }
        public void showbookFrm(string id)
        {
            _bookInfBox.changedata(id);
            showBookEdit();
        }

        public void preinitstdfrm()
        {
            
                _stdInfBox = new editStudentinfo(this);
                _stdInfBox.TopLevel = false;
                _stdInfBox.TopMost = true;
                _stdInfBox.Location = new Point(0, 0);
                booksmenu.Controls.Add(_stdInfBox);
                _stdInfBox.Hide();
                booksmenu.Hide();
            
                _bookInfBox = new editBookinfo(this);
                _bookInfBox.TopLevel = false;
                _bookInfBox.TopMost = true;
                _bookInfBox.Show();
                booksmenu.Controls.Add(_bookInfBox);
                _bookInfBox.Hide();
                booksmenu.Hide();

            
                

            
            
        }
        public void showStdEdit()
        {

            _bookInfBox.Hide();
            _stdInfBox.Show();
        }
        public void showBookEdit()
        {
            _stdInfBox.Hide();
            _bookInfBox.Show();
        }
        public void preInit()
        {
            preinitstdfrm();
            showMenu2();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showStdFrm("1");
        }

        private void booksmenu_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showRecord()
        {
            panel2.Controls.Clear();
            notif.Hide();
            booksmenu.Hide();
            _adminForm = new adminForm(this) { TopLevel = false };
            panel2.Controls.Add(_adminForm);
            _adminForm.Show();

        }
        
    }
}
 
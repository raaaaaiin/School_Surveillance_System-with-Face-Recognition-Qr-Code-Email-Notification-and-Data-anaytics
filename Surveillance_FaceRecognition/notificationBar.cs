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
    public partial class notificationBar : Form 
    {

        SSmenu _menu;
        connection _con = new connection();
        function _func = new function();
        SSstudentBox[] _Studentbox = new SSstudentBox[9];
        DataHandler cache = new DataHandler();
        public string[,] info;
        static int next = 7;
        static int current = 0;
        int loc = 0;
        static int index = 0;
        string filter = "";
        int end = -1;
        string search = "";
        public static string identify = "null";
        public notificationBar(SSmenu ths)
        {
            InitializeComponent();
            _menu = ths;
        }
        
        public void forinitiatebox()
        {
            for (int i = 0; i <= 7; i++)
            {
                _Studentbox[i] = new SSstudentBox(_menu,"","","",identify) { TopLevel = false };
                jonel.Controls.AddRange(_Studentbox);
                _Studentbox[i].Location = new Point(0, loc);
                loc += 68;
            }
           
        }
        public void forshow(string identifier)
        {
            identify = identifier;
            if (identify.Equals("STD"))
            {
                for (int i = 0; i <= 7; i++)
                {
                    try
                    {
                        _Studentbox[i].identify = "STD";
                        _Studentbox[i].fullname = cache.returnstud_info(index, 0);
                        _Studentbox[i].section = cache.returnstud_info(index, 1);
                        _Studentbox[i].id = cache.returnstud_info(index, 2);
                        _Studentbox[i].process();
                        _Studentbox[i].Show();
                        index++;

                    }
                    catch
                    {
                        end = index;
                        _Studentbox[i].Hide();
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 7; i++)
                {
                    try
                    {
                        _Studentbox[i].identify = "Books";
                        _Studentbox[i].fullname = cache.returnbook_info(index, 0);
                        _Studentbox[i].section = cache.returnbook_info(index, 1);
                        _Studentbox[i].id = cache.returnbook_info(index, 2);
                        _Studentbox[i].process();
                        _Studentbox[i].Show();
                        index++;

                    }
                    catch
                    {
                        end = index;
                        _Studentbox[i].Hide();
                    }

                }
               
            }
        }
       
        public void fornextstudent()
        {
            
            for (int i = 0; i <= 7 ; i++)
            {
                try
                {

                    _Studentbox[i].fullname = cache.returnstud_info(index, 0);
                    _Studentbox[i].section = cache.returnstud_info(index, 1);
                    _Studentbox[i].id = cache.returnstud_info(index, 2);
                    _Studentbox[i].process();
                    _Studentbox[i].Show();
                    index++;

                }
                catch
                {
                    end = index;
                    _Studentbox[i].Hide();
                }
                
            }

        }


        //
        
        public void fornextbook()
        {
          
                for (int i = 0; i <= 7; i++)
                {
                    try
                    {

                        _Studentbox[i].fullname = cache.returnbook_info(index, 0);
                        _Studentbox[i].section = cache.returnbook_info(index, 1);
                        _Studentbox[i].id = cache.returnbook_info(index, 2);
                        _Studentbox[i].process();
                        _Studentbox[i].Show();
                        index++;

                    }
                    catch
                    {
                        end = index;
                        _Studentbox[i].Hide();
                    }

                }
            
            

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (identify.Equals("STD"))
            {
                _func.OverwriteloadDataSTD(bunifuMaterialTextbox1.Text);
                index = 0;
                fornextstudent();
            }
            else
            {
                _func.overWriteloadDataBook(bunifuMaterialTextbox1.Text);
                index = 0;
                fornextbook();
            }
                
            

        }


     //

        private void bunifuMaterialTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void jonel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            
            
        }




        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (end != index)
            {
                if (identify.Equals("STD"))
                {
                    fornextstudent();
                }
                else
                {
                    fornextbook();
                }
            }
                         
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (index >= 14)
            {
                index -= 7 * 2;
                if (identify.Equals("STD"))
                {
                    fornextstudent();
                }
                else{
                    fornextbook();
                }
            }
            else if (index > 7 && index < 14){
                index = 0;
                if (identify.Equals("STD"))
                {
                    fornextstudent();
                }
                else
                {
                    fornextbook();
                }
            }
            
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            if (identify.Equals("STD"))
            {
                _func.OverwriteloadDataSTD(bunifuMaterialTextbox1.Text);
                index = 0;
                fornextstudent();
            }
            else
            {
                _func.overWriteloadDataBook(bunifuMaterialTextbox1.Text);
                index = 0;
                fornextbook();
            }
        }
    }
}

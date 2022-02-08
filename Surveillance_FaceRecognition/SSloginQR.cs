using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using BasselTech_CamCapture;
using ZXing;

namespace Surveillance_FaceRecognition
{
    public partial class SSloginQR : Form
    {
        connection _con;
        function _func = new function();
        fileHandler _filehandler = new fileHandler();
        Camera cam;
        Timer t;
        BackgroundWorker worker;
        Bitmap CapImage;
        public SSloginQR()
        {
            InitializeComponent();
            t = new Timer();
            cam = new Camera(pictureBox1);
            worker = new BackgroundWorker();

            worker.DoWork += Worker_DoWork;
            t.Tick += T_Tick;
            t.Interval = 1;
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                bool auth = false;
                _func.logIn(Textbox1.Text, Textbox2.Text);
                auth = _func.authentication();
                if (auth == true)
                {
                    SSmenu manu = new SSmenu();
                    manu.setrole = _func.role;
                    manu.preInit();
                    manu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }
            catch
            {
                MessageBox.Show("Connection to Database Failed!");
            }


        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LFRForm1 reg = new LFRForm1();
            reg.Show();
        }




        private void T_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result = barcode.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    MessageBox.Show(result.ToString());
                    t.Stop();
                   

                }

            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            QRCodeDecoder Decoder = new QRCodeDecoder();

            try
            {
                MessageBox.Show(Decoder.decode(new QRCodeBitmapImage(CapImage)));
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            /*
            t.Stop();   // I forgot this line in the video
            cam.Stop();
            SSlogIn newlog = new SSlogIn();
            newlog.Show();
            this.Close();*/
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
            try
            {
                cam.Start();
                t.Start();
            }
            catch (Exception ex)
            {
                cam.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
    }
}

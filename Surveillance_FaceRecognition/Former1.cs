using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using AForge.Video.DirectShow;
using AForge.Video;
using ZXing;

namespace Surveillance_FaceRecognition
{
    public partial class Former1 : Form
    {
        Timer t;
        BackgroundWorker worker;
        Bitmap CapImage;
        connection _con;
        function _func = new function();
        createInfo _info = new createInfo();
        fileHandler _filehandler = new fileHandler();
        SSmenu manu = new SSmenu();
        String camera = "";
        FilterInfoCollection filter;
        VideoCaptureDevice captureDevice;

        bool accepted = false;
        public Former1( )
        {
            InitializeComponent();
            SSmenu manu = new SSmenu();
            manu.setrole = "Admin";
            manu.preInit();
        }

        private void T_Tick(object sender, EventArgs e)
        {

           
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                captureDevice.Start();
                t.Start();
                button2.Enabled = true;
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                captureDevice.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();   // I forgot this line in the video
            captureDevice.Stop();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filter[0].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            timer1.Stop();   // I forgot this line in the video
            captureDevice.Stop();
            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                captureDevice.Stop();
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
            catch(NullReferenceException ex)
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


        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result = barcode.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    
                    try
                    {

                        _func.logIn(_info.DecryptCipherTextToPlainText(result.ToString()));
                        bool auth = false;
                        auth = _func.authentication();
                        if (auth == true)
                        {
                            captureDevice.Stop();
                           
                            SSmenu manu = new SSmenu();

                            manu.setrole = _func.role;
                            manu.preInit();
                            manu.Show();
                            this.Hide();
                            accepted = true;
                            timer1.Stop();

                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                        }
                        timer1.Stop();
                        if (captureDevice.IsRunning)
                            captureDevice.Stop();

                    }
                    catch (Exception ex)
                    {
                    }
                }

            }
        }
    }
}

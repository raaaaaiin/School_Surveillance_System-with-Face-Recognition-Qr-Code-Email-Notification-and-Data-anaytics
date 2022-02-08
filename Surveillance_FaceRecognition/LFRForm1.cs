using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Luxand;
using MySql.Data.MySqlClient;

namespace Surveillance_FaceRecognition
{
    public partial class LFRForm1 : Form
    {
        // program states: whether we recognize faces, or user has clicked a face
        enum ProgramState { psRemember, psRecognize }
        ProgramState programState = ProgramState.psRecognize;
        connection conn = new connection();
        String cameraName;
        bool needClose = false;
        string userName;
        String TrackerMemoryFile = "tracker70.dat";
        int mouseX = 0;
        int mouseY = 0;
        byte[] savedFacedata;
        function _func = new function();
        public long[] IDs;
        public long faceCount = 0;
        public string[] signalLock;
        string count = "0";
        public SSUserpanel studentshower;
        public int trialcount = 0;
        public int counter;

        // WinAPI procedure to release HBITMAP handles returned by FSDKCam.GrabFrame
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        public LFRForm1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (FSDK.FSDKE_OK != FSDK.ActivateLibrary("fVrFCzYC5wOtEVspKM/zfLWVcSIZA4RNqx74s+QngdvRiCC7z7MHlSf2w3+OUyAZkTFeD4kSpfVPcRVIqAKWUZzJG975b/P4HNNzpl11edXGIyGrTO/DImoZksDSRs6wktvgr8lnNCB5IukIPV5j/jBKlgL5aqiwSfyCR8UdC9s="))
            {
                MessageBox.Show("Please run the License Key Wizard (Start - Luxand - FaceSDK - License Key Wizard)", "Error activating FaceSDK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            FSDK.InitializeLibrary();
            FSDKCam.InitializeCapturing();

            string [] cameraList;
            int count;
            FSDKCam.GetCameraList(out cameraList, out count);

            if (0 == count) {
                MessageBox.Show("Please attach a camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            cameraName = cameraList[0];

            FSDKCam.VideoFormatInfo[] formatList;
            FSDKCam.GetVideoFormatList(ref cameraName, out formatList, out count);

            int VideoFormat = 0; // choose a video format
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 50;
            //pictureBox1.Width = formatList[VideoFormat].Width;
            //pictureBox1.Height = formatList[VideoFormat].Height;
            //this.Width = formatList[VideoFormat].Width + 48;
            //this.Height = formatList[VideoFormat].Height + 96;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            needClose = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            timer1.Start();
            int cameraHandle = 0;

            int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            if (r != FSDK.FSDKE_OK)
            {
                MessageBox.Show("Error opening the first camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            int tracker = 0; 	// creating a Tracker
            if (FSDK.FSDKE_OK != FSDK.LoadTrackerMemoryFromFile(ref tracker, TrackerMemoryFile))
            {
                MessageBox.Show("Not Loaded");
                FSDK.CreateTracker(ref tracker);
            }// try to load saved tracker state
             // if could not be loaded, create a new tracker
            //int err = 0; // set realtime face detection parameters
            //without facemask
            // FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetectMultipleFaces=true; DetermineFaceRotationAngle=false; InternalResizeWidth=384; FaceDetectionThreshold=1;", ref err);

            //with facemask

            int err = 0;
            FSDK.SetTrackerMultipleParameters(tracker, "RecognizeFaces=true; HandleArbitraryRotations=true;DetermineFaceRotationAngle = false; InternalResizeWidth = 1024; FaceDetectionThreshold = 1;FaceDetectionModel=fd_masks1.bin;TrimFacesWithUncertainFacialFeatures=false ", ref err);

            


            while (!needClose)
            {
                Int32 imageHandle = 0;

                
                if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
                {
                    Application.DoEvents();
                    continue;
                }
                FSDK.CImage image = new FSDK.CImage(imageHandle);

                faceCount = 0;
                FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum of 256 faces detected
                Array.Resize(ref IDs, (int)faceCount);
                counter = 0;


        // make UI controls accessible (to find if the user clicked on a face)
        Application.DoEvents();

                Image frameImage = image.ToCLRImage();
                Graphics gr = Graphics.FromImage(frameImage);

                for (int i = 0; i < IDs.Length; ++i)
                {
                    FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
                    FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);

                    int left = facePosition.xc - (int)(facePosition.w * 0.6);
                    int top = facePosition.yc - (int)(facePosition.w * 0.5);
                    int w = (int)(facePosition.w * 1.2);

                    String name;
                    int res = FSDK.GetAllNames(tracker, IDs[i], out name, 65536); // maximum of 65536 characters

                    if (FSDK.FSDKE_OK == res && name.Length > 0)
                    { // draw name
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        
                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen),
                            facePosition.xc, top + w + 5, format);
                        gr.DrawString(_func.saveRecord(name.ToString(), studentshower), new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen),
                            facePosition.xc, top + 18 + w + 5, format);
                        trialcount += 1;
                        Console.WriteLine(trialcount + " :Face Detected");
                        count = _func.getPendingViolation(name);
                        if (count.Equals("0"))
                        {
                           
                        }
                        else
                        {
                            gr.DrawString("Violation: " + count, new System.Drawing.Font("Arial", 16),
                          new System.Drawing.SolidBrush(System.Drawing.Color.Red),
                          facePosition.xc, top + 18 + 18 + w + 5, format);
                        }
                       


                    }
                    if (FSDK.FSDKE_OK == res && name.Equals(""))
                    {
                        // draw name
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.Red),
                            facePosition.xc, top + w + 5, format);
                        trialcount += 1;
                        Console.WriteLine(trialcount + " :Generate Sound not detected");
                    }

                    Pen pen = Pens.LightGreen;

                    if (mouseX >= left && mouseX <= left + w && mouseY >= top && mouseY <= top + w)
                    {
                        pen = Pens.Blue;
                        if (ProgramState.psRemember == programState)
                        {
                            if (FSDK.FSDKE_OK == FSDK.LockID(tracker, IDs[i]))
                            {
                                LFRInputName inputName = new LFRInputName();
                                if (DialogResult.OK == inputName.ShowDialog())
                                {
                                    userName = inputName.userName;
                                    if (userName == null || userName.Length == 0)
                                    {
                                        String s = "Unknown";
                                        FSDK.SetName(tracker, IDs[i], "Unknown Face");
                                    }
                                    else
                                    {
                                        FSDK.SetName(tracker, IDs[i], userName);



                                    }
                                    FSDK.UnlockID(tracker, IDs[i]);
                                }
                            }
                        }
                    }
                    gr.DrawRectangle(pen, left, top, w, w);
                }
                programState = ProgramState.psRecognize;

                // display current frame
                pictureBox1.Image = frameImage;
                GC.Collect(); // collect the garbage after the deletion
            }
            //original code to save to file is below 
            FSDK.SaveTrackerMemoryToFile(tracker, TrackerMemoryFile);

            //Save to Database mysql free to delete

            //byte[] trackerData;
            //FSDK.SaveTrackerMemoryToBuffer(1, out trackerData, 50000);
            //Console.WriteLine(trackerData);
            //checkData(trackerData);
            //end my personal file
            FSDK.FreeTracker(tracker);
            FSDKCam.CloseVideoCamera(cameraHandle);
            FSDKCam.FinalizeCapturing();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            programState = ProgramState.psRemember;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            mouseX = 0;
            mouseY = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _func.resetLock();
        }

        private void LFRForm1_ResizeBegin(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 44;
        }

        private void LFRForm1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 44;
        }
        public void Stop()
        {
            needClose = true;
        }

        private void LFRForm1_ClientSizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height - 44;
        }
    }
}

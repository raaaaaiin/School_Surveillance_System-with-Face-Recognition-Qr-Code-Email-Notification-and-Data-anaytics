 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Below is for Camera


using System.Runtime.InteropServices;
using Luxand;
using MySql.Data.MySqlClient;

namespace Surveillance_FaceRecognition
{
    public partial class SSmenu : Form
    {
        static notificationBar _notif;
        static int upcontrol = 1;
        public string setrole = "";
        public SSeditStaffinfo _stdInfBox;
        public SSeditStdinfo _editstdinfo;
        public SSadminForm _adminForm;
        public SSnextback[] _nextback = new SSnextback[1];
        public SSsectionBox[] _Sectionbox;
        public long[] IDs;
        public long faceCount = 0;
        public string[] signalLock;
        public int counter;



        enum ProgramState { psRemember, psRecognize }
        ProgramState programState = ProgramState.psRecognize;
        connection conn = new connection();
        String cameraName;
        bool needClose = false;
        string userName;
        String TrackerMemoryFile = "tracker70.dat";
        int mouseX = 0;
        int mouseY = 0;
        int TempX = 71, TempY = 35;
        function _func = new function();

        // WinAPI procedure to release HBITMAP handles returned by FSDKCam.GrabFrame
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        public SSmenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

            notif.Hide();
            stdstaffmenu.Hide();
            pictureBox3.Hide();
            if (setrole.Equals("Admin"))
            {
                SSprevilages _priv = new SSprevilages(this);
                _priv.TopLevel = false;
                _priv.TopMost = true;
                prvlg.Controls.Add(_priv);
                _priv.Show();
            }
            else if (setrole.Equals("Staff"))
            {
                SSprevilagesUser _priv = new SSprevilagesUser(this);
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
            timer2.Start();



            // Face Recog



            if (FSDK.FSDKE_OK != FSDK.ActivateLibrary("fVrFCzYC5wOtEVspKM/zfLWVcSIZA4RNqx74s+QngdvRiCC7z7MHlSf2w3+OUyAZkTFeD4kSpfVPcRVIqAKWUZzJG975b/P4HNNzpl11edXGIyGrTO/DImoZksDSRs6wktvgr8lnNCB5IukIPV5j/jBKlgL5aqiwSfyCR8UdC9s="))
            {
                MessageBox.Show("Please run the License Key Wizard (Start - Luxand - FaceSDK - License Key Wizard)", "Error activating FaceSDK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            FSDK.InitializeLibrary();
            FSDKCam.InitializeCapturing();

            string[] cameraList;
            int count;
            FSDKCam.GetCameraList(out cameraList, out count);

            if (0 == count)
            {
                MessageBox.Show("Please attach a camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            cameraName = cameraList[0];

            FSDKCam.VideoFormatInfo[] formatList;
            FSDKCam.GetVideoFormatList(ref cameraName, out formatList, out count);

            int VideoFormat = 0; // choose a video format
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox3.Width = formatList[VideoFormat].Width;
            //pictureBox3.Height = formatList[VideoFormat].Height;
            //this.Width = pictureBox1.Width +48;
            //this.Height = pictureBox1.Height + 96;
            //this.Width = formatList[VideoFormat].Width + 200;
            //this.Height = formatList[VideoFormat].Height + 200;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _func.resetLock();

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
            panel2.Show();


        }
        public void addstdstaff()
        {
            SSaddStd _SSaddstd = new SSaddStd(this);
            _SSaddstd.TopLevel = false;
            _SSaddstd.TopMost = true;
            panel2.Controls.Add(_SSaddstd);
            _SSaddstd.Show();
            _SSaddstd.Top = upcontrol * 68;
            upcontrol = upcontrol + 1;
            if (upcontrol >= 9)
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                upcontrol = 0;
                addstdstaff();
            }
            panel2.Show();

        }
        public void addStd()
        {
            SSaddStd _addStd = new SSaddStd(this);
            _addStd.TopLevel = false;
            _addStd.TopMost = true;
            panel2.Controls.Add(_addStd);
            _addStd.Top = upcontrol * 68;
            upcontrol = upcontrol + 1;
            if (upcontrol >= 9)
            {
                panel2.Controls.Clear();
                panel2.Refresh();
                upcontrol = 0;
                addStd();
            }
            _addStd.Show();
            panel2.Show();
        }

        public void reset()
        {
            offCam();
            pictureBox3.Hide();
            panel2.Controls.Clear();
            notif.Hide();
            stdstaffmenu.Hide();
            panel2.Hide();
            upcontrol = 0;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            needClose = true;
            this.Dispose();
            SSlogIn _log = new SSlogIn();
            _log.Show();
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void showMenu2(string identifier)
        {
            notif.Show();
            _notif.resetIndex();
            _notif.Show();
            _notif.forshow(identifier);
            stdstaffmenu.Show();


        }

        public void showMenu2()
        {

            _notif = new notificationBar(this);
            _notif.resetIndex();
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
            _editstdinfo.Hide();
            _stdInfBox.Hide();
        }
        public void showstdinfoFrm(string id)
        {

            _editstdinfo.changedata(id);

            showstdinfoEdit();
        }

        public void preinitstdfrm()
        {

            _stdInfBox = new SSeditStaffinfo(this);
            _stdInfBox.TopLevel = false;
            _stdInfBox.TopMost = true;
            _stdInfBox.Location = new Point(0, 0);
            stdstaffmenu.Controls.Add(_stdInfBox);

            _stdInfBox.Hide();
            stdstaffmenu.Hide();

            _editstdinfo = new SSeditStdinfo(this);
            _editstdinfo.TopLevel = false;
            _editstdinfo.TopMost = true;


            _editstdinfo.Show();
            stdstaffmenu.Controls.Add(_editstdinfo);
            _editstdinfo.Hide();
            stdstaffmenu.Hide();






        }
        public void showStdEdit()
        {

            _editstdinfo.Hide();
            _stdInfBox.Show();
        }
        public void showstdinfoEdit()
        {
            _stdInfBox.Hide();
            _editstdinfo.Show();
        }
        public void preInit()
        {
            preinitstdfrm();
            showMenu2();
        }
        public void hidepanel()
        {
            panel2.Hide();
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
            stdstaffmenu.Hide();
            _adminForm = new SSadminForm(this) { TopLevel = false };
            panel2.Controls.Add(_adminForm);
            _adminForm.Show();
            panel2.Show();




        }

        private void prvlg_Paint(object sender, PaintEventArgs e)
        {

        }



















        /* LFR FORM 1 MERGE */









        public void InitiateCamera()
        {
            pictureBox3.Show();

            needClose = false;
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
            int err = 0; // set realtime face detection parameters
            FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetectMultipleFaces=true; DetermineFaceRotationAngle=false; InternalResizeWidth=384; FaceDetectionThreshold=1;", ref err);

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



                    }
                    if (FSDK.FSDKE_OK == res && name.Equals("Unknown Face"))
                    {
                        // draw name
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.Red),
                            facePosition.xc, top + w + 5, format);
                    }

                    Pen pen = Pens.LightGreen;

                    if (mouseX >= left && mouseX <= left + w && mouseY >= top && mouseY <= top + w)
                    {
                        pen = Pens.Blue;
                        Console.WriteLine("Hatodoko2");
                        if (ProgramState.psRemember == programState)
                        {
                            Console.WriteLine("Hatodoko1");
                            if (FSDK.FSDKE_OK == FSDK.LockID(tracker, IDs[i]))
                            {
                                // get the user name
                                Console.WriteLine("Hatodoko");
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
                pictureBox3.Image = frameImage;
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


        public void InitiateSurveillance()
        {
            pictureBox3.Show();
            needClose = false;
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
            int err = 0; // set realtime face detection parameters
            FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetectMultipleFaces=true; DetermineFaceRotationAngle=false; InternalResizeWidth=384; FaceDetectionThreshold=1;", ref err);

            while (!needClose)
            {
                Int32 imageHandle = 0;
                if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
                {
                    Application.DoEvents();
                    continue;
                }
                FSDK.CImage image = new FSDK.CImage(imageHandle);

                long[] IDs;
                long faceCount = 0;
                FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum of 256 faces detected
                Array.Resize(ref IDs, (int)faceCount);

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
                    }
                    if (FSDK.FSDKE_OK == res && name.Equals(""))
                    { // draw name
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;

                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.Red),
                            facePosition.xc, top + w + 5, format);
                    }

                    Pen pen = Pens.LightGreen;

                    if (mouseX >= left && mouseX <= left + w && mouseY >= top && mouseY <= top + w)
                    {
                        pen = Pens.Blue;
                        if (ProgramState.psRemember == programState)
                        {

                            if (FSDK.FSDKE_OK == FSDK.LockID(tracker, IDs[i]))
                            {
                                // get the user name

                                LFRInputName inputName = new LFRInputName();
                                if (DialogResult.OK == inputName.ShowDialog())
                                {
                                    userName = inputName.userName;
                                    if (userName == null || userName.Length <= 0)
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
                pictureBox3.Image = frameImage;
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


        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            programState = ProgramState.psRemember;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X + TempX;
            mouseY = e.Y + TempY;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            mouseX = 0;
            mouseY = 0;
        }

        public void offCam()
        {
            pictureBox3.Hide();
            needClose = true;
        }























        //For client

















        public string[,] info;
        static int next = 7;
        static int current = 0;
        int locX = 2;
        int locY = 0;
        static int index = 0;
        string filter = "";
        int end = -1;
        string search = "";
        public static string identify = "null";

        public void showRecSurv(LFRForm1 asd)
        {
            panel2.Controls.Clear();
            notif.Hide();
            stdstaffmenu.Hide();
            SSUserpanel _userpanel = new SSUserpanel(asd) { TopLevel = false };
            panel2.Controls.Add(_userpanel);
            _userpanel.Show();
            panel2.Show();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Text = "Time: " + DateTime.Now.ToString();
        }

        private void SSmenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            reset();
        }

        private void SSmenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            reset();
        }

        public void initiateSection()
        {

            locX = 0;
            locY = 0;
            panel2.Hide();
            current = 0;
            panel2.Controls.Clear();
            pictureBox2.Hide();
            for (int z = 0; z <= 2; z++)
            {
                for (int i = 0; i <= 3; i++)
                {
                    _Sectionbox[current] = new SSsectionBox(this) { TopLevel = false };
                    panel2.Controls.AddRange(_Sectionbox);
                    _Sectionbox[current].Location = new Point(locX, locY);
                    _Sectionbox[current].Show();
                    current += 1;
                    locX += 233;


                }
                locX = 0;
                locY += 195;
            }
            locY = panel2.Size.Height - 35;
            _nextback[0] = new SSnextback(this, "", "", "", "") { TopLevel = false };
            panel2.Controls.AddRange(_nextback);
            _nextback[0].Location = new Point((panel2.Width - _nextback[0].Size.Width) / 2, locY);
            _nextback[0].Show();
            panel2.Show();
        }




    }
   
    
}
 
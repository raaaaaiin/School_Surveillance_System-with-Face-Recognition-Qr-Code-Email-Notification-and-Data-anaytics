using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    class fileHandler 
    {
        string imagestd;
        string imagebooks;
        public string path;
        connection _con = new connection();
        public string[] dataTransfer = new string[6];
        public void Initialize()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string fileName = path + "Config.properties";
            path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));
            path += '\\';
           
        }
        public void createProperties()
        {
            string fileName = path + "Config.properties";
            try
            {
                // Check if file already exists. If yes, delete it.     
               
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.WriteLine("#E-lib Configuration Properties");
                        sw.WriteLine("#file created: {0}", DateTime.Now.ToString());
                        sw.WriteLine("usingPassword = "+ dataTransfer [0]+ "");
                        sw.WriteLine("uid = " + dataTransfer[1] + "");
                        sw.WriteLine("pass = " + dataTransfer[2] + "");
                        sw.WriteLine("server = " + dataTransfer[3] + "");
                        sw.WriteLine("port = " + dataTransfer[4] + "");
                        sw.WriteLine("dataBase = " + dataTransfer[5] + "");
                    }  
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        public void readFile()
        {
            bool signal = false;
            int i = 0;
            string selected;
            string fileName = path + "Config.properties";
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Substring(s.LastIndexOf("=")+2).Equals("false")){
                        signal = true;
                    }
                    if(signal == true) { 
                    selected = s.Substring(s.LastIndexOf("=") + 2);
                        dataTransfer[i] = selected;
                        i++;
                    }
                }
            }
            _con.setCon(dataTransfer[3], dataTransfer[5], dataTransfer[1], dataTransfer[2]);
        }
        }
    }


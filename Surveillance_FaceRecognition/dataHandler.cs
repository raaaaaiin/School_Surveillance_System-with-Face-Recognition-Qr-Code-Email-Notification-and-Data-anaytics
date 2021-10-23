using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    class DataHandler
    {
        private static string[,] staff_info;
        private static string[,] std_info;
        private static string[] slctd_staff = new string[13];
        private static string[] slctd_std = new string[13];
        private static string[] user_std = new string[13];

        private string selected_stdId;
        
        public string selected_stdID
        {

            get { return selected_stdId; }

            set { selected_stdId = value; }

        }
       

        public void populateslctd_staff(int index, string info)
        {
            slctd_staff[index] = info;
        }
        public string returnslctd_staff(int index)
        {
            return slctd_staff[index];
        }
        public void populateslctd_std(int index, string info)
        {
            slctd_std[index] = info;
        }
        public string returnslctd_std(int index)
        {
            return slctd_staff[index];
        }
        public void populateuser_staff(int index, string info)
        {
            user_std[index] = info;
        }
        public string returnuser_std(int index)
        {
            return user_std[index];
        }
        public void setstaff_info(int counter)
        {
            
            staff_info = new string[counter, 3];
        }
        public void populatestaff_info(int counter,string data,int index)
        {
            staff_info[counter, index] = data;
        }
        public string returnstaff_info(int counter, int index)
        {
            return staff_info[counter, index];
        }
        public void setstd_info(int counter)
        {
            std_info = new string[counter, 3];
        }
        public void populatestd_info(int counter, string data, int index)
        {
            std_info[counter, index] = data;
        }
        public string returnstd_info(int counter, int index)
        {
            return std_info[counter, index];
        }
        public void clearslctd()
        {
            for(int i = 0; i< slctd_std.Length;i++)
            {
                slctd_std[i] = "";
            }
            for (int i = 0; i < slctd_staff.Length; i++)
            {
                slctd_staff[i] = "";
            }
        }
        

    }
}

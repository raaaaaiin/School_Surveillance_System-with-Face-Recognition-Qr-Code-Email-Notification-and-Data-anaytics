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
        private static string[,] stud_info;
        private static string[,] book_info;
        private static string[] slctd_std = new string[13];
        private static string[] slctd_book = new string[13];
        private static string[] user_std = new string[13];

        private string selected_stdId;
        
        public string selected_stdID
        {

            get { return selected_stdId; }

            set { selected_stdId = value; }

        }
        public string[,] std_info { get { return (string[,])stud_info.Clone(); } }

        public void populateslctd_std(int index, string info)
        {
            slctd_std[index] = info;
        }
        public string returnslctd_std(int index)
        {
            return slctd_std[index];
        }
        public void populateslctd_book(int index, string info)
        {
            slctd_book[index] = info;
        }
        public string returnslctd_book(int index)
        {
            return slctd_book[index];
        }
        public void populateuser_std(int index, string info)
        {
            user_std[index] = info;
        }
        public string returnuser_std(int index)
        {
            return user_std[index];
        }
        public void setstud_info(int counter)
        {
            
            stud_info = new string[counter, 3];
        }
        public void populatestud_info(int counter,string data,int index)
        {
            stud_info[counter, index] = data;
        }
        public string returnstud_info(int counter, int index)
        {
            return stud_info[counter, index];
        }
        public void setbook_info(int counter)
        {
            book_info = new string[counter, 3];
        }
        public void populatebook_info(int counter, string data, int index)
        {
            book_info[counter, index] = data;
        }
        public string returnbook_info(int counter, int index)
        {
            return book_info[counter, index];
        }
        public void clearslctd()
        {
            for(int i = 0; i< slctd_book.Length;i++)
            {
                slctd_book[i] = "";
            }
            for (int i = 0; i < slctd_std.Length; i++)
            {
                slctd_std[i] = "";
            }
        }
        

    }
}

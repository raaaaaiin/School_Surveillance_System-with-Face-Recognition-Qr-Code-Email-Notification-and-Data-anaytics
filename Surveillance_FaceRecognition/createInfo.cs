using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surveillance_FaceRecognition
{
    class createInfo : connection
    {
        public void insertBooks()
        {

        }
     
        public void inserteacc(string Id, string username, string password, string role)
        {
            
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "insert into user_acc values('" + Id + "','" + username + "','" + password + "','" + role + "')";
            com.ExecuteNonQuery();
            con.Close();
            con.Open();
            com.CommandText = "insert into stud_status(Id,isLegible,credit_score,returned_quantity,Hours_borrowed,borrowed_book_quan) values('" + Id + "','True','100','0','0','0')";
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}

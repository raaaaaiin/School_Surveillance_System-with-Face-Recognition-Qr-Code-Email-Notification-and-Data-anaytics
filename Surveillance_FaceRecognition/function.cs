using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surveillance_FaceRecognition
{
    class function : connection
    {
        createInfo _inf = new createInfo();
        DataHandler _cache = new DataHandler();
        private Boolean authuser = false, authpass = false;
        public int laststdindex = 0;
        public string role = "";
        public string book_id;
        public void addStudent(string lastname, string firstname, string middlename, string suffix, string year, string section, string program, string prvlg,string sy)
        {
            try { 
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "insert into Stud_info(first_name,middle_name,last_name,suffix,stud_level,stud_section,stud_program,user_prvlg,stud_sy) values('" + firstname + "' , '" + middlename + "', '" + lastname + "','" + suffix + "','" + year + "','" + section + "','" + program + "','" + prvlg + "','" + sy + "')";
            com.ExecuteNonQuery();
            con.Close();
            string id = readId(firstname, middlename, lastname, suffix);
            if (prvlg.Equals("Admin"))
            {
                _inf.inserteacc(id, lastname, "admin", "Admin");

            }
            else
            {
                _inf.inserteacc(id, lastname, firstname + lastname + section, "Student");
            }
            loadDataStud();
            }
            catch
            {

            }
        }
        public void delStud(string firstname, string middlename, string lastname, string suffix)
        {
            string id = readId(firstname, middlename, lastname, suffix);
            con.Open();

            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Delete From Stud_info Where UID = '"+id+"'";
            com.ExecuteNonQuery();
            con.Close();
            con.Open();

            com.CommandText = "Delete From user_acc Where UID = '" + id + "'";
            com.ExecuteNonQuery();
            con.Close();
            con.Open();

            com.CommandText = "Delete From stud_status Where iD = '" + id + "'";
            com.ExecuteNonQuery();
            con.Close();
        }
        
        public void fill(string column, System.Windows.Forms.ComboBox selected, string table)
        {
            selected.Items.Clear();
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT "+column+ " FROM " + table + " where " + column + " IS not null order by "+column+" ASC";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[column].ToString().Length != 0)
                    {
                        selected.Items.Add(reader[column].ToString());
                    }
                    else
                    {

                    }


                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        public void fill(string column, System.Windows.Forms.ComboBox selected, string table, string parameter)
        {
            selected.Items.Clear();
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT " + column + " FROM " + table + " "+parameter+"";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[column].ToString().Length != 0)
                    {
                        selected.Items.Add(reader[column].ToString());
                    }
                    else
                    {

                    }


                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        public string getfill(string column, string table, string parameter)
        {
            string item = "";
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT " + column + " FROM " + table + " " + parameter + "";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[column].ToString().Length != 0)
                    {
                        item = (reader[column].ToString());
                    }
                    else
                    {

                    }


                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return item;

        }
        public string readId(string firstname, string middlename, string lastname, string suffix)
        {
            string id = "";
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Select * from stud_info Where first_name = '" + firstname + "' and middle_name = '" + middlename + "' and last_name ='" + lastname + "' and suffix = '" + suffix + "'";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                if (reader["UID"].ToString().Length != 0)
                {
                    id = (reader["UID"].ToString());
                }
                else
                {

                }


            }
            con.Close();
            return id;
        }
        public string readIdBook(string title, string author)
        {
            string id = "";
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Select id from book Where Title = '" + title + "' and Author = '" + author + "'";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString().Length != 0)
                {
                    id = (reader[0].ToString());
                }
                else
                {

                }


            }
            con.Close();
            return id;
        }
        public void addBooks(string title, string author, string category, string page, string qty)
        {
             
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "insert into book(Title, Author, Page, Quantity) values('" + title + "','" + author + "','" + page + "','" + qty + "')";
            com.ExecuteNonQuery();
            con.Close();
            book_id = readIdBook(title, author);

        }
        public void addBookscateg(string book_id,string category)
        {
            int indicator = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "select * from book_categ_data where book_id='"+book_id+"' and category='"+category+"'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    indicator++;
                }
                con.Close();
            }
            catch 
            {

            }
            if(indicator == 0)
            {
                try
                {
                    con.Open();
                    com = con.CreateCommand();
                    com.CommandType = System.Data.CommandType.Text;
                    com.CommandText = "insert INTO book_categ_data(book_id,Category) values('" + book_id + "','" + category + "')";
                    com.ExecuteNonQuery();
                    con.Close();
                    SSMessagebox MessageBox = new SSMessagebox("Added new category!"); MessageBox.Show();
                }
                catch
                {

                   
                    con.Close();
                }
            }
            else if(indicator == 1)
            {
                SSMessagebox MessageBox = new SSMessagebox("Duplicate entry of category!"); MessageBox.Show();
            }
            

        }
        public void delBooks(string title, string author)
        {
            string id = readIdBook(title, author);
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Delete From book Where id = '" + id + "'";
            com.ExecuteNonQuery();
            con.Close();
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Delete From book_categ_data Where book_id = '" + id + "' ";
            com.ExecuteNonQuery();
            con.Close();
        }
        public void logIn(String username, string password)
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select * from user_acc where Username = '" + username + "' and Password = '" + password + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    role = (reader["role"].ToString());
                    counter++;

                }
                con.Close();
            }
            catch
            {

                con.Close();
            }
            if (counter == 1)
            {
                authpass = true;
                authuser = true;
            }
            else
            {
                authpass = false;
                authuser = false;
            }
        }
        public bool authentication()
        {
                return authuser == true && authpass == true;
        }
        public void loadDataStud(/*string search,string filter*/)
        {
            readStud();

            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),concat(stud_program,' ',stud_section),UID from stud_info order by UID desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populatestud_info(counter, reader[0].ToString(), 0);
                    _cache.populatestud_info(counter, reader[1].ToString(), 1);
                    _cache.populatestud_info(counter, reader["UID"].ToString(), 2);

                    counter++;
                }
                laststdindex = counter;
                con.Close();
            }
            catch
            {
                con.Close();

            }
        }
        public void readStud()
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),concat(stud_program,' ',stud_section),UID from stud_info order by UID desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }
            }
            catch
            {
                con.Close();
            }
            con.Close();
            _cache.setstud_info(counter);
        }
        public void loadDataBook(/*string search,string filter*/)
        {
            readBook();

            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select ID,Title,Author from book order by ID desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populatebook_info(counter, reader["Title"].ToString(), 0);
                    _cache.populatebook_info(counter, reader["Author"].ToString(), 1);
                    _cache.populatebook_info(counter, reader["ID"].ToString(), 2);

                    counter++;
                }
                con.Close();
            }
            catch
            {
                con.Close();

            }
        }
        public void readBook()
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select ID from book order by ID desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }
            }
            catch
            {
                con.Close();
            }
            con.Close();
            _cache.setbook_info(counter);
        }
        public void overWriteloadDataBook(string search)
        {
            if (search.Equals(""))
            {
                loadDataBook();
            }
            else
            {
                overWritereadBook(search);

                int counter = 0;
                try
                {
                    con.Open();
                    com = con.CreateCommand();
                    com.CommandText = "Select ID,Title,Author from book where Title like '%"+search+"%' or Author like '%" + search +"%' order by ID desc";
                    reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        _cache.populatebook_info(counter, reader[1].ToString(), 0);
                        _cache.populatebook_info(counter, reader[2].ToString(), 1);
                        _cache.populatebook_info(counter, reader[0].ToString(), 2);

                        counter++;
                    }
                    con.Close();
                }
                catch
                {
                    con.Close();

                }
            }
            
        }
        public void overWritereadBook(string search)
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select ID,Title,Author from book where Title like '%" + search + "%' or Author like '%" + search + "%' order by ID desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }
            }
            catch
            {
                con.Close();
            }
            con.Close();
            _cache.setbook_info(counter);
        }
        public void OverwriteloadDataSTD(string search)
        {
            if (search.Equals(""))
            {
                loadDataStud();
            }
            else
            {
                OverwritereadSTD(search);

                int counter = 0;
                try
                {

                    con.Open();
                    com = con.CreateCommand();
                    com.CommandText = "SELECT concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),Concat(stud_program,' ',stud_section),UID FROM `stud_info` where " +
                        "UID like '%" + search + "%' or " +
                        "First_Name like '%" + search + "%' or " +
                        "Middle_name like '%" + search + "%' or " +
                        "Last_Name like '%" + search + "%' or " +
                        "suffix like '%" + search + "%' or " +
                        "stud_level like '%" + search + "%' or " +
                        "stud_section like '%" + search + "%' or " +
                        "stud_sy like '%" + search + "%' or " +
                        "user_prvlg like '%" + search + "%' or " +
                        "concat(First_Name,' ',Middle_Name,' ',Last_Name) like '%" + search + "%' or " +
                        "concat(Last_Name,' ',First_Name,' ',Middle_Name) like '%" + search + "%' or " +
                        "concat(stud_section,' ',stud_level) like '%" + search + "%' or " +
                        "concat(stud_level,' ',stud_section) like '%" + search + "%' or " +
                        "concat(stud_section,' ',stud_sy) like '%" + search + "%' or " +
                        "concat(stud_sy,' ',stud_section) like '%" + search + "%' or " +
                        "concat(user_prvlg,' ',Last_Name) like '%" + search + "%'";
                    reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        _cache.populatestud_info(counter, reader[0].ToString(), 0);
                        _cache.populatestud_info(counter, reader[1].ToString(), 1);
                        _cache.populatestud_info(counter, reader[2].ToString(), 2);
                        counter++;
                    }
                    con.Close();
                }
                catch
                {
                    con.Close();

                }
            }

        }
        public void OverwritereadSTD( string search)
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "SELECT concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),Concat(stud_program,' ',stud_section),UID FROM `stud_info` where " +
                    "UID like '%" + search + "%' or " +
                    "First_Name like '%" + search + "%' or " +
                    "Middle_name like '%" + search + "%' or " +
                    "Last_Name like '%" + search + "%' or " +
                    "suffix like '%" + search + "%' or " +
                    "stud_level like '%" + search + "%' or " +
                    "stud_section like '%" + search + "%' or " +
                    "stud_sy like '%" + search + "%' or " +
                    "user_prvlg like '%" + search + "%' or " +
                    "concat(First_Name,' ',Middle_Name,' ',Last_Name) like '%" + search + "%' or " +
                    "concat(Last_Name,' ',First_Name,' ',Middle_Name) like '%" + search + "%' or " +
                    "concat(stud_section,' ',stud_level) like '%" + search + "%' or " +
                    "concat(stud_level,' ',stud_section) like '%" + search + "%' or " +
                    "concat(stud_section,' ',stud_sy) like '%" + search + "%' or " +
                    "concat(stud_sy,' ',stud_section) like '%" + search + "%' or " +
                    "concat(user_prvlg,' ',Last_Name) like '%" + search + "%'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    counter++;
                }

            }
            catch
            {
                con.Close();

            }
            con.Close();
            _cache.setstud_info(counter);

        }
        public void Editstudent(string id)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select UID, First_Name, Middle_Name, Last_Name, suffix, stud_level, stud_section, stud_sy,user_prvlg,stud_program from Stud_info where UID = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populateslctd_std(11, reader[0].ToString());//uid
                    _cache.populateslctd_std(0, reader[1].ToString());//Firstname
                    _cache.populateslctd_std(1, reader[2].ToString());//Mn
                    _cache.populateslctd_std(2, reader[3].ToString());//Ln
                    _cache.populateslctd_std(3, reader[4].ToString());//suffix
                    _cache.populateslctd_std(4, reader[5].ToString());//stdlvl
                    _cache.populateslctd_std(5, reader[6].ToString());//stdsec
                    _cache.populateslctd_std(6, reader[7].ToString());//stdsy
                    _cache.populateslctd_std(9, reader[8].ToString());//role
                    _cache.populateslctd_std(10, reader[9].ToString());//program
                }
                con.Close();
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select Username, Password from user_acc where UID = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populateslctd_std(7, reader[0].ToString());//username
                    _cache.populateslctd_std(8, reader[1].ToString());//password
                }
                con.Close();
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }


        }
        public void Editbook(string id)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "select * from book where id = '"+id+"'";
                reader = com.ExecuteReader();
                _cache.clearslctd();
                while (reader.Read())
                {
                    _cache.populateslctd_book(0, reader[0].ToString());
                    _cache.populateslctd_book(1, reader[1].ToString());
                    _cache.populateslctd_book(2, reader[2].ToString());
                    _cache.populateslctd_book(3, reader[3].ToString());
                    _cache.populateslctd_book(4, reader[4].ToString());
                    _cache.populateslctd_book(5, reader[5].ToString());
                }
                con.Close();
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "select * from book_info where id = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populateslctd_book(0, reader[0].ToString());
                    _cache.populateslctd_book(7, reader[1].ToString());
                    _cache.populateslctd_book(8, reader[2].ToString());
                    _cache.populateslctd_book(9, reader[3].ToString());
                    _cache.populateslctd_book(10, reader[4].ToString());
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }


        }
        public void Updatestudent(string id, string firstname, string middlename, string lastname, string suffix, string studlevel, string studsection, string studsy,string stdprogram)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Update Stud_info set First_Name = '" +firstname +"' ,stud_program = '"+stdprogram+"',Middle_Name= '" + middlename + "' ,Last_Name= '" + lastname + "' ,suffix= '" + suffix + "' ,stud_level= '" + studlevel + "' ,stud_section= '" + studsection + "' ,stud_sy= '" +studsy + "' where UID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

                
            }
            
            
        }
        public void updatestudentacc(string id,string username,string password,string Role)
        {
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Update user_acc set Username = '" + username + "' ,Password= '" +password+ "' ,role= '" + Role + "' where UID = '" + id + "'";
            com.ExecuteNonQuery();
            SSMessagebox MessageBox = new SSMessagebox("Updated Successfully");MessageBox.Show();
            con.Close();
        }
        public void updateBookinfo(string id,string title,string author, string page, string qty,string information)
        {
            MessageBox.Show(id);
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Update book set title = '" + title + "' ,author= '" + author + "' ,page= '" + page + "' ,Quantity= '" + qty + "',Information = '" + information + "' where ID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
                SSMessagebox MessageBox = new SSMessagebox("Data updated successfully!");MessageBox.Show();
            }
            catch
            {
                SSMessagebox MessageBox = new SSMessagebox("Data updated failed!"); MessageBox.Show();

            }
        }


        public void refresh()
        {
            //loadDataStud();
           // loadDataBook();
        }

        public byte[] retrieveFaceData()
        {
            byte[] faceData = {0x12,0x32};
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select tracker from faceData";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    faceData = (byte[]) reader["tracker"];

                }
                con.Close();
                
            }catch(Exception ex)
            {
                MessageBox.Show("Error Loading face data");
                con.Close();
            }
            return faceData;
        }

    }

}




 
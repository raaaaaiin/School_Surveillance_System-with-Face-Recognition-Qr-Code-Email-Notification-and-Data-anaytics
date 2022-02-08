using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
        public string[] signalLock = new string[65500];
        public int counter = 0;
        public void addStudent(string lastname, string firstname, string middlename, string suffix, string year, string section, string program, string prvlg, string sy, string secid)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "insert into Stud_info(first_name,middle_name,last_name,suffix,stud_level,stud_section,stud_program,user_prvlg,stud_sy,AdvisoryID) values('" + firstname + "' , '" + middlename + "', '" + lastname + "','" + suffix + "','" + year + "','" + section + "','" + program + "','" + prvlg + "','" + sy + "','" + secid + "')";
                com.ExecuteNonQuery();
                con.Close();
                string id = readId(firstname, middlename, lastname, suffix);
                if (prvlg.Equals("Admin"))
                {
                    _inf.inserteacc(id, lastname, lastname + firstname, "Admin");

                }
                else
                {
                    _inf.inserteacc(id, lastname, lastname + firstname, "Staff");
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
            try
            {

                con.Open();

                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Delete From Stud_info Where UID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();

                com.CommandText = "Delete From user_acc Where UID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
            }



        }
        public void delStud(string id)
        {
            try
            {
                con.Open();

                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Delete From Stud_info Where UID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
                con.Open();

                com.CommandText = "Delete From user_acc Where UID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }



        }


        public void fill(string column, System.Windows.Forms.ComboBox selected, string table)
        {
            selected.Items.Clear();
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT " + column + " FROM " + table + " where " + column + " IS not null order by " + column + " ASC";
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
                com.CommandText = "SELECT " + column + " FROM " + table + " " + parameter + "";
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
        public string[] getarray(string singlecolumn, string column, string table, string parameter)
        {
            int i = 0;
            string[] arrayret;
            string count = "";
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT Count(" + singlecolumn + ") FROM " + table + " " + parameter + "";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    count = reader[0].ToString();


                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            arrayret = new String[Int32.Parse(count)];
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

                    arrayret[i] = reader[column].ToString();
                    i++;


                }
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return arrayret;

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

        public string readStdID(string stdID)
        {
            string id = "";
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Select stdID from std Where StdID = '" + stdID + "'";
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

        public void addStd(string stdId, string lastname, string firstname, string middlename, string suffix, string year, string section, string program, string sy)
        {

            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "insert into std (StdID,First_Name,Middle_Name,Last_Name,Suffix,Std_Program,Std_Level,Std_Section,Std_Sy) values('" + stdId + "','" + firstname + "','" + middlename + "','" + lastname + "','" + suffix + "','" + program + "','" + year + "','" + section + "','" + sy + "')";
            com.ExecuteNonQuery();
            con.Close();


        }
        public void closecon()
        {
            con.Close();
        }

        public void delStd(string stdID)
        {
            string id = readStdID(stdID);
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Delete From Std Where StdID = '" + id + "'";
            com.ExecuteNonQuery();
            con.Close();

        }
        public void logIn(String username, string password)
        {
            string id = "";
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
                    id = (reader["UID"].ToString());
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
            readUser(id);
        }
        public void logIn(String id)
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select * from user_acc where UID = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    role = (reader["role"].ToString());
                    id = (reader["UID"].ToString());
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
            readUser(id);
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
                    _cache.populatestaff_info(counter, reader[0].ToString(), 0);
                    _cache.populatestaff_info(counter, reader[1].ToString(), 1);
                    _cache.populatestaff_info(counter, reader["UID"].ToString(), 2);

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
            _cache.setstaff_info(counter);
        }

        public void readSection()
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
            _cache.setSection_info(counter);
        }
        public string readSectionID(string secid)
        {
            string id = "";
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Select stud_section from std Where SecID = '" + secid + "'";
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
        public void loadDataSection(/*string search,string filter*/)
        {
            readSection();

            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select Section,Year,Program,SecID from stud_section order by SecID desc";
                reader = com.ExecuteReader();


                while (reader.Read())
                {
                    _cache.populateSection_info(counter, reader[0].ToString(), 0);//Section
                    _cache.populateSection_info(counter, reader[1].ToString(), 1);//Year
                    _cache.populateSection_info(counter, reader[2].ToString(), 2);//Program
                    _cache.populateSection_info(counter, reader[3].ToString(), 3);//SecID

                    counter++;
                }
                con.Close();
            }
            catch
            {
                con.Close();

            }

        }
        public void loadDataStd(/*string search,string filter*/)
        {
            reaadSTD();

            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),concat(std_program,' ',std_section),StdID from std  order by ID desc";
                reader = com.ExecuteReader();


                while (reader.Read())
                {
                    _cache.populatestd_info(counter, reader[0].ToString(), 0);
                    _cache.populatestd_info(counter, reader[1].ToString(), 1);
                    _cache.populatestd_info(counter, reader["StdID"].ToString(), 2);

                    counter++;
                }
                con.Close();
            }
            catch
            {
                con.Close();

            }

        }

        public void reaadSTD()
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "Select stdID from Std order by stdID desc";
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
            _cache.setstd_info(counter);
        }
        public void overWriteloadDataSTD(string search)
        {
            if (search.Equals(""))
            {
                loadDataStd();
            }
            else
            {
                overWritereadSTD(search);

                int counter = 0;
                try
                {
                    con.Open();
                    com = con.CreateCommand();
                    com.CommandText = "SELECT concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),Concat(std_program,' ',std_section),StdID FROM `std` where " +
                        "StdID like '%" + search + "%' or " +
                        "First_Name like '%" + search + "%' or " +
                        "Middle_name like '%" + search + "%' or " +
                        "Last_Name like '%" + search + "%' or " +
                        "suffix like '%" + search + "%' or " +
                        "std_level like '%" + search + "%' or " +
                        "std_program like '%" + search + "%' or " +
                        "std_section like '%" + search + "%' or " +
                        "std_sy like '%" + search + "%' or " +
                        "concat(First_Name,' ',Middle_Name,' ',Last_Name) like '%" + search + "%' or " +
                        "concat(Last_Name,' ',First_Name,' ',Middle_Name) like '%" + search + "%' or " +
                        "concat(std_section,' ',std_level) like '%" + search + "%' or " +
                        "concat(std_program,' ',std_section) like '%" + search + "%' or " +
                        "concat(std_level,' ',std_section) like '%" + search + "%' or " +
                        "concat(std_section,' ',std_sy) like '%" + search + "%' or " +
                        "concat(std_sy,' ',std_section) like '%" + search + "%'";
                    reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        _cache.populatestd_info(counter, reader[0].ToString(), 0);
                        _cache.populatestd_info(counter, reader[1].ToString(), 1);
                        _cache.populatestd_info(counter, reader[2].ToString(), 2);

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
        public void overWritereadSTD(string search)
        {
            int counter = 0;
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandText = "SELECT concat(Last_Name,' ',First_Name,' ',SUBSTRING(Middle_Name,1,1),'.'),Concat(std_program,' ',std_section),StdID FROM `std` where " +
                        "StdID like '%" + search + "%' or " +
                        "First_Name like '%" + search + "%' or " +
                        "Middle_name like '%" + search + "%' or " +
                        "Last_Name like '%" + search + "%' or " +
                        "suffix like '%" + search + "%' or " +
                        "std_level like '%" + search + "%' or " +
                        "std_program like '%" + search + "%' or " +
                        "std_section like '%" + search + "%' or " +
                        "std_sy like '%" + search + "%' or " +
                        "concat(First_Name,' ',Middle_Name,' ',Last_Name) like '%" + search + "%' or " +
                        "concat(Last_Name,' ',First_Name,' ',Middle_Name) like '%" + search + "%' or " +
                        "concat(std_section,' ',std_level) like '%" + search + "%' or " +
                        "concat(std_program,' ',std_section) like '%" + search + "%' or " +
                        "concat(std_level,' ',std_section) like '%" + search + "%' or " +
                        "concat(std_section,' ',std_sy) like '%" + search + "%' or " +
                        "concat(std_sy,' ',std_section) like '%" + search + "%'";
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
            _cache.setstd_info(counter);
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
                        "concat(stud_program,' ',stud_section) like '%" + search + "%' or " +
                        "concat(stud_section,' ',stud_level) like '%" + search + "%' or " +
                        "concat(stud_level,' ',stud_section) like '%" + search + "%' or " +
                        "concat(stud_section,' ',stud_sy) like '%" + search + "%' or " +
                        "concat(stud_sy,' ',stud_program) like '%" + search + "%' or " +
                        "concat(user_prvlg,' ',Last_Name) like '%" + search + "%'";
                    reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        _cache.populatestaff_info(counter, reader[0].ToString(), 0);
                        _cache.populatestaff_info(counter, reader[1].ToString(), 1);
                        _cache.populatestaff_info(counter, reader[2].ToString(), 2);
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
        public void OverwritereadSTD(string search)
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
                    "concat(stud_program,' ',stud_section) like '%" + search + "%' or " +
                    "concat(stud_program,' ',stud_section,' ',stud_sy) like '%" + search + "%' or " +
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
            _cache.setstaff_info(counter);

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
                    _cache.populateslctd_staff(11, reader[0].ToString());//uid
                    _cache.populateslctd_staff(0, reader[1].ToString());//Firstname
                    _cache.populateslctd_staff(1, reader[2].ToString());//Mn
                    _cache.populateslctd_staff(2, reader[3].ToString());//Ln
                    _cache.populateslctd_staff(3, reader[4].ToString());//suffix
                    _cache.populateslctd_staff(4, reader[5].ToString());//stdlvl
                    _cache.populateslctd_staff(5, reader[6].ToString());//stdsec
                    _cache.populateslctd_staff(6, reader[7].ToString());//stdsy
                    _cache.populateslctd_staff(9, reader[8].ToString());//role
                    _cache.populateslctd_staff(10, reader[9].ToString());//program
                }
                con.Close();
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select Username, Password from user_acc where UID = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populateslctd_staff(7, reader[0].ToString());//username
                    _cache.populateslctd_staff(8, reader[1].ToString());//password
                }
                con.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }


        }

        public void editStd(string id)
        {
            DateTime time = DateTime.Now;
            string year, month, day;
            year = time.ToString("yyyy");
            month = time.ToString("MMMM");
            day = time.ToString("dd");
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select StdID, First_Name, Middle_Name, Last_Name, Suffix, Std_Level, Std_Section, Std_Sy,Std_Program,Email,Number from Std where StdID = '" + id + "'";

                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    //uid 11
                    //firstname 0
                    //mn        1
                    //ln        2
                    //suffix    3
                    //stdlvl    4
                    //stdsec    5
                    //stdsy     6
                    //stdprogram7
                    //secId     8
                    //lastStatus9
                    //
                    _cache.populateslctd_std(11, reader[0].ToString());//uid
                    _cache.populateslctd_std(0, reader[1].ToString());//Firstname
                    _cache.populateslctd_std(1, reader[2].ToString());//Mn
                    _cache.populateslctd_std(2, reader[3].ToString());//Ln
                    _cache.populateslctd_std(3, reader[4].ToString());//suffix
                    _cache.populateslctd_std(4, reader[5].ToString());//stdlvl
                    _cache.populateslctd_std(5, reader[6].ToString());//stdsec
                    _cache.populateslctd_std(6, reader[7].ToString());//stdsy
                    _cache.populateslctd_std(7, reader[8].ToString());//program
                    _cache.populateslctd_std(19, reader[9].ToString());//Email
                    _cache.populateslctd_std(20, reader[10].ToString());//Number


                }
                con.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                con.Close();
            }
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select Time, Day, Dd, Month, Year, isLate, secID from Std_record where StdID = '" + id + "' ORDER  BY ID DESC limit 1";
                reader = com.ExecuteReader();
                while (reader.Read())
                {

                    _cache.populateslctd_std(9, reader[0].ToString());//time

                    _cache.populateslctd_std(10, reader[1].ToString());//day
                    _cache.populateslctd_std(12, reader[2].ToString());//dd
                    _cache.populateslctd_std(13, reader[3].ToString());//month
                    _cache.populateslctd_std(14, reader[4].ToString());//year
                    _cache.populateslctd_std(15, reader[5].ToString());//late
                    _cache.populateslctd_std(16, reader[6].ToString());//secid


                }
                if (reader.HasRows)
                {

                }
                else
                {
                    _cache.populateslctd_std(9, "");//time

                    _cache.populateslctd_std(10, "");//day
                    _cache.populateslctd_std(12, "");//dd
                    _cache.populateslctd_std(13, "");//month
                    _cache.populateslctd_std(14, "");//year
                    _cache.populateslctd_std(15, "");//late
                    _cache.populateslctd_std(16, "");//secid
                }
                con.Close();
            }
            catch (Exception e)
            {
                con.Close();
            }
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select concat(Month,' ',Dd,' ',year),isLate from Std_record where StdID = '" + id + "' and isLate = 'late' or isLate = 'Absent' ORDER  BY ID DESC limit 1";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    //Previous date
                    //previous status
                    _cache.populateslctd_std(17, reader[0].ToString());//secid
                    _cache.populateslctd_std(18, reader[1].ToString());//secid

                }
                if (reader.HasRows) //The key Word is **.HasRows**

                {



                }
                else
                {
                    _cache.populateslctd_std(17, "No Record");//secid
                    _cache.populateslctd_std(18, "No Record");//secid
                }
                con.Close();
            }
            catch (Exception e)
            {
                _cache.populateslctd_std(17, "No Record");//secid
                _cache.populateslctd_std(18, "No Record");//secid
                con.Close();
            }

        }
        public void Updatestudent(string id, string firstname, string middlename, string lastname, string suffix, string studlevel, string studsection, string email, string stdprogram)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Update Stud_info set First_Name = '" + firstname + "' ,stud_program = '" + stdprogram + "',Middle_Name= '" + middlename + "' ,Last_Name= '" + lastname + "' ,suffix= '" + suffix + "' ,stud_level= '" + studlevel + "' ,stud_section= '" + studsection + "' ,email= '" + email + "' where UID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
            }
            catch
            {


            }


        }
        public void updatestudentacc(string id, string username, string password, string Role)
        {
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "Update user_acc set Username = '" + username + "' ,Password= '" + password + "' ,role= '" + Role + "' where UID = '" + id + "'";
            com.ExecuteNonQuery();
            com.CommandText = "Update stud_info set user_prvlg= '" + Role + "' where UID = '" + id + "'";
            com.ExecuteNonQuery();
            SSMessagebox MessageBox = new SSMessagebox("Updated Successfully"); MessageBox.Show();
            con.Close();
        }
        public void updateBookinfo(string id, string title, string author, string page, string qty, string information)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Update book set title = '" + title + "' ,author= '" + author + "' ,page= '" + page + "' ,Quantity= '" + qty + "',Information = '" + information + "' where ID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
                SSMessagebox MessageBox = new SSMessagebox("Data updated successfully!"); MessageBox.Show();
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
        public void resetLock()
        {
            signalLock = new string[65550];
        }
        public string saveRecord(string sectionID, SSUserpanel studentshower)
        {
            editStd(sectionID);
            if (((IList<string>)signalLock).Contains(sectionID))
            {
                Console.WriteLine("Exist");
                return _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1);

            }
            else
            {
                signalLock[counter] = sectionID;
                counter++;
                editStd(sectionID);
                string secId = _cache.returnslctd_std(16);
                DateTime dt = DateTime.Today;
                DateTime time = DateTime.Now;
                Console.WriteLine(time.ToString("HH:mm"));
                string day = dt.DayOfWeek.ToString();
                string isLate = Late(secId, day);
                string hasrecord = getfill("isLate", "std_record", "where stdId = '' and Dd = '' and Month = '' and Year = '' order by ID ASC  limit 1");
                if (hasrecord.Length != 0)
                {
                    isLate = hasrecord;
                }
                else
                {

                }

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "insert into std_record (StdiD,StdName,Time,Day,Dd,Month,Year,isLate,SecID)  values('" + _cache.returnslctd_std(11) + "','" + _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1) + "','" + time.ToString("HH:mm") + "','" + time.ToString("dddd") + "','" + time.ToString("dd") + "','" + time.ToString("MMMM") + "','" + time.ToString("yyyy") + "','" + isLate + "','" + secId + "')";
                com.ExecuteNonQuery();
                con.Close();
                studentshower.show(_cache.returnslctd_std(11), _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1), isLate, _cache.returnslctd_std(7) + " " + _cache.returnslctd_std(5) + " " + _cache.returnslctd_std(6));

                if (isLate.Equals("Late"))
                {
                    studentshower.addLate();
                }
                else
                {
                    studentshower.addOntime();
                }
                studentshower.addfacecount();

                return _cache.returnslctd_std(2) + " " + _cache.returnslctd_std(0) + " " + _cache.returnslctd_std(1);
            }

        }
        public string getSectionID(string year, string Program, string section)
        {
            try
            {
                string secID = "";
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select secID from stud_section where Section = " + section + " and Year = " + year + " and Program = '" + Program + "'";
                reader = com.ExecuteReader();
                if (reader.Read())
                {
                    secID = (string)reader["secID"].ToString();
                }
                con.Close();
                return secID;

            }
            catch (Exception ex)
            {
                SSMessagebox show = new SSMessagebox("Invalid input");
                show.Show();
                throw new Exception();
            }


        }

        public string Late(string section, string date)
        {
            string Schedule = "";

            string status = "No class";
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select Time from std_sched where SecID = " + section + " and Day = '" + date + "'";
                reader = com.ExecuteReader();
                if (reader.Read())
                {
                    Schedule = reader["time"].ToString();
                }
                DateTime late = DateTime.Now;
                DateTime dateTime = DateTime.Parse(Schedule);
                int studentDetected = (dateTime.Hour * 60) + dateTime.Minute;
                int studentSched = (late.Hour * 60) + late.Minute;
                if (studentDetected < studentSched)
                {
                    status = "Late";
                }
                else
                {
                    status = "On Time";
                }
                con.Close();
            }
            catch (Exception e)
            {
                status = "No classes";
                con.Close();
            }
            return status;
        }
        public byte[] retrieveFaceData()
        {
            byte[] faceData = { 0x12, 0x32 };
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select tracker from faceData";
                reader = com.ExecuteReader();
                if (reader.Read())
                {
                    faceData = (byte[])reader["tracker"];

                }
                else
                {

                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading face data");
                con.Close();
            }
            return faceData;
        }

        public string WorkingDay(string secID)
        {
            string Day = "";
            string trimmed = "";
            string[] day = { "0", "0", "0", "0", "0", "0", "0" };
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select Day from std_sched where SecID = '" + secID + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString().Equals("Monday"))
                    {
                        day[0] = "1";
                    }
                    else if (reader[0].ToString().Equals("Tuesday"))
                    {
                        day[1] = "1";
                    }
                    else if (reader[0].ToString().Equals("Wednesday"))
                    {
                        day[2] = "1";
                    }
                    else if (reader[0].ToString().Equals("Thursday"))
                    {
                        day[3] = "1";
                    }
                    else if (reader[0].ToString().Equals("Friday"))
                    {
                        day[4] = "1";
                    }
                    else if (reader[0].ToString().Equals("Saturday"))
                    {
                        day[5] = "1";
                    }
                    else if (reader[0].ToString().Equals("Sunday"))
                    {
                        day[6] = "1";
                    }
                    else
                    {
                        Day += reader[0].ToString() + " ";
                    }



                }
                con.Close();
                if (day[0] == "1")
                {
                    day[0] = "1";
                    Day += "M/";
                }
                if (day[2] == "1")
                {
                    day[1] = "1";
                    Day += "T/";
                }
                if (day[2] == "1")
                {
                    day[2] = "1";
                    Day += "W/";
                }
                if (day[3] == "1")
                {
                    day[3] = "1";
                    Day += "TH/";
                }
                if (day[4] == "1")
                {
                    day[4] = "1";
                    Day += "F/";
                }
                if (day[5] == "1")
                {
                    day[5] = "1";
                    Day += "S/";
                }
                if (day[6] == "1")
                {
                    day[6] = "1";
                    Day += "SS/";
                }

                trimmed = Day.Remove(Day.Length - 1, 1);
            }
            catch (Exception ex)
            {
                con.Close();
                Day = "No Data Available";
            }


            return Day;

        }
        public String showInformation(String stdID)
        {
            String info = "";
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select  concat('Seen : ', Time, ' on ' , Month,' ',Dd,' ',year, ' @ ' , isLate) from std_record where stdID = '" + stdID + "' order by ID Desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    info += reader[0].ToString() + System.Environment.NewLine;


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                info = "No Data Available";
            }
            return info;
        }

        public void updateStd(string id, string fn, string mn, string ln, string sffx, string stdp, string stdl, string stds, string stysy, string email, string num)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Update std set First_Name = '" + fn + "' ,Middle_Name= '" + mn + "' ,Last_Name= '" + ln + "' ,Suffix= '" + sffx + "',Std_Program = '" + stdp + "',Std_Level = '" + stdl + "' ,Std_Section= '" + stds + "' ,Std_Sy= '" + stysy + "' ,Email= '" + email + "',Number = '" + num + "' where stdID = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
                SSMessagebox MessageBox = new SSMessagebox("Data updated successfully!"); MessageBox.Show();
            }
            catch (Exception ex)
            {
                con.Close();
                SSMessagebox MessageBox = new SSMessagebox("Data update failed!");
                MessageBox.Show();

            }
        }









        // LOGIN


        public void readUser(string id)
        {
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select * from stud_info where UID = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populateuser_std(0, reader[0].ToString());//uid
                    _cache.populateuser_std(1, reader[1].ToString());//Fn
                    _cache.populateuser_std(2, reader[2].ToString());//Mn
                    _cache.populateuser_std(3, reader[3].ToString());//ln
                    _cache.populateuser_std(4, reader[4].ToString());//suffix
                    _cache.populateuser_std(5, reader[5].ToString());//stdlvl
                    _cache.populateuser_std(6, reader[6].ToString());//stdsec
                    _cache.populateuser_std(7, reader[7].ToString());//studsy

                    _cache.populateuser_std(8, reader[8].ToString());//userprvlg
                    _cache.populateuser_std(9, reader[9].ToString());//std_prog


                }
                con.Close();
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select * from user_acc where UID = '" + id + "'";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    _cache.populateuser_std(10, reader[1].ToString());
                    _cache.populateuser_std(9, reader[2].ToString());
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

        }

        public void sendEmail(string reciever, string title, string content)
        {
            if (reciever.Equals(""))
            {

            }
            else
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                path = path.Remove(path.LastIndexOfAny(new char[] { '\\' }, path.LastIndexOf('\\') - 0));
                path += '\\';

                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                string to, from, pass, mail;
                to = reciever;
                from = "surveillance.philsca@gmail.com";

                ContentType imgType = new ContentType("image/jpg");
                LinkedResource lr = new LinkedResource(path + "Assets\\Philsca2.png", imgType);
                LinkedResource lr1 = new LinkedResource(path + "Assets\\Philsca1.png", imgType);


                lr.ContentId = "imgpath";
                lr1.ContentId = "imgpath1";

                AlternateView imgview = AlternateView.CreateAlternateViewFromString(@"<body style ='color:#008356;'><br/><img src=cid:imgpath  alt='Philsca Logo' width='510' height='140'><br><center>" + content + "<br>Philsca Surveillance 2021 <br>Surveillance, PhilSCA <br> M : Surveillance.PhilSCA@gmail.com <br> <img src=cid:imgpath1 alt='Philsca Logo' width='225' height='75'><br><span<br>Continues to produce world class professional. | </body>", null, MediaTypeNames.Text.Html);
                imgview.LinkedResources.Add(lr);
                imgview.LinkedResources.Add(lr1);
                message.AlternateViews.Add(imgview);
                mail = content;
                pass = "PhilscaSurveillance123";
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = lr.ContentId;

                message.Subject = title;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        public void emailBuilder(string day, string month, string year, string level, string program, string section, string sy, string email)
        {

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;


            string stdid = "";
            string stdname = "";
            string date = "";
            string islate = "";
            string thead = /*$"<h1> )*/$"<br><h1 style ='font-family: OpenSans-Regular;'> PHILSCA SURVEILLANCE ATTENDANCE ({month + " " + day + " " + year}) </h1><h3 style ='font-family: OpenSans-Regular;'>Absent List</h3></center><table style='margin: 0 auto;padding: 0px;box-sizing: border-box;border-spacing: 1;border-collapse: collapse;background: #fbfbfb;border-radius: 10px;overflow: hidden;position: relative;'><thead style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;'> <tr class='table100-head' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;height: 60px;background: #008356;'> <th class='column1' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 40px;text-align: left;width: 260px;font-family: OpenSans-Regular;font-size: 18px;color: #fff;line-height: 1.2;font-weight: unset;'>Date</th> <th class='column2' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 160px;font-family: OpenSans-Regular;font-size: 18px;color: #fff;line-height: 1.2;font-weight: unset;'>Student ID</th> <th class='column3' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 245px;font-family: OpenSans-Regular;font-size: 18px;color: #fff;line-height: 1.2;font-weight: unset;'>Name</th> <th class='column4' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 110px;font-family: OpenSans-Regular;font-size: 18px;color: #fff;line-height: 1.2;font-weight: unset;'>Attendance</th> </thead> <tbody style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;'>";
            string tbody = "";
            string builder = "";
            string tfoot = "<span------------------ </tbody></table>";
            //<br><br><br>" +
            /*
            "--<br>" +
            "Philsca Surveillance 2021 <br>" +
            "Surveillance, PhilSCA <br>" +
            "M: Surveillance.PhilSCA@gmail.com <br>" +
            "____________________________ <br>" +
            "Continues to produce world-class professional. | www.philsca.edu.ph ";*/
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = $"SELECT distinct a.StdID, CONCAT(a.Last_Name,' ',a.First_Name,' ',a.Middle_Name) as Name , Concat('Absent') as Attendance FROM std as a " +
                    $"JOIN std_record AS b " +
                    $"WHERE a.StdID NOT IN (select distinct StdID from std_record " +
                    $"where Dd = '{day}' AND " +
                    $"Month ='{month}' AND " +
                    $"Year = '{year}') AND " +
                    $"a.Std_Level = '{level}' AND " +
                    $"a.Std_Program = '{program}' And " +
                    $"a.Std_Section = '{section}' AND " +
                    $"a.Std_Sy = '{sy}' ORDER BY Name Asc;";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    tbody += "<tr style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;font-family: OpenSans-Regular;font-size: 15px;color: #808080;line-height: 1.2;font-weight: unset;height: 50px;'>";

                    tbody += $"<td class='column1' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 40px;text-align: left;width: 260px;'>{month + " " + day + " " + year}</td>";
                    tbody += $"<td class='column2' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 160px;'>{reader[0].ToString()}</td>";
                    tbody += $"<td class='column3' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 245px;'>{reader[1].ToString()}</td>";
                    tbody += $"<td class='column4' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 110px;'>{reader[2].ToString()}</td>";
                    tbody += "</tr>";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                tbody += "<tr style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;font-family: OpenSans-Regular;font-size: 15px;color: #808080;line-height: 1.2;font-weight: unset;height: 50px;'>";
                tbody += $"<td class='column1' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 40px;text-align: left;width: 260px;'>{month + " " + day + " " + year}</td>";
                tbody += $"<td class='column2' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 160px;'>No Data Recorded</td>";
                tbody += $"<td class='column3' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 245px;'>No Data Recorded</td>";
                tbody += $"<td class='column4' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 110px;'>No Data Recorded</td>";
                tbody += "</tr>";
            }
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = $@"SELECT distinct StdID, StdName as Name ,isLate, Time  as Attendance 
                FROM std_record
                WHERE StdID IN (select distinct StdID from std where
                Std_Level = '{level}' AND
                Std_Program = '{program}' And
                Std_Section = '{section}' AND
                Std_Sy = '{sy}') AND
                Dd = '{day}' AND
                Month ='{month}' AND
                Year = '{year}' GROUP BY StdID ORDER BY ID Asc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    tbody += "<tr style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;font-family: OpenSans-Regular;font-size: 15px;color: #808080;line-height: 1.2;font-weight: unset;height: 50px;'>";

                    tbody += $"<td class='column1' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 40px;text-align: left;width: 260px;'>{month + " " + day + " " + year}</td>";
                    tbody += $"<td class='column2' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 160px;'>{reader[0].ToString()}</td>";
                    tbody += $"<td class='column3' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 245px;'>{reader[1].ToString()}</td>";
                    tbody += $"<td class='column4' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 110px;'>{reader[2].ToString()}</td>";
                    tbody += "</tr>";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                tbody += "<tr style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;font-family: OpenSans-Regular;font-size: 15px;color: #808080;line-height: 1.2;font-weight: unset;height: 50px;'>";
                tbody += $"<td class='column1' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 40px;text-align: left;width: 260px;'>{month + " " + day + " " + year}</td>";
                tbody += $"<td class='column2' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 160px;'>No Data Recorded</td>";
                tbody += $"<td class='column3' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 245px;'>No Data Recorded</td>";
                tbody += $"<td class='column4' style='margin: 0px;padding: 0px;box-sizing: border-box;position: relative;padding-left: 8px;text-align: left;width: 110px;'>No Data Recorded</td>";
                tbody += "</tr>";
            }
            builder = thead + tbody + tfoot;
            sendEmail(email, month + " " + day + " " + year + " : " + program + " " + section, builder);
        }
        public void addViolation(string studentid, string name, string date, string violation)
        {
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "insert into violation (studentid,name,date,violation,remark) values('" + studentid + "','" + name + "','" + date + "','" + violation + "','Pending')";
            com.ExecuteNonQuery();
            con.Close();

        }
        public void deleteViolation(string id)
        {
            try
            {
                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Update violation set remark = 'Settled' where id = '" + id + "'";
                com.ExecuteNonQuery();
                con.Close();
                SSMessagebox MessageBox = new SSMessagebox("Data updated successfully!"); MessageBox.Show();
            }
            catch
            {
                SSMessagebox MessageBox = new SSMessagebox("Data updated failed!"); MessageBox.Show();

            }
        }

        public String showViolation(String stdID)
        {
            String info = "";
            try
            {

                con.Open();
                com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "Select  concat( violation, ' on ' , date,' @ ', remark) from violation where studentid = '" + stdID + "' order by ID Desc";
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    info += reader[0].ToString() + System.Environment.NewLine;


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
                info = "No Data Available";
            }
            return info;
        }

        public string getPendingViolation(string id)
        {
            string count = "";
            con.Open();
            com = con.CreateCommand();
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = "SELECT Count(violation) FROM violation where studentid = '"+id+"' and remark = 'Pending' ";
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                count = reader[0].ToString();


            }
            con.Close();
            return count;
        }
        public void sound()
        {
            MessageBox.Show("*Random noise*");
        }
    }

   
}




 
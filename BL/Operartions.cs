using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DBL;
using BEL;

namespace BL
{
    public class Operations

    {
        string invalid = "invalid";
        string valid = "valid";
        public DBConnect dbc = new DBConnect();
        public Informations inf = new Informations();
        public Books b = new Books();
        //SqlCommandBuilder sql;
        //SqlDataAdapter sda;


        public int insertstudent(Informations inf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_registration values ('" + inf.Name + "','" + inf.Gender + "','" + inf.Dob + "','" + inf.Address + "','" + inf.Username + "','" + inf.Email + "','" + inf.Password + "','S','"+this.valid+"' ) ";
            return dbc.ExNonQuery(cmd);
        }

        public int insertstudentlogin(Informations inf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_registration values ('" + inf.Name + "','" + inf.Gender + "','" + inf.Dob + "','" + inf.Address + "','" + inf.Username + "','" + inf.Email + "','" + inf.Password + "','S','"+this.invalid+"' ) ";
            return dbc.ExNonQuery(cmd);
        }

        public DataTable forgetpass(string sn, string un, string gm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where usertype = ('" + sn + "') and username = ('" + un + "') and gmail = ('" + gm + "') ";
            return dbc.ExeReader(cmd);

        }

        public void changedpassword(string pos, string un, string gm,string p)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_registration SET password='{0}' where  usertype='{1}' and username='{2}' and gmail='{3}' ", p,pos ,un,gm);
            dbc.ExeQuery(cmd);
        }

        public DataTable srchforreturn(string bookname, string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_issue where std_user_name like ('%" + username + "%') and book_name like ('%" + bookname + "%') ";
            return dbc.ExeReader(cmd);
        }

        public DataTable displayallissue()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_issue ";
            return dbc.ExeReader(cmd);
        }

        public void promotestudent(string id,string pos)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_registration SET usertype='{0}' where  id='{1}' ", pos, id);
            dbc.ExeQuery(cmd);
        }

        public DataTable srchstdissue(string s, string t)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where username like ('%" + s + "%') and gmail like ('%" + t + "%') and usertype ='S'";
            return dbc.ExeReader(cmd);
        }

        public void updatebookquan(string passbookqn,string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_book SET quantity='{0}' where  id='{1}' ", passbookqn, id);
            dbc.ExeQuery(cmd);
        }

        public void updatebookissuequan(string upibn,string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_issue SET Quantity ='{0}' where  issue_id='{1}' ", upibn, id);
            dbc.ExeQuery(cmd);
        }

        public int getbookqn(string bookid)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select quantity from tbl_book where id = '" + bookid + "'", "Data Source=DESKTOP-AG2EEU5\\MRIDULSQLSERVER;Initial Catalog=LMAIUB;Integrated Security=True");
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select quantity from tbl_book where id = '" + bookid + "'";
           // System.Console.WriteLine(dbc.Exgetbook(cmd));
          // dbc.Exgetbook(cmd);
            //string s1 = cmd.CommandText;
            //int i = Convert.ToInt32(s1);
            return int.Parse(dt.Rows[0][0].ToString());
        }

        public DataTable adminprofilefunc(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where id = '" + id + "'";
            return dbc.ExeReader(cmd);
        }

        public DataTable showstudent(Informations inf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where usertype ='S' ";
            return dbc.ExeReader(cmd);
        }

        public DataTable filterstudent(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where gender= ('" + s + "') OR status =('"+s+ "') and usertype ='S'";
            return dbc.ExeReader(cmd);
        }

        public DataTable displaybook(Books b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_book ";
            return dbc.ExeReader(cmd);
        }

        public DataTable srchbookissue(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_book where name like ('%" + s + "%')";
            return dbc.ExeReader(cmd);

        }

        public DataTable searchbook(Books b, string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_book where name ='" + s + "'";
            return dbc.ExeReader(cmd);

        }

        public DataTable searchstudent(string s)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where username like ('%" + s + "%') and usertype ='S'";
            return dbc.ExeReader(cmd);
        }

        public DataTable deletestudent(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tbl_registration where username= ('" + s + "') and usertype ='S'";
            return dbc.ExeReader(cmd);
        }

        public void updatebookadmin(string n, string e, string a, string d, string t, string q, string id)
        {
            // string IDB = Convert.ToString(id);
            //string qn = Convert.ToString(q);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_book SET name ='{0}',edition='{1}',author='{2}',title='{3}',quantity='{4}',department='{5}' where  id='{6}' ", n, e, a, t, q, d, id);
            dbc.ExeQuery(cmd);


        }



        public DataTable filterbook(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_book where department ='" + s + "'";
            return dbc.ExeReader(cmd);
        }

        public void updatebookissue(string bid, string br)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_book SET quantity='{0}' where  id='{1}' ", br, bid);
            dbc.ExeQuery(cmd);
        }

        public void updatestudent(string name, string gender, string dob, string address, string gmail, string id,string v)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = string.Format("Update tbl_registration SET name ='{0}',gender='{1}',dob='{2}',address='{3}',gmail='{4}',status='{5}' where  id='{6}' ", name, gender, dob, address, gmail, v,id);
            dbc.ExeQuery(cmd);


        }

        public DataTable deletebook(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tbl_book where name= ('" + s + "')";
            return dbc.ExeReader(cmd);
        }



        public DataTable displaybookfromf(Books b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_book ";
            return dbc.ExeReader(cmd);
        }

        public int insertbook(Books b)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into  tbl_book values ( '" + b.Name + "', '" + b.Edition + "','" + b.Author + "','" + b.Title + "','" + b.Quantity + "' ,'" + b.Department + "'  )";

            return dbc.ExNonQuery(cmd);

        }

        public DataTable searchlibrarian(Informations inf, string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where username= ('" + s + "') and usertype ='L'";
            return dbc.ExeReader(cmd);
        }

        public DataTable deleteemp(string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tbl_registration where username= ('" + s + "') and usertype ='L'";
            return dbc.ExeReader(cmd);
        }

        public DataTable filteremp(Informations inf, string s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where gender= ('" + s + "') and usertype ='L'";
            return dbc.ExeReader(cmd);

        }



        public int insertlibrarian(Informations inf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_registration values ('" + inf.Name + "','" + inf.Gender + "','" + inf.Dob + "','" + inf.Address + "','" + inf.Username + "','" + inf.Email + "','" + inf.Password + "','L' ) ";
            return dbc.ExNonQuery(cmd);
        }

        public DataTable Display(Informations inf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where usertype ='L' ";
            return dbc.ExeReader(cmd);
        }

        public DataTable Login(Informations inf)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_registration where username= '" + inf.Username + "' and password= '" + inf.Password + "'";
            return dbc.ExeReader(cmd);


        }

        public int insertissuedetails(string stdname,string stdgmail,string stdusername, string stdadd,string bookname,string bookquan,string issuedate,string stdif,string bookid)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tbl_issue values ('" + stdname + "','" + stdgmail + "','" + stdusername + "','" + stdadd + "','" + bookname + "','" + issuedate + "','" + bookquan + "' ,'" + stdif + "','" + bookid + "') ";
            return dbc.ExNonQuery(cmd);
        }
    }
}

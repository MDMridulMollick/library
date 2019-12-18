using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBL
{
    public class DBConnect
    {
      public  SqlConnection sql = new SqlConnection("Data Source=DESKTOP-AG2EEU5\\MRIDULSQLSERVER;Initial Catalog=LMAIUB;Integrated Security=True");

        public SqlConnection GetSql() {
            if (sql.State == ConnectionState.Closed) {
                sql.Open();
            }
            return sql;
        }

        public int ExNonQuery(SqlCommand cmd)
        {
            cmd.Connection = GetSql();
            int r = -1;
            r = cmd.ExecuteNonQuery();
            sql.Close();
            return r;

        }
        public object ExScaler(SqlCommand cmd)
        {
            cmd.Connection = GetSql();
            object ob = -1;
            ob = cmd.ExecuteScalar();
            sql.Close();
            return ob;

        }

        public DataTable ExeReader(SqlCommand cmd)
        {
            cmd.Connection = GetSql();
            SqlDataReader sdr;
            DataTable dt = new DataTable();
            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sql.Close();
            return dt;

        }

      

        public void ExeQuery(SqlCommand cmd)
        {
            cmd.Connection = GetSql();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public int Exgetbook(SqlCommand cmd)
        {
            cmd.Connection = GetSql();
           int i= cmd.ExecuteNonQuery();
            sql.Close();
            return i;
        }



    }
}

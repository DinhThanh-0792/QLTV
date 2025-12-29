using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Connect
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;
                                                 Initial Catalog=QUAN_LY_THU_VIEN;
                                                 Integrated Security=True");
        SqlCommand cmd;
        public DataTable LoadData(string sql)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void ExecuteNonQuery(SqlCommand cmd)
        {
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public object ExecuteScalar(SqlCommand cmd)
        {
            cmd.Connection = conn;
            conn.Open();
            object obj = cmd.ExecuteScalar();
            conn.Close();
            return obj;
        }
    }
}

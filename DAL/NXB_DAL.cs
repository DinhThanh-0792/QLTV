using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class NXB_DAL: Connect
    {
        public DataTable Load()
        {
            return LoadData(@"SELECT * FROM NXB");
        }
        

        public void Insert(NXB_DTO nxb)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO NXB (ID_NXB, TenNXB, DiaChi) VALUES (@ID_NXB, @TenNXB, @DiaChi)");
            cmd.Parameters.Add("@ID_NXB", SqlDbType.NVarChar, 100).Value = nxb.ID_NXB;
            cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar, 100).Value = nxb.TenNXB;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100).Value = nxb.DiaChi;
            ExecuteNonQuery(cmd);
        }

        public void Update(NXB_DTO nxb)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE NXB SET TenNXB = @TenNXB, DiaChi = @DiaChi WHERE ID_NXB = @ID_NXB");
            cmd.Parameters.Add("@ID_NXB", SqlDbType.NVarChar, 100).Value = nxb.ID_NXB;
            cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar, 100).Value = nxb.TenNXB;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100).Value = nxb.DiaChi;
            ExecuteNonQuery(cmd);
        }

        public void Delete(NXB_DTO nxb)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM NXB WHERE ID_NXB = @ID_NXB");
            cmd.Parameters.Add("@ID_NXB", SqlDbType.NVarChar, 100).Value = nxb.ID_NXB;
            ExecuteNonQuery(cmd);
        }

        public DataTable Search(NXB_DTO nxb)
        {
            string sql = @"SELECT * FROM NXB
                            WHERE TenNXB LIKE N'%" + nxb.TenNXB + "%'";

            return LoadData(sql);
        }
    }
}

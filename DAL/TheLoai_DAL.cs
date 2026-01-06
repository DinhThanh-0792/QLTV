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
    public class TheLoai_DAL : Connect
    {
        public DataTable Load()
        {
            return LoadData(@"SELECT * FROM DANHMUC");
        }

        public void Insert(TheLoai_DTO tl)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO DANHMUC (ID_DM, TenDM, ID_DanhMucCha) VALUES (@ID_DM, @TenDM, @ID_DanhMucCha)");
            cmd.Parameters.Add("@ID_DM", SqlDbType.NVarChar, 100).Value = tl.ID_DM;
            cmd.Parameters.Add("@TenDM", SqlDbType.NVarChar, 100).Value = tl.TenDM;
            cmd.Parameters.AddWithValue("@ID_DanhMucCha",(object)tl.ID_DanhMucCha ?? DBNull.Value);
            ExecuteNonQuery(cmd);
        }

        public void Update(TheLoai_DTO tl)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE DANHMUC SET ID_DM = @ID_DM, TenDM = @TenDM, ID_DanhMucCha = @ID_DanhMucCha WHERE ID_DM = @ID_DM");
            cmd.Parameters.Add("@ID_DM", SqlDbType.NVarChar, 100).Value = tl.ID_DM;
            cmd.Parameters.Add("@TenDM", SqlDbType.NVarChar, 100).Value = tl.TenDM;
            cmd.Parameters.Add("@ID_DanhMucCha", SqlDbType.NVarChar, 100).Value = tl.ID_DanhMucCha;
            ExecuteNonQuery(cmd);
        }

        public void Delete(TheLoai_DTO tl)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM DANHMUC WHERE ID_DM = @ID_DM");
            cmd.Parameters.Add("@ID_DM", SqlDbType.NVarChar, 100).Value = tl.ID_DM;
            ExecuteNonQuery(cmd);
        }

        public DataTable Search(TheLoai_DTO tl)
        {
            string sql = "SELECT * FROM DANHMUC " +
                 "WHERE TenDM LIKE N'%" + tl.TenDM + "%'";
            return LoadData(sql);
        }


        public DataTable LoadDanhMucCha()
        {
            return LoadData(@"SELECT TenDM, ID_DM FROM DANHMUC");
        }
    }
}

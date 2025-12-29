using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class Phieu_DAL: Connect
    {
        public DataTable LoadPhieu()
        {
            string sql = "SELECT * FROM PHIEU";
            return LoadData(sql);
        }
        public int InsertPhieu(Phieu p)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PHIEU (LoaiPhieu, ID_DG, ID_NV, NgayMuon, NgayPhaiTra, NgayTraThucTe, GhiChu) VALUES (@LoaiPhieu, @ID_DG, @ID_NV, @NgayMuon, @NgayPhaiTra, @NgayTraThucTe, @GhiChu)");
            cmd.Parameters.AddWithValue("@LoaiPhieu", p.LoaiPhieu);
            cmd.Parameters.AddWithValue("@ID_DG", p.ID_DG);
            cmd.Parameters.AddWithValue("@ID_NV", p.ID_NV);
            cmd.Parameters.AddWithValue("@NgayMuon", p.NgayMuon);
            cmd.Parameters.AddWithValue("@NgayPhaiTra", p.NgayPhaiTra);
            cmd.Parameters.AddWithValue("@NgayTraThucTe", (object)p.NgayTraThucTe ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@GhiChu", p.GhiChu);
            ExecuteNonQuery(cmd);
            return int.Parse(ExecuteScalar(cmd).ToString());
        }
        public void UpdatePhieu(Phieu p)
        {
            SqlCommand cmd = new SqlCommand("Update Phieu Set LoaiPhieu ='Trả',NgayTraThucTe = @NgayTra Where ID_Phieu = @ID_Phieu");
            cmd.Parameters.AddWithValue("@ID_Phieu", p.ID_Phieu);
            cmd.Parameters.AddWithValue("@NgayTra", p.NgayTraThucTe);
            ExecuteNonQuery(cmd);
        }
    }
}

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
    public class CTPhieu_DAL : Connect
    {
        public void InsertCTPhieu(CTPhieu ct)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CHITIET_PHIEU (ID_Phieu, ID_Sach, SoLuong, TinhTrangTra) VALUES (@ID_Phieu, @ID_Sach, @SoLuong, @TinhTrangTra)");
            cmd.Parameters.AddWithValue("@ID_Phieu", ct.ID_Phieu);
            cmd.Parameters.AddWithValue("@ID_Sach", ct.ID_Sach);
            cmd.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
            cmd.Parameters.AddWithValue("@TinhTrangTra", ct.TinhTrangTra);
            ExecuteNonQuery(cmd);
        }
        public DataTable LoadChiTiet(int id_Phieu)
        {
            string sql = "SELECT ct.ID_ChiTiet, s.TenSach, ct.SoLuong, ct.TinhTrangTra " +
                         "FROM CHITIET_PHIEU ct " +
                         "JOIN SACH s ON ct.ID_Sach = s.ID_Sach " +
                         "WHERE ct.ID_Phieu = @ID_Phieu";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID_Phieu", id_Phieu);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            
        }
    }
}

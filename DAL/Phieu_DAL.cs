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
            string sql = "SELECT        PHIEU.ID_Phieu, PHIEU.LoaiPhieu, DOCGIA.TenDG, NHANVIEN.TenNV, PHIEU.NgayMuon, PHIEU.NgayPhaiTra, PHIEU.GhiChu, PHIEU.ID_DG, PHIEU.ID_NV\r\nFROM            PHIEU INNER JOIN\r\n                         NHANVIEN ON PHIEU.ID_NV = NHANVIEN.ID_NV INNER JOIN\r\n                         DOCGIA ON PHIEU.ID_DG = DOCGIA.ID_DocGia";
            return LoadData(sql);
        }
        public int InsertPhieu(Phieu p)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PHIEU (LoaiPhieu, ID_DG, ID_NV, NgayMuon, NgayPhaiTra, NgayTraThucTe, GhiChu) OUTPUT INSERTED.ID_Phieu VALUES (@LoaiPhieu, @ID_DG, @ID_NV, @NgayMuon, @NgayPhaiTra, @NgayTraThucTe, @GhiChu)");
            cmd.Parameters.AddWithValue("@LoaiPhieu", p.LoaiPhieu);
            cmd.Parameters.AddWithValue("@ID_DG", p.ID_DG);
            cmd.Parameters.AddWithValue("@ID_NV", p.ID_NV);
            cmd.Parameters.AddWithValue("@NgayMuon", p.NgayMuon);
            cmd.Parameters.AddWithValue("@NgayPhaiTra", p.NgayPhaiTra);
            cmd.Parameters.AddWithValue("@NgayTraThucTe", (object)p.NgayTraThucTe ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@GhiChu", p.GhiChu);
            //ExecuteNonQuery(cmd);
            //return int.Parse(ExecuteScalar(cmd).ToString());
            return (int)ExecuteScalar(cmd);
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

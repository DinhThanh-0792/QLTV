using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DocGia_DAL : Connect
    {
        // 1️⃣ Load danh sách độc giả
        public DataTable LoadDocGia()
        {
            string sql = @"SELECT ID_DocGia, TenDG, SDT, Email, DiaChi, TrangThai
                           FROM DOCGIA";
            return LoadData(sql);
        }

        // 2️⃣ Thêm độc giả
        public void InsertDocGia(DTO_DocGia dg)
        {
            SqlCommand cmd = new SqlCommand(
                @"INSERT INTO DOCGIA (ID_DocGia, TenDG, SDT, Email, DiaChi, TrangThai)
                  VALUES (@ID_DocGia, @TenDG, @SDT, @Email, @DiaChi, @TrangThai)"
            );

            cmd.Parameters.AddWithValue("@ID_DocGia", dg.ID_DocGia);
            cmd.Parameters.AddWithValue("@TenDG", dg.TenDG);
            cmd.Parameters.AddWithValue("@SDT", dg.SDT);
            cmd.Parameters.AddWithValue("@Email", dg.Email);
            cmd.Parameters.AddWithValue("@DiaChi", dg.DiaChi);
            cmd.Parameters.AddWithValue("@TrangThai", dg.TrangThai);

            ExecuteNonQuery(cmd);
        }

        // 3️⃣ Cập nhật độc giả
        public void UpdateDocGia(DTO_DocGia dg)
        {
            SqlCommand cmd = new SqlCommand(
                @"UPDATE DOCGIA
                  SET TenDG = @TenDG,
                      SDT = @SDT,
                      Email = @Email,
                      DiaChi = @DiaChi,
                      TrangThai = @TrangThai
                  WHERE ID_DocGia = @ID_DocGia"
            );

            cmd.Parameters.AddWithValue("@ID_DocGia", dg.ID_DocGia);
            cmd.Parameters.AddWithValue("@TenDG", dg.TenDG);
            cmd.Parameters.AddWithValue("@SDT", dg.SDT);
            cmd.Parameters.AddWithValue("@Email", dg.Email);
            cmd.Parameters.AddWithValue("@DiaChi", dg.DiaChi);
            cmd.Parameters.AddWithValue("@TrangThai", dg.TrangThai);

            ExecuteNonQuery(cmd);
        }

        // 4️⃣ Xóa độc giả
        public void DeleteDocGia(string idDocGia)
        {
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM DOCGIA WHERE ID_DocGia = @ID_DocGia"
            );
            cmd.Parameters.AddWithValue("@ID_DocGia", idDocGia);
            ExecuteNonQuery(cmd);
        }

        // 5️⃣ Tìm kiếm độc giả theo tên
        public DataTable SearchDocGia(string tenDG)
        {
            string sql =
                @"SELECT ID_DocGia, TenDG, SDT, Email, DiaChi, TrangThai
                  FROM DOCGIA
                  WHERE TenDG LIKE N'%" + tenDG + "%'";
            
            

            return LoadData(sql);
        }

        // 6️⃣ Cập nhật trạng thái độc giả (hay dùng)
        
    }
}

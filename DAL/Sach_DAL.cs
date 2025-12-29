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
    public class Sach_DAL:Connect
    {
        public DataTable Load()
        {
            string sql = @"SELECT s.ID_Sach, s.TenSach, s.SoLuong, s.NamXB, tg.TenTG, nxb.TenNXB, dm.TenDM 
                            FROM SACH s
                            INNER JOIN TACGIA tg ON s.ID_TG = tg.ID_TG
                            INNER JOIN NXB nxb ON s.ID_NXB = nxb.ID_NXB
                            INNER JOIN DANHMUC dm ON s.ID_DM = dm.ID_DM";
            return LoadData(sql);
        }

        public void Insert(Sach_DTO s)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO SACH 
                                            (ID_Sach, TenSach, ID_TG, ID_NXB, ID_DM, NamXB, SoLuong, TonKho, GiaSach)
                                            VALUES 
                                            (@ID_Sach, @TenSach, @ID_TG, @ID_NXB, @ID_DM, @NamXB, @SoLuong, @TonKho, @GiaSach)");

            cmd.Parameters.Add("@ID_Sach", SqlDbType.NVarChar).Value = s.ID_Sach;
            cmd.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = s.TenSach;
            cmd.Parameters.Add("@ID_TG", SqlDbType.NVarChar).Value = s.ID_TG;
            cmd.Parameters.Add("@ID_NXB", SqlDbType.NVarChar).Value = s.ID_NXB;
            cmd.Parameters.Add("@ID_DM", SqlDbType.NVarChar).Value = s.ID_DM;
            cmd.Parameters.Add("@NamXB", SqlDbType.DateTime).Value = s.NamXB;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = s.SoLuong;
            cmd.Parameters.Add("@TonKho", SqlDbType.Int).Value = s.TonKho;
            //cmd.Parameters.Add("@Anh", SqlDbType.VarBinary).Value =
            //    (object)s.Anh ?? DBNull.Value;
            cmd.Parameters.Add("@GiaSach", SqlDbType.Float).Value = s.GiaSach;

            ExecuteNonQuery(cmd);
        }

        public void Update(Sach_DTO s)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE SACH 
                                            SET ID_Sach = @ID_Sach, TenSach = @TenSach, ID_TG = @ID_TG, ID_NXB = @ID_NXB,
                                            ID_DM = @ID_DM,NamXB = @NamXB,SoLuong = @SoLuong,TonKho = @TonKho,
                                            Anh = @Anh, GiaSach = @GiaSach
                                            WHERE ID_Sach = @ID_Sach");

            cmd.Parameters.Add("@ID_Sach", SqlDbType.NVarChar).Value = s.ID_Sach;
            cmd.Parameters.Add("@TenSach", SqlDbType.NVarChar).Value = s.TenSach;
            cmd.Parameters.Add("@ID_TG", SqlDbType.NVarChar).Value = s.ID_TG;
            cmd.Parameters.Add("@ID_NXB", SqlDbType.NVarChar).Value = s.ID_NXB;
            cmd.Parameters.Add("@ID_DM", SqlDbType.NVarChar).Value = s.ID_DM;
            cmd.Parameters.Add("@NamXB", SqlDbType.Date).Value = s.NamXB;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = s.SoLuong;
            cmd.Parameters.Add("@TonKho", SqlDbType.Int).Value = s.TonKho;
            cmd.Parameters.Add("@Anh", SqlDbType.VarBinary).Value =
                (object)s.Anh ?? DBNull.Value;
            cmd.Parameters.Add("@GiaSach", SqlDbType.Float).Value = s.GiaSach;

            ExecuteNonQuery(cmd);
        }

        public void Delete(Sach_DTO s)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM SACH WHERE ID_Sach = @ID_Sach");

            cmd.Parameters.Add("@ID_Sach", SqlDbType.NVarChar).Value = s.ID_Sach;
            ExecuteNonQuery(cmd);
        }

        public DataTable Search(Sach_DTO s)
        {
            string sql = @"SELECT * FROM SACH WHERE TenSach LIKE N'%" + s.TenSach + "%'";

            
            return LoadData(sql);
        }

        public DataTable LoadDanhMuc()
        {
            return LoadData(@"SELECT TenDM, ID_DM FROM DANHMUC");
        }

        public DataTable LoadTacGia()
        {
            return LoadData(@"SELECT TenTG, ID_TG FROM TACGIA");
        }

        public DataTable LoadNXB()
        {
            return LoadData(@"SELECT TenNXB, ID_NXB FROM NXB");
        }
    }
}

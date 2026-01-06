using System.Data;
using DTO;

namespace DAL
{
    public class ThongKe_DAL : Connect
    {
        public ThongKe_DAL() { }
        public DataTable Load_Sach()
        {
            return LoadData("SELECT * FROM SACH");
        }
        public DataTable ThongKe_Sach(DTO_ThongKeSach s)
        {
            string sql = @"
                            SELECT 
                                s.ID_Sach,
                                s.TenSach,
                                tg.TenTG,
                                nxb.TenNXB,
                                dm.TenDM,
                                s.SoLuong,
                                s.GiaSach,
                                s.NamXB
                            FROM SACH s
                            INNER JOIN TACGIA tg ON s.ID_TG = tg.ID_TG
                            INNER JOIN NXB nxb ON s.ID_NXB = nxb.ID_NXB
                            INNER JOIN DANHMUC dm ON s.ID_DM = dm.ID_DM
                            WHERE 1 = 1";
            // Tên sách
            if (!string.IsNullOrEmpty(s.TenSach))
            {
                sql += " AND s.TenSach LIKE N'%" + s.TenSach + "%'";
            }

            // tên tác giả
            if (!string.IsNullOrEmpty(s.TenTG))
            {
                sql += " AND tg.TenTG LIKE N'%" + s.TenTG + "%'";
            }

            // tên nhà xuất bản
            if (!string.IsNullOrEmpty(s.TenNXB))
            {
                sql += " AND nxb.TenNXB LIKE N'%" + s.TenNXB + "%'";
            }

            // tên danh mục
            if (!string.IsNullOrEmpty(s.TenDM))
            {
                sql += " AND dm.TenDM LIKE N'%" + s.TenDM + "%'";
            }

            // số lượng
            if (s.SoLuongTu.HasValue)
            {
                if (s.SoLuongDen.HasValue)
                    sql += " AND s.SoLuong BETWEEN " + s.SoLuongTu + " AND " + s.SoLuongDen;
                else
                    sql += " AND s.SoLuong >= " + s.SoLuongTu;
            }
            else if (s.SoLuongDen.HasValue)
            {
                sql += " AND s.SoLuong <= " + s.SoLuongDen;
            }

            // tồn kho
            if(s.TonKhoTu.HasValue)
            {
                if (s.TonKhoDen.HasValue)
                {
                    sql += " AND s.TonKho BETWEEN " + s.TonKhoTu + " AND " + s.TonKhoDen;
                } 
                else
                    sql += " AND s.TonKho >= " + s.TonKhoTu;
            }
            if (s.TonKhoDen.HasValue)
            {
                sql += " AND s.TonKho <= " + s.TonKhoDen;
            }

            // giá sách
            if (s.GiaTu.HasValue)
            {
                if (s.GiaDen.HasValue)
                    sql += " AND s.GiaSach BETWEEN " + s.GiaTu + " AND " + s.GiaDen;
                else
                    sql += " AND s.GiaSach >= " + s.GiaTu;
            }
            else if (s.GiaDen.HasValue)
            {
                sql += " AND s.GiaSach <= " + s.GiaDen;
            }

            // năm xuất bản
            if (s.NamTu.HasValue)
            {
                if (s.NamDen.HasValue)
                    sql += " AND s.NamXB BETWEEN " + s.NamTu + " AND " + s.NamDen;
                else
                    sql += " AND s.NamXB >= " + s.NamTu;
            }
            else if (s.NamDen.HasValue)
            {
                sql += " AND s.NamXB <= " + s.NamDen;
            }

            return LoadData(sql);
        }
    }
}
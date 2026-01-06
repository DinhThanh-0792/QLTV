using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TongQuan_DAL : Connect
    {
        public TongQuan_DAL() { }
        public DataTable Top4DocGia()
        {
            string sql = @"
                            SELECT TOP 4 
                                dg.TenDG, 
                                SUM(ct.SoLuong) AS SoLuongMuon
                            FROM DOCGIA dg
                            JOIN PHIEU p ON dg.ID_DocGia = p.ID_DG
                            JOIN [CHITIET_PHIEU] ct ON p.ID_Phieu = ct.ID_Phieu
                            GROUP BY dg.TenDG
                            ORDER BY SoLuongMuon DESC";
            return LoadData(sql);
        }
        public DataTable SLSach()
        {
            string sql = @"
                            SELECT 
                                SUM(SoLuong) AS TongSoLuong, 
                                SUM(TonKho) AS TongTonKho 
                            FROM SACH";
            return LoadData(sql);
        }
        public DataTable Top4NV()
        {
            string sql = @"
                            SELECT TOP 4 
                                nv.TenNV, 
                                SUM(ct.SoLuong) AS TongSachChoMuon
                            FROM NHANVIEN nv
                            JOIN PHIEU p ON nv.ID_NV = p.ID_NV
                            JOIN [CHITIET_PHIEU] ct ON p.ID_Phieu = ct.ID_Phieu
                            WHERE p.LoaiPhieu = N'Phiếu mượn' -- Chỉ tính các phiếu loại cho mượn
                            GROUP BY nv.TenNV
                            ORDER BY TongSachChoMuon DESC";
            return LoadData(sql);
        }
    }
}

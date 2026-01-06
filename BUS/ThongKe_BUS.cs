using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class ThongKe_BUS
    {
        ThongKe_DAL tks = new ThongKe_DAL();
        ThongKeDocGia_DAL tkdg = new ThongKeDocGia_DAL();
        ThongKeNhanVien_DAL tknv = new ThongKeNhanVien_DAL();
        ThongKeMuonTra_DAL tkmt = new ThongKeMuonTra_DAL();
        TongQuan_DAL tq = new TongQuan_DAL();
        public DataTable Load_Sach()
        {
            return tks.Load_Sach();
        }
        public DataTable ThongKe_Sach(DTO_ThongKeSach s)
        {
            return tks.ThongKe_Sach(s);
        }
        public DataTable Load_DocGia()
        {
            return tkdg.Load_DocGia();
        }
        public DataTable ThongKe_DocGia(DTO_ThongKeDocGia dk)
        {
            return tkdg.ThongKe_DocGia(dk);
        }
        public DataTable Load_NhanVien()
        {
            return tknv.Load_NhanVien();
        }
        public DataTable ThongKe_NhanVien(DTO_ThongKeNhanVien dk)
        {
            return tknv.ThongKe_NhanVien(dk);
        }
        public DataTable Load_PhieuMuonTra()
        {
            return tkmt.Load_PhieuMuonTra();
        }
        public DataTable ThongKeMuonTra(DTO_ThongKeMuonTra dk)
        {
            return tkmt.ThongKeMuonTra(dk);
        }
        public DataTable Top4DG()
        {
            return tq.Top4DocGia();
        }
        public DataTable SLSach()
        {
            return tq.SLSach();
        }
        public DataTable Top4NV()
        {
            return tq.Top4NV();
        }
    }
}

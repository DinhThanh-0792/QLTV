using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhieu
    {
        public int ID_ChiTiet { get; set; }
        public int ID_Phieu { get; set; }
        public string ID_Sach { get; set; }
        public int SoLuong { get; set; }
        public bool TinhTrangTra { get; set; }
        public CTPhieu() { }
        public CTPhieu(int id_ChiTiet, int id_Phieu, string id_Sach, int soLuong, bool tinhTrangTra)
        {
            ID_ChiTiet = id_ChiTiet;
            ID_Phieu = id_Phieu;
            ID_Sach = id_Sach;
            SoLuong = soLuong;
            TinhTrangTra = tinhTrangTra;
        }
    }
}

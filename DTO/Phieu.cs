using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Phieu
    {
        public int ID_Phieu { get; set; }
        public string LoaiPhieu { get; set; }
        public int ID_DG { get; set; }
        public int ID_NV { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayPhaiTra { get; set; }
        public DateTime? NgayTraThucTe { get; set; }
        public string GhiChu { get; set; }
        public Phieu() { }
        public Phieu(int id_Phieu, string loaiPhieu, int id_DG, int id_NV, DateTime ngayMuon, DateTime ngayPhaiTra, DateTime? ngayTraThucTe, string ghiChu)
        {
            ID_Phieu = id_Phieu;
            LoaiPhieu = loaiPhieu;
            ID_DG = id_DG;
            ID_NV = id_NV;
            NgayMuon = ngayMuon;
            NgayPhaiTra = ngayPhaiTra;
            NgayTraThucTe = ngayTraThucTe;
            GhiChu = ghiChu;
        }
    }
}

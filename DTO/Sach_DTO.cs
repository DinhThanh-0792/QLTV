using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sach_DTO
    {
        public string ID_Sach { get; set; }
        public string TenSach { get; set; }
        public string ID_TG { get; set; }
        public string ID_NXB { get; set; }
        public string ID_DM { get; set; }
        public DateTime NamXB { get; set; }
        public int SoLuong { get; set; }
        public int TonKho { get; set; }
        public byte[] Anh { get; set; }
        public float GiaSach { get; set; }
    }
}

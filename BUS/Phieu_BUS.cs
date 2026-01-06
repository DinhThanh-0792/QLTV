using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class Phieu_BUS
    {
        Phieu_DAL phieuDAL = new Phieu_DAL();
        CTPhieu_DAL ctDAL = new CTPhieu_DAL();
        public DataTable LoadPhieu()
        {
            return phieuDAL.LoadPhieu();
        }
        public DataTable LoadCTPhieu(int ID_Phieu)
        {
            return ctDAL.LoadChiTiet(ID_Phieu);
        }
        // LẬP PHIẾU MƯỢN
        public void LapPhieuMuon(Phieu p, List<CTPhieu> dsChiTiet)
        {
            p.LoaiPhieu = "MUON";

            int maPhieu = phieuDAL.InsertPhieu(p);

            foreach (CTPhieu ct in dsChiTiet)
            {
                ct.ID_Phieu = maPhieu;
                ctDAL.InsertCTPhieu(ct);
            }
        }
    }
}

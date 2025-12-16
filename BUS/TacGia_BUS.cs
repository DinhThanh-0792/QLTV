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
    public class TacGia_BUS
    {
        TacGia_DAL dAL = new TacGia_DAL();
        public DataTable LoadTacGia()
        {
            return dAL.LoadTacGia();
        }
        public void InsertTacGia(TacGia tg)
        {
            dAL.InsertTacGia(tg);
        }
        public void UpdateTacGia(TacGia tg)
        {
            dAL.UpdateTacGia(tg);
        }
        public void DeleteTacGia(string maTG)
        {
            dAL.DeleteTacGia(maTG);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
//using static System.Net.Mime.MediaTypeNames;

namespace BUS
{
    public class TacGia_BUS
    {
        TacGia_DAL dAL = new TacGia_DAL();
        public DataTable LoadTacGia()
        {
            return dAL.LoadTacGia();
        }

        public DataTable SearchTacGia(string tenTG)
        {
            return dAL.Search(tenTG);
        }
        public void InsertTacGia(TacGia tg)
        {
            dAL.InsertTacGia(tg);
        }
        public void UpdateTacGia(TacGia tg)
        {
            dAL.UpdateTacGia(tg);
        }
        public void DeleteTacGia(string tenTG)
        {
            dAL.DeleteTacGia(tenTG);
        }
    }
}

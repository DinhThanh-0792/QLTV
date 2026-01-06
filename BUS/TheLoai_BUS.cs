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
    public class TheLoai_BUS
    {
        TheLoai_DAL dal = new TheLoai_DAL();

        public DataTable Load()
        {
            return dal.Load();
        }

        public void Insert(TheLoai_DTO tl)
        {
            dal.Insert(tl);
        }

        public void Update(TheLoai_DTO tl)
        {
            dal.Update(tl);
        }

        public void Delete(TheLoai_DTO tl)
        {
            dal.Delete(tl);
        }

        public DataTable SearchDM(TheLoai_DTO tl)
        {
            return dal.Search(tl);
        }

        public DataTable DanhMucCha()
        {
            return dal.LoadDanhMucCha();
        }
    }
}

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
    public class Sach_BUS
    {
        Sach_DAL dal = new Sach_DAL();

        // LOAD
        public DataTable Load()
        {
            return dal.Load();
        }

        // INSERT
        public void Insert(Sach_DTO s)
        {
            dal.Insert(s);
        }

        // UPDATE
        public void Update(Sach_DTO s)
        {
            dal.Update(s);
        }

        // DELETE
        public void Delete(Sach_DTO s)
        {
            dal.Delete(s);
        }

        // SEARCH
        public DataTable Search(Sach_DTO s)
        {
            return dal.Search(s);
        }

        public DataTable LoadDanhMuc()
        {
            return dal.LoadDanhMuc();
        }

        public DataTable LoadTacGia()
        {
            return dal.LoadTacGia();
        }

        public DataTable LoadNXB()
        {
            return dal.LoadNXB();
        }
    }
}

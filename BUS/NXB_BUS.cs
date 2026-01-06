using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace BUS
{
    public class NXB_BUS
    {
        //Khai báo DAL
        NXB_DAL dal = new NXB_DAL();

        public DataTable Load()
        {
            return dal.Load();
        }

        public void Insert(NXB_DTO nxb)
        {
            dal.Insert(nxb);
        }

        public void Update(NXB_DTO nxb)
        {
            dal.Update(nxb);
        }

        public void Delete(NXB_DTO nxb)
        {
            dal.Delete(nxb);
        }

        public DataTable SearchNXB(NXB_DTO nxb)
        {
            return dal.Search(nxb);
        }
    }
}

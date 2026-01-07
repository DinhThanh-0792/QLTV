using System;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class DocGia_BUS
    {
        DocGia_DAL dal = new DocGia_DAL();

        // LOAD
        public DataTable Load()
        {
            return dal.LoadDocGia();
        }

        public DataTable Load_Report()
        {
            return dal.LoadDocGia();
        }

        // INSERT
        public void Insert(DTO_DocGia dg)
        {
            dal.InsertDocGia(dg);
        }

        // UPDATE
        public void Update(DTO_DocGia dg)
        {
            dal.UpdateDocGia(dg);
        }

        // DELETE
        public void Delete(DTO_DocGia dg)
        {
            dal.DeleteDocGia(dg.ID_DocGia);
        }

        // SEARCH
        public DataTable Search(string dg)
        {
            return dal.SearchDocGia(dg);
        }
    }
}

        
        

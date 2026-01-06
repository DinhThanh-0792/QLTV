using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class TacGia_DAL: Connect
    {
        public DataTable LoadTacGia()
        {
            string sql = "SELECT * FROM TACGIA";
            return LoadData(sql);
        }
        public void InsertTacGia(TacGia tg)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO TACGIA (ID_TG, TenTG, QuocGia) VALUES (@ID_TG, @TenTG, @QuocGia)");
            cmd.Parameters.AddWithValue("@ID_TG" +
                "", tg.MaTG);
            cmd.Parameters.AddWithValue("@TenTG", tg.TenTG);
            cmd.Parameters.AddWithValue("@QuocGia", tg.QuocGia);
            ExecuteNonQuery(cmd);
        }
        public void UpdateTacGia(TacGia tg)
        {
            SqlCommand cmd = new SqlCommand("UPDATE TACGIA SET TenTG = @TenTG, QuocGia = @QuocGia WHERE ID_TG = @ID_TG");
            cmd.Parameters.AddWithValue("@ID_TG", tg.MaTG);
            cmd.Parameters.AddWithValue("@TenTG", tg.TenTG);
            cmd.Parameters.AddWithValue("@QuocGia", tg.QuocGia);
            ExecuteNonQuery(cmd);
        }
        public void DeleteTacGia(string maTG)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TACGIA WHERE ID_TG = @ID_TG");
            cmd.Parameters.AddWithValue("@ID_TG", maTG);
            ExecuteNonQuery(cmd);
        }

        public DataTable Search(string TenTG)
        {
            string sql = @"SELECT * FROM TACGIA 
                   WHERE TenTG LIKE N'%" + TenTG + "%'";

            

            return LoadData(sql);
        }

    }
}

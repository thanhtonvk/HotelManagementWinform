using System.Collections.Generic;
using System.Data;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Utils;

namespace QuanLyKhachSan.DAL
{
    internal class DichVuDAL
    {
        public int Add(DichVu dv)
        {
            string query = $"insert into DichVu(TenDV,Gia) values(N'{dv.TenDV}',{dv.Gia})";
            return DBHelper.NonQuery(query,null);
        }

        public int Update(DichVu dv)
        {
            string query = $"update DichVu set TenDV = N'{dv.TenDV}',Gia = {dv.Gia} where Id = {dv.Id}";
            return DBHelper.NonQuery(query, null);
        }

        public int Delete(int Id)
        {
            string query = $"delete from DichVu where Id = {Id}";
            return DBHelper.NonQuery(query, null);
        }

        public List<DichVu> GetAll()
        {
            List<DichVu> list = new List<DichVu>();
            string query = "select * from DichVu";
            DataTable dt = DBHelper.Query(query,null);
            foreach (DataRow row in dt.Rows)
            {
                DichVu dichVu = new DichVu()
                {
                    Gia = int.Parse(row["Gia"].ToString()),
                    Id = int.Parse(row["Id"].ToString()),
                    TenDV = row["TenDV"] as string
                };
                list.Add(dichVu);
            }

            return list;
        }   
    }
}
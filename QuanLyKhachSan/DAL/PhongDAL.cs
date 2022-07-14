using QuanLyKhachSan.Models;
using QuanLyKhachSan.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.DAL
{
    internal class PhongDAL
    {
        public int Add(Phong phong)
        {
            string query = $"insert into Phong(LoaiPhong,Gia,TrangThai) values(N'{phong.LoaiPhong}',{phong.Gia},0)";
            return DBHelper.NonQuery(query,null);
        }
        public int Update(Phong phong)
        {
            string query = $"update Phong set LoaiPhong = N'{phong.LoaiPhong}',Gia = {phong.Gia} where Id = {phong.Id}";
            return DBHelper.NonQuery(query, null);
        }
        public int Update(int id,int trangThai)
        {
            string query = $"update Phong set TrangThai = {trangThai} where Id = {id}";
            return DBHelper.NonQuery(query, null);
        }
        public int Delete(int id)
        {
            string query = $"delete from Phong where Id = {id}";
            return DBHelper.NonQuery(query, null);
        }
        
        public List<Phong> GetAll()
        {
            string query = "select * from Phong";
            DataTable dt = DBHelper.Query(query, null);
            List<Phong> list = new List<Phong>();
            foreach(DataRow row in dt.Rows)
            {
                Phong phong = new Phong()
                {
                    Id = int.Parse(row[0].ToString()),
                    LoaiPhong = row[1] as string,
                    Gia = int.Parse(row[2].ToString()),
                };
             
                bool trangThai = bool.Parse(row[3].ToString());
                if (!trangThai) phong.TrangThai = "Trống";
                else phong.TrangThai = "Có người";
                list.Add(phong);
            }
            return list;
        }
        public List<Phong> GetPhongTrong()
        {
            string query = "select * from Phong where TrangThai = 0";
            DataTable dt = DBHelper.Query(query, null);
            List<Phong> list = new List<Phong>();
            foreach (DataRow row in dt.Rows)
            {
                Phong phong = new Phong()
                {
                    Id = int.Parse(row[0].ToString()),
                    LoaiPhong = row[1] as string,
                    Gia = int.Parse(row[2].ToString()),
                };

                bool trangThai = bool.Parse(row[3].ToString());
                if (!trangThai) phong.TrangThai = "Trống";
                else phong.TrangThai = "Có người";
                list.Add(phong);
            }
            return list;
        }
       
    }
}

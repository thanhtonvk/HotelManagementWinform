using QuanLyKhachSan.Models;
using QuanLyKhachSan.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAL
{
    internal class NhanVienDAL
    {
        public int Add(NhanVien nv)
        {
            string query = $"insert into NhanVien(TenNV,NgaySinh,DiaChi,SDT) values(N'{nv.TenNV}','{nv.NgaySinh}',N'{nv.DiaChi}','{nv.SDT}')";
            return DBHelper.NonQuery(query,null);
        }
        public int Update(NhanVien nv)
        {
            string query = $"update NhanVien set TenNV = N'{nv.TenNV}',NgaySinh = '{nv.NgaySinh}',DiaChi = '{nv.DiaChi}',SDT = '{nv.SDT}'";
            return DBHelper.NonQuery(query, null);
        }
        public int Delete(int id)
        {
            string query = $"delete from NhanVien where Id = {id}";
            return DBHelper.NonQuery(query, null);
        }
        public List<NhanVien> GetAll()
        {
            string query = "select * from NhanVien";
            List<NhanVien> list = new List<NhanVien>();
            DataTable dt = DBHelper.Query(query,null);
            foreach (DataRow row in dt.Rows)
            {
                NhanVien nhanVien = new NhanVien()
                {
                    DiaChi = row["Diachi"] as string,
                    Id = int.Parse(row["id"].ToString()),
                    NgaySinh = row["NgaySinh"] as string,
                    SDT = row["SDT"] as string,
                    TenNV = row["TenNV"] as string
                };
                list.Add(nhanVien);
            }

            return list;
        }
    }
}

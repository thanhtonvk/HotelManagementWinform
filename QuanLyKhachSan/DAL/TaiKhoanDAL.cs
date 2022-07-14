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
    internal class TaiKhoanDAL
    {
        public int Add(TaiKhoan tk)
        {
            string query = $"insert into TaiKhoan values('{tk.TenTK}','{tk.MatKhau}','{tk.LoaiTK}')";
            return DBHelper.NonQuery(query,null);
        }
        public int Update(TaiKhoan tk)
        {
            string query = $"update TaiKhoan set MatKhau = '{tk.MatKhau}',LoaiTk  = '{tk.LoaiTK}'";
            return DBHelper.NonQuery(query, null);
        }
        public int Delete(string TenTK)
        {
            string query = $"delete TaiKhoan where TenTK = '{TenTK}'";
            return DBHelper.NonQuery(query, null);
        }
        public List<TaiKhoan> GetAll()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            string query = "select * from TaiKhoan";
            DataTable tb = DBHelper.Query(query, null);
            foreach(DataRow row in tb.Rows)
            {
                TaiKhoan tk = new TaiKhoan()
                {
                    TenTK = row[0] as string,
                    MatKhau = row[1] as string,
                    LoaiTK = row[2] as string
                };
                list.Add(tk);
            }
            return list;
        }
        
    }
}

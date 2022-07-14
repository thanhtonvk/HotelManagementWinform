using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Utils;

namespace QuanLyKhachSan.DAL
{
    class HoaDonDAL
    {
        public int ThuePhong(HoaDon hoaDon)
        {
            string query =
                $"insert into HoaDon(TenKH,SoCC,IdPhong,NgayThue,TrangThai) values(N'{hoaDon.TenKH}','{hoaDon.SoCC}',{hoaDon.IdPhong},'{hoaDon.NgayThue}',0)";
            new PhongDAL().Update(hoaDon.IdPhong, 1);
            return DBHelper.NonQuery(query, null);
        }

        public int TraPhong(HoaDon hoaDon)
        {
           
            string query = $"update HoaDon set TrangThai = 1,NgayTra = '{hoaDon.NgayTra}' where Id = {hoaDon.Id}";
            new PhongDAL().Update(hoaDon.IdPhong, 0);
            return DBHelper.NonQuery(query, null);
        }
        public ThanhToan GetTienThue(HoaDon hoaDon)
        {
            string query = $"SELECT (DATEDIFF(day, '{hoaDon.NgayThue}', '{hoaDon.NgayTra}'))+1 AS SoNgay,(DATEDIFF(day, '{hoaDon.NgayThue}', '{hoaDon.NgayTra}')+1)*Phong.Gia as TongTien from HoaDon, Phong where HoaDon.IdPhong = Phong.Id and HoaDon.Id = {hoaDon.Id}";
            DataTable dt = DBHelper.Query(query, null);
            ThanhToan thanhToan=new ThanhToan();
            foreach(DataRow row in dt.Rows)
            {
                thanhToan = new ThanhToan()
                {
                    SoNgay = int.Parse(row["SoNgay"].ToString()),
                    TongTien = int.Parse(row["TongTien"].ToString())
                };

            }
            return thanhToan;
        }

        public int Update(HoaDon hoaDon)
        {
            string query =
                $"update HoaDon set TenKH = N'{hoaDon.TenKH}',SoCC = '{hoaDon.SoCC}',IdPhong = {hoaDon.IdPhong},NgayThue = '{hoaDon.NgayThue}' where Id = {hoaDon.Id}";
            return DBHelper.NonQuery(query, null);
        }
      

        public List<HoaDon> GetDaThue()
        {
            string query = "select * from HoaDon where TrangThai =0";
            DataTable dt = DBHelper.Query(query, null);
            List<HoaDon> hoaDons = new List<HoaDon>();
            foreach (DataRow row in dt.Rows)
            {
                HoaDon hoaDon = new HoaDon()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    IdPhong = int.Parse(row["IdPhong"].ToString()),
                    NgayThue = row["NgayThue"].ToString(),
                    NgayTra = "",
                    SoCC = row["SoCC"].ToString(),
                    TenKH = row["TenKH"].ToString(),
                    TrangThai = "Đang thuê"
                };
                hoaDons.Add(hoaDon);
            }

            return hoaDons;
        }
        public List<HoaDon> GetDaTra()
        {
            string query = "select * from HoaDon where TrangThai =1";
            DataTable dt = DBHelper.Query(query, null);
            List<HoaDon> hoaDons = new List<HoaDon>();
            foreach (DataRow row in dt.Rows)
            {
                HoaDon hoaDon = new HoaDon()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    IdPhong = int.Parse(row["IdPhong"].ToString()),
                    NgayThue = row["NgayThue"].ToString(),
                    NgayTra =row["NgayTra"].ToString(),
                    SoCC = row["SoCC"].ToString(),
                    TenKH = row["TenKH"].ToString(),
                    TrangThai = "Đã trả phòng"
                };
                hoaDons.Add(hoaDon);
            }

            return hoaDons;
        }
    }
}
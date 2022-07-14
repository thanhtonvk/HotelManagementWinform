using System.Collections.Generic;

using System.Linq;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.BLL
{
    class HoaDonBLL
    {
        private HoaDonDAL dal = new HoaDonDAL();

       public string ThuePhong(HoaDon hoaDon)
       {
           if (dal.ThuePhong(hoaDon) > 0) return "Thành công";
           return "Thất bại";
       }

        public string TraPhong(HoaDon hoaDon)
        {
            if (dal.TraPhong(hoaDon) > 0) return "Thành công";
            return "Thất bại";
        }

        public string Update(HoaDon hoaDon)
        {
            if (dal.Update(hoaDon) > 0) return "Thành công";
            return "Thất bại";
        }

        public List<HoaDon> GetDaThue(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa)) return dal.GetDaThue();
            return dal.GetDaThue().Where(x => x.NgayThue.Contains(tuKhoa) || x.TenKH.Contains(tuKhoa)).ToList();
        }
        public List<HoaDon> GetDaTra(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa)) return dal.GetDaTra();
            return dal.GetDaTra().Where(x => x.NgayThue.Contains(tuKhoa) || x.TenKH.Contains(tuKhoa)).ToList();
        }
        public ThanhToan GetTienThue(HoaDon hoaDon)
        {
            return dal.GetTienThue(hoaDon);
        }
        public List<HoaDon> GetAll(string tukhoa)
        {
            List<HoaDon> list = new List<HoaDon>();
            list.AddRange(GetDaThue(tukhoa));
            list.AddRange(GetDaTra(tukhoa));
            return list;
        }
    }
}
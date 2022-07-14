using System.Collections.Generic;
using System.Linq;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.BLL
{
    class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public string Add(NhanVien nhanVien)
        {
            if (dal.Add(nhanVien) > 0) return "Thêm thành công";
            return "Thất bại";
        }

        public string Update(NhanVien nhanVien)
        {
            if (dal.Update(nhanVien) > 0) return "Thành công";
            return "Thất bại";
        }

        public string Delete(int id)
        {
            if (dal.Delete(id) > 0) return "Thành công";
            return "Thất bại";
        }

        public List<NhanVien> GetAll(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa)) return dal.GetAll();
            return dal.GetAll().Where(x =>
                x.TenNV.Contains(tuKhoa) || x.DiaChi.Contains(tuKhoa) || x.NgaySinh.Contains(tuKhoa)).ToList();
        }
    }
}
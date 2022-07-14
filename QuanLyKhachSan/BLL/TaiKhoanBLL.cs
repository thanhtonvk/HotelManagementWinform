using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyKhachSan.BLL
{
    internal class TaiKhoanBLL
    {
        TaiKhoanDAL dal = new TaiKhoanDAL();
        public string Add(TaiKhoan tk)
        {
            if (dal.Add(tk) > 0) return "Thành công";
            return "Thất bại";
        }
        public string Update(TaiKhoan tk)
        {
            if (dal.Update(tk) > 0) return "Thành công";
            return "Thất bại";
        }
        public string Delete(string TenTK)
        {
            if (dal.Delete(TenTK) > 0) return "Thành công";
            return "Thất bại";
        }
        public List<TaiKhoan> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return dal.GetAll();
            return dal.GetAll().Where(x=>x.TenTK.Contains(keyword)).ToList();
        }
        public TaiKhoan DangNhap(string tenTK, string matKhau)
        {
            TaiKhoan taiKhoan = GetAll("").FirstOrDefault(x => x.TenTK == tenTK && x.MatKhau == matKhau);
            return taiKhoan;
        }
    }
}

using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;
using System.Collections.Generic;
using System.Linq;


namespace QuanLyKhachSan.BLL
{
    internal class PhongBLL
    {
        PhongDAL dal = new PhongDAL();
        public string Add(Phong phong)
        {
            if (dal.Add(phong) > 0) return "Thành công";
            return "Thất bại";
        }
        public string Update(Phong phong)
        {
            if (dal.Update(phong) > 0) return "Thành công";
            return "Thất bại";
        }
        public string Update(int id,int trangThai)
        {
            if (dal.Update(id, trangThai) > 0) return "Thành công";
            return "Thất bại";
        }
        public string Delete(int id)
        {
            if (dal.Delete(id) > 0) return "Thành công";
            return "Thất bại";
        }

        public List<Phong> GetAll(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa)) return dal.GetAll();
            return dal.GetAll().Where(x => x.LoaiPhong.Contains(tuKhoa)).ToList();
        }
        public List<Phong> GetPhongTrong()
        {
            return dal.GetPhongTrong();
        }
    }
}

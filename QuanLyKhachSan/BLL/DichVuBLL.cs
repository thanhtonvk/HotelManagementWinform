using System.Collections.Generic;
using System.Linq;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.BLL
{
    class DichVuBLL
    {
        private DichVuDAL dal = new DichVuDAL();
        public string Add(DichVu dichVu)
        {
            if (dal.Add(dichVu) > 0) return "Thành công";
            return "Thất bại";
        }

        public string Update(DichVu dichVu)
        {
            if (dal.Update(dichVu) > 0) return "Thành công";
            return "Thất bại";
        }

        public string Delete(int id)
        {
            if (dal.Delete(id) > 0) return "Thành công";
            return "Thất bại";
        }

        public List<DichVu> GetAll(string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa)) return dal.GetAll();
            return dal.GetAll().Where(x => x.TenDV.Contains(tuKhoa)).ToList();
        }
    }
}
using System.Collections.Generic;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.BLL
{
    class CTHoaDonBLL
    {
        private CTHoaDonDAL dal = new CTHoaDonDAL();
        public string Add(CTHoaDon hd)
        {
            if (dal.Add(hd) > 0) return "Thành công";
            return "Thất bại";
        }

        public string Update(CTHoaDon hd)
        {
            if (dal.Update(hd) > 0) return "Thành công";
            return "Thất bại";
        }

        public string Delete(int id)
        {
            if (dal.Delete(id) > 0) return "Thành công";
            return "Thất bại";
        }
        public List<CTHoaDon> GetAll(int idHD)
        {
            return dal.GetAll(idHD);
        }
    }
}
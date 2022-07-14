using System.Collections.Generic;
using System.Data;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Utils;

namespace QuanLyKhachSan.DAL
{
    class CTHoaDonDAL
    {
        public int Add(CTHoaDon hd)
        {
            string query =
                $"insert into CTHoaDon(IdHoaDon,IdDichVu,SoLuong) values({hd.IdHoaDon},{hd.IdDichVu},{hd.SoLuong})";
            return DBHelper.NonQuery(query, null);
        }

        public int Update(CTHoaDon hd)
        {
            string query = $"update CTHoaDon set IdDichVu = {hd.IdDichVu},SoLuong = {hd.SoLuong} where Id = {hd.Id}";
            return DBHelper.NonQuery(query, null);
        }

        public int Delete(int id)
        {
            string query = $"delete from CTHoaDon where Id = {id}";
            return DBHelper.NonQuery(query, null);
        }
        public List<CTHoaDon> GetAll(int idHD)
        {
            List<CTHoaDon> list = new List<CTHoaDon>();
            string query =
                $"select CTHoaDon.Id,CTHoaDon.IdHoaDon,CTHoaDon.IdDichVu,DichVu.TenDV,DichVu.Gia,CTHoaDon.SoLuong ,DichVu.Gia*CTHoaDon.SoLuong [ThanhTien] from HoaDon,CTHoaDon,DichVu where HoaDon.Id = CTHoaDon.IdHoaDon and CTHoaDon.IdDichVu = DichVu.ID and HoaDon.Id = {idHD}";
            DataTable dt = DBHelper.Query(query, null);
            foreach (DataRow row in dt.Rows)
            {
                CTHoaDon hd = new CTHoaDon()
                {
                    DonGia = int.Parse(row["Gia"].ToString()),
                    Id = int.Parse(row["Id"].ToString()),
                    IdDichVu = int.Parse(row["IdDichVu"].ToString()),
                    IdHoaDon = int.Parse(row["IdHoaDon"].ToString()),
                    SoLuong = int.Parse(row["SoLuong"].ToString()),
                    TenDV = row["TenDV"].ToString(),
                    ThanhTien = int.Parse(row["ThanhTien"].ToString())
                };
                list.Add(hd);
            }
            return list;
        }
    }
}
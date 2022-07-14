using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models
{
    internal class CTHoaDon
    {
   
        public int Id { get; set; }
        public int IdHoaDon { get; set; }
        public int IdDichVu { get; set; }
        public string TenDV { get; set; }
        public int DonGia { get; set; }

        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }

    }
}

using QuanLyKhachSan.BLL;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.GUI
{
    public partial class HoaDonThanhToanGUI : Form
    {
        public HoaDonThanhToanGUI()
        {
            InitializeComponent();
            load();
        }
        CTHoaDonBLL cthdBll = new CTHoaDonBLL();
        HoaDonBLL hdBLL = new HoaDonBLL();
        private void load()
        {
            dataGridView1.DataSource = cthdBll.GetAll(Common.idHD);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ThanhToan thanhToan = hdBLL.GetTienThue(Common.hoaDon);
            txtngaythue.Text = Common.hoaDon.NgayThue;
            txtngaytra.Text = Common.hoaDon.NgayTra;
            txtsocc.Text = Common.hoaDon.SoCC;
            txttienthue.Text = thanhToan.TongTien+"vnd";
            txtsongaythue.Text = thanhToan.SoNgay+"";
            txttenkh.Text = Common.hoaDon.TenKH;
            int tong = thanhToan.TongTien;
            foreach(CTHoaDon cthd in cthdBll.GetAll(Common.idHD))
            {
                tong += cthd.ThanhTien;
            }
            txttongthanhtoan.Text = tong + "vnd";
        }
    }
}

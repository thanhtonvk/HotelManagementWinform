using QuanLyKhachSan.BLL;
using QuanLyKhachSan.Models;
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
    public partial class DangNhapGUI : Form
    {
        public DangNhapGUI()
        {
            InitializeComponent();
        }

        TaiKhoanBLL bll = new TaiKhoanBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = bll.DangNhap(txttk.Text, txtmk.Text);
            if (taiKhoan != null)
            {
                if (taiKhoan.LoaiTK == "admin")
                {
                    this.Hide();
                    AdminGUI gui = new AdminGUI();
                    gui.ShowDialog();
                    this.Show();
                }
                else
                {
                    this.Hide();
                    NhanVienGUI gui = new NhanVienGUI();
                    gui.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }
        }
    }
}

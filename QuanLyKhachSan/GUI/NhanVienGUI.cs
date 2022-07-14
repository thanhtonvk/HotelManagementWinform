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
    public partial class NhanVienGUI : Form
    {
        public NhanVienGUI()
        {
            InitializeComponent();
            Load();
        }
        PhongBLL phongBLL = new PhongBLL();
        DichVuBLL dichVuBLL = new DichVuBLL();
        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private void Load()
        {
            dgvphong.DataSource = phongBLL.GetAll("");
            dgvphong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvphong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdichvu.DataSource = dichVuBLL.GetAll("");
            dgvdichvu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvdichvu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbphong.DataSource = phongBLL.GetPhongTrong();
            cbphong.DisplayMember = "Id";
            cbphong.ValueMember = "Id";
            dgvthuephong.DataSource = hoaDonBLL.GetDaThue("");
            dgvthuephong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvthuephong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong()
            {
                LoaiPhong = txtloaiphong.Text.Trim(),
                Gia = int.Parse(txtgiaphong.Text.Trim())
            };
            MessageBox.Show(phongBLL.Add(phong));
            Load();
        }
        int idPhong = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            Phong phong = new Phong()
            {
                Id = idPhong,
                LoaiPhong = txtloaiphong.Text.Trim(),
                Gia = int.Parse(txtgiaphong.Text.Trim())
            };
            MessageBox.Show(phongBLL.Update(phong));
            Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(phongBLL.Delete(idPhong));
            Load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvphong.DataSource = phongBLL.GetAll(txttimkiemphong.Text.Trim());
        }

        private void dgvphong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dgvphong.SelectedRows)
            {
                idPhong = int.Parse(row.Cells[0].Value.ToString());
                txtloaiphong.Text = row.Cells[1].Value.ToString();
                txtgiaphong.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu()
            {
                TenDV = txttendv.Text,
                Gia = int.Parse(txtgia.Text)
            };
            MessageBox.Show(dichVuBLL.Add(dv));
            Load();
        }
        int idDV = -1;

        private void button7_Click(object sender, EventArgs e)
        {
            DichVu dv = new DichVu()
            {
                Id = idDV,
                TenDV = txttendv.Text,
                Gia = int.Parse(txtgia.Text)
            };
            MessageBox.Show(dichVuBLL.Update(dv));
            Load();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dichVuBLL.Delete(idDV));
            Load();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvdichvu.DataSource = dichVuBLL.GetAll(txttimkiemdv.Text.Trim());
        }

        private void dgvdichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dgvdichvu.Rows)
            {
                idDV = int.Parse(row.Cells[0].Value.ToString());
                txttendv.Text = row.Cells[1].Value.ToString();
                txtgia.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dgvthuephong.DataSource = hoaDonBLL.GetDaThue("");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dgvthuephong.DataSource = hoaDonBLL.GetDaTra("");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dgvthuephong.DataSource = hoaDonBLL.GetAll("");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dgvthuephong.DataSource = hoaDonBLL.GetAll(txttimkiemhoadon.Text.Trim()) ;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon()
            {
                IdPhong = (cbphong.SelectedItem as Phong).Id,
                NgayThue = dtpngaythue.Value.ToString("yyyy/MM/dd"),
                TenKH = txttenkh.Text,
                SoCC = txtsocc.Text
            };
            MessageBox.Show(hoaDonBLL.ThuePhong(hoaDon));
            Load();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Common.idHD = idHoaDon;
            Common.hoaDon = hoaDonBLL.GetAll("").Where(x=>x.Id==idHoaDon).FirstOrDefault();
            Common.hoaDon.NgayTra = dtpngaytra.Value.ToString("yyyy/MM/dd");
            MessageBox.Show(hoaDonBLL.TraPhong(Common.hoaDon));
            Load();
            HoaDonThanhToanGUI hdtt = new HoaDonThanhToanGUI();
            hdtt.ShowDialog();
        }
        int idHoaDon = -1;

        private void button11_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon()
            {
                Id = idHoaDon,
                IdPhong = (cbphong.SelectedItem as Phong).Id,
                NgayThue = dtpngaythue.Value.ToString("yyyy/MM/dd"),
                TenKH = txttenkh.Text,
                SoCC = txtsocc.Text
            };
            MessageBox.Show(hoaDonBLL.Update(hoaDon));
            Load();
        }

        private void dgvthuephong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dgvthuephong.Rows)
            {
                idHoaDon = int.Parse(row.Cells[0].Value.ToString());
                txttenkh.Text = row.Cells[1].Value.ToString();
                txtsocc.Text = row.Cells[2].Value.ToString();
                dtpngaythue.Value = DateTime.Parse(row.Cells[4].Value.ToString());
                cbphong.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
            Common.idHD = idHoaDon;
            SuDungDichVuGUI gui = new SuDungDichVuGUI();
            gui.ShowDialog();
           
        }
    }
}

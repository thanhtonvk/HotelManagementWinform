using QuanLyKhachSan.BLL;
using QuanLyKhachSan.Models;
using System;
using System.Windows.Forms;

namespace QuanLyKhachSan.GUI
{
    public partial class AdminGUI : Form
    {
        public AdminGUI()
        {
            InitializeComponent();
            Load();
        }
        NhanVienBLL nvBll = new NhanVienBLL();
        TaiKhoanBLL tkBll = new TaiKhoanBLL();
        private void Load()
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = nvBll.GetAll("");
            dataGridView2.DataSource = tkBll.GetAll("");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien()
            {
                DiaChi = txtdiachi.Text.Trim(),
                NgaySinh = txtngaysinh.Value.ToString("yyyy/MM/dd"),
                SDT = txtsdt.Text,
                TenNV = txthoten.Text
            };
            MessageBox.Show(nvBll.Add(nv));
            Load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien()
            {
                DiaChi = txtdiachi.Text.Trim(),
                NgaySinh = txtngaysinh.Value.ToString("yyyy/MM/dd"),
                SDT = txtsdt.Text,
                TenNV = txthoten.Text
            };
            nv.Id = idNV;
            MessageBox.Show(nvBll.Update(nv));
            Load();

        }
        int idNV = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                idNV = int.Parse(row.Cells[0].Value.ToString());
                txthoten.Text = row.Cells[1].Value.ToString();
                txtngaysinh.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                txtdiachi.Text = row.Cells[3].Value.ToString();
                txtsdt.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(nvBll.Delete(idNV));
            Load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nvBll.GetAll(txttimkiemnv.Text.Trim());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan()
            {
                TenTK = txttentk.Text.Trim(),
                MatKhau = txtmk.Text.Trim(),
                LoaiTK = txtloaitk.Text.Trim()
            };
            MessageBox.Show(tkBll.Add(tk));
            Load();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan()
            {
                TenTK = txttentk.Text.Trim(),
                MatKhau = txtmk.Text.Trim(),
                LoaiTK = txtloaitk.Text.Trim()
            };
            MessageBox.Show(tkBll.Update(tk));
            Load();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tkBll.Delete(txttentk.Text.Trim()));
            Load();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView2.SelectedRows)
            {
                txttentk.Text = row.Cells[0].Value.ToString().Trim();
                txtmk.Text = row.Cells[1].Value.ToString().Trim();
                txtloaitk.Text = row.Cells[2].Value.ToString().Trim();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = nvBll.GetAll(txttimkiem.Text);
        }
    }
}

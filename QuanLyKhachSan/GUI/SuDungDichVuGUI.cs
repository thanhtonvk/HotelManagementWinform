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
    public partial class SuDungDichVuGUI : Form
    {
        public SuDungDichVuGUI()
        {
            InitializeComponent();
            Load();
        }
        CTHoaDonBLL cthdBll = new CTHoaDonBLL();
        DichVuBLL dvBll = new DichVuBLL();
        private void Load()
        {
            dataGridView1.DataSource = cthdBll.GetAll(Common.idHD);
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox1.DataSource = dvBll.GetAll("");
            comboBox1.DisplayMember = "TenDV";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DichVu dv = comboBox1.SelectedItem as DichVu;
            CTHoaDon cthd = new CTHoaDon()
            {
                IdHoaDon = Common.idHD,
                SoLuong = int.Parse(textBox1.Text.Trim()),
                IdDichVu = dv.Id
            };
            MessageBox.Show(cthdBll.Add(cthd));
            Load();
        }
        int idCTHD = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            DichVu dv = comboBox1.SelectedItem as DichVu;
            CTHoaDon cthd = new CTHoaDon()
            {
                Id = idCTHD,
                IdHoaDon = Common.idHD,
                SoLuong = int.Parse(textBox1.Text.Trim()),
                IdDichVu = dv.Id
            };
            MessageBox.Show(cthdBll.Update(cthd));
            Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cthdBll.Delete(idCTHD));
            Load();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                idCTHD = int.Parse(row.Cells[0].Value.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLTV
{
    public partial class UserControlMuon : UserControl
    {
        public UserControlMuon()
        {
            InitializeComponent();
        }

        //private void btnThem_Click(object sender, EventArgs e)
        //{

        //}
        Phieu_BUS phieuBUS = new Phieu_BUS();

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            FormPhieuMuon f = new FormPhieuMuon();
            f.ShowDialog();
            LoadDanhSachPhieu();
        }
        void LoadDanhSachPhieu()
        {
            dataGridViewPhieu.DataSource = phieuBUS.LoadPhieu();
            dataGridViewPhieu.Columns["ID_DG"].Visible = false;
            dataGridViewPhieu.Columns["ID_NV"].Visible = false ;
        }

        private void UserControlMuon_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhieu();

        }

        private void dataGridViewPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieu.Text = dataGridViewPhieu.CurrentRow.Cells["ID_Phieu"].Value.ToString();
            txtMaDocGia.Text = dataGridViewPhieu.CurrentRow.Cells["ID_DG"].Value.ToString();
            txtTenDocGia.Text = dataGridViewPhieu.CurrentRow.Cells["TenDG"].Value.ToString();
            txtMaNhanVien.Text = dataGridViewPhieu.CurrentRow.Cells["ID_NV"].Value.ToString();
            txtTenNhanVien.Text = dataGridViewPhieu.CurrentRow.Cells["TenNV"].Value.ToString();
            txtNgayMuon.Text = dataGridViewPhieu.CurrentRow.Cells["NgayMuon"].Value.ToString();
            txtNgayPhaiTra.Text = dataGridViewPhieu.CurrentRow.Cells["NgayPhaiTra"].Value.ToString();
            dataGridViewChiTiet.DataSource = phieuBUS.LoadCTPhieu(int.Parse(txtMaPhieu.Text));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLTV
{
    public partial class UserControlDocGia : UserControl
    {
        DocGia_BUS dgBUS = new DocGia_BUS();
        public UserControlDocGia()
        {
            InitializeComponent();
            this.Load += UserControlDocGia_Load;
        }
        void LoadGridViewDocGia()
        {
            DataGridViewDG.DataSource = dgBUS.Load();

            DataGridViewDG.Columns["ID_DocGia"].HeaderText = "Mã độc giả";
            DataGridViewDG.Columns["TenDG"].HeaderText = "Tên độc giả";
            DataGridViewDG.Columns["SDT"].HeaderText = "Số điện thoại";
            DataGridViewDG.Columns["Email"].HeaderText = "Email";
            DataGridViewDG.Columns["DiaChi"].HeaderText = "Địa chỉ";
            DataGridViewDG.Columns["TrangThai"].HeaderText = "Trạng thái";
        }
        void LoadTrangThai()
        {
            ComBoBoxTT.DropDownStyle = ComboBoxStyle.DropDownList;
            ComBoBoxTT.Items.Clear();

            ComBoBoxTT.Items.Add("Hoạt động");
            ComBoBoxTT.Items.Add("Dừng hoạt động");

            ComBoBoxTT.SelectedIndex = 0; // BẮT BUỘC để thấy hiển thị
        }


        private void UserControlDocGia_Load(object sender, EventArgs e)
        {
            LoadTrangThai();   // 1️⃣ load trước (fix cứng)
            LoadGridViewDocGia();      // 2️⃣ load dữ liệu
        }



        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            DTO_DocGia dg = new DTO_DocGia
            {
                ID_DocGia = txtMaDG.Text,
                TenDG = txtTenDG.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                TrangThai = ComBoBoxTT.Text
            };

            dgBUS.Update(dg);
            LoadGridViewDocGia();

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComBoBoxTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridViewDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewDG.Rows.Count > 0)
            {
                txtMaDG.Text = DataGridViewDG.CurrentRow.Cells[0].Value.ToString();
                txtTenDG.Text = DataGridViewDG.CurrentRow.Cells[1].Value.ToString();
                txtSDT.Text = DataGridViewDG.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = DataGridViewDG.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = DataGridViewDG.CurrentRow.Cells[4].Value.ToString();
                ComBoBoxTT.Text = DataGridViewDG.CurrentRow.Cells[5].Value.ToString();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DTO_DocGia dg = new DTO_DocGia
            {
                ID_DocGia = txtMaDG.Text,
                TenDG = txtTenDG.Text,
                SDT = txtSDT.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                TrangThai = ComBoBoxTT.Text
            };

            dgBUS.Insert(dg);
            LoadGridViewDocGia();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DTO_DocGia dg = new DTO_DocGia
            {
                ID_DocGia = txtMaDG.Text
            };

            dgBUS.Delete(dg);
            LoadGridViewDocGia();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DTO_DocGia dg = new DTO_DocGia
            {
                TenDG = txtTimKiem.Text
            };

            DataGridViewDG.DataSource = dgBUS.Search(dg.TenDG);

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DocGia_BUS dgBUS = new DocGia_BUS();
            DataTable dt = dgBUS.Load(); // hoặc Load_Report()

            FormReportDG frm = new FormReportDG(dt);
            frm.ShowDialog(); // hoặc Show()
        }
    }
}

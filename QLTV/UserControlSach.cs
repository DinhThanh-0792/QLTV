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
using System.Diagnostics;

namespace QLTV
{
    public partial class UserControlSach : UserControl
    {

     // Tác Giả
        TacGia_BUS tgBUS = new TacGia_BUS();
        public UserControlSach()
        {
            InitializeComponent();
        }
        void LoadGridViewTacGia()
        {
            DataGridViewTG.DataSource = tgBUS.LoadTacGia();
            DataGridViewTG.Columns["ID_TG"].HeaderText = "Mã tác giả";
            DataGridViewTG.Columns["TenTG"].HeaderText = "Tên tác giả";
            DataGridViewTG.Columns["QuocGia"].HeaderText = "Quốc gia";
           
        }

        private void UserControlSach_Load(object sender, EventArgs e)
        {
            LoadGridViewTacGia();
            LoadGridViewNXB();
            LoadGridViewDM();
            LoadDanhMucCha();
            LoadDanhMuc();
            LoadTacGia();
            LoadNXB();
            LoadGridViewSach();
        }

        private void DataGridViewTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewTG.Rows.Count>0)
            {
                txtMaTG.Text = DataGridViewTG.CurrentRow.Cells[0].Value.ToString();
                txtTenTG.Text = DataGridViewTG.CurrentRow.Cells[1].Value.ToString();
                txtQue.Text = DataGridViewTG.CurrentRow.Cells[2].Value.ToString();

            }
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia
            {
                MaTG = txtMaTG.Text,
                TenTG = txtTenTG.Text,
                QuocGia = txtQue.Text
            };
            tgBUS.InsertTacGia(tg);
            LoadGridViewTacGia();
        }

        

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia
            {
                MaTG = txtMaTG.Text,
                TenTG = txtTenTG.Text,
                QuocGia = txtQue.Text
            };
            tgBUS.UpdateTacGia(tg);
            LoadGridViewTacGia();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia
            {
                MaTG = txtMaTG.Text,
            };
            tgBUS.DeleteTacGia(tg.MaTG);
            LoadGridViewTacGia();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia
            {
                TenTG = txtTimKiemTG.Text,
            };
            DataGridViewTG.DataSource = tgBUS.SearchTacGia(tg.TenTG);

        }

    //Nhà Xuất Bản
        NXB_BUS nxbBus = new NXB_BUS();
        void LoadGridViewNXB()
        {
            dtgvNXB.DataSource = nxbBus.Load();
            dtgvNXB.Columns["ID_NXB"].HeaderText = "Mã nhà xuất bản";
            dtgvNXB.Columns["TenNXB"].HeaderText = "Tên nhà xuất bản";
            dtgvNXB.Columns["DiaChi"].HeaderText = "Địa chỉ";
           
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            NXB_DTO nxb = new NXB_DTO
            {
                ID_NXB = txtID_NXB.Text,
                TenNXB = txtTenNXB.Text,
                DiaChi = txtDiaChi.Text
            };
                nxbBus.Insert(nxb);
                LoadGridViewNXB();
            
            
        }
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            NXB_DTO nxb = new NXB_DTO
            {
                ID_NXB = txtID_NXB.Text,
                TenNXB = txtTenNXB.Text,
                DiaChi = txtDiaChi.Text
            };
            nxbBus.Update(nxb);
            LoadGridViewNXB();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NXB_DTO nxb = new NXB_DTO
            {
                ID_NXB = txtID_NXB.Text,
           
            };
            nxbBus.Delete(nxb);
            LoadGridViewNXB();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NXB_DTO nxb = new NXB_DTO
            {
                TenNXB = txtTimKiemNXB.Text,

            };
            dtgvNXB.DataSource = nxbBus.SearchNXB(nxb);
        }

        private void dtgvNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvNXB.Rows.Count > 0)
            {
                txtID_NXB.Text = dtgvNXB.CurrentRow.Cells[0].Value.ToString();

                txtTenNXB.Text = dtgvNXB.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dtgvNXB.CurrentRow.Cells[2].Value.ToString();
                txtID_NXB.ReadOnly = true;

            }
        }

     //Thể loại
        TheLoai_BUS tlBus = new TheLoai_BUS();

        void LoadDanhMucCha()
        {
            cmbDanhMucCha.DataSource = tlBus.DanhMucCha();
            cmbDanhMucCha.DisplayMember = "TenDM";
            cmbDanhMucCha.ValueMember = "ID_DM";
            cmbDanhMucCha.SelectedIndex = -1;
        }

        void LoadGridViewDM()
        {
            dtgvDanhMuc.DataSource = tlBus.Load();

            if (dtgvDanhMuc.Columns.Count > 0)
            {
                dtgvDanhMuc.Columns["ID_DM"].HeaderText = "Mã thể loại";
                dtgvDanhMuc.Columns["TenDM"].HeaderText = "Tên thể loại";
            }

        }

        private void btnThemDM_Click(object sender, EventArgs e)
        {
            TheLoai_DTO tl = new TheLoai_DTO
            {
                ID_DM = txtMaDanhMuc.Text,
                TenDM = txtTenDanhMuc.Text,
                ID_DanhMucCha = cmbDanhMucCha.SelectedValue == null ? null : cmbDanhMucCha.SelectedValue.ToString()
            };

            tlBus.Insert(tl);
            LoadGridViewDM();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhatDM_Click(object sender, EventArgs e)
        {
            TheLoai_DTO tl = new TheLoai_DTO
            {
                ID_DM = txtMaDanhMuc.Text,
                TenDM = txtTenDanhMuc.Text,
                ID_DanhMucCha = cmbDanhMucCha.SelectedValue == null ? null : cmbDanhMucCha.SelectedValue.ToString()
            };

            tlBus.Update(tl);
            LoadGridViewDM();
        }

        private void dtgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhMuc.Rows.Count > 0)
            {
                txtMaDanhMuc.Text = dtgvDanhMuc.CurrentRow.Cells[0].Value.ToString();

                txtTenDanhMuc.Text = dtgvDanhMuc.CurrentRow.Cells[1].Value.ToString();
                cmbDanhMucCha.Text = cmbDanhMucCha.Text;
                txtID_NXB.ReadOnly = true;
            }
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            TheLoai_DTO tl = new TheLoai_DTO
            {
                ID_DM = txtMaDanhMuc.Text,
                
            };

            tlBus.Delete(tl);
            LoadGridViewDM();
        }
        private void btnTimKiemDM_Click(object sender, EventArgs e)
        {
            TheLoai_DTO tl = new TheLoai_DTO
            {
                TenDM = txtTimKiemDM.Text,

            };
            dtgvDanhMuc.DataSource = tlBus.SearchDM(tl);
        }

        //Sách
        Sach_BUS sachBus = new Sach_BUS();
        void LoadGridViewSach()
        {
            dtgvSach.DataSource = sachBus.Load();


            dtgvSach.Columns["ID_Sach"].HeaderText = "Mã sách";
            dtgvSach.Columns["TenSach"].HeaderText = "Tên sách";
            dtgvSach.Columns["TenTG"].HeaderText = "Tên tác giả";
            dtgvSach.Columns["SoLuong"].HeaderText = "Số lượng";

            dtgvSach.Columns["TenDM"].HeaderText = "Tên thể loại";
            dtgvSach.Columns["TenNXB"].HeaderText = "Nhà xuất bản";
            dtgvSach.Columns["NamXB"].HeaderText = "Năm xuất bản";
        

            //dtgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dtgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        void LoadDanhMuc()
        {
            comboBoxTheLoai.DataSource = sachBus.LoadDanhMuc();
            comboBoxTheLoai.DisplayMember = "TenDM";
            comboBoxTheLoai.ValueMember = "ID_DM";
            comboBoxTheLoai.SelectedIndex = -1;
        }

        void LoadTacGia()
        {
            comboBoxTG.DataSource = sachBus.LoadTacGia();
            comboBoxTG.DisplayMember = "TenTG";
            comboBoxTG.ValueMember = "ID_TG";
            comboBoxTG.SelectedIndex = -1;
        }

        void LoadNXB()
        {
            comboBoxNXB.DataSource = sachBus.LoadNXB();
            comboBoxNXB.DisplayMember = "TenNXB";
            comboBoxNXB.ValueMember = "ID_NXB";
            comboBoxNXB.SelectedIndex = -1;
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            Sach_DTO s = new Sach_DTO
            {
                ID_Sach = txtMaSach.Text,
                TenSach = txtTenSach.Text,
                SoLuong = int.Parse(txtSoLuong.Text),
                ID_TG = comboBoxTG.SelectedValue == null ? null : comboBoxTG.SelectedValue.ToString(),
                ID_NXB = comboBoxNXB.SelectedValue == null ? null : comboBoxNXB.SelectedValue.ToString(),
                ID_DM = comboBoxTheLoai.SelectedValue == null ? null : comboBoxTheLoai.SelectedValue.ToString(),
                NamXB = dtNamXBSach.Value
            };

            sachBus.Insert(s);
            LoadGridViewSach();
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            Sach_DTO s = new Sach_DTO
            {
                ID_Sach = txtMaSach.Text,
                
            };

            sachBus.Delete(s);
            LoadGridViewSach();
        }

        private void btnCapNhatSach_Click(object sender, EventArgs e)
        {
            Sach_DTO s = new Sach_DTO
            {
                ID_Sach = txtMaSach.Text,
                TenSach = txtTenSach.Text,
                SoLuong = int.Parse(txtSoLuong.Text),

                ID_TG = comboBoxTG.SelectedValue == null ? null : comboBoxTG.SelectedValue.ToString(),
                ID_NXB = comboBoxNXB.SelectedValue == null ? null : comboBoxNXB.SelectedValue.ToString(),
                ID_DM = comboBoxTheLoai.SelectedValue == null ? null : comboBoxTheLoai.SelectedValue.ToString(),
                NamXB = dtNamXBSach.Value
            };

            sachBus.Update(s);
            LoadGridViewSach();
        }

        private void btnTimKiemSach_Click(object sender, EventArgs e)
        {
            Sach_DTO s = new Sach_DTO
            {
                TenSach = txtTimKiemSach.Text,

            };
            dtgvSach.DataSource = sachBus.Search(s);
        }

        private void dtgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvSach.Rows.Count > 0)
            {
                txtMaDanhMuc.Text = dtgvSach.CurrentRow.Cells[0].Value.ToString();
                txtTenSach.Text = dtgvSach.CurrentRow.Cells[1].Value.ToString();
                txtSoLuong.Text = dtgvSach.CurrentRow.Cells[2].Value.ToString();
                comboBoxNXB.Text = comboBoxNXB.Text;
                comboBoxTG.Text = comboBoxTG.Text;
                comboBoxTheLoai.Text = comboBoxTheLoai.Text;
                dtNamXBSach.Value = dtNamXBSach.Value;
                txtMaSach.ReadOnly = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormReportFormSach frm = new FormReportFormSach();
            frm.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FormReportFormSach frm = new FormReportFormSach();
            frm.Show();
        }

        private void btnThongKeTL_Click(object sender, EventArgs e)
        {
            FormReportFormSach frm = new FormReportFormSach();
            frm.Show();
        }

        private void btnThongKeNXB_Click(object sender, EventArgs e)
        {
            FormReportFormSach frm = new FormReportFormSach();
            frm.Show();
        }
    }
}

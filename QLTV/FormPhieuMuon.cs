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
    public partial class FormPhieuMuon : Form
    {
        public FormPhieuMuon()
        {
            InitializeComponent();
        }
        Phieu_BUS phieuBUS = new Phieu_BUS();
        List<CTPhieu> dsChiTiet = new List<CTPhieu>();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormThemSach formThemSach = new FormThemSach();
            if (formThemSach.ShowDialog() == DialogResult.OK)
            {
                CTPhieu ct = formThemSach.SachDuocChon;
                dsChiTiet.Add(ct);
                dataGridViewSach.DataSource = null;
                dataGridViewSach.DataSource = dsChiTiet;
            }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dsChiTiet.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sách vào phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //MessageBox.Show("ID_NV = " + comboBoxNV.SelectedValue);
            Phieu p = new Phieu()
            {
                LoaiPhieu = "MUON",
                ID_DG = comboBoxDG.SelectedValue.ToString(),
                ID_NV = comboBoxNV.SelectedValue.ToString(),
                NgayMuon = dateTimePickerNgayMuon.Value,
                NgayPhaiTra = dateTimePickerNgayPhaiTra.Value,
                GhiChu = txtGhiChu.Text
            };


            phieuBUS.LapPhieuMuon(p, dsChiTiet);
            MessageBox.Show("Lập phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormPhieuMuon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUAN_LY_THU_VIENDataSet1.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.qUAN_LY_THU_VIENDataSet1.NHANVIEN);
            // TODO: This line of code loads data into the 'qUAN_LY_THU_VIENDataSet.DOCGIA' table. You can move, or remove it, as needed.
            this.dOCGIATableAdapter.Fill(this.qUAN_LY_THU_VIENDataSet.DOCGIA);

        }

        //private void guna2Button2_Click(object sender, EventArgs e)
        //{

        //}
    }
}

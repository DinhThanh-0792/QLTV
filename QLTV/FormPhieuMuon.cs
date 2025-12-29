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
    }
}

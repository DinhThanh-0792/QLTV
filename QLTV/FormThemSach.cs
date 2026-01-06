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
    public partial class FormThemSach : Form
    {
        public CTPhieu SachDuocChon { get; set; }
        Sach_BUS sachBUS = new Sach_BUS();
        public FormThemSach()
        {
            InitializeComponent();
        }

        private void btnChonSach_Click(object sender, EventArgs e)
        {
            if(dataGridViewSachMuon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sách.");
                return;
            }
            SachDuocChon = new CTPhieu()
            {
                ID_Sach = dataGridViewSachMuon.CurrentRow.Cells["ID_Sach"].Value.ToString(),
                SoLuong = (int)numericUpDownSLSach.Value,
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormThemSach_Load(object sender, EventArgs e)
        {
            dataGridViewSachMuon.DataSource = sachBUS.Load();
        }
    }
}

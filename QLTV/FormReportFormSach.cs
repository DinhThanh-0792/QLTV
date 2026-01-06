using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class FormReportFormSach: Form
    {
        public FormReportFormSach()
        {
            InitializeComponent();
        }

        private void LoadControl(UserControl uc)
        {
            panelReportSach.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelReportSach.Controls.Add(uc);
        }
        private void FormReportSach_Load(object sender, EventArgs e)
        {

            //this.reportViewerSach.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }

        private void reportViewerSach_Load(object sender, EventArgs e)
        {

        }

        private void sachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sach_BUS sachBUS = new Sach_BUS();
           
           
            // Gọi BUS lấy dữ liệu
            DataTable dt = sachBUS.Load_Report();

            // Load UserControlReportSach vào panel
            LoadControl(new UserControlReportSach(dt));
        }

        private void panelReportSach_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia_BUS tacgiaBUS = new TacGia_BUS();


            // Gọi BUS lấy dữ liệu
            DataTable dt = tacgiaBUS.LoadTacGia();

            // Load UserControlReportSach vào panel
            LoadControl(new UserControlReportTG(dt));
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NXB_BUS nxbBUS = new NXB_BUS();
            DataTable dt = nxbBUS.Load();
            LoadControl(new UserControlReportNXB(dt));
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheLoai_BUS tlBUS = new TheLoai_BUS();
            DataTable dt = tlBUS.Load();
            LoadControl(new UserControlReportTL(dt));
        }
    }
}

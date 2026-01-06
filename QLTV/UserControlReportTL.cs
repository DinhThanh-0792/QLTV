using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLTV
{
    public partial class UserControlReportTL : UserControl
    {
        private DataTable _dataTable;

        // Constructor nhận dữ liệu từ ngoài vào
        public UserControlReportTL(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt ?? new DataTable(); // đảm bảo không null
        }

        private void UserControlReportTL_Load(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (_dataTable == null || _dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị báo cáo!");
                return;
            }

            // Xóa datasource cũ
            reportViewerTL.LocalReport.DataSources.Clear();

            // Gán file RDLC
            string rdlcPath = System.IO.Path.Combine(
                Application.StartupPath, "Report_TL.rdlc"); // tên file rdlc của thể loại

            if (!System.IO.File.Exists(rdlcPath))
            {
                MessageBox.Show("Không tìm thấy file ReportTL.rdlc");
                return;
            }

            reportViewerTL.LocalReport.ReportPath = rdlcPath;

            // Dock ReportViewer full UserControl
            reportViewerTL.Dock = DockStyle.Fill;

            // Gán datasource
            ReportDataSource rds = new ReportDataSource("DataSetTL", _dataTable);
            reportViewerTL.LocalReport.DataSources.Add(rds);

            // Refresh
            reportViewerTL.RefreshReport();
        }
    }
}

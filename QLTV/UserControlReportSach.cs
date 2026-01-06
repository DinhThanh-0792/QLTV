using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLTV
{
    public partial class UserControlReportSach : UserControl
    {
        // DataTable dùng cho report
        private DataTable _dataTable;

        // Constructor nhận dữ liệu từ ngoài vào
        public UserControlReportSach(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt;
        }

        private void UserControlReportSach_Load(object sender, EventArgs e)
        {
            // Xóa datasource cũ
            reportViewerSach.LocalReport.DataSources.Clear();

            // Gán file RDLC
            reportViewerSach.LocalReport.ReportPath =
                System.Windows.Forms.Application.StartupPath + @"\report_Sach.rdlc";

            reportViewerSach.Dock = DockStyle.Fill;

            // Gán datasource
            ReportDataSource rds = new ReportDataSource(
                "DataSetSach", _dataTable);

            reportViewerSach.LocalReport.DataSources.Add(rds);

            // Refresh report
            reportViewerSach.RefreshReport();
        }

        private void reportViewerSach_Load(object sender, EventArgs e)
        {

        }
    }
}

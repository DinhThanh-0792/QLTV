using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLTV
{
    public partial class UserControlReportNXB : UserControl
    {
        private DataTable _dataTable;

        public UserControlReportNXB(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt; // tránh null
        }

        private void UserControlReportNXB_Load(object sender, EventArgs e)
        {
            // Xóa datasource cũ
            reportViewerNXB.LocalReport.DataSources.Clear();

            // Gán file RDLC
            reportViewerNXB.LocalReport.ReportPath =
                System.Windows.Forms.Application.StartupPath + @"\Report_NXB.rdlc";

            reportViewerNXB.Dock = DockStyle.Fill;

            // Gán datasource
            ReportDataSource rds = new ReportDataSource(
                "DataSetNXB", _dataTable);

            reportViewerNXB.LocalReport.DataSources.Add(rds);

            // Refresh report
            reportViewerNXB.RefreshReport();
        }

        private void reportViewerNXB_Load(object sender, EventArgs e)
        {

        }
    }
}

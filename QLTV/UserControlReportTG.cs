using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLTV
{
    public partial class UserControlReportTG : UserControl
    {
        private DataTable _dataTable; // dữ liệu report

        // Constructor nhận DataTable từ Form
        public UserControlReportTG(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt;
        }

        private void UserControlReportTG_Load(object sender, EventArgs e)
        {
            // Xóa datasource cũ
            reportViewerTG.LocalReport.DataSources.Clear();

            // Gán đường dẫn file RDLC
            reportViewerTG.LocalReport.ReportPath =
                System.Windows.Forms.Application.StartupPath + @"\Report_TG.rdlc";

            // Dock full
            reportViewerTG.Dock = DockStyle.Fill;

            // Gán datasource (Dataset name trong RDLC phải trùng)
            ReportDataSource rds = new ReportDataSource("DataSetTG", _dataTable);

            reportViewerTG.LocalReport.DataSources.Add(rds);

            // Refresh report
            reportViewerTG.RefreshReport();
        }
    }
}

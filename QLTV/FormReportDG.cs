using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QLTV
{
    public partial class FormReportDG: Form
    {
        private DataTable _dataTable;
        // Constructor nhận DataTable từ ngoài
        // CHỈ GIỮ 1 constructor
        public FormReportDG(DataTable dt)
        {
            InitializeComponent();
            _dataTable = dt;
        }

        private void FormReportDG_Load(object sender, EventArgs e)
        {

            // Xóa datasource cũ
            reportViewerDG.LocalReport.DataSources.Clear();

            // Gán file RDLC
            reportViewerDG.LocalReport.ReportPath =
                System.Windows.Forms.Application.StartupPath + @"\Report_DG.rdlc";

            reportViewerDG.Dock = DockStyle.Fill;

            // Gán datasource
            ReportDataSource rds = new ReportDataSource(
                "DataSetDG", _dataTable);

            reportViewerDG.LocalReport.DataSources.Add(rds);

            // Refresh report
            reportViewerDG.RefreshReport();
        }
    }
}

namespace QLTV
{
    partial class UserControlReportSach
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerSach = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerSach
            // 
            this.reportViewerSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerSach.Location = new System.Drawing.Point(0, 0);
            this.reportViewerSach.Name = "reportViewerSach";
            this.reportViewerSach.ServerReport.BearerToken = null;
            this.reportViewerSach.Size = new System.Drawing.Size(1263, 542);
            this.reportViewerSach.TabIndex = 0;
            this.reportViewerSach.Load += new System.EventHandler(this.reportViewerSach_Load);
            // 
            // UserControlReportSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewerSach);
            this.Name = "UserControlReportSach";
            this.Size = new System.Drawing.Size(1263, 542);
            this.Load += new System.EventHandler(this.UserControlReportSach_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerSach;
    }
}

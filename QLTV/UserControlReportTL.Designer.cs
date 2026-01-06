namespace QLTV
{
    partial class UserControlReportTL
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
            this.reportViewerTL = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerTL
            // 
            this.reportViewerTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerTL.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTL.Name = "reportViewerTL";
            this.reportViewerTL.ServerReport.BearerToken = null;
            this.reportViewerTL.Size = new System.Drawing.Size(1263, 542);
            this.reportViewerTL.TabIndex = 0;
            // 
            // UserControlReportTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewerTL);
            this.Name = "UserControlReportTL";
            this.Size = new System.Drawing.Size(1263, 542);
            this.Load += new System.EventHandler(this.UserControlReportTL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTL;
    }
}

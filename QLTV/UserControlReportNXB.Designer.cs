namespace QLTV
{
    partial class UserControlReportNXB
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
            this.reportViewerNXB = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerNXB
            // 
            this.reportViewerNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerNXB.Location = new System.Drawing.Point(0, 0);
            this.reportViewerNXB.Name = "reportViewerNXB";
            this.reportViewerNXB.ServerReport.BearerToken = null;
            this.reportViewerNXB.Size = new System.Drawing.Size(1263, 542);
            this.reportViewerNXB.TabIndex = 0;
            this.reportViewerNXB.Load += new System.EventHandler(this.reportViewerNXB_Load);
            // 
            // UserControlReportNXB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewerNXB);
            this.Name = "UserControlReportNXB";
            this.Size = new System.Drawing.Size(1263, 542);
            this.Load += new System.EventHandler(this.UserControlReportNXB_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerNXB;
    }
}

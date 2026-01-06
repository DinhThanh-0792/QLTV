namespace QLTV
{
    partial class UserControlReportTG
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
            this.reportViewerTG = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerTG
            // 
            this.reportViewerTG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerTG.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTG.Name = "reportViewerTG";
            this.reportViewerTG.ServerReport.BearerToken = null;
            this.reportViewerTG.Size = new System.Drawing.Size(1263, 542);
            this.reportViewerTG.TabIndex = 0;
            // 
            // UserControlReportTG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewerTG);
            this.Name = "UserControlReportTG";
            this.Size = new System.Drawing.Size(1263, 542);
            this.Load += new System.EventHandler(this.UserControlReportTG_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTG;
    }
}

namespace QLTV
{
    partial class FormReportDG
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportViewerDG = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerDG
            // 
            this.reportViewerDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerDG.Location = new System.Drawing.Point(0, 0);
            this.reportViewerDG.Name = "reportViewerDG";
            this.reportViewerDG.ServerReport.BearerToken = null;
            this.reportViewerDG.Size = new System.Drawing.Size(800, 450);
            this.reportViewerDG.TabIndex = 0;
            // 
            // FormReportDG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerDG);
            this.Name = "FormReportDG";
            this.Text = "FormReportDG";
            this.Load += new System.EventHandler(this.FormReportDG_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDG;
    }
}
namespace eMAS.Forms.Reports
{
    partial class SSNITPaymentVoucherFormatForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SSNITPaymentVoucherFormatReport1 = new eMAS.Forms.Reports.SSNITPaymentVoucherFormatReport();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.SSNITPaymentVoucherFormatReport1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(284, 261);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(238, 28);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(10, 23);
            this.btnExportReport.TabIndex = 9;
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.UseWaitCursor = true;
            this.btnExportReport.Visible = false;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Location = new System.Drawing.Point(246, 28);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(11, 23);
            this.btnPrintReport.TabIndex = 8;
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.UseWaitCursor = true;
            this.btnPrintReport.Visible = false;
            // 
            // SSNITPaymentVoucherFormatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "SSNITPaymentVoucherFormatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSNITPaymentVoucherFormatForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SSNITPaymentVoucherFormatForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private SSNITPaymentVoucherFormatReport SSNITPaymentVoucherFormatReport1;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Button btnPrintReport;
    }
}
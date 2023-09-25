namespace eMAS.Forms.Reports
{
    partial class TrainingBondReportForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.crvExcuseDutyReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.crvExcuseDutyReport);
            this.panel1.Location = new System.Drawing.Point(0, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 387);
            this.panel1.TabIndex = 0;
            // 
            // crvExcuseDutyReport
            // 
            this.crvExcuseDutyReport.ActiveViewIndex = -1;
            this.crvExcuseDutyReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvExcuseDutyReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvExcuseDutyReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvExcuseDutyReport.Location = new System.Drawing.Point(0, 0);
            this.crvExcuseDutyReport.Name = "crvExcuseDutyReport";
            this.crvExcuseDutyReport.Size = new System.Drawing.Size(861, 383);
            this.crvExcuseDutyReport.TabIndex = 1;
            this.crvExcuseDutyReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(770, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ExternalTrainingReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 445);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "ExternalTrainingReportForm";
            this.Text = "Training Bond Report";
            this.Load += new System.EventHandler(this.ExcuseDutyReport_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvExcuseDutyReport;
        private System.Windows.Forms.Button btnClose;
    }
}
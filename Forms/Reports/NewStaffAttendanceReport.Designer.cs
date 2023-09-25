namespace eMAS.Forms.Reports
{
    partial class NewStaffAttendanceReport
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
            this.crvStaffAttendanceReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 41);
            this.panel1.TabIndex = 0;
            // 
            // crvStaffAttendanceReport
            // 
            this.crvStaffAttendanceReport.ActiveViewIndex = -1;
            this.crvStaffAttendanceReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvStaffAttendanceReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvStaffAttendanceReport.DisplayStatusBar = false;
            this.crvStaffAttendanceReport.DisplayToolbar = false;
            this.crvStaffAttendanceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvStaffAttendanceReport.Location = new System.Drawing.Point(0, 0);
            this.crvStaffAttendanceReport.Name = "crvStaffAttendanceReport";
            this.crvStaffAttendanceReport.Size = new System.Drawing.Size(828, 350);
            this.crvStaffAttendanceReport.TabIndex = 1;
            this.crvStaffAttendanceReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(742, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // NewStaffAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 391);
            this.Controls.Add(this.crvStaffAttendanceReport);
            this.Controls.Add(this.panel1);
            this.Name = "NewStaffAttendanceReport";
            this.Text = "Staff Attendance Report";
            //this.Load += new System.EventHandler(this.NewStaffAttendanceReport_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvStaffAttendanceReport;
    }
}
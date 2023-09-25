namespace eMAS.Forms.Reports
{
    partial class PreviewExcusedDutyForm
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
            this.closebtn = new System.Windows.Forms.Button();
            this.crvPreviewExcusedDuty = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Location = new System.Drawing.Point(0, 506);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 43);
            this.panel1.TabIndex = 40;
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.Location = new System.Drawing.Point(854, 9);
            this.closebtn.Margin = new System.Windows.Forms.Padding(4);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(89, 28);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // crvPreviewExcusedDuty
            // 
            this.crvPreviewExcusedDuty.ActiveViewIndex = -1;
            this.crvPreviewExcusedDuty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crvPreviewExcusedDuty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPreviewExcusedDuty.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvPreviewExcusedDuty.Location = new System.Drawing.Point(0, 0);
            this.crvPreviewExcusedDuty.Name = "crvPreviewExcusedDuty";
            this.crvPreviewExcusedDuty.Size = new System.Drawing.Size(944, 499);
            this.crvPreviewExcusedDuty.TabIndex = 41;
            // 
            // PreviewExcusedDutyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 552);
            this.Controls.Add(this.crvPreviewExcusedDuty);
            this.Controls.Add(this.panel1);
            this.Name = "PreviewExcusedDutyForm";
            this.Text = "PreviewExcusedDutyForm";
            this.Load += new System.EventHandler(this.PreviewExcusedDutyForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closebtn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPreviewExcusedDuty;
    }
}
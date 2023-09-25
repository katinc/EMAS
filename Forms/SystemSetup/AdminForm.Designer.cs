namespace eMAS.Forms.SystemSetup
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDatasets = new System.Windows.Forms.Button();
            this.cboFacility = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Facility";
            // 
            // btnDatasets
            // 
            this.btnDatasets.Location = new System.Drawing.Point(203, 13);
            this.btnDatasets.Name = "btnDatasets";
            this.btnDatasets.Size = new System.Drawing.Size(75, 23);
            this.btnDatasets.TabIndex = 2;
            this.btnDatasets.Text = "Datasets";
            this.btnDatasets.UseVisualStyleBackColor = true;
            this.btnDatasets.Click += new System.EventHandler(this.btnDatasets_Click);
            // 
            // cboFacility
            // 
            this.cboFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacility.FormattingEnabled = true;
            this.cboFacility.Location = new System.Drawing.Point(57, 13);
            this.cboFacility.Name = "cboFacility";
            this.cboFacility.Size = new System.Drawing.Size(131, 21);
            this.cboFacility.TabIndex = 38;
            this.cboFacility.DropDown += new System.EventHandler(this.cboFacility_DropDown);
            this.cboFacility.SelectionChangeCommitted += new System.EventHandler(this.cboFacility_SelectionChangeCommitted);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(345, 157);
            this.Controls.Add(this.cboFacility);
            this.Controls.Add(this.btnDatasets);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "Developer";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDatasets;
        private System.Windows.Forms.ComboBox cboFacility;
    }
}
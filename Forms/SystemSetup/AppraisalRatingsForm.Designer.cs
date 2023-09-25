namespace eMAS.Forms.SystemSetup
{
    partial class AppraisalRatingsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAvgMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAvgMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOveralMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOveralMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 30);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(208, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Indicate -1 For Value(s) that are not applicable";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appraisal Ratings Form";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(1, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 27);
            this.panel2.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(587, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(497, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridID,
            this.gridRating,
            this.gridValue,
            this.gridAvgMin,
            this.gridAvgMax,
            this.gridOveralMin,
            this.gridOveralMax});
            this.grid.Location = new System.Drawing.Point(2, 35);
            this.grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(668, 321);
            this.grid.TabIndex = 10;
            // 
            // gridID
            // 
            this.gridID.HeaderText = "ID";
            this.gridID.Name = "gridID";
            this.gridID.Visible = false;
            // 
            // gridRating
            // 
            this.gridRating.HeaderText = "Rating";
            this.gridRating.Name = "gridRating";
            this.gridRating.Width = 200;
            // 
            // gridValue
            // 
            this.gridValue.HeaderText = "Value";
            this.gridValue.Name = "gridValue";
            // 
            // gridAvgMin
            // 
            this.gridAvgMin.HeaderText = "Average Min";
            this.gridAvgMin.Name = "gridAvgMin";
            this.gridAvgMin.Width = 120;
            // 
            // gridAvgMax
            // 
            this.gridAvgMax.HeaderText = "Average Max";
            this.gridAvgMax.Name = "gridAvgMax";
            this.gridAvgMax.Width = 120;
            // 
            // gridOveralMin
            // 
            this.gridOveralMin.HeaderText = "Overal Average Min.";
            this.gridOveralMin.Name = "gridOveralMin";
            this.gridOveralMin.Width = 170;
            // 
            // gridOveralMax
            // 
            this.gridOveralMax.HeaderText = "Overal Average Max";
            this.gridOveralMax.Name = "gridOveralMax";
            this.gridOveralMax.Width = 170;
            // 
            // AppraisalRatingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 386);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "AppraisalRatingsForm";
            this.Text = "Appraisal Ratings Form";
            this.Load += new System.EventHandler(this.AppraisalRatingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAvgMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAvgMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridOveralMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridOveralMax;
    }
}
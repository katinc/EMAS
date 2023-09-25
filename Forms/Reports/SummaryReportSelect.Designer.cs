
namespace eMAS.Forms.Reports
{
    partial class SummaryReportSelect
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
            this.components = new System.ComponentModel.Container();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbDoughnut = new System.Windows.Forms.CheckBox();
            this.cbBarChart = new System.Windows.Forms.CheckBox();
            this.btnChartSetup = new System.Windows.Forms.Button();
            this.cbPieChart = new System.Windows.Forms.CheckBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblGradeCategory = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.cboSummary = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.clb = new System.Windows.Forms.CheckedListBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(9, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Charts Report Criteria";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(171, 290);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 24);
            this.btnOK.TabIndex = 27;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(232, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lavender;
            this.panel2.Controls.Add(this.clb);
            this.panel2.Controls.Add(this.cbDoughnut);
            this.panel2.Controls.Add(this.cbBarChart);
            this.panel2.Controls.Add(this.btnChartSetup);
            this.panel2.Controls.Add(this.cbPieChart);
            this.panel2.Controls.Add(this.lblDepartment);
            this.panel2.Controls.Add(this.lblGradeCategory);
            this.panel2.Controls.Add(this.cboDepartment);
            this.panel2.Controls.Add(this.cboSummary);
            this.panel2.Location = new System.Drawing.Point(12, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 253);
            this.panel2.TabIndex = 24;
            // 
            // cbDoughnut
            // 
            this.cbDoughnut.AutoSize = true;
            this.cbDoughnut.Location = new System.Drawing.Point(262, 219);
            this.cbDoughnut.Name = "cbDoughnut";
            this.cbDoughnut.Size = new System.Drawing.Size(73, 17);
            this.cbDoughnut.TabIndex = 16;
            this.cbDoughnut.Text = "Doughnut";
            this.cbDoughnut.UseVisualStyleBackColor = true;
            this.cbDoughnut.Visible = false;
            // 
            // cbBarChart
            // 
            this.cbBarChart.AutoSize = true;
            this.cbBarChart.Location = new System.Drawing.Point(186, 219);
            this.cbBarChart.Name = "cbBarChart";
            this.cbBarChart.Size = new System.Drawing.Size(70, 17);
            this.cbBarChart.TabIndex = 16;
            this.cbBarChart.Text = "Bar Chart";
            this.cbBarChart.UseVisualStyleBackColor = true;
            this.cbBarChart.Visible = false;
            // 
            // btnChartSetup
            // 
            this.btnChartSetup.Location = new System.Drawing.Point(341, 55);
            this.btnChartSetup.Name = "btnChartSetup";
            this.btnChartSetup.Size = new System.Drawing.Size(32, 24);
            this.btnChartSetup.TabIndex = 27;
            this.btnChartSetup.Text = "...";
            this.btnChartSetup.UseVisualStyleBackColor = true;
            this.btnChartSetup.Click += new System.EventHandler(this.btnChartSetup_Click);
            // 
            // cbPieChart
            // 
            this.cbPieChart.AutoSize = true;
            this.cbPieChart.Location = new System.Drawing.Point(111, 219);
            this.cbPieChart.Name = "cbPieChart";
            this.cbPieChart.Size = new System.Drawing.Size(69, 17);
            this.cbPieChart.TabIndex = 16;
            this.cbPieChart.Text = "Pie Chart";
            this.cbPieChart.UseVisualStyleBackColor = true;
            this.cbPieChart.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(3, 85);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(87, 13);
            this.lblDepartment.TabIndex = 15;
            this.lblDepartment.Text = "Grade Category :";
            this.lblDepartment.Visible = false;
            // 
            // lblGradeCategory
            // 
            this.lblGradeCategory.AutoSize = true;
            this.lblGradeCategory.Location = new System.Drawing.Point(44, 58);
            this.lblGradeCategory.Name = "lblGradeCategory";
            this.lblGradeCategory.Size = new System.Drawing.Size(43, 13);
            this.lblGradeCategory.TabIndex = 15;
            this.lblGradeCategory.Text = "Charts :";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(93, 82);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(242, 21);
            this.cboDepartment.TabIndex = 14;
            this.cboDepartment.Visible = false;
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // cboSummary
            // 
            this.cboSummary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSummary.FormattingEnabled = true;
            this.cboSummary.Location = new System.Drawing.Point(93, 55);
            this.cboSummary.Name = "cboSummary";
            this.cboSummary.Size = new System.Drawing.Size(242, 21);
            this.cboSummary.TabIndex = 14;
            this.cboSummary.SelectionChangeCommitted += new System.EventHandler(this.cboSummary_SelectionChangeCommitted);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // clb
            // 
            this.clb.FormattingEnabled = true;
            this.clb.Items.AddRange(new object[] {
            "Pie Chart",
            "Bar Chart",
            "Doughnut"});
            this.clb.Location = new System.Drawing.Point(93, 110);
            this.clb.Name = "clb";
            this.clb.Size = new System.Drawing.Size(242, 94);
            this.clb.TabIndex = 28;
            // 
            // SummaryReportSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(470, 326);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Name = "SummaryReportSelect";
            this.Text = "SummaryReportSelect";
            this.Load += new System.EventHandler(this.SummaryReportSelect_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGradeCategory;
        private System.Windows.Forms.ComboBox cboSummary;
        private System.Windows.Forms.CheckBox cbDoughnut;
        private System.Windows.Forms.CheckBox cbBarChart;
        private System.Windows.Forms.CheckBox cbPieChart;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnChartSetup;
        private System.Windows.Forms.CheckedListBox clb;
    }
}
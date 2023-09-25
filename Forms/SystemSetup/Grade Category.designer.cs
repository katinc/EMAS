namespace eMAS.All_UIs.System_SetupFORMS
{
    partial class Grade_Category
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
            this.label1 = new System.Windows.Forms.Label();
            this.descriptiontxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codetxt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewbtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.codeErorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOvertime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLeaveEncashment = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeErorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(72, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description:";
            // 
            // descriptiontxt
            // 
            this.descriptiontxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptiontxt.Location = new System.Drawing.Point(141, 50);
            this.descriptiontxt.Name = "descriptiontxt";
            this.descriptiontxt.Size = new System.Drawing.Size(203, 20);
            this.descriptiontxt.TabIndex = 2;
            this.descriptiontxt.TextChanged += new System.EventHandler(this.descriptiontxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(100, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code:";
            // 
            // codetxt
            // 
            this.codetxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codetxt.CausesValidation = false;
            this.codetxt.Location = new System.Drawing.Point(141, 78);
            this.codetxt.Name = "codetxt";
            this.codetxt.Size = new System.Drawing.Size(203, 20);
            this.codetxt.TabIndex = 2;
            this.codetxt.TextChanged += new System.EventHandler(this.codetxt_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.viewbtn);
            this.panel2.Controls.Add(this.closebtn);
            this.panel2.Controls.Add(this.clearbtn);
            this.panel2.Controls.Add(this.savebtn);
            this.panel2.ForeColor = System.Drawing.Color.SlateGray;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 40);
            this.panel2.TabIndex = 19;
            // 
            // viewbtn
            // 
            this.viewbtn.BackColor = System.Drawing.Color.Snow;
            this.viewbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.viewbtn.Location = new System.Drawing.Point(222, 7);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(59, 23);
            this.viewbtn.TabIndex = 1;
            this.viewbtn.Text = "View";
            this.viewbtn.UseVisualStyleBackColor = false;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.BackColor = System.Drawing.Color.Snow;
            this.closebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.closebtn.Location = new System.Drawing.Point(287, 7);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(59, 23);
            this.closebtn.TabIndex = 1;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.BackColor = System.Drawing.Color.Snow;
            this.clearbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearbtn.Location = new System.Drawing.Point(157, 7);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(59, 23);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.BackColor = System.Drawing.Color.Snow;
            this.savebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.savebtn.Location = new System.Drawing.Point(92, 7);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(59, 23);
            this.savebtn.TabIndex = 1;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = false;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.ForeColor = System.Drawing.Color.SlateGray;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 34);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Grade Category";
            // 
            // descriptionErrorProvider
            // 
            this.descriptionErrorProvider.ContainerControl = this;
            // 
            // codeErorProvider
            // 
            this.codeErorProvider.ContainerControl = this;
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Location = new System.Drawing.Point(141, 156);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(56, 17);
            this.checkBoxActive.TabIndex = 20;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(57, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Overtime Rate:";
            // 
            // txtOvertime
            // 
            this.txtOvertime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOvertime.CausesValidation = false;
            this.txtOvertime.Location = new System.Drawing.Point(141, 104);
            this.txtOvertime.Name = "txtOvertime";
            this.txtOvertime.Size = new System.Drawing.Size(76, 20);
            this.txtOvertime.TabIndex = 2;
            this.txtOvertime.TextChanged += new System.EventHandler(this.codetxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(11, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Leave Encashment Rate:";
            // 
            // txtLeaveEncashment
            // 
            this.txtLeaveEncashment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeaveEncashment.CausesValidation = false;
            this.txtLeaveEncashment.Location = new System.Drawing.Point(141, 130);
            this.txtLeaveEncashment.Name = "txtLeaveEncashment";
            this.txtLeaveEncashment.Size = new System.Drawing.Size(76, 20);
            this.txtLeaveEncashment.TabIndex = 2;
            this.txtLeaveEncashment.TextChanged += new System.EventHandler(this.codetxt_TextChanged);
            // 
            // Grade_Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(388, 233);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtLeaveEncashment);
            this.Controls.Add(this.txtOvertime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.codetxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descriptiontxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Grade_Category";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grade_Category";
            this.Load += new System.EventHandler(this.Grade_Category_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeErorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptiontxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codetxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
        private System.Windows.Forms.ErrorProvider codeErorProvider;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.TextBox txtLeaveEncashment;
        private System.Windows.Forms.TextBox txtOvertime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
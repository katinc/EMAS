namespace eMAS.All_UIs.Staff_Information_FORMS
{
    partial class frmCameraCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUseImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picCropped = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picDisplay);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // picDisplay
            // 
            this.picDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDisplay.Location = new System.Drawing.Point(3, 16);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(269, 206);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(94, 251);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(103, 37);
            this.btnCapture.TabIndex = 2;
            this.btnCapture.Text = "&Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picCapture);
            this.groupBox3.Location = new System.Drawing.Point(324, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 230);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Draw a rectangular area around image to crop";
            // 
            // picCapture
            // 
            this.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCapture.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCapture.Location = new System.Drawing.Point(6, 19);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(241, 197);
            this.picCapture.TabIndex = 1;
            this.picCapture.TabStop = false;
            this.picCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCapture_MouseMove);
            this.picCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCapture_MouseDown);
            this.picCapture.Paint += new System.Windows.Forms.PaintEventHandler(this.picCapture_Paint);
            this.picCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCapture_MouseUp);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUseImage);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.picCropped);
            this.groupBox4.Location = new System.Drawing.Point(617, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(205, 267);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cropped Picture";
            // 
            // btnUseImage
            // 
            this.btnUseImage.Location = new System.Drawing.Point(105, 219);
            this.btnUseImage.Name = "btnUseImage";
            this.btnUseImage.Size = new System.Drawing.Size(88, 31);
            this.btnUseImage.TabIndex = 4;
            this.btnUseImage.Text = "Use Image";
            this.btnUseImage.UseVisualStyleBackColor = true;
            this.btnUseImage.Click += new System.EventHandler(this.btnUseImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 31);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picCropped
            // 
            this.picCropped.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCropped.Location = new System.Drawing.Point(16, 19);
            this.picCropped.Name = "picCropped";
            this.picCropped.Size = new System.Drawing.Size(181, 181);
            this.picCropped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCropped.TabIndex = 3;
            this.picCropped.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "==>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(586, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "==>";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "jpg";
            this.saveFileDialog1.Filter = "JPEG |*.jpg |BITMAP | *.bmp";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // frmCameraCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(836, 298);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCameraCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Capture";
            this.Load += new System.EventHandler(this.frmCameraCapture_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCameraCapture_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picCropped;
        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnUseImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

namespace FiberView
{
    partial class Form1
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
            this.Next = new System.Windows.Forms.Button();
            this.schedule = new System.Windows.Forms.DataGridView();
            this.camera = new System.Windows.Forms.PictureBox();
            this.lblDecodedInfo = new System.Windows.Forms.Label();
            this.scan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera)).BeginInit();
            this.SuspendLayout();
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(64, 282);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(101, 48);
            this.Next.TabIndex = 1;
            this.Next.Text = "View";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // schedule
            // 
            this.schedule.AllowUserToAddRows = false;
            this.schedule.AllowUserToDeleteRows = false;
            this.schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schedule.Location = new System.Drawing.Point(405, 314);
            this.schedule.Name = "schedule";
            this.schedule.ReadOnly = true;
            this.schedule.RowHeadersWidth = 51;
            this.schedule.RowTemplate.Height = 24;
            this.schedule.Size = new System.Drawing.Size(593, 236);
            this.schedule.TabIndex = 2;
            // 
            // camera
            // 
            this.camera.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.camera.Location = new System.Drawing.Point(482, 27);
            this.camera.Name = "camera";
            this.camera.Size = new System.Drawing.Size(461, 261);
            this.camera.TabIndex = 3;
            this.camera.TabStop = false;
            // 
            // lblDecodedInfo
            // 
            this.lblDecodedInfo.AutoSize = true;
            this.lblDecodedInfo.Location = new System.Drawing.Point(309, 60);
            this.lblDecodedInfo.Name = "lblDecodedInfo";
            this.lblDecodedInfo.Size = new System.Drawing.Size(0, 17);
            this.lblDecodedInfo.TabIndex = 4;
            // 
            // scan
            // 
            this.scan.Location = new System.Drawing.Point(211, 282);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(106, 48);
            this.scan.TabIndex = 5;
            this.scan.Text = "Scan QR";
            this.scan.UseVisualStyleBackColor = true;
            this.scan.Click += new System.EventHandler(this.scan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 584);
            this.Controls.Add(this.scan);
            this.Controls.Add(this.lblDecodedInfo);
            this.Controls.Add(this.camera);
            this.Controls.Add(this.schedule);
            this.Controls.Add(this.Next);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiberView";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.DataGridView schedule;
        private System.Windows.Forms.PictureBox camera;
        private System.Windows.Forms.Label lblDecodedInfo;
        private System.Windows.Forms.Button scan;
    }
}


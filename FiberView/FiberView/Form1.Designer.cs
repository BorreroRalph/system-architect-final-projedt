
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
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            this.SuspendLayout();
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(114, 282);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(101, 48);
            this.Next.TabIndex = 1;
            this.Next.Text = "View";
            this.Next.UseVisualStyleBackColor = true;
            // 
            // schedule
            // 
            this.schedule.AllowUserToAddRows = false;
            this.schedule.AllowUserToDeleteRows = false;
            this.schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schedule.Location = new System.Drawing.Point(420, 57);
            this.schedule.Name = "schedule";
            this.schedule.ReadOnly = true;
            this.schedule.RowHeadersWidth = 51;
            this.schedule.RowTemplate.Height = 24;
            this.schedule.Size = new System.Drawing.Size(500, 478);
            this.schedule.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 581);
            this.Controls.Add(this.schedule);
            this.Controls.Add(this.Next);
            this.Name = "Form1";
            this.Text = "FiberView";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.DataGridView schedule;
    }
}


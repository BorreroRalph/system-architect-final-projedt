
namespace FiberView
{
    partial class Form2
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
            this.back = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.list)).BeginInit();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(12, 546);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(119, 47);
            this.back.TabIndex = 0;
            this.back.Text = "Return";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // list
            // 
            this.list.AllowUserToAddRows = false;
            this.list.AllowUserToDeleteRows = false;
            this.list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.list.Location = new System.Drawing.Point(490, 58);
            this.list.Name = "list";
            this.list.ReadOnly = true;
            this.list.RowHeadersWidth = 51;
            this.list.RowTemplate.Height = 24;
            this.list.Size = new System.Drawing.Size(504, 464);
            this.list.TabIndex = 1;
            this.list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.list_CellContentClick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 605);
            this.Controls.Add(this.list);
            this.Controls.Add(this.back);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiberView";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.DataGridView list;
    }
}
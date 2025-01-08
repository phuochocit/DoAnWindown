namespace POS_System
{
    partial class frmRevenueReport
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
            this.btnDoanhthutongthe = new System.Windows.Forms.Button();
            this.btnChiTietHoaDon = new System.Windows.Forms.Button();
            this.btnDanhsachhoadon = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvRevenueReport = new System.Windows.Forms.DataGridView();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDoanhthutongthe
            // 
            this.btnDoanhthutongthe.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDoanhthutongthe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhthutongthe.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnDoanhthutongthe.Location = new System.Drawing.Point(12, 41);
            this.btnDoanhthutongthe.Name = "btnDoanhthutongthe";
            this.btnDoanhthutongthe.Size = new System.Drawing.Size(420, 55);
            this.btnDoanhthutongthe.TabIndex = 1;
            this.btnDoanhthutongthe.Text = "Doanh thu tổng thể";
            this.btnDoanhthutongthe.UseVisualStyleBackColor = false;
            this.btnDoanhthutongthe.Click += new System.EventHandler(this.btnDoanhthutongthe_Click);
            // 
            // btnChiTietHoaDon
            // 
            this.btnChiTietHoaDon.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnChiTietHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiTietHoaDon.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnChiTietHoaDon.Location = new System.Drawing.Point(830, 42);
            this.btnChiTietHoaDon.Name = "btnChiTietHoaDon";
            this.btnChiTietHoaDon.Size = new System.Drawing.Size(420, 55);
            this.btnChiTietHoaDon.TabIndex = 1;
            this.btnChiTietHoaDon.Text = "Chi tiết hóa đơn";
            this.btnChiTietHoaDon.UseVisualStyleBackColor = false;
            this.btnChiTietHoaDon.Click += new System.EventHandler(this.btnChiTietHoaDon_Click);
            // 
            // btnDanhsachhoadon
            // 
            this.btnDanhsachhoadon.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDanhsachhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhsachhoadon.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnDanhsachhoadon.Location = new System.Drawing.Point(420, 42);
            this.btnDanhsachhoadon.Name = "btnDanhsachhoadon";
            this.btnDanhsachhoadon.Size = new System.Drawing.Size(420, 55);
            this.btnDanhsachhoadon.TabIndex = 1;
            this.btnDanhsachhoadon.Text = "Danh sách hóa đơn";
            this.btnDanhsachhoadon.UseVisualStyleBackColor = false;
            this.btnDanhsachhoadon.Click += new System.EventHandler(this.btnDanhsachhoadon_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnBack.Location = new System.Drawing.Point(1095, 615);
            this.btnBack.Name = "btnBack";
            this.btnBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBack.Size = new System.Drawing.Size(155, 53);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvRevenueReport
            // 
            this.dgvRevenueReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenueReport.BackgroundColor = System.Drawing.Color.Aqua;
            this.dgvRevenueReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevenueReport.Location = new System.Drawing.Point(12, 100);
            this.dgvRevenueReport.Name = "dgvRevenueReport";
            this.dgvRevenueReport.RowHeadersWidth = 51;
            this.dgvRevenueReport.RowTemplate.Height = 24;
            this.dgvRevenueReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRevenueReport.Size = new System.Drawing.Size(629, 509);
            this.dgvRevenueReport.TabIndex = 3;
            this.dgvRevenueReport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRevenueReport_CellClick);
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.Aqua;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(647, 100);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 24;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(603, 509);
            this.dgvChiTietHoaDon.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "BÁO CÁO DOANH THU";
            // 
            // frmRevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.dgvRevenueReport);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDanhsachhoadon);
            this.Controls.Add(this.btnChiTietHoaDon);
            this.Controls.Add(this.btnDoanhthutongthe);
            this.Name = "frmRevenueReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRevenueReport_FormClosed);
            this.ForeColorChanged += new System.EventHandler(this.frmRevenueReport_ForeColorChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenueReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDoanhthutongthe;
        private System.Windows.Forms.Button btnChiTietHoaDon;
        private System.Windows.Forms.Button btnDanhsachhoadon;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvRevenueReport;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Label label1;
    }
}
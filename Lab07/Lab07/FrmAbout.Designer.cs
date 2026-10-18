namespace ShopManagerMini.Forms
{
    partial class FrmAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTenUngDung = new System.Windows.Forms.Label();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.lblSinhVien = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblPhienBan = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();

            //
            // lblTenUngDung
            //
            this.lblTenUngDung.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTenUngDung.Location = new System.Drawing.Point(20, 20);
            this.lblTenUngDung.Name = "lblTenUngDung";
            this.lblTenUngDung.Size = new System.Drawing.Size(340, 30);
            this.lblTenUngDung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenUngDung.Text = "ShopManagerMini";

            //
            // lblMonHoc
            //
            this.lblMonHoc.Location = new System.Drawing.Point(20, 62);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(340, 20);
            this.lblMonHoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMonHoc.Text = "COMP1019 - Lập trình trên Windows";

            //
            // lblSinhVien
            //
            this.lblSinhVien.Location = new System.Drawing.Point(20, 102);
            this.lblSinhVien.Name = "lblSinhVien";
            this.lblSinhVien.Size = new System.Drawing.Size(340, 20);
            this.lblSinhVien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSinhVien.Text = "Sinh viên: (Nhập họ tên của bạn vào đây)";

            //
            // lblLop
            //
            this.lblLop.Location = new System.Drawing.Point(20, 127);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(340, 20);
            this.lblLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLop.Text = "Lớp: (Nhập lớp của bạn vào đây)";

            //
            // lblPhienBan
            //
            this.lblPhienBan.ForeColor = System.Drawing.Color.Gray;
            this.lblPhienBan.Location = new System.Drawing.Point(20, 160);
            this.lblPhienBan.Name = "lblPhienBan";
            this.lblPhienBan.Size = new System.Drawing.Size(340, 20);
            this.lblPhienBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhienBan.Text = "Phiên bản 1.0";

            //
            // btnDong
            //
            this.btnDong.Location = new System.Drawing.Point(140, 200);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            //
            // FrmAbout
            //
            this.AcceptButton = this.btnDong;
            this.CancelButton = this.btnDong;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 250);
            this.Controls.Add(this.lblTenUngDung);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.lblSinhVien);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.lblPhienBan);
            this.Controls.Add(this.btnDong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Giới thiệu";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTenUngDung;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.Label lblSinhVien;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblPhienBan;
        private System.Windows.Forms.Button btnDong;
    }
}

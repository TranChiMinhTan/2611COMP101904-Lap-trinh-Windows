namespace Lab01
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblTieuDe = new Label();
            lblHoTen = new Label();
            lblEmail = new Label();
            lblNamSinh = new Label();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            txtNamSinh = new TextBox();
            grpGioiTinh = new GroupBox();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            btnHienThi = new Button();
            cboKhoaLop = new ComboBox();
            lblKhoaLop = new Label();
            btnXoa = new Button();
            btnThoat = new Button();
            lblKetQua = new Label();
            txtKetQua = new TextBox();
            grpGioiTinh.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(208, 61);
            label1.Name = "label1";
            label1.Size = new Size(0, 29);
            label1.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(100, 25);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(400, 40);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "THÔNG TIN CÁ NHÂN";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHoTen.Location = new Point(30, 90);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 17);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(30, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 17);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamSinh.Location = new Point(30, 130);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(74, 17);
            lblNamSinh.TabIndex = 4;
            lblNamSinh.Text = "Năm sinh:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(160, 85);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 23);
            txtHoTen.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 165);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 6;
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(160, 125);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(150, 23);
            txtNamSinh.TabIndex = 7;
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpGioiTinh.Location = new Point(30, 210);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(430, 55);
            grpGioiTinh.TabIndex = 8;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(130, 25);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(46, 21);
            rdoNu.TabIndex = 10;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(20, 25);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(57, 21);
            rdoNam.TabIndex = 9;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // btnHienThi
            // 
            btnHienThi.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHienThi.Location = new Point(30, 335);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(120, 40);
            btnHienThi.TabIndex = 10;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // cboKhoaLop
            // 
            cboKhoaLop.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboKhoaLop.FormattingEnabled = true;
            cboKhoaLop.Items.AddRange(new object[] { "Khoa Ngữ Văn", "Khoa Toán - Tin học", "Khoa Công nghệ thông tin", "Khoa Vật lý", "Khoa Hóa học", "Khoa Sinh học", "Khoa Lịch sử", "Khoa Địa lý", "Khoa tiếng Anh", "Khoa tiếng Pháp", "Khoa tiếng Nga", "Khoa tiếng Trung", "Khoa tiếng Nhật", "Khoa tiếng Hàn quốc", "Khoa Giáo dục chính trị", "Khoa Tâm lý học", "Khoa Khoa học Giáo dục", "Khoa Giáo dục Tiểu học", "Khoa Giáo dục Mầm non", "Khoa Giáo dục Quốc phòng", "Khoa Giáo dục đặc biệt", "Khoa Giáo dục Thể chất", "Tổ Nữ công" });
            cboKhoaLop.Location = new Point(160, 280);
            cboKhoaLop.Name = "cboKhoaLop";
            cboKhoaLop.Size = new Size(300, 25);
            cboKhoaLop.TabIndex = 11;
            // 
            // lblKhoaLop
            // 
            lblKhoaLop.AutoSize = true;
            lblKhoaLop.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKhoaLop.Location = new Point(30, 285);
            lblKhoaLop.Name = "lblKhoaLop";
            lblKhoaLop.Size = new Size(76, 17);
            lblKhoaLop.TabIndex = 12;
            lblKhoaLop.Text = "Khoa/Lớp:";
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(180, 335);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(330, 335);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 40);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKetQua.Location = new Point(30, 390);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(68, 19);
            lblKetQua.TabIndex = 15;
            lblKetQua.Text = "Kết quả";
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(30, 415);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(520, 100);
            txtKetQua.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 521);
            Controls.Add(txtKetQua);
            Controls.Add(lblKetQua);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(lblKhoaLop);
            Controls.Add(cboKhoaLop);
            Controls.Add(btnHienThi);
            Controls.Add(grpGioiTinh);
            Controls.Add(txtNamSinh);
            Controls.Add(txtEmail);
            Controls.Add(txtHoTen);
            Controls.Add(lblNamSinh);
            Controls.Add(lblEmail);
            Controls.Add(lblHoTen);
            Controls.Add(lblTieuDe);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab 01 - Ứng dụng thông tin cá nhân";
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblTieuDe;
        private Label lblHoTen;
        private Label lblEmail;
        private Label lblNamSinh;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtNamSinh;
        private GroupBox grpGioiTinh;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private Button btnHienThi;
        private ComboBox cboKhoaLop;
        private Label lblKhoaLop;
        private Button btnXoa;
        private Button btnThoat;
        private Label lblKetQua;
        private TextBox txtKetQua;
    }
}
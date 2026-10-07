namespace WinFormsApp1
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
            grpHocVien = new GroupBox();
            HoTen = new Label();
            lblSDT = new Label();
            lblNgaySinh = new Label();
            lblDemKyTu = new Label();
            txtHoTen = new TextBox();
            textBox3 = new TextBox();
            chkEmail = new CheckBox();
            lblTrangThaiEmail = new Label();
            dtpNgaySinh = new DateTimePicker();
            grpKhoaHoc = new GroupBox();
            txtTongTien = new Label();
            lblSoThang = new Label();
            lblHinhThuc = new Label();
            lblKhoaHoc = new Label();
            comboBox1 = new ComboBox();
            radOnline = new RadioButton();
            radTrucTiep = new RadioButton();
            numSoThang = new NumericUpDown();
            txtHocPhiThang = new Label();
            lblTongTien = new Label();
            lblHocPhiThang = new Label();
            grpHocVien.SuspendLayout();
            grpKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(406, 34);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(291, 23);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG KÝ KHÓA HỌC DÀI HẠN";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // grpHocVien
            // 
            grpHocVien.BackColor = SystemColors.ActiveCaption;
            grpHocVien.Controls.Add(dtpNgaySinh);
            grpHocVien.Controls.Add(lblTrangThaiEmail);
            grpHocVien.Controls.Add(chkEmail);
            grpHocVien.Controls.Add(textBox3);
            grpHocVien.Controls.Add(txtHoTen);
            grpHocVien.Controls.Add(lblDemKyTu);
            grpHocVien.Controls.Add(lblNgaySinh);
            grpHocVien.Controls.Add(lblSDT);
            grpHocVien.Controls.Add(HoTen);
            grpHocVien.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpHocVien.Location = new Point(12, 104);
            grpHocVien.Name = "grpHocVien";
            grpHocVien.Size = new Size(475, 353);
            grpHocVien.TabIndex = 1;
            grpHocVien.TabStop = false;
            grpHocVien.Text = "Thông Tin Học Viên";
            grpHocVien.Enter += groupBox1_Enter;
            // 
            // HoTen
            // 
            HoTen.AutoSize = true;
            HoTen.Location = new Point(24, 69);
            HoTen.Name = "HoTen";
            HoTen.Size = new Size(73, 23);
            HoTen.TabIndex = 0;
            HoTen.Text = "Họ tên:";
            HoTen.Click += HoTen_Click;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(24, 115);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(53, 23);
            lblSDT.TabIndex = 1;
            lblSDT.Text = "SĐT:";
            lblSDT.Click += this.label3_Click;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(24, 163);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(101, 23);
            lblNgaySinh.TabIndex = 2;
            lblNgaySinh.Text = "Ngày sinh:";
            lblNgaySinh.Click += label4_Click;
            // 
            // lblDemKyTu
            // 
            lblDemKyTu.AutoSize = true;
            lblDemKyTu.Location = new Point(339, 69);
            lblDemKyTu.Name = "lblDemKyTu";
            lblDemKyTu.Size = new Size(49, 23);
            lblDemKyTu.TabIndex = 3;
            lblDemKyTu.Text = "0/50";
            lblDemKyTu.Click += label5_Click;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(120, 61);
            txtHoTen.MaxLength = 50;
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(203, 30);
            txtHoTen.TabIndex = 4;
            txtHoTen.TextChanged += textBox1_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(120, 107);
            textBox3.MaxLength = 10;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(203, 30);
            textBox3.TabIndex = 6;
            // 
            // chkEmail
            // 
            chkEmail.AutoSize = true;
            chkEmail.Location = new Point(118, 247);
            chkEmail.Name = "chkEmail";
            chkEmail.Size = new Size(223, 27);
            chkEmail.TabIndex = 7;
            chkEmail.Text = "Nhận Email thông báo";
            chkEmail.UseVisualStyleBackColor = true;
            // 
            // lblTrangThaiEmail
            // 
            lblTrangThaiEmail.AutoSize = true;
            lblTrangThaiEmail.Font = new Font("Arial", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTrangThaiEmail.Location = new Point(118, 293);
            lblTrangThaiEmail.Name = "lblTrangThaiEmail";
            lblTrangThaiEmail.Size = new Size(232, 19);
            lblTrangThaiEmail.TabIndex = 8;
            lblTrangThaiEmail.Text = "Không nhận email thông báo";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(120, 157);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(203, 30);
            dtpNgaySinh.TabIndex = 9;
            // 
            // grpKhoaHoc
            // 
            grpKhoaHoc.BackColor = SystemColors.ActiveCaption;
            grpKhoaHoc.Controls.Add(lblTongTien);
            grpKhoaHoc.Controls.Add(lblHocPhiThang);
            grpKhoaHoc.Controls.Add(txtHocPhiThang);
            grpKhoaHoc.Controls.Add(numSoThang);
            grpKhoaHoc.Controls.Add(radTrucTiep);
            grpKhoaHoc.Controls.Add(radOnline);
            grpKhoaHoc.Controls.Add(comboBox1);
            grpKhoaHoc.Controls.Add(txtTongTien);
            grpKhoaHoc.Controls.Add(lblSoThang);
            grpKhoaHoc.Controls.Add(lblHinhThuc);
            grpKhoaHoc.Controls.Add(lblKhoaHoc);
            grpKhoaHoc.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpKhoaHoc.Location = new Point(592, 104);
            grpKhoaHoc.Name = "grpKhoaHoc";
            grpKhoaHoc.Size = new Size(528, 353);
            grpKhoaHoc.TabIndex = 10;
            grpKhoaHoc.TabStop = false;
            grpKhoaHoc.Text = "Thông Tin Khóa Học";
            // 
            // txtTongTien
            // 
            txtTongTien.AutoSize = true;
            txtTongTien.Location = new Point(16, 264);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(91, 23);
            txtTongTien.TabIndex = 8;
            txtTongTien.Text = "Tổng tiền";
            // 
            // lblSoThang
            // 
            lblSoThang.AutoSize = true;
            lblSoThang.Location = new Point(16, 164);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.Size = new Size(88, 23);
            lblSoThang.TabIndex = 2;
            lblSoThang.Text = "Số tháng";
            // 
            // lblHinhThuc
            // 
            lblHinhThuc.AutoSize = true;
            lblHinhThuc.Location = new Point(16, 115);
            lblHinhThuc.Name = "lblHinhThuc";
            lblHinhThuc.Size = new Size(137, 23);
            lblHinhThuc.TabIndex = 1;
            lblHinhThuc.Text = "Hình thức học:";
            lblHinhThuc.Click += label5_Click_1;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(16, 68);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Size = new Size(98, 23);
            lblKhoaHoc.TabIndex = 0;
            lblKhoaHoc.Text = "Khóa học:";
            lblKhoaHoc.Click += lblKhoaHoc_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(120, 60);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(203, 31);
            comboBox1.TabIndex = 10;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Location = new Point(159, 113);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(86, 27);
            radOnline.TabIndex = 11;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            radOnline.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radTrucTiep
            // 
            radTrucTiep.AutoSize = true;
            radTrucTiep.Location = new Point(307, 113);
            radTrucTiep.Name = "radTrucTiep";
            radTrucTiep.Size = new Size(110, 27);
            radTrucTiep.TabIndex = 12;
            radTrucTiep.TabStop = true;
            radTrucTiep.Text = "Trực tiếp";
            radTrucTiep.UseVisualStyleBackColor = true;
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(120, 161);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(149, 30);
            numSoThang.TabIndex = 13;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtHocPhiThang
            // 
            txtHocPhiThang.AutoSize = true;
            txtHocPhiThang.Location = new Point(16, 214);
            txtHocPhiThang.Name = "txtHocPhiThang";
            txtHocPhiThang.Size = new Size(143, 23);
            txtHocPhiThang.TabIndex = 14;
            txtHocPhiThang.Text = "Học phí / tháng";
            txtHocPhiThang.Click += label3_Click_1;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(178, 264);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(91, 23);
            lblTongTien.TabIndex = 11;
            lblTongTien.Text = "Tổng tiền";
            lblTongTien.Click += label2_Click;
            // 
            // lblHocPhiThang
            // 
            lblHocPhiThang.AutoSize = true;
            lblHocPhiThang.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHocPhiThang.Location = new Point(178, 214);
            lblHocPhiThang.Name = "lblHocPhiThang";
            lblHocPhiThang.Size = new Size(68, 24);
            lblHocPhiThang.TabIndex = 12;
            lblHocPhiThang.Text = "0 VND";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 518);
            Controls.Add(grpKhoaHoc);
            Controls.Add(grpHocVien);
            Controls.Add(label1);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            grpHocVien.ResumeLayout(false);
            grpHocVien.PerformLayout();
            grpKhoaHoc.ResumeLayout(false);
            grpKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grpHocVien;
        private TextBox txtHoTen;
        private Label lblDemKyTu;
        private Label lblNgaySinh;
        private Label lblSDT;
        private Label HoTen;
        private TextBox textBox3;
        private Label lblTrangThaiEmail;
        private CheckBox chkEmail;
        private DateTimePicker dtpNgaySinh;
        private GroupBox grpKhoaHoc;
        private Label txtTongTien;
        private TextBox textBox1;
        private Label label3;
        private Label lblSoThang;
        private Label lblHinhThuc;
        private Label lblKhoaHoc;
        private ComboBox comboBox1;
        private RadioButton radTrucTiep;
        private RadioButton radOnline;
        private NumericUpDown numSoThang;
        private Label txtHocPhiThang;
        private Label lblTongTien;
        private Label lblHocPhiThang;
    }
}

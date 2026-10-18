namespace COMP1019_Lab09_StudentCard
{
    partial class FrmStudentCard
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
            this.printDocument = new System.Drawing.Printing.PrintDocument();

            // ----- Vùng nhập liệu bên trái -----
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.lblAnh = new System.Windows.Forms.Label();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblTenFileAnh = new System.Windows.Forms.Label();

            // ----- Vùng xem trước bên phải -----
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.pnlPreview = new COMP1019_Lab09_StudentCard.DoubleBufferedPanel();

            // ----- Hàng nút lệnh -----
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnMauThe = new System.Windows.Forms.Button();
            this.btnLuuPng = new System.Windows.Forms.Button();
            this.btnXemTruocIn = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            this.grpPreview.SuspendLayout();
            this.SuspendLayout();

            //
            // printDocument
            //
            this.printDocument.DocumentName = "The sinh vien";
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);

            //
            // grpThongTin
            //
            this.grpThongTin.Controls.Add(this.lblMaSV);
            this.grpThongTin.Controls.Add(this.txtMaSV);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblGioiTinh);
            this.grpThongTin.Controls.Add(this.cboGioiTinh);
            this.grpThongTin.Controls.Add(this.lblLop);
            this.grpThongTin.Controls.Add(this.cboLop);
            this.grpThongTin.Controls.Add(this.lblKhoa);
            this.grpThongTin.Controls.Add(this.cboKhoa);
            this.grpThongTin.Controls.Add(this.lblKhoaHoc);
            this.grpThongTin.Controls.Add(this.cboKhoaHoc);
            this.grpThongTin.Controls.Add(this.lblAnh);
            this.grpThongTin.Controls.Add(this.picAnh);
            this.grpThongTin.Controls.Add(this.btnChonAnh);
            this.grpThongTin.Controls.Add(this.lblTenFileAnh);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(430, 452);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin sinh viên";

            //
            // lblMaSV / txtMaSV
            //
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(15, 31);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Text = "Mã sinh viên (*):";

            this.txtMaSV.Location = new System.Drawing.Point(125, 28);
            this.txtMaSV.MaxLength = 20;
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(285, 23);
            this.txtMaSV.TabIndex = 0;
            this.txtMaSV.TextChanged += new System.EventHandler(this.InputChanged);

            //
            // lblHoTen / txtHoTen
            //
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 65);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên (*):";

            this.txtHoTen.Location = new System.Drawing.Point(125, 62);
            this.txtHoTen.MaxLength = 35;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(285, 23);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextChanged += new System.EventHandler(this.InputChanged);

            //
            // lblNgaySinh / dtpNgaySinh
            //
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 99);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Text = "Ngày sinh:";

            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Location = new System.Drawing.Point(125, 96);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(140, 23);
            this.dtpNgaySinh.TabIndex = 2;
            this.dtpNgaySinh.ValueChanged += new System.EventHandler(this.InputChanged);

            //
            // lblGioiTinh / cboGioiTinh
            //
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 133);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Text = "Giới tính:";

            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(125, 130);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(140, 23);
            this.cboGioiTinh.TabIndex = 3;
            this.cboGioiTinh.SelectedIndexChanged += new System.EventHandler(this.InputChanged);

            //
            // lblLop / cboLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(15, 167);
            this.lblLop.Name = "lblLop";
            this.lblLop.Text = "Lớp:";

            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(125, 164);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(285, 23);
            this.cboLop.TabIndex = 4;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.InputChanged);

            //
            // lblKhoa / cboKhoa
            //
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(15, 201);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Text = "Khoa:";

            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(125, 198);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(285, 23);
            this.cboKhoa.TabIndex = 5;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.InputChanged);

            //
            // lblKhoaHoc / cboKhoaHoc
            //
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Location = new System.Drawing.Point(15, 235);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Text = "Khóa học:";

            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(125, 232);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(140, 23);
            this.cboKhoaHoc.TabIndex = 6;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.InputChanged);

            //
            // lblAnh / picAnh / btnChonAnh / lblTenFileAnh
            //
            this.lblAnh.AutoSize = true;
            this.lblAnh.Location = new System.Drawing.Point(15, 275);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Text = "Ảnh đại diện (*):";

            this.picAnh.BackColor = System.Drawing.Color.White;
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Location = new System.Drawing.Point(125, 272);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(150, 170);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabStop = false;

            this.btnChonAnh.Location = new System.Drawing.Point(290, 272);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(120, 32);
            this.btnChonAnh.TabIndex = 7;
            this.btnChonAnh.Text = "Chọn ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            this.lblTenFileAnh.AutoEllipsis = true;
            this.lblTenFileAnh.ForeColor = System.Drawing.Color.Gray;
            this.lblTenFileAnh.Location = new System.Drawing.Point(290, 310);
            this.lblTenFileAnh.Name = "lblTenFileAnh";
            this.lblTenFileAnh.Size = new System.Drawing.Size(125, 60);
            this.lblTenFileAnh.Text = "(Chưa chọn ảnh)";

            //
            // grpPreview
            //
            this.grpPreview.Controls.Add(this.pnlPreview);
            this.grpPreview.Location = new System.Drawing.Point(454, 12);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
            this.grpPreview.Size = new System.Drawing.Size(534, 452);
            this.grpPreview.TabIndex = 1;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Xem trước thẻ sinh viên";

            //
            // pnlPreview
            //
            this.pnlPreview.BackColor = System.Drawing.Color.FromArgb(232, 236, 241);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreview.Location = new System.Drawing.Point(8, 22);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(518, 422);
            this.pnlPreview.TabIndex = 0;
            this.pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPreview_Paint);

            //
            // btnLamMoi
            //
            this.btnLamMoi.Location = new System.Drawing.Point(12, 476);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 36);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            //
            // btnMauThe
            //
            this.btnMauThe.Location = new System.Drawing.Point(132, 476);
            this.btnMauThe.Name = "btnMauThe";
            this.btnMauThe.Size = new System.Drawing.Size(110, 36);
            this.btnMauThe.TabIndex = 3;
            this.btnMauThe.Text = "Màu thẻ...";
            this.btnMauThe.UseVisualStyleBackColor = true;
            this.btnMauThe.Click += new System.EventHandler(this.btnMauThe_Click);

            //
            // btnLuuPng
            //
            this.btnLuuPng.Location = new System.Drawing.Point(252, 476);
            this.btnLuuPng.Name = "btnLuuPng";
            this.btnLuuPng.Size = new System.Drawing.Size(110, 36);
            this.btnLuuPng.TabIndex = 4;
            this.btnLuuPng.Text = "Lưu PNG...";
            this.btnLuuPng.UseVisualStyleBackColor = true;
            this.btnLuuPng.Click += new System.EventHandler(this.btnLuuPng_Click);

            //
            // btnXemTruocIn
            //
            this.btnXemTruocIn.Location = new System.Drawing.Point(596, 476);
            this.btnXemTruocIn.Name = "btnXemTruocIn";
            this.btnXemTruocIn.Size = new System.Drawing.Size(130, 36);
            this.btnXemTruocIn.TabIndex = 5;
            this.btnXemTruocIn.Text = "Xem trước in";
            this.btnXemTruocIn.UseVisualStyleBackColor = true;
            this.btnXemTruocIn.Click += new System.EventHandler(this.btnXemTruocIn_Click);

            //
            // btnIn
            //
            this.btnIn.Location = new System.Drawing.Point(736, 476);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(120, 36);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "In thẻ";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);

            //
            // btnThoat
            //
            this.btnThoat.Location = new System.Drawing.Point(868, 476);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 36);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            //
            // FrmStudentCard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 530);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnMauThe);
            this.Controls.Add(this.btnLuuPng);
            this.Controls.Add(this.btnXemTruocIn);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnThoat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmStudentCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết kế và in thẻ sinh viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmStudentCard_FormClosed);
            this.Load += new System.EventHandler(this.FrmStudentCard_Load);

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            this.grpPreview.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument;

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblKhoaHoc;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblTenFileAnh;

        private System.Windows.Forms.GroupBox grpPreview;
        private DoubleBufferedPanel pnlPreview;

        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnMauThe;
        private System.Windows.Forms.Button btnLuuPng;
        private System.Windows.Forms.Button btnXemTruocIn;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThoat;
    }
}

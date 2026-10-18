namespace QuanLyLop
{
    partial class FrmLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblMaLop = new Label();
            lblTenLop = new Label();
            txtMaLop = new TextBox();
            txtTenLop = new TextBox();
            txtTimKiem = new TextBox();
            dgvLop = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();

            // lblMaLop
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(20, 25);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Text = "Mã lớp:";

            // txtMaLop
            txtMaLop.Location = new Point(100, 22);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(180, 27);

            // lblTenLop
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(20, 65);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Text = "Tên lớp:";

            // txtTenLop
            txtTenLop.Location = new Point(100, 62);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(380, 27);

            // btnThem
            btnThem.Location = new Point(20, 105);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            // btnSua
            btnSua.Location = new Point(120, 105);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            // btnXoa
            btnXoa.Location = new Point(220, 105);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            // btnLamMoi
            btnLamMoi.Location = new Point(320, 105);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            // txtTimKiem
            txtTimKiem.Location = new Point(20, 158);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên lớp cần tìm...";
            txtTimKiem.Size = new Size(390, 27);

            // btnTimKiem
            btnTimKiem.Location = new Point(420, 155);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(90, 34);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.Click += btnTimKiem_Click;

            // dgvLop
            dgvLop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLop.Location = new Point(20, 200);
            dgvLop.Name = "dgvLop";
            dgvLop.Size = new Size(490, 250);
            dgvLop.CellClick += dgvLop_CellClick;

            // FrmLop
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 471);
            Controls.AddRange(new Control[] {
                lblMaLop, txtMaLop, lblTenLop, txtTenLop,
                btnThem, btnSua, btnXoa, btnLamMoi,
                txtTimKiem, btnTimKiem, dgvLop });
            Name = "FrmLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học - EduManagerDB";
            Load += FrmLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblMaLop;
        private Label lblTenLop;
        private TextBox txtMaLop;
        private TextBox txtTenLop;
        private TextBox txtTimKiem;
        private DataGridView dgvLop;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
    }
}

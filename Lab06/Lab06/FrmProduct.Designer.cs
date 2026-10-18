namespace ProductManager
{
    partial class FrmProduct
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
            this.components = new System.ComponentModel.Container();

            this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bsProducts = new System.Windows.Forms.BindingSource(this.components);

            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSepQuanLy1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLamMoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();

            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbThem = new System.Windows.Forms.ToolStripButton();
            this.tsbSua = new System.Windows.Forms.ToolStripButton();
            this.tsbXoa = new System.Windows.Forms.ToolStripButton();
            this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLamMoi = new System.Windows.Forms.ToolStripButton();
            this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblTimKiem = new System.Windows.Forms.ToolStripLabel();
            this.tstxtTimKiem = new System.Windows.Forms.ToolStripTextBox();
            this.tsbTimKiem = new System.Windows.Forms.ToolStripButton();

            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSoLuongSanPham = new System.Windows.Forms.ToolStripStatusLabel();

            this.grpThongTinSanPham = new System.Windows.Forms.GroupBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.chkConKinhDoanh = new System.Windows.Forms.CheckBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblAnh = new System.Windows.Forms.Label();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblTenFileAnh = new System.Windows.Forms.Label();

            this.dgvProducts = new System.Windows.Forms.DataGridView();

            this.cmsGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSua = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsXemChiTiet = new System.Windows.Forms.ToolStripMenuItem();

            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducts)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.grpThongTinSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.cmsGrid.SuspendLayout();
            this.SuspendLayout();

            //
            // menuStripMain
            //
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuFile, this.mnuQuanLy, this.mnuTroGiup});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(970, 24);
            this.menuStripMain.TabIndex = 0;

            //
            // mnuFile
            //
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuThoat});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(40, 20);
            this.mnuFile.Text = "File";

            //
            // mnuThoat
            //
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(120, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);

            //
            // mnuQuanLy
            //
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuThem, this.mnuSua, this.mnuXoa, this.mnuSepQuanLy1, this.mnuTimKiem, this.mnuLamMoi});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(75, 20);
            this.mnuQuanLy.Text = "Quản lý";

            //
            // mnuThem
            //
            this.mnuThem.Name = "mnuThem";
            this.mnuThem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuThem.Size = new System.Drawing.Size(220, 22);
            this.mnuThem.Text = "Thêm sản phẩm";
            this.mnuThem.Click += new System.EventHandler(this.mnuThem_Click);

            //
            // mnuSua
            //
            this.mnuSua.Name = "mnuSua";
            this.mnuSua.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuSua.Size = new System.Drawing.Size(220, 22);
            this.mnuSua.Text = "Sửa sản phẩm";
            this.mnuSua.Click += new System.EventHandler(this.mnuSua_Click);

            //
            // mnuXoa
            //
            this.mnuXoa.Name = "mnuXoa";
            this.mnuXoa.Size = new System.Drawing.Size(220, 22);
            this.mnuXoa.Text = "Xóa sản phẩm";
            this.mnuXoa.Click += new System.EventHandler(this.mnuXoa_Click);

            //
            // mnuSepQuanLy1
            //
            this.mnuSepQuanLy1.Name = "mnuSepQuanLy1";
            this.mnuSepQuanLy1.Size = new System.Drawing.Size(217, 6);

            //
            // mnuTimKiem
            //
            this.mnuTimKiem.Name = "mnuTimKiem";
            this.mnuTimKiem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuTimKiem.Size = new System.Drawing.Size(220, 22);
            this.mnuTimKiem.Text = "Tìm kiếm";
            this.mnuTimKiem.Click += new System.EventHandler(this.mnuTimKiem_Click);

            //
            // mnuLamMoi
            //
            this.mnuLamMoi.Name = "mnuLamMoi";
            this.mnuLamMoi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuLamMoi.Size = new System.Drawing.Size(220, 22);
            this.mnuLamMoi.Text = "Làm mới";
            this.mnuLamMoi.Click += new System.EventHandler(this.mnuLamMoi_Click);

            //
            // mnuTroGiup
            //
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuGioiThieu});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(70, 20);
            this.mnuTroGiup.Text = "Trợ giúp";

            //
            // mnuGioiThieu
            //
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(150, 22);
            this.mnuGioiThieu.Text = "Giới thiệu";
            this.mnuGioiThieu.Click += new System.EventHandler(this.mnuGioiThieu_Click);

            //
            // toolStripMain
            //
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsbThem, this.tsbSua, this.tsbXoa, this.tsSep1, this.tsbLamMoi,
                this.tsSep2, this.tslblTimKiem, this.tstxtTimKiem, this.tsbTimKiem});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(970, 25);
            this.toolStripMain.TabIndex = 1;

            //
            // tsbThem
            //
            this.tsbThem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbThem.Name = "tsbThem";
            this.tsbThem.Size = new System.Drawing.Size(55, 22);
            this.tsbThem.Text = "Thêm";
            this.tsbThem.Click += new System.EventHandler(this.tsbThem_Click);

            //
            // tsbSua
            //
            this.tsbSua.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSua.Name = "tsbSua";
            this.tsbSua.Size = new System.Drawing.Size(45, 22);
            this.tsbSua.Text = "Sửa";
            this.tsbSua.Click += new System.EventHandler(this.tsbSua_Click);

            //
            // tsbXoa
            //
            this.tsbXoa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbXoa.Name = "tsbXoa";
            this.tsbXoa.Size = new System.Drawing.Size(45, 22);
            this.tsbXoa.Text = "Xóa";
            this.tsbXoa.Click += new System.EventHandler(this.tsbXoa_Click);

            //
            // tsSep1
            //
            this.tsSep1.Name = "tsSep1";
            this.tsSep1.Size = new System.Drawing.Size(6, 25);

            //
            // tsbLamMoi
            //
            this.tsbLamMoi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLamMoi.Name = "tsbLamMoi";
            this.tsbLamMoi.Size = new System.Drawing.Size(65, 22);
            this.tsbLamMoi.Text = "Làm mới";
            this.tsbLamMoi.Click += new System.EventHandler(this.tsbLamMoi_Click);

            //
            // tsSep2
            //
            this.tsSep2.Name = "tsSep2";
            this.tsSep2.Size = new System.Drawing.Size(6, 25);

            //
            // tslblTimKiem
            //
            this.tslblTimKiem.Name = "tslblTimKiem";
            this.tslblTimKiem.Size = new System.Drawing.Size(65, 22);
            this.tslblTimKiem.Text = "Tìm kiếm:";

            //
            // tstxtTimKiem
            //
            this.tstxtTimKiem.Name = "tstxtTimKiem";
            this.tstxtTimKiem.Size = new System.Drawing.Size(180, 25);
            this.tstxtTimKiem.ToolTipText = "Nhập mã hoặc tên sản phẩm cần tìm rồi nhấn Enter";
            this.tstxtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstxtTimKiem_KeyDown);

            //
            // tsbTimKiem
            //
            this.tsbTimKiem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTimKiem.Name = "tsbTimKiem";
            this.tsbTimKiem.Size = new System.Drawing.Size(45, 22);
            this.tsbTimKiem.Text = "Tìm";
            this.tsbTimKiem.Click += new System.EventHandler(this.tsbTimKiem_Click);

            //
            // statusStripMain
            //
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblStatus, this.lblSoLuongSanPham});
            this.statusStripMain.Location = new System.Drawing.Point(0, 678);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(970, 22);
            this.statusStripMain.TabIndex = 2;

            //
            // lblStatus
            //
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(830, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Text = "Sẵn sàng";

            //
            // lblSoLuongSanPham
            //
            this.lblSoLuongSanPham.Name = "lblSoLuongSanPham";
            this.lblSoLuongSanPham.Size = new System.Drawing.Size(130, 17);
            this.lblSoLuongSanPham.Text = "Tổng số sản phẩm: 0";

            //
            // grpThongTinSanPham
            //
            this.grpThongTinSanPham.Controls.Add(this.lblMaSP);
            this.grpThongTinSanPham.Controls.Add(this.txtMaSP);
            this.grpThongTinSanPham.Controls.Add(this.lblTenSP);
            this.grpThongTinSanPham.Controls.Add(this.txtTenSP);
            this.grpThongTinSanPham.Controls.Add(this.lblLoaiSP);
            this.grpThongTinSanPham.Controls.Add(this.cboLoaiSP);
            this.grpThongTinSanPham.Controls.Add(this.lblNgayNhap);
            this.grpThongTinSanPham.Controls.Add(this.dtpNgayNhap);
            this.grpThongTinSanPham.Controls.Add(this.chkConKinhDoanh);
            this.grpThongTinSanPham.Controls.Add(this.lblDonGia);
            this.grpThongTinSanPham.Controls.Add(this.numDonGia);
            this.grpThongTinSanPham.Controls.Add(this.lblSoLuong);
            this.grpThongTinSanPham.Controls.Add(this.numSoLuong);
            this.grpThongTinSanPham.Controls.Add(this.lblAnh);
            this.grpThongTinSanPham.Controls.Add(this.picAnh);
            this.grpThongTinSanPham.Controls.Add(this.btnChonAnh);
            this.grpThongTinSanPham.Controls.Add(this.lblTenFileAnh);
            this.grpThongTinSanPham.Location = new System.Drawing.Point(12, 58);
            this.grpThongTinSanPham.Name = "grpThongTinSanPham";
            this.grpThongTinSanPham.Size = new System.Drawing.Size(946, 230);
            this.grpThongTinSanPham.TabIndex = 0;
            this.grpThongTinSanPham.TabStop = false;
            this.grpThongTinSanPham.Text = "Thông tin sản phẩm";

            //
            // lblMaSP
            //
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Location = new System.Drawing.Point(15, 28);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(84, 15);
            this.lblMaSP.Text = "Mã sản phẩm:";

            //
            // txtMaSP
            //
            this.txtMaSP.Location = new System.Drawing.Point(120, 25);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(210, 23);
            this.txtMaSP.TabIndex = 0;

            //
            // lblTenSP
            //
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Location = new System.Drawing.Point(15, 61);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(89, 15);
            this.lblTenSP.Text = "Tên sản phẩm:";

            //
            // txtTenSP
            //
            this.txtTenSP.Location = new System.Drawing.Point(120, 58);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(210, 23);
            this.txtTenSP.TabIndex = 1;

            //
            // lblLoaiSP
            //
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Location = new System.Drawing.Point(15, 94);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(93, 15);
            this.lblLoaiSP.Text = "Loại sản phẩm:";

            //
            // cboLoaiSP
            //
            this.cboLoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(120, 91);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(210, 23);
            this.cboLoaiSP.TabIndex = 2;

            //
            // lblNgayNhap
            //
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(15, 127);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(71, 15);
            this.lblNgayNhap.Text = "Ngày nhập:";

            //
            // dtpNgayNhap
            //
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(120, 124);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(210, 23);
            this.dtpNgayNhap.TabIndex = 3;

            //
            // chkConKinhDoanh
            //
            this.chkConKinhDoanh.AutoSize = true;
            this.chkConKinhDoanh.Location = new System.Drawing.Point(120, 160);
            this.chkConKinhDoanh.Name = "chkConKinhDoanh";
            this.chkConKinhDoanh.Size = new System.Drawing.Size(132, 19);
            this.chkConKinhDoanh.TabIndex = 4;
            this.chkConKinhDoanh.Text = "Còn kinh doanh";
            this.chkConKinhDoanh.UseVisualStyleBackColor = true;

            //
            // lblDonGia
            //
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(360, 28);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(55, 15);
            this.lblDonGia.Text = "Đơn giá:";

            //
            // numDonGia
            //
            this.numDonGia.Location = new System.Drawing.Point(440, 25);
            this.numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numDonGia.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(150, 23);
            this.numDonGia.TabIndex = 5;
            this.numDonGia.ThousandsSeparator = true;

            //
            // lblSoLuong
            //
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(360, 61);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(63, 15);
            this.lblSoLuong.Text = "Số lượng:";

            //
            // numSoLuong
            //
            this.numSoLuong.Location = new System.Drawing.Point(440, 58);
            this.numSoLuong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numSoLuong.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(150, 23);
            this.numSoLuong.TabIndex = 6;

            //
            // lblAnh
            //
            this.lblAnh.AutoSize = true;
            this.lblAnh.Location = new System.Drawing.Point(640, 28);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Size = new System.Drawing.Size(118, 15);
            this.lblAnh.Text = "Hình ảnh sản phẩm:";

            //
            // picAnh
            //
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.Location = new System.Drawing.Point(640, 50);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(110, 110);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabStop = false;

            //
            // btnChonAnh
            //
            this.btnChonAnh.Location = new System.Drawing.Point(640, 166);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(110, 27);
            this.btnChonAnh.TabIndex = 7;
            this.btnChonAnh.Text = "Chọn ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            //
            // lblTenFileAnh
            //
            this.lblTenFileAnh.AutoEllipsis = true;
            this.lblTenFileAnh.Location = new System.Drawing.Point(640, 196);
            this.lblTenFileAnh.Name = "lblTenFileAnh";
            this.lblTenFileAnh.Size = new System.Drawing.Size(110, 15);
            this.lblTenFileAnh.Text = "(Không có ảnh)";

            //
            // dgvProducts
            //
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.ContextMenuStrip = this.cmsGrid;
            this.dgvProducts.DataSource = this.bsProducts;
            this.dgvProducts.Location = new System.Drawing.Point(12, 296);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(946, 350);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            this.dgvProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProducts_KeyDown);

            //
            // cmsGrid
            //
            this.cmsGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.cmsSua, this.cmsXoa, this.cmsXemChiTiet});
            this.cmsGrid.Name = "cmsGrid";
            this.cmsGrid.Size = new System.Drawing.Size(160, 70);
            this.cmsGrid.Opening += new System.ComponentModel.CancelEventHandler(this.cmsGrid_Opening);

            //
            // cmsSua
            //
            this.cmsSua.Name = "cmsSua";
            this.cmsSua.Size = new System.Drawing.Size(159, 22);
            this.cmsSua.Text = "Sửa";
            this.cmsSua.Click += new System.EventHandler(this.cmsSua_Click);

            //
            // cmsXoa
            //
            this.cmsXoa.Name = "cmsXoa";
            this.cmsXoa.Size = new System.Drawing.Size(159, 22);
            this.cmsXoa.Text = "Xóa";
            this.cmsXoa.Click += new System.EventHandler(this.cmsXoa_Click);

            //
            // cmsXemChiTiet
            //
            this.cmsXemChiTiet.Name = "cmsXemChiTiet";
            this.cmsXemChiTiet.Size = new System.Drawing.Size(159, 22);
            this.cmsXemChiTiet.Text = "Xem chi tiết";
            this.cmsXemChiTiet.Click += new System.EventHandler(this.cmsXemChiTiet_Click);

            //
            // FrmProduct
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 700);
            this.Controls.Add(this.grpThongTinSanPham);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(820, 600);
            this.Name = "FrmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.FrmProduct_Load);

            ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducts)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.grpThongTinSanPham.ResumeLayout(false);
            this.grpThongTinSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.cmsGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errProvider;
        private System.Windows.Forms.BindingSource bsProducts;

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuThem;
        private System.Windows.Forms.ToolStripMenuItem mnuSua;
        private System.Windows.Forms.ToolStripMenuItem mnuXoa;
        private System.Windows.Forms.ToolStripSeparator mnuSepQuanLy1;
        private System.Windows.Forms.ToolStripMenuItem mnuTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuLamMoi;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tsbThem;
        private System.Windows.Forms.ToolStripButton tsbSua;
        private System.Windows.Forms.ToolStripButton tsbXoa;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripButton tsbLamMoi;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripLabel tslblTimKiem;
        private System.Windows.Forms.ToolStripTextBox tstxtTimKiem;
        private System.Windows.Forms.ToolStripButton tsbTimKiem;

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSoLuongSanPham;

        private System.Windows.Forms.GroupBox grpThongTinSanPham;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblTenFileAnh;

        private System.Windows.Forms.DataGridView dgvProducts;

        private System.Windows.Forms.ContextMenuStrip cmsGrid;
        private System.Windows.Forms.ToolStripMenuItem cmsSua;
        private System.Windows.Forms.ToolStripMenuItem cmsXoa;
        private System.Windows.Forms.ToolStripMenuItem cmsXemChiTiet;
    }
}

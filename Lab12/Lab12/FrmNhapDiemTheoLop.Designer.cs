namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
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
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.lblNguCanh = new System.Windows.Forms.Label();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuTatCa = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.bsLop = new System.Windows.Forms.BindingSource(this.components);
            this.bsMonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.bsKetQua = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKetQua)).BeginInit();
            this.SuspendLayout();
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(20, 22);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(28, 15);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(75, 19);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(210, 23);
            this.cboLop.TabIndex = 1;
            //
            // lblMonHoc
            //
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(305, 22);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(55, 15);
            this.lblMonHoc.TabIndex = 2;
            this.lblMonHoc.Text = "Môn học:";
            //
            // cboMonHoc
            //
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(370, 19);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(240, 23);
            this.cboMonHoc.TabIndex = 3;
            //
            // btnTaiDanhSach
            //
            this.btnTaiDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaiDanhSach.Location = new System.Drawing.Point(630, 15);
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Size = new System.Drawing.Size(150, 30);
            this.btnTaiDanhSach.TabIndex = 4;
            this.btnTaiDanhSach.Text = "Tải danh sách";
            this.btnTaiDanhSach.UseVisualStyleBackColor = true;
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);
            //
            // lblNguCanh
            //
            this.lblNguCanh.AutoSize = true;
            this.lblNguCanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNguCanh.Location = new System.Drawing.Point(20, 58);
            this.lblNguCanh.Name = "lblNguCanh";
            this.lblNguCanh.Size = new System.Drawing.Size(10, 15);
            this.lblNguCanh.TabIndex = 5;
            this.lblNguCanh.Text = " ";
            //
            // dgvKetQua
            //
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AllowUserToResizeRows = false;
            this.dgvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQua.AutoGenerateColumns = false;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSV,
            this.colHoTen,
            this.colDiem,
            this.colGhiChu});
            this.dgvKetQua.DataSource = this.bsKetQua;
            this.dgvKetQua.Location = new System.Drawing.Point(20, 82);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 24;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(760, 378);
            this.dgvKetQua.TabIndex = 6;
            this.dgvKetQua.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellEndEdit);
            this.dgvKetQua.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKetQua_CellValueChanged);
            this.dgvKetQua.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvKetQua_DataError);
            //
            // colMaSV
            //
            this.colMaSV.DataPropertyName = "MaSV";
            this.colMaSV.FillWeight = 20F;
            this.colMaSV.HeaderText = "Mã SV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.ReadOnly = true;
            this.colMaSV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaSV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            //
            // colHoTen
            //
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.FillWeight = 35F;
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            //
            // colDiem
            //
            this.colDiem.DataPropertyName = "Diem";
            this.colDiem.FillWeight = 12F;
            this.colDiem.HeaderText = "Điểm";
            this.colDiem.MaxInputLength = 5;
            this.colDiem.Name = "colDiem";
            this.colDiem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDiem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            //
            // colGhiChu
            //
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 33F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.MaxInputLength = 200;
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            //
            // btnLuuTatCa
            //
            this.btnLuuTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuTatCa.Location = new System.Drawing.Point(630, 470);
            this.btnLuuTatCa.Name = "btnLuuTatCa";
            this.btnLuuTatCa.Size = new System.Drawing.Size(150, 36);
            this.btnLuuTatCa.TabIndex = 7;
            this.btnLuuTatCa.Text = "Lưu tất cả";
            this.btnLuuTatCa.UseVisualStyleBackColor = true;
            this.btnLuuTatCa.Click += new System.EventHandler(this.btnLuuTatCa_Click);
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTrangThai});
            this.statusStrip1.Location = new System.Drawing.Point(0, 518);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 8;
            //
            // lblTrangThai
            //
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(39, 17);
            this.lblTrangThai.Text = "Sẵn sàng";
            //
            // FrmNhapDiemTheoLop
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLuuTatCa);
            this.Controls.Add(this.lblNguCanh);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "FrmNhapDiemTheoLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập điểm theo lớp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNhapDiemTheoLop_FormClosing);
            this.Load += new System.EventHandler(this.FrmNhapDiemTheoLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.Label lblNguCanh;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Button btnLuuTatCa;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.BindingSource bsLop;
        private System.Windows.Forms.BindingSource bsMonHoc;
        private System.Windows.Forms.BindingSource bsKetQua;
    }
}

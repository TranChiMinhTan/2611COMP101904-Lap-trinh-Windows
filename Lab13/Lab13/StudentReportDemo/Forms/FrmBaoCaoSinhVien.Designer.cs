namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
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
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.lblTieuDeBang = new System.Windows.Forms.Label();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblKhongDat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiemTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            //
            // grpBoLoc
            //
            this.grpBoLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoLoc.Controls.Add(this.lblLop);
            this.grpBoLoc.Controls.Add(this.cboLop);
            this.grpBoLoc.Controls.Add(this.lblKetQua);
            this.grpBoLoc.Controls.Add(this.cboKetQua);
            this.grpBoLoc.Controls.Add(this.lblTuKhoa);
            this.grpBoLoc.Controls.Add(this.txtTuKhoa);
            this.grpBoLoc.Controls.Add(this.btnXemBaoCao);
            this.grpBoLoc.Controls.Add(this.btnThongKe);
            this.grpBoLoc.Controls.Add(this.btnXuatFile);
            this.grpBoLoc.Location = new System.Drawing.Point(10, 8);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(880, 112);
            this.grpBoLoc.TabIndex = 0;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Điều kiện báo cáo";
            //
            // lblLop
            //
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(15, 31);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(28, 15);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(75, 28);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(250, 23);
            this.cboLop.TabIndex = 1;
            //
            // lblKetQua
            //
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(345, 31);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(47, 15);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "Kết quả:";
            //
            // cboKetQua
            //
            this.cboKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Location = new System.Drawing.Point(400, 28);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(130, 23);
            this.cboKetQua.TabIndex = 3;
            //
            // lblTuKhoa
            //
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(550, 31);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(54, 15);
            this.lblTuKhoa.TabIndex = 4;
            this.lblTuKhoa.Text = "Từ khóa:";
            //
            // txtTuKhoa
            //
            this.txtTuKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTuKhoa.Location = new System.Drawing.Point(610, 28);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.PlaceholderText = "Mã SV hoặc họ tên";
            this.txtTuKhoa.Size = new System.Drawing.Size(250, 23);
            this.txtTuKhoa.TabIndex = 5;
            //
            // btnXemBaoCao
            //
            this.btnXemBaoCao.Location = new System.Drawing.Point(15, 68);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(130, 32);
            this.btnXemBaoCao.TabIndex = 6;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            //
            // btnThongKe
            //
            this.btnThongKe.Location = new System.Drawing.Point(155, 68);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(130, 32);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            //
            // btnXuatFile
            //
            this.btnXuatFile.Location = new System.Drawing.Point(295, 68);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(130, 32);
            this.btnXuatFile.TabIndex = 8;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            //
            // lblTieuDeBang
            //
            this.lblTieuDeBang.AutoSize = true;
            this.lblTieuDeBang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeBang.Location = new System.Drawing.Point(12, 130);
            this.lblTieuDeBang.Name = "lblTieuDeBang";
            this.lblTieuDeBang.Size = new System.Drawing.Size(10, 15);
            this.lblTieuDeBang.TabIndex = 1;
            this.lblTieuDeBang.Text = " ";
            //
            // dgvBaoCao
            //
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.AllowUserToResizeRows = false;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(10, 152);
            this.dgvBaoCao.MultiSelect = false;
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(880, 372);
            this.dgvBaoCao.TabIndex = 2;
            this.dgvBaoCao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBaoCao_CellFormatting);
            //
            // statusStrip1
            //
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTong,
            this.lblDat,
            this.lblKhongDat,
            this.lblDiemTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 3;
            //
            // lblTong
            //
            this.lblTong.AutoSize = false;
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(170, 17);
            this.lblTong.Text = "Tổng số sinh viên: 0";
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblDat
            //
            this.lblDat.AutoSize = false;
            this.lblDat.Name = "lblDat";
            this.lblDat.Size = new System.Drawing.Size(100, 17);
            this.lblDat.Text = "Đạt: 0";
            this.lblDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblKhongDat
            //
            this.lblKhongDat.AutoSize = false;
            this.lblKhongDat.Name = "lblKhongDat";
            this.lblKhongDat.Size = new System.Drawing.Size(120, 17);
            this.lblKhongDat.Text = "Không đạt: 0";
            this.lblKhongDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblDiemTB
            //
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(120, 17);
            this.lblDiemTB.Text = "Điểm trung bình: 0";
            //
            // FrmBaoCaoSinhVien
            //
            this.AcceptButton = this.btnXemBaoCao;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.lblTieuDeBang);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpBoLoc);
            this.MinimumSize = new System.Drawing.Size(760, 420);
            this.Name = "FrmBaoCaoSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sinh viên (LINQ)";
            this.Load += new System.EventHandler(this.FrmBaoCaoSinhVien_Load);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Label lblTieuDeBang;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTong;
        private System.Windows.Forms.ToolStripStatusLabel lblDat;
        private System.Windows.Forms.ToolStripStatusLabel lblKhongDat;
        private System.Windows.Forms.ToolStripStatusLabel lblDiemTB;
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProductManager
{
    // Form chính: QUẢN LÝ SẢN PHẨM.
    // File này chỉ chứa LOGIC xử lý. Phần khai báo/bố trí control
    // nằm ở FrmProduct.Designer.cs.
    public partial class FrmProduct : Form
    {
        // Danh sách sản phẩm - dùng BindingList để DataGridView tự động
        // cập nhật khi Add/Remove (không cần gọi Refresh thủ công).
        private BindingList<Product> danhSachSanPham;

        // null  => đang ở chế độ "Thêm mới"
        // khác null => đang sửa sản phẩm có MaSP này (đã được nạp lên form)
        private string maSPDangSua;

        // Đường dẫn ảnh hiện đang hiển thị trên PictureBox (ảnh của sản phẩm
        // đang nhập/sửa), dùng khi lưu lại vào đối tượng Product.
        private string duongDanAnhDangChon;

        public FrmProduct()
        {
            InitializeComponent();
        }

        // ================= SỰ KIỆN LOAD CỦA FORM =================
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            KhoiTaoLoaiSanPham();
            CauHinhDataGridView();

            danhSachSanPham = new BindingList<Product>();
            TaoDuLieuMauBanDau();

            bsProducts.DataSource = danhSachSanPham;

            dtpNgayNhap.MaxDate = DateTime.Now;

            ClearInput();
            UpdateStatus("Sẵn sàng.");
        }

        // Nạp danh sách loại sản phẩm cố định vào ComboBox (yêu cầu 5.1)
        private void KhoiTaoLoaiSanPham()
        {
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.Add("Điện tử");
            cboLoaiSP.Items.Add("Văn phòng");
            cboLoaiSP.Items.Add("Gia dụng");
            cboLoaiSP.Items.Add("Thời trang");
        }

        // Khai báo cột cho DataGridView bằng code để kiểm soát tiêu đề,
        // định dạng hiển thị (ngày, tiền) rõ ràng hơn so với tự sinh cột.
        private void CauHinhDataGridView()
        {
            dgvProducts.Columns.Clear();

            DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn
            {
                Name = "colMaSP",
                DataPropertyName = "MaSP",
                HeaderText = "Mã SP",
                Width = 80
            };
            dgvProducts.Columns.Add(colMaSP);

            DataGridViewTextBoxColumn colTenSP = new DataGridViewTextBoxColumn
            {
                Name = "colTenSP",
                DataPropertyName = "TenSP",
                HeaderText = "Tên sản phẩm",
                MinimumWidth = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvProducts.Columns.Add(colTenSP);

            DataGridViewTextBoxColumn colLoaiSP = new DataGridViewTextBoxColumn
            {
                Name = "colLoaiSP",
                DataPropertyName = "LoaiSP",
                HeaderText = "Loại SP",
                Width = 110
            };
            dgvProducts.Columns.Add(colLoaiSP);

            DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá",
                Width = 110
            };
            colDonGia.DefaultCellStyle.Format = "N0";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colDonGia);

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "colSoLuong",
                DataPropertyName = "SoLuong",
                HeaderText = "Số lượng",
                Width = 80
            };
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colSoLuong);

            DataGridViewTextBoxColumn colNgayNhap = new DataGridViewTextBoxColumn
            {
                Name = "colNgayNhap",
                DataPropertyName = "NgayNhap",
                HeaderText = "Ngày nhập",
                Width = 100
            };
            colNgayNhap.DefaultCellStyle.Format = "dd/MM/yyyy";
            colNgayNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProducts.Columns.Add(colNgayNhap);

            DataGridViewCheckBoxColumn colConKinhDoanh = new DataGridViewCheckBoxColumn
            {
                Name = "colConKinhDoanh",
                DataPropertyName = "ConKinhDoanh",
                HeaderText = "Còn kinh doanh",
                Width = 100
            };
            dgvProducts.Columns.Add(colConKinhDoanh);
        }

        // Tạo tối thiểu 3 sản phẩm mẫu để có dữ liệu demo (yêu cầu 5.1)
        private void TaoDuLieuMauBanDau()
        {
            danhSachSanPham.Add(new Product("SP001", "Bàn phím cơ AKKO", "Điện tử",
                890000, 25, new DateTime(2026, 1, 15), true, null));
            danhSachSanPham.Add(new Product("SP002", "Ghế xoay văn phòng", "Văn phòng",
                1250000, 10, new DateTime(2026, 3, 2), true, null));
            danhSachSanPham.Add(new Product("SP003", "Nồi cơm điện 1.8L", "Gia dụng",
                650000, 18, new DateTime(2026, 5, 20), true, null));
            danhSachSanPham.Add(new Product("SP004", "Áo thun nam cổ tròn", "Thời trang",
                150000, 0, new DateTime(2025, 11, 10), false, null));
        }

        // ================= VALIDATE DỮ LIỆU NHẬP =================
        // maSPBoQuaKiemTraTrung: khi đang SỬA, truyền vào mã của chính sản
        // phẩm đang sửa để không báo "trùng mã" với chính nó.
        private bool ValidateInput(string maSPBoQuaKiemTraTrung = null)
        {
            bool hopLe = true;
            errProvider.Clear();

            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrEmpty(maSP))
            {
                errProvider.SetError(txtMaSP, "Mã sản phẩm không được để trống.");
                hopLe = false;
            }
            else
            {
                bool bTrungMa = danhSachSanPham.Any(sp =>
                    sp.MaSP.Equals(maSP, StringComparison.OrdinalIgnoreCase) &&
                    !sp.MaSP.Equals(maSPBoQuaKiemTraTrung ?? string.Empty, StringComparison.OrdinalIgnoreCase));

                if (bTrungMa)
                {
                    errProvider.SetError(txtMaSP, "Mã sản phẩm đã tồn tại.");
                    hopLe = false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                errProvider.SetError(txtTenSP, "Tên sản phẩm không được để trống.");
                hopLe = false;
            }

            if (cboLoaiSP.SelectedIndex == -1)
            {
                errProvider.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm.");
                hopLe = false;
            }

            if (numDonGia.Value <= 0)
            {
                errProvider.SetError(numDonGia, "Đơn giá phải lớn hơn 0.");
                hopLe = false;
            }

            if (numSoLuong.Value < 0)
            {
                errProvider.SetError(numSoLuong, "Số lượng không được âm.");
                hopLe = false;
            }

            if (dtpNgayNhap.Value.Date > DateTime.Now.Date)
            {
                errProvider.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại.");
                hopLe = false;
            }

            return hopLe;
        }

        // ================= CÁC HÀM DÙNG CHUNG =================

        // Xóa trắng form nhập liệu, bỏ lỗi ErrorProvider, thoát chế độ sửa.
        private void ClearInput()
        {
            txtMaSP.Clear();
            txtMaSP.ReadOnly = false;
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = cboLoaiSP.Items.Count > 0 ? 0 : -1;
            numDonGia.Value = numDonGia.Minimum;
            numSoLuong.Value = numSoLuong.Minimum;
            var now = DateTime.Now;
            dtpNgayNhap.MaxDate = now;
            dtpNgayNhap.Value = now;
            chkConKinhDoanh.Checked = false;

            duongDanAnhDangChon = null;            
            HienThiAnh(null);

            errProvider.Clear();

            maSPDangSua = null;
            dgvProducts.ClearSelection();

            txtMaSP.Focus();
        }

        // Đưa dữ liệu của 1 sản phẩm lên các control nhập liệu (yêu cầu 5.3)
        private void LoadProductToForm(Product sp)
        {
            if (sp == null)
            {
                return;
            }

            txtMaSP.Text = sp.MaSP;
            txtMaSP.ReadOnly = true; // không cho đổi Mã khi đang sửa (Mã là khóa)
            txtTenSP.Text = sp.TenSP;
            cboLoaiSP.SelectedItem = sp.LoaiSP;
            numDonGia.Value = sp.DonGia;
            numSoLuong.Value = sp.SoLuong;
            dtpNgayNhap.Value = sp.NgayNhap;
            chkConKinhDoanh.Checked = sp.ConKinhDoanh;

            duongDanAnhDangChon = sp.DuongDanAnh;
            HienThiAnh(sp.DuongDanAnh);

            errProvider.Clear();
            maSPDangSua = sp.MaSP;
        }

        // Cập nhật StatusStrip: thông báo thao tác + tổng số sản phẩm hiện có
        private void UpdateStatus(string thongBao)
        {
            lblStatus.Text = thongBao;
            lblSoLuongSanPham.Text = $"Tổng số sản phẩm: {danhSachSanPham.Count}";
        }

        // Lấy đối tượng Product tương ứng với dòng đang được chọn trên lưới
        private Product LaySanPhamDangChon()
        {
            if (dgvProducts.CurrentRow == null)
            {
                return null;
            }
            return dgvProducts.CurrentRow.DataBoundItem as Product;
        }

        // Hiển thị ảnh sản phẩm lên PictureBox; đọc qua MemoryStream để
        // tránh khóa (lock) file ảnh gốc trên đĩa.
        private void HienThiAnh(string duongDan)
        {
            if (picAnh.Image != null)
            {
                Image anhCu = picAnh.Image;
                picAnh.Image = null;
                anhCu.Dispose();
            }

            if (string.IsNullOrEmpty(duongDan) || !File.Exists(duongDan))
            {
                lblTenFileAnh.Text = "(Không có ảnh)";
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    picAnh.Image = Image.FromStream(ms);
                }
                lblTenFileAnh.Text = Path.GetFileName(duongDan);
            }
            catch
            {
                lblTenFileAnh.Text = "(Không đọc được ảnh)";
            }
        }

        // ================= CHỌN ẢNH (OpenFileDialog) =================
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Chọn ảnh sản phẩm";
                dlg.Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp (*.*)|*.*";

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    duongDanAnhDangChon = dlg.FileName;
                    HienThiAnh(duongDanAnhDangChon);
                }
            }
        }

        // ================= THÊM SẢN PHẨM =================
        private void ThemSanPham()
        {
            if (!ValidateInput())
            {
                UpdateStatus("Dữ liệu chưa hợp lệ. Vui lòng kiểm tra lại các ô báo lỗi.");
                return;
            }

            Product spMoi = new Product(
                txtMaSP.Text.Trim(),
                txtTenSP.Text.Trim(),
                cboLoaiSP.SelectedItem.ToString(),
                numDonGia.Value,
                (int)numSoLuong.Value,
                dtpNgayNhap.Value.Date,
                chkConKinhDoanh.Checked,
                duongDanAnhDangChon);

            danhSachSanPham.Add(spMoi);

            // Thêm xong luôn hiển thị lại toàn bộ danh sách (bỏ bộ lọc tìm kiếm nếu có)
            bsProducts.DataSource = danhSachSanPham;
            tstxtTimKiem.Text = string.Empty;

            string maVuaThem = spMoi.MaSP;
            ClearInput();
            UpdateStatus($"Đã thêm sản phẩm '{maVuaThem}' thành công.");
        }

        // ================= SỬA SẢN PHẨM =================
        private void SuaSanPham()
        {
            if (string.IsNullOrEmpty(maSPDangSua))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trong danh sách.", "Chưa chọn sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(maSPDangSua))
            {
                UpdateStatus("Dữ liệu chưa hợp lệ. Vui lòng kiểm tra lại các ô báo lỗi.");
                return;
            }

            Product spCanSua = danhSachSanPham.FirstOrDefault(
                sp => sp.MaSP.Equals(maSPDangSua, StringComparison.OrdinalIgnoreCase));

            if (spCanSua == null)
            {
                MessageBox.Show("Sản phẩm không còn tồn tại trong danh sách.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearInput();
                return;
            }

            spCanSua.TenSP = txtTenSP.Text.Trim();
            spCanSua.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            spCanSua.DonGia = numDonGia.Value;
            spCanSua.SoLuong = (int)numSoLuong.Value;
            spCanSua.NgayNhap = dtpNgayNhap.Value.Date;
            spCanSua.ConKinhDoanh = chkConKinhDoanh.Checked;
            spCanSua.DuongDanAnh = duongDanAnhDangChon;

            // Báo cho BindingList biết dòng này vừa thay đổi để DataGridView tự vẽ lại
            int viTri = danhSachSanPham.IndexOf(spCanSua);
            if (viTri >= 0)
            {
                danhSachSanPham.ResetItem(viTri);
            }

            string maVuaSua = spCanSua.MaSP;
            ClearInput();
            UpdateStatus($"Đã cập nhật sản phẩm '{maVuaSua}' thành công.");
        }

        // ================= XÓA SẢN PHẨM =================
        private void XoaSanPham()
        {
            Product spDangChon = LaySanPhamDangChon();
            if (spDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trong danh sách.", "Chưa chọn sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{spDangChon.MaSP} - {spDangChon.TenSP}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            danhSachSanPham.Remove(spDangChon);

            bsProducts.DataSource = danhSachSanPham;
            tstxtTimKiem.Text = string.Empty;

            string maVuaXoa = spDangChon.MaSP;
            ClearInput();
            UpdateStatus($"Đã xóa sản phẩm '{maVuaXoa}' thành công.");
        }

        // ================= TÌM KIẾM (theo mã hoặc tên) =================
        private void TimKiem()
        {
            string tuKhoa = tstxtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                bsProducts.DataSource = danhSachSanPham;
                UpdateStatus("Đã hiển thị toàn bộ danh sách sản phẩm.");
                return;
            }

            var ketQua = danhSachSanPham.Where(sp =>
                sp.MaSP.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                sp.TenSP.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            bsProducts.DataSource = ketQua;
            UpdateStatus($"Tìm thấy {ketQua.Count} sản phẩm khớp với từ khóa '{tuKhoa}'.");
        }

        // ================= XEM CHI TIẾT =================
        private void XemChiTietSanPham()
        {
            Product sp = LaySanPhamDangChon();
            if (sp == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xem.", "Chưa chọn sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string noiDung =
                "CHI TIẾT SẢN PHẨM" + Environment.NewLine +
                "-----------------------------------" + Environment.NewLine +
                "Mã sản phẩm: " + sp.MaSP + Environment.NewLine +
                "Tên sản phẩm: " + sp.TenSP + Environment.NewLine +
                "Loại sản phẩm: " + sp.LoaiSP + Environment.NewLine +
                "Đơn giá: " + sp.DonGia.ToString("N0") + " VNĐ" + Environment.NewLine +
                "Số lượng: " + sp.SoLuong + Environment.NewLine +
                "Ngày nhập: " + sp.NgayNhap.ToString("dd/MM/yyyy") + Environment.NewLine +
                "Tình trạng: " + (sp.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh") + Environment.NewLine +
                "Ảnh: " + (string.IsNullOrEmpty(sp.DuongDanAnh) ? "(Không có ảnh)" : sp.DuongDanAnh);

            MessageBox.Show(noiDung, "Xem chi tiết sản phẩm",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= SỰ KIỆN DATAGRIDVIEW =================

        // Chọn 1 dòng -> tự động đưa dữ liệu lên form để xem/sửa (yêu cầu 5.3)
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            Product spDangChon = LaySanPhamDangChon();
            if (spDangChon != null)
            {
                LoadProductToForm(spDangChon);
            }
        }

        // Double-click 1 dòng -> xem nhanh chi tiết (sự kiện chuột)
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // double-click vào phần header, bỏ qua
            }
            XemChiTietSanPham();
        }

        // Nhấn phím Delete khi đang chọn dòng trên lưới -> xóa (sự kiện bàn phím)
        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaSanPham();
            }
        }

        // Trước khi hiện ContextMenuStrip, chọn đúng dòng nằm dưới con trỏ chuột
        private void cmsGrid_Opening(object sender, CancelEventArgs e)
        {
            Point viTriChuot = dgvProducts.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hit = dgvProducts.HitTest(viTriChuot.X, viTriChuot.Y);

            if (hit.RowIndex >= 0)
            {
                dgvProducts.ClearSelection();
                dgvProducts.Rows[hit.RowIndex].Selected = true;
                dgvProducts.CurrentCell = dgvProducts.Rows[hit.RowIndex].Cells[0];
            }
            else
            {
                e.Cancel = true; // right-click ra ngoài vùng có dữ liệu -> không hiện menu
            }
        }

        // ================= Ô TÌM KIẾM TRÊN TOOLSTRIP =================
        private void tstxtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiem();
                e.SuppressKeyPress = true; // tránh tiếng "beep" khi nhấn Enter trong TextBox
            }
        }

        // ================= TOOLSTRIP =================
        private void tsbThem_Click(object sender, EventArgs e)
        {
            ThemSanPham();
        }

        private void tsbSua_Click(object sender, EventArgs e)
        {
            SuaSanPham();
        }

        private void tsbXoa_Click(object sender, EventArgs e)
        {
            XoaSanPham();
        }

        private void tsbLamMoi_Click(object sender, EventArgs e)
        {
            bsProducts.DataSource = danhSachSanPham;
            tstxtTimKiem.Text = string.Empty;
            ClearInput();
            UpdateStatus("Đã làm mới dữ liệu.");
        }

        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        // ================= MENUSTRIP =================
        private void mnuThem_Click(object sender, EventArgs e)
        {
            ThemSanPham();
        }

        private void mnuSua_Click(object sender, EventArgs e)
        {
            SuaSanPham();
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            XoaSanPham();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            tstxtTimKiem.Focus();
        }

        private void mnuLamMoi_Click(object sender, EventArgs e)
        {
            bsProducts.DataSource = danhSachSanPham;
            tstxtTimKiem.Text = string.Empty;
            ClearInput();
            UpdateStatus("Đã làm mới dữ liệu.");
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ỨNG DỤNG QUẢN LÝ SẢN PHẨM" + Environment.NewLine +
                "Môn học: COMP1019 - Lập trình trên Windows" + Environment.NewLine +
                "Chức năng: Thêm, sửa, xóa, tìm kiếm sản phẩm (dữ liệu lưu trong bộ nhớ).",
                "Giới thiệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ================= CONTEXTMENUSTRIP TRÊN LƯỚI =================
        private void cmsSua_Click(object sender, EventArgs e)
        {
            SuaSanPham();
        }

        private void cmsXoa_Click(object sender, EventArgs e)
        {
            XoaSanPham();
        }

        private void cmsXemChiTiet_Click(object sender, EventArgs e)
        {
            XemChiTietSanPham();
        }
    }
}

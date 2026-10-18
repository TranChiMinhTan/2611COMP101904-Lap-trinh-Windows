using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    // Form con MDI: Quản lý sản phẩm. Dữ liệu chỉ lưu tạm trong bộ nhớ
    // bằng BindingList<Product> (chưa kết nối SQL Server - đúng yêu cầu
    // của bài lab này).
    public partial class FrmProduct : Form
    {
        private BindingList<Product> danhSachSanPham;

        // null => đang ở chế độ Thêm mới; khác null => đang sửa sản phẩm có mã này
        private string maSPDangSua;

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            KhoiTaoLoaiSanPham();
            CauHinhDataGridView();

            danhSachSanPham = new BindingList<Product>();
            TaoDuLieuMauBanDau();

            dgvProducts.DataSource = danhSachSanPham;

            LamMoi();
        }

        private void KhoiTaoLoaiSanPham()
        {
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.Add("Điện tử");
            cboLoaiSP.Items.Add("Văn phòng");
            cboLoaiSP.Items.Add("Gia dụng");
            cboLoaiSP.Items.Add("Thời trang");
        }

        private void CauHinhDataGridView()
        {
            dgvProducts.Columns.Clear();

            DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn
            {
                Name = "colMaSP",
                DataPropertyName = "MaSP",
                HeaderText = "Mã SP",
                Width = 90
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
                Width = 120
            };
            dgvProducts.Columns.Add(colLoaiSP);

            DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá",
                Width = 120
            };
            colDonGia.DefaultCellStyle.Format = "N0";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colDonGia);

            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn
            {
                Name = "colSoLuong",
                DataPropertyName = "SoLuong",
                HeaderText = "Số lượng",
                Width = 90
            };
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns.Add(colSoLuong);
        }

        private void TaoDuLieuMauBanDau()
        {
            danhSachSanPham.Add(new Product("SP001", "Bàn phím cơ AKKO", "Điện tử", 890000, 25));
            danhSachSanPham.Add(new Product("SP002", "Ghế xoay văn phòng", "Văn phòng", 1250000, 10));
            danhSachSanPham.Add(new Product("SP003", "Nồi cơm điện 1.8L", "Gia dụng", 650000, 18));
        }

        // ================= VALIDATE =================
        // maSPBoQuaKiemTraTrung: khi SỬA, truyền mã của chính sản phẩm đang
        // sửa vào để không báo "trùng mã" với chính nó.
        private bool KiemTraHopLe(string maSPBoQuaKiemTraTrung = null)
        {
            string maSP = txtMaSP.Text.Trim();

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return false;
            }

            bool bTrungMa = danhSachSanPham.Any(sp =>
                sp.MaSP.Equals(maSP, StringComparison.OrdinalIgnoreCase) &&
                !sp.MaSP.Equals(maSPBoQuaKiemTraTrung ?? string.Empty, StringComparison.OrdinalIgnoreCase));

            if (bTrungMa)
            {
                MessageBox.Show($"Mã sản phẩm '{maSP}' đã tồn tại.", "Trùng mã sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return false;
            }

            if (cboLoaiSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiSP.Focus();
                return false;
            }

            if (numDonGia.Value <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDonGia.Focus();
                return false;
            }

            if (numSoLuong.Value < 0)
            {
                MessageBox.Show("Số lượng không được âm.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoLuong.Focus();
                return false;
            }

            return true;
        }

        // ================= CÁC HÀM DÙNG CHUNG =================
        private void XoaTrangForm()
        {
            txtMaSP.Clear();
            txtMaSP.ReadOnly = false;
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = cboLoaiSP.Items.Count > 0 ? 0 : -1;
            numDonGia.Value = numDonGia.Minimum;
            numSoLuong.Value = numSoLuong.Minimum;

            maSPDangSua = null;
            dgvProducts.ClearSelection();
            txtMaSP.Focus();
        }

        private void DuaDuLieuLenForm(Product sp)
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

            maSPDangSua = sp.MaSP;
        }

        private Product LaySanPhamDangChon()
        {
            // Dùng SelectedRows (dòng đang được tô sáng) chứ không dùng CurrentRow,
            // vì sau ClearSelection() CurrentRow vẫn còn trỏ vào 1 dòng cũ.
            if (dgvProducts.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvProducts.SelectedRows[0].DataBoundItem as Product;
        }

        // ================= THÊM / SỬA / XÓA / TÌM KIẾM / LÀM MỚI =================
        private void ThemSanPham()
        {
            if (!KiemTraHopLe())
            {
                return;
            }

            Product spMoi = new Product(
                txtMaSP.Text.Trim(),
                txtTenSP.Text.Trim(),
                cboLoaiSP.SelectedItem.ToString(),
                numDonGia.Value,
                (int)numSoLuong.Value);

            danhSachSanPham.Add(spMoi);

            MessageBox.Show($"Đã thêm sản phẩm '{spMoi.MaSP}' thành công.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoi();
        }

        private void SuaSanPham()
        {
            if (string.IsNullOrEmpty(maSPDangSua))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trong danh sách.", "Chưa chọn sản phẩm",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraHopLe(maSPDangSua))
            {
                return;
            }

            Product spCanSua = danhSachSanPham.FirstOrDefault(
                sp => sp.MaSP.Equals(maSPDangSua, StringComparison.OrdinalIgnoreCase));

            if (spCanSua == null)
            {
                MessageBox.Show("Sản phẩm không còn tồn tại trong danh sách.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                return;
            }

            spCanSua.TenSP = txtTenSP.Text.Trim();
            spCanSua.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            spCanSua.DonGia = numDonGia.Value;
            spCanSua.SoLuong = (int)numSoLuong.Value;

            int viTri = danhSachSanPham.IndexOf(spCanSua);
            if (viTri >= 0)
            {
                danhSachSanPham.ResetItem(viTri); // báo DataGridView tự vẽ lại dòng này
            }

            MessageBox.Show("Đã cập nhật sản phẩm thành công.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoi();
        }

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
            LamMoi();
        }

        private void TimKiem()
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                dgvProducts.DataSource = danhSachSanPham;
                return;
            }

            var ketQua = danhSachSanPham.Where(sp =>
                sp.MaSP.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                sp.TenSP.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            dgvProducts.DataSource = ketQua;

            if (ketQua.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy sản phẩm nào khớp với từ khóa '{tuKhoa}'.",
                    "Không có kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Làm mới: xóa nội dung nhập, hiển thị lại toàn bộ danh sách (yêu cầu 7.3)
        private void LamMoi()
        {
            txtTimKiem.Clear();
            dgvProducts.DataSource = danhSachSanPham;
            XoaTrangForm();
        }

        // ================= SỰ KIỆN =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSanPham();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaSanPham();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiem();
                e.SuppressKeyPress = true;
            }
        }

        // Chọn 1 dòng trên lưới -> tự động đưa dữ liệu lên form để sửa
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            Product spDangChon = LaySanPhamDangChon();
            if (spDangChon != null)
            {
                DuaDuLieuLenForm(spDangChon);
            }
        }
    }
}

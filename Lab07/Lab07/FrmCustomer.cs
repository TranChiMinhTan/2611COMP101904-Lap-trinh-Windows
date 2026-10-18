using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    // Form con MDI: Quản lý khách hàng. Đề bài chỉ bắt buộc chức năng
    // Thêm + hiển thị danh sách, nhưng để nhất quán với FrmProduct và
    // theo gợi ý "khuyến khích bổ sung" của đề bài, Form này cũng có đủ
    // Sửa/Xóa/Tìm kiếm/Làm mới.
    public partial class FrmCustomer : Form
    {
        private BindingList<Customer> danhSachKhachHang;

        // null => đang ở chế độ Thêm mới; khác null => đang sửa khách hàng có mã này
        private string maKHDangSua;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            KhoiTaoLoaiKhachHang();
            CauHinhDataGridView();

            danhSachKhachHang = new BindingList<Customer>();
            TaoDuLieuMauBanDau();

            dgvCustomers.DataSource = danhSachKhachHang;

            LamMoi();
        }

        private void KhoiTaoLoaiKhachHang()
        {
            cboLoaiKhachHang.Items.Clear();
            cboLoaiKhachHang.Items.Add("Khách lẻ");
            cboLoaiKhachHang.Items.Add("Khách sỉ");
            cboLoaiKhachHang.Items.Add("VIP");
        }

        private void CauHinhDataGridView()
        {
            dgvCustomers.Columns.Clear();

            DataGridViewTextBoxColumn colMaKH = new DataGridViewTextBoxColumn
            {
                Name = "colMaKH",
                DataPropertyName = "MaKH",
                HeaderText = "Mã KH",
                Width = 90
            };
            dgvCustomers.Columns.Add(colMaKH);

            DataGridViewTextBoxColumn colHoTen = new DataGridViewTextBoxColumn
            {
                Name = "colHoTen",
                DataPropertyName = "HoTen",
                HeaderText = "Họ tên",
                MinimumWidth = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvCustomers.Columns.Add(colHoTen);

            DataGridViewTextBoxColumn colSoDienThoai = new DataGridViewTextBoxColumn
            {
                Name = "colSoDienThoai",
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số điện thoại",
                Width = 130
            };
            dgvCustomers.Columns.Add(colSoDienThoai);

            DataGridViewTextBoxColumn colLoaiKhachHang = new DataGridViewTextBoxColumn
            {
                Name = "colLoaiKhachHang",
                DataPropertyName = "LoaiKhachHang",
                HeaderText = "Loại khách hàng",
                Width = 130
            };
            dgvCustomers.Columns.Add(colLoaiKhachHang);
        }

        private void TaoDuLieuMauBanDau()
        {
            danhSachKhachHang.Add(new Customer("KH001", "Nguyễn Văn A", "0901234567", "Khách lẻ"));
            danhSachKhachHang.Add(new Customer("KH002", "Trần Thị B", "0912345678", "VIP"));
        }

        // ================= VALIDATE =================
        private bool KiemTraHopLe(string maKHBoQuaKiemTraTrung = null)
        {
            string maKH = txtMaKH.Text.Trim();

            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return false;
            }

            bool bTrungMa = danhSachKhachHang.Any(kh =>
                kh.MaKH.Equals(maKH, StringComparison.OrdinalIgnoreCase) &&
                !kh.MaKH.Equals(maKHBoQuaKiemTraTrung ?? string.Empty, StringComparison.OrdinalIgnoreCase));

            if (bTrungMa)
            {
                MessageBox.Show($"Mã khách hàng '{maKH}' đã tồn tại.", "Trùng mã khách hàng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }

            if (cboLoaiKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiKhachHang.Focus();
                return false;
            }

            return true;
        }

        // ================= CÁC HÀM DÙNG CHUNG =================
        private void XoaTrangForm()
        {
            txtMaKH.Clear();
            txtMaKH.ReadOnly = false;
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            cboLoaiKhachHang.SelectedIndex = cboLoaiKhachHang.Items.Count > 0 ? 0 : -1;

            maKHDangSua = null;
            dgvCustomers.ClearSelection();
            txtMaKH.Focus();
        }

        private void DuaDuLieuLenForm(Customer kh)
        {
            if (kh == null)
            {
                return;
            }

            txtMaKH.Text = kh.MaKH;
            txtMaKH.ReadOnly = true; // không cho đổi Mã khi đang sửa (Mã là khóa)
            txtHoTen.Text = kh.HoTen;
            txtSoDienThoai.Text = kh.SoDienThoai;
            cboLoaiKhachHang.SelectedItem = kh.LoaiKhachHang;

            maKHDangSua = kh.MaKH;
        }

        private Customer LayKhachHangDangChon()
        {
            // Dùng SelectedRows (dòng đang được tô sáng) chứ không dùng CurrentRow,
            // vì sau ClearSelection() CurrentRow vẫn còn trỏ vào 1 dòng cũ.
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                return null;
            }
            return dgvCustomers.SelectedRows[0].DataBoundItem as Customer;
        }

        // ================= THÊM / SỬA / XÓA / TÌM KIẾM / LÀM MỚI =================
        private void ThemKhachHang()
        {
            if (!KiemTraHopLe())
            {
                return;
            }

            Customer khMoi = new Customer(
                txtMaKH.Text.Trim(),
                txtHoTen.Text.Trim(),
                txtSoDienThoai.Text.Trim(),
                cboLoaiKhachHang.SelectedItem.ToString());

            danhSachKhachHang.Add(khMoi);

            MessageBox.Show($"Đã thêm khách hàng '{khMoi.MaKH}' thành công.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoi();
        }

        private void SuaKhachHang()
        {
            if (string.IsNullOrEmpty(maKHDangSua))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa trong danh sách.", "Chưa chọn khách hàng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraHopLe(maKHDangSua))
            {
                return;
            }

            Customer khCanSua = danhSachKhachHang.FirstOrDefault(
                kh => kh.MaKH.Equals(maKHDangSua, StringComparison.OrdinalIgnoreCase));

            if (khCanSua == null)
            {
                MessageBox.Show("Khách hàng không còn tồn tại trong danh sách.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoi();
                return;
            }

            khCanSua.HoTen = txtHoTen.Text.Trim();
            khCanSua.SoDienThoai = txtSoDienThoai.Text.Trim();
            khCanSua.LoaiKhachHang = cboLoaiKhachHang.SelectedItem.ToString();

            int viTri = danhSachKhachHang.IndexOf(khCanSua);
            if (viTri >= 0)
            {
                danhSachKhachHang.ResetItem(viTri);
            }

            MessageBox.Show("Đã cập nhật khách hàng thành công.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoi();
        }

        private void XoaKhachHang()
        {
            Customer khDangChon = LayKhachHangDangChon();
            if (khDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trong danh sách.", "Chưa chọn khách hàng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng '{khDangChon.MaKH} - {khDangChon.HoTen}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua != DialogResult.Yes)
            {
                return;
            }

            danhSachKhachHang.Remove(khDangChon);
            LamMoi();
        }

        private void TimKiem()
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                dgvCustomers.DataSource = danhSachKhachHang;
                return;
            }

            var ketQua = danhSachKhachHang.Where(kh =>
                kh.MaKH.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                kh.HoTen.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            dgvCustomers.DataSource = ketQua;

            if (ketQua.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy khách hàng nào khớp với từ khóa '{tuKhoa}'.",
                    "Không có kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LamMoi()
        {
            txtTimKiem.Clear();
            dgvCustomers.DataSource = danhSachKhachHang;
            XoaTrangForm();
        }

        // ================= SỰ KIỆN =================
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemKhachHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaKhachHang();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaKhachHang();
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

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            Customer khDangChon = LayKhachHangDangChon();
            if (khDangChon != null)
            {
                DuaDuLieuLenForm(khDangChon);
            }
        }
    }
}
